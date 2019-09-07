using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*TODO
 * Being able to start simulation
 * COMMENTS!!!
*/

namespace BrABENECi
{
    class Logic
    {
        static System.Windows.Forms.Timer timer;
        static System.Windows.Forms.Form sim_form;
        static Menu_form menu_form;

        public static int PARTY_SIZE = 15; //Party je velikost členů jedné rasy, než se zaplní prostor ve formu
        public static int parties_num; //Kolikátá party se testuje/simuluje
        public static int current_party;

        public static int DMG_PTS_MULTIPLIER = 1;
        public static int KILL_PTS = 100;
        public static int MISS_PENALTY = 5;

        public static int generation = 0;
        public static int elapsed_ticks;
        public static int match_ticks = 400;

        public static bool Collisions = true;
        public static int agents_in_race;
        public static int num_of_agents;
        public static Agent[] Reds;
        public static Agent[] Greens;
        public static Agent[] Blues;
        public static Agent[] All_agents;
        public static Agent[] Current_agents;//V současné simulaci
        public static bool[,] battled_flag;
        public static bool sim_in_progress = false;
        public static bool fast_forward = false;
        public static bool automatic = false;
        public static int best_fitness;
        public static int mean_fitness;
        public static int median_fitness;
        public static int[,] all_stats;


        public static Random rand = new Random();

        static void Race_init(ref Agent[] race, ref Agent[] all_agents, int first_id, int color)
        {
            race = new Agent[agents_in_race];
            for (int i = 0; i < agents_in_race; i++)
            {
                race[i] = new Agent(i + first_id, color);
                all_agents[i + first_id] = race[i];
            }
        }

        public static void Evolution_init(System.Windows.Forms.Timer timer_form, System.Windows.Forms.Form ex_form,
            Menu_form me_form)
        {
            timer = timer_form;
            sim_form = ex_form;
            menu_form = me_form;
            all_stats = new int[3, 3];
            All_agents = new Agent[agents_in_race * 3];
            Race_init(ref Reds, ref All_agents, 0, 0);
            Race_init(ref Greens, ref All_agents, agents_in_race, 1);
            Race_init(ref Blues, ref All_agents, agents_in_race * 2, 2);
            generation = 0;
            Generation_init();

        }

        public static void Position_init(Agent[] agents, int agents_num)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < agents_num; i++)
            {
                bool collision_detected = true;
                while (collision_detected)
                {
                    x = rand.Next(20, 830);
                    y = rand.Next(20, 830);
                    collision_detected = false;
                    for (int j = 0; j < i; j++)
                    {
                        if ((Math.Abs(x - agents[j].pos_X) < 40)
                            && (Math.Abs(y - agents[j].pos_Y) < 40))
                        {
                            collision_detected = true;
                            break;
                        }
                    }
                }
                agents[i].pos_X = x;
                agents[i].pos_Y = y;
            }
        }

        static int Get_dist(Agent first, Agent second)
        {
            return (int)Math.Sqrt(Math.Pow(first.pos_X - second.pos_X, 2) + Math.Pow(first.pos_Y - second.pos_Y, 2));
        }

        static double Get_angle(Agent first, Agent second) //Returns global angle
        {
            int x1 = first.pos_X;
            int x2 = second.pos_X;
            int y1 = first.pos_Y;
            int y2 = second.pos_Y;
            double angle = Math.Atan2(y2 - y1, x2 - x1);
            Normalize_angle(ref angle);
            return angle;
        }

        static bool Is_in_sight(Agent first, Agent second, out double[] vis_input)//Input se vytváří
        {
            int dist = Get_dist(first, second);
            vis_input = new double[Agent.EYES_NUM];
            bool output = false;

            if (dist > Agent.SIGHT_LENGTH)
                return false;
            else
            {
                double angle = Get_angle(first, second);
                double tolerance = Math.Atan((double)Visual_bridge.Health_to_size(second.max_health) / (double)dist);
                for (int i = 0; i < Agent.EYES_NUM; i++)
                {
                    vis_input[i] = 0.0;
                    double eye_angle = first.orient + first.eyes[i];
                    Normalize_angle(ref eye_angle);
                    if (Math.Abs(angle - eye_angle) < tolerance)
                    {
                        vis_input[i] = (double)(Agent.SIGHT_LENGTH - dist) / (double)Agent.SIGHT_LENGTH;
                        if (first.color == second.color)
                            vis_input[i] *= -1;
                        output = true;
                    }
                }
                return output;
            }
        }

        public static void Normalize_angle(ref double angle)
        {
            while (angle < 0)
                angle += Math.PI * 2;
            angle = angle % (Math.PI * 2);
        }

        public static void Excite_agents()
        {
            double[] sensory_input;
            double[] local_sens_input;
            for (int first_num = 0; first_num < PARTY_SIZE * 3; first_num++)
            {
                Agent agent = Current_agents[first_num];
                if (agent.alive == true)
                {
                    if (Visual_bridge.SHOW_ID)
                        Visual_bridge.Write_text(Convert.ToString(agent.id), agent.pos_X, agent.pos_Y, Visual_bridge.black_pen);

                    sensory_input = new double[Agent.SENSOR_NUM];
                    for (int sec_num = 0; sec_num < PARTY_SIZE * 3; sec_num++)
                    {
                        Agent sec_agent = Current_agents[sec_num];
                        if ((first_num != sec_num) && (Is_in_sight(agent, sec_agent, out local_sens_input)))
                        {
                            for (int i = 0; i < Agent.EYES_NUM; i++)
                            {
                                if (Math.Abs(local_sens_input[i]) > Math.Abs(sensory_input[i]))
                                    sensory_input[i] = local_sens_input[i];
                            }        
                        }
                    }
                    sensory_input[8] = 1 - agent.time_to_fire / agent.reload_time;

                    agent.input = sensory_input;
                    agent.Make_decision();
                    agent.Commit_move();

                    if (Collisions)
                    {
                        for (int i = 0; i < Current_agents.Length; i++)
                        {
                            Agent sec_agent = Current_agents[i];
                            if ((!agent.Equals(sec_agent)) && (sec_agent.alive == true) &&
                                (Get_dist(agent, sec_agent) < Visual_bridge.Health_to_size(agent.max_health) + Visual_bridge.Health_to_size(sec_agent.max_health)))
                            {
                                double angle = Get_angle(agent, sec_agent);
                                angle = angle - Math.PI;
                                Normalize_angle(ref angle);
                                int old_x = agent.pos_X;
                                int old_y = agent.pos_Y;
                                agent.pos_X = agent.pos_X + (int)(Math.Cos(angle) * (Visual_bridge.Health_to_size(agent.max_health) + Visual_bridge.Health_to_size(sec_agent.max_health) - Get_dist(agent, sec_agent)));
                                agent.pos_Y = agent.pos_Y + (int)(Math.Sin(angle) * (Visual_bridge.Health_to_size(agent.max_health) + Visual_bridge.Health_to_size(sec_agent.max_health) - Get_dist(agent, sec_agent)));
                                Visual_bridge.Move_agent(old_x, old_y, agent.pos_X, agent.pos_Y, agent.max_health, agent.color_string, agent.orient);
                            }
                        }
                    }

                    if (agent.attacking == true)
                        Fire(agent);
                    agent.attacking = false;
                    if (agent.time_to_fire > 0)
                        agent.time_to_fire--;
                    if (Visual_bridge.SHOW_ID)
                        Visual_bridge.Write_text(Convert.ToString(agent.id), agent.pos_X, agent.pos_Y, Visual_bridge.white_pen);
                }
                else
                    if (!fast_forward)
                        Visual_bridge.Kill_agent(agent.pos_X, agent.pos_Y, agent.max_health);
            }
        }

        public static void Fire(Agent agent)
        {
            agent.time_to_fire = agent.reload_time;
            int x2 = agent.pos_X + (int)(Math.Cos(agent.orient) * Agent.FIRING_RANGE * 0.7);
            int y2 = agent.pos_Y + (int)(Math.Sin(agent.orient) * Agent.FIRING_RANGE * 0.7);
            Visual_bridge.Draw_bullet(agent.pos_X, agent.pos_Y, x2, y2, Visual_bridge.white_pen);

            int friendly_fire; //Multiplier for either adding or substracting score

            bool wasted_shot = true;
            for (int i = 0; i < PARTY_SIZE * 3; i++)
            {
                Agent second_agent = Current_agents[i];
                if ((second_agent.alive == true) &&
                    !second_agent.Equals(agent) && (Get_dist(agent, second_agent) < Agent.FIRING_RANGE))
                {
                    if ((agent.orient < Math.Abs(Get_angle(agent, second_agent)) + Math.PI / 6) &&
                        (agent.orient > Math.Abs(Get_angle(agent, second_agent)) - Math.PI / 6))
                    {
                        wasted_shot = false;
                        second_agent.health -= agent.damage;
                        friendly_fire = 1;
                        if (agent.color == second_agent.color)
                        {
                            wasted_shot = true;
                            friendly_fire = -1;
                        }

                        agent.fitness += DMG_PTS_MULTIPLIER * agent.damage * friendly_fire; ;
                        if (second_agent.health <= 0)
                        {
                            second_agent.alive = false;
                            Visual_bridge.Kill_agent(second_agent.pos_X, second_agent.pos_Y, second_agent.max_health);
                            Visual_bridge.Draw_dead_bullet(second_agent.pos_X, second_agent.pos_Y, second_agent.orient);
                            agent.fitness += KILL_PTS * friendly_fire * agent.enemies_killed;
                            if (friendly_fire == 1)
                            {
                                agent.enemies_killed++;
                                agent.health += (agent.max_health / 3) % agent.max_health; //Nechat nebo nenechat?
                            }

                        }
                    }
                }
            }
            if (wasted_shot)
                agent.health -= MISS_PENALTY;
            if (agent.health < 0)
            {
                agent.alive = false;
                Visual_bridge.Kill_agent(agent.pos_X, agent.pos_Y, agent.max_health);
                Visual_bridge.Draw_dead_bullet(agent.pos_X, agent.pos_Y, agent.orient);
            }
        }

        public static void Do_sim_tick()
        {
            elapsed_ticks++;
            Excite_agents();

            menu_form.ticks_label.Text = Convert.ToString(100 * (elapsed_ticks + match_ticks * (current_party)) / (match_ticks * parties_num)) + "%";

            if (elapsed_ticks >= match_ticks)//Konec matche
            {
                timer.Enabled = false;
                current_party++;
                Simulate_battle();
            }
        }

        public static void Generation_init()
        {
            menu_form.generation_label.Text = Convert.ToString(generation);
            menu_form.Next_gen_button.Enabled = false;
            current_party = 0;
            battled_flag = new bool[3,agents_in_race];
            menu_form.Update_text();

            for (int i = 0; i < num_of_agents; i++)
            {
                All_agents[i].health = All_agents[i].max_health;
                All_agents[i].attacking = false;
                All_agents[i].alive = true;
                All_agents[i].fitness = 0;
                All_agents[i].enemies_killed = 0;
            }
        }

        public static void Simulate_battle()
        {
            timer.Enabled = false;
            if(current_party >= parties_num) //Keeps control over which battle goes on
            {
                Finish_simulation();
                
            }
            else
            {
                menu_form.progress_label.Text = "Simulating...";
                Divide_agents();
                Visual_bridge.Reset();
                Position_init(Current_agents, PARTY_SIZE * 3);
                sim_in_progress = true;
                elapsed_ticks = 0;

                timer.Enabled = true;
            }
        }

        public static void Finish_simulation()
        {
            current_party = 0;
            battled_flag = new bool[3, agents_in_race];
            Get_stats(All_agents, out best_fitness, out mean_fitness, out median_fitness);
            Get_stats(Reds, out all_stats[0, 0], out all_stats[0, 1], out all_stats[0, 2]);
            Get_stats(Greens, out all_stats[1, 0], out all_stats[1, 1], out all_stats[1, 2]);
            Get_stats(Blues, out all_stats[2, 0], out all_stats[2, 1], out all_stats[2, 2]);
            if (automatic)
            {
                menu_form.Set_stats();
                current_party = 0;
                Evolve_population();
                Generation_init();
                Simulate_battle();
            }
            else
            {
                menu_form.Simulation_done();
                timer.Enabled = false;
                sim_in_progress = false;
                sim_form.Hide();
            }
        }

        public static void Divide_agents()
        {
            Current_agents = new Agent[PARTY_SIZE * 3];
            int rand_num;
            int j = 0;
            for (int i = 0; i < PARTY_SIZE; i++)
            {
                rand_num = Find_unoccupied(0);
                battled_flag[0,rand_num] = true;
                Current_agents[j] = Reds[rand_num];
                j++;
                rand_num = Find_unoccupied(1);
                battled_flag[1, rand_num] = true;
                Current_agents[j] = Greens[rand_num];
                j++;
                rand_num = Find_unoccupied(2);
                battled_flag[2, rand_num] = true;
                Current_agents[j] = Blues[rand_num];
                j++;
            }
        }

        static int Find_unoccupied(int race)
        {
            int rand_num = rand.Next(0, agents_in_race);
            while (battled_flag[race, rand_num] == true)
            {
                rand_num++;
                if (rand_num == agents_in_race)
                    rand_num = 0;
            }
            return rand_num;
        }

        public static void Cancel_battle()
        {
            timer.Enabled = false;
            sim_in_progress = false;
            Visual_bridge.Reset();
            Generation_init();
        }

        public static void Get_stats(Agent[] agents, out int best_fitness, out int mean_fitness, out int median_fitness)
        {
            int best = 0;
            int sum = 0;
            int median = 0;
            foreach (Agent agent in agents)
            {
                if (agent.fitness > best)
                    best = agent.fitness;
                sum += agent.fitness;
            }
            best_fitness = best;
            mean_fitness = sum / agents.Length;
            median_fitness = 0;
        }

        public static void Evolve_population()
        {
            Genetic_algorithm.last_id = 0;
            Reds = Genetic_algorithm.Evolve(Reds, Convert.ToInt32(menu_form.Mutation_txtbox.Text));
            Greens = Genetic_algorithm.Evolve(Greens, Convert.ToInt32(menu_form.Mutation_txtbox.Text));
            Blues = Genetic_algorithm.Evolve(Blues, Convert.ToInt32(menu_form.Mutation_txtbox.Text));

            for (int j = 0; j < agents_in_race; j++)
                All_agents[j] = Reds[j];
            for (int j = 0; j < agents_in_race; j++)
                All_agents[j + agents_in_race] = Greens[j];
            for (int j = 0; j < agents_in_race; j++)
                All_agents[j + agents_in_race*2] = Blues[j];

            generation++;
            Generation_init();
        }


    }
}
