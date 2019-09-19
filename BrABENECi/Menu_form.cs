using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace BrABENECi
{
    public partial class Menu_form : Form
    {
        //Důležité proměnné a objekty
        Sim_form sim_form;

        public Menu_form()
        {
            InitializeComponent();
        }

        private void Menu_form_Load(object sender, EventArgs e)
        {
            sim_form = new Sim_form();
            Visual_bridge.Initialize(sim_form.Canvas_PB);
        }

        private void Start_button_Click(object sender, EventArgs e)//Začne semi-automatickou bitvu
        {
            switch (Start_button.Text)
            {
                case "Start!":
                    Battle_button.Enabled = false;
                    Next_gen_button.Enabled = false;
                    Logic.automatic = true;
                    Battle_button_Click(sender, e);
                    Start_button.Text = "Pause";
                    break;
                case "Pause":
                    Battle_button.Enabled = true;
                    Next_gen_button.Enabled = false;
                    Logic.automatic = false;
                    Battle_button_Click(sender, e);
                    Start_button.Text = "Start!";
                    break;
            }

        }

        private void Sim_timer_Tick(object sender, EventArgs e)//Používá se jako časovač logiky
        {
            Logic.Do_sim_tick();
        }

        private void chck_hide_sim_CheckedChanged(object sender, EventArgs e)//Schová simulaci a provádí jí na pozadí
        {
            Logic.fast_forward = chck_hide_sim.Checked;
            if (chck_hide_sim.Checked == true)
            {
                Sim_timer.Interval = 1;
                sim_form.Hide();
            }
            else
            {
                Sim_timer.Interval = 1000 / (int)(Convert.ToDouble(speed_txt_box.Text) * 20);
            }
        }

        private void New_evol_button_Click(object sender, EventArgs e)//Vytvoří novou Simulaci s náhodně inicializovanými agenty
        {
            bool safe_to_continue = false;
            if (Num_of_agents_txtbox.Text != "" && Party_size_txbox.Text != "")
            {
                try
                {
                    if (Convert.ToInt32(Num_of_agents_txtbox.Text) < 1 || Convert.ToInt32(Num_of_agents_txtbox.Text) > 30 ||
                        Convert.ToInt32(Party_size_txbox.Text) < 1 || Convert.ToInt32(Party_size_txbox.Text) > 10) 
                        throw new Exception("WrongInput");
                    safe_to_continue = true;
                }
                catch
                {
                    MessageBox.Show("Invalid input! Number of agents must be between  1 and 30 and Parties must be between 1 and 10. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    safe_to_continue = false;
                }
            }
            if (safe_to_continue)
            {
                Logic.sim_in_progress = false;
                sim_form.Hide();
                Visual_bridge.Reset();
                Sim_control_group.Enabled = true;
                Evol_control_group.Enabled = true;
                Logic.parties_num = Convert.ToInt32(Num_of_agents_txtbox.Text);
                Logic.PARTY_SIZE = Convert.ToInt32(Party_size_txbox.Text);
                Logic.agents_in_race = Convert.ToInt32(Num_of_agents_txtbox.Text) * Logic.PARTY_SIZE;
                Logic.num_of_agents = Convert.ToInt32(Num_of_agents_txtbox.Text) * Logic.PARTY_SIZE * 3;
                Logic.Evolution_init(Sim_timer, sim_form, this);
            }
        }

        public void Update_text()//Nastaví textboxy v menu_formu na hodnoty, které jsou v paměti
        {
            generation_label.Text = Convert.ToString(Logic.generation);
            Num_of_agents_txtbox.Text = Convert.ToString(Logic.agents_in_race/Logic.PARTY_SIZE);
            Party_size_txbox.Text = Convert.ToString(Logic.PARTY_SIZE);
            if (!Logic.fast_forward)
                speed_txt_box.Text = Convert.ToString( (double)(1000.0 / (Sim_timer.Interval * 20.0)) );
            Match_time_txtbox.Text = Convert.ToString(Logic.match_ticks / 20);

            
        }

        private void Battle_button_Click(object sender, EventArgs e)//Započne nebo zruší bitvu
        {
            if (Battle_button.Text == "Battle")
            {
                if (Logic.fast_forward == false)
                    sim_form.Show();
                Logic.Simulate_battle();
                Battle_button.Text = "Cancel";
                Match_time_txtbox.Enabled = false;
                show_gen_button.Enabled = false;
            }
            else
            {
                show_gen_button.Enabled = true;
                Match_time_txtbox.Enabled = true;
                Battle_button.Text = "Battle";
                sim_form.Hide();
                Logic.Cancel_battle();
            }
        }

        public void Simulation_done()//Spustí se, když doběhne simulace
        {
            Battle_button.Text = "Battle";
            Next_gen_button.Enabled = true;
            Match_time_txtbox.Enabled = true;
            show_gen_button.Enabled = true;
            progress_label.Text = "Idle";
             Set_stats();
        }

        public void Set_stats()//Nastaví statistiku z paměti do menu_formu
        {
            best_fit_label.Text = Convert.ToString(Logic.best_fitness);
            avg_fit_label.Text = Convert.ToString(Logic.mean_fitness);
            label_best_R.Text = Convert.ToString(Logic.all_stats[0, 0]);
            label_mean_R.Text = Convert.ToString(Logic.all_stats[0, 1]);
            label_best_G.Text = Convert.ToString(Logic.all_stats[1, 0]);
            label_mean_G.Text = Convert.ToString(Logic.all_stats[1, 1]);
            label_best_B.Text = Convert.ToString(Logic.all_stats[2, 0]);
            label_mean_B.Text = Convert.ToString(Logic.all_stats[2, 1]);
        }

        private void Match_time_txtbox_TextChanged(object sender, EventArgs e)
        {


            if (Match_time_txtbox.Text != "")
            {
                try
                {
                    if (Convert.ToInt32(Match_time_txtbox.Text) < 1 || Convert.ToInt32(Match_time_txtbox.Text) > 41)
                        throw new Exception("WrongInput");
                    Logic.match_ticks = 20 * Convert.ToInt32(Match_time_txtbox.Text);
                }
                catch
                {
                    MessageBox.Show("Match time must be an integer between 1 and 40!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void speed_txt_box_TextChanged(object sender, EventArgs e)
        {
            if ((speed_txt_box.Text != "") && ! (speed_txt_box.Text.EndsWith(".")) && !(speed_txt_box.Text.EndsWith("0")))
            {
                try
                {
                    if (Convert.ToDouble(speed_txt_box.Text) < 0.001 || Convert.ToDouble(speed_txt_box.Text) > 3)
                        throw new Exception("WrongInput");
                    Sim_timer.Interval = (int)(1000.0 / (Convert.ToDouble(speed_txt_box.Text) * 20));
                }
                catch
                {
                    MessageBox.Show("Match speed must be a decimal number between 0 and 3!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Next_gen_button_Click(object sender, EventArgs e)
        {
            Logic.Evolve_population();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter(save_txt_box.Text + ".txt");
            file.WriteLine(Logic.agents_in_race);
            file.WriteLine(Logic.generation);
            file.WriteLine(Logic.best_fitness);
            file.WriteLine(Logic.mean_fitness);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    file.WriteLine(Logic.all_stats[i,j]);
                }
            }
            file.WriteLine(Logic.num_of_agents);
            file.WriteLine(Logic.parties_num);
            //file.WriteLine(Logic.agents_in_race);
            file.WriteLine(Logic.PARTY_SIZE);
            file.WriteLine(Agent.GENOME_LENGTH);
            file.WriteLine(Agent.DAMAGE_MULTIPLIER);
            file.WriteLine(Agent.SIGHT_LENGTH);
            file.WriteLine(Agent.FIRING_RANGE);
            for (int i = 0; i < Logic.num_of_agents / 3; i++)
            {
                for (int j = 0; j < Agent.GENOME_LENGTH; j++)
                {
                    file.WriteLine(Logic.Reds[i].genome[j]);
                }
                file.WriteLine(Logic.Reds[i].id);
            }
            for (int i = 0; i < Logic.num_of_agents / 3; i++)
            {
                for (int j = 0; j < Agent.GENOME_LENGTH; j++)
                {
                    file.WriteLine(Logic.Greens[i].genome[j]);
                }
                file.WriteLine(Logic.Greens[i].id);
            }
            for (int i = 0; i < Logic.num_of_agents / 3; i++)
            {
                for (int j = 0; j < Agent.GENOME_LENGTH; j++)
                {
                    file.WriteLine(Logic.Greens[i].genome[j]);
                }
                file.WriteLine(Logic.Blues[i].id);
            }

            file.Close();
        }

        private void load_button_Click(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader(Convert.ToString(load_txt_box.Text) + ".txt");

            Logic.agents_in_race = Convert.ToInt32(file.ReadLine());
            Logic.Evolution_init(Sim_timer, sim_form, this);

            Logic.all_stats = new int[3, 3];

            Logic.generation = Convert.ToInt32(file.ReadLine());
            Logic.best_fitness = Convert.ToInt32(file.ReadLine());
            Logic.mean_fitness = Convert.ToInt32(file.ReadLine());
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Logic.all_stats[i, j] = Convert.ToInt32(file.ReadLine());
                }
            }
            Logic.num_of_agents = Convert.ToInt32(file.ReadLine());
            Logic.parties_num = Convert.ToInt32(file.ReadLine());
            Logic.PARTY_SIZE = Convert.ToInt32(file.ReadLine());
            Agent.GENOME_LENGTH = Convert.ToInt32(file.ReadLine());
            Agent.DAMAGE_MULTIPLIER = Convert.ToInt32(file.ReadLine());
            Agent.SIGHT_LENGTH = Convert.ToInt32(file.ReadLine());
            Agent.FIRING_RANGE = Convert.ToInt32(file.ReadLine());

            for (int i = 0; i < Logic.num_of_agents / 3; i++)
            {
                for (int j = 0; j < Agent.GENOME_LENGTH; j++)
                {
                    Logic.Reds[i].genome[j] = Convert.ToChar(file.ReadLine());
                }
                Logic.Reds[i].id = Convert.ToInt32(file.ReadLine());
                Logic.Reds[i].Get_fenotype();

            }
            for (int i = 0; i < Logic.num_of_agents / 3; i++)
            {
                for (int j = 0; j < Agent.GENOME_LENGTH; j++)
                {
                    Logic.Greens[i].genome[j] = Convert.ToChar(file.ReadLine());
                }
                Logic.Greens[i].id = Convert.ToInt32(file.ReadLine());
                Logic.Greens[i].Get_fenotype();
            }
            for (int i = 0; i < Logic.num_of_agents / 3; i++)
            {
                for (int j = 0; j < Agent.GENOME_LENGTH; j++)
                {
                    Logic.Greens[i].genome[j] = Convert.ToChar(file.ReadLine());
                }
                Logic.Blues[i].id = Convert.ToInt32(file.ReadLine());
                Logic.Blues[i].Get_fenotype();
            }

            generation_label.Text = Convert.ToString(Logic.generation);
            Sim_control_group.Enabled = true;
            Evol_control_group.Enabled = true;
            Set_stats();
            file.Close();

            Logic.Generation_init();
        }

        private void show_gen_button_Click(object sender, EventArgs e)//Zobrazí genomy jednotlivých agentů
        {
            sim_form.Show();
            sim_form.Refresh();
            Visual_bridge.Reset();
            Visual_bridge.Render_genome();
        }

        private void collision_chcbox_CheckedChanged(object sender, EventArgs e)
        {
            Logic.Collisions = collision_chcbox.Checked;
        }

        private void seed_txtbox_TextChanged(object sender, EventArgs e)//Tohle je tu k ničemu, ale VS mi nedovolí to smazat
        {

        }

        private void Seed_button_Click(object sender, EventArgs e)
        {
            if ((seed_txtbox.Text != ""))
            {
               try
               {
                    Logic.rand = new Random(Convert.ToInt32(seed_txtbox.Text));
               }
               catch
               {
                    MessageBox.Show("Seed must be an integer between 0 and 1000!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
        }//Nastaví seed pro náhodné proměnné

        private void fast_forward_button_Click(object sender, EventArgs e)//Započne automatickou evoluci až do zadané generace
        {
            int gens;
            bool safe_to_continue = true;
            try
            {
                gens = Convert.ToInt32(fast_forward_txtbox.Text);
            }
            catch
            {
                MessageBox.Show("Generation number must be an integer between 1 and 1000!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                safe_to_continue = false;
            }


            if (safe_to_continue)
            {
                Logic.fast_forward = true;
                Battle_button.Enabled = false;
                Start_button.Enabled = false;
                save_button.Enabled = false;
                load_button.Enabled = false;
                Mutation_txtbox.Enabled = false;
                New_evol_button.Enabled = false;
                speed_txt_box.Enabled = false;
                Match_time_txtbox.Enabled = false;
                collision_chcbox.Enabled = false;
                show_gen_button.Enabled = false;

                gens = Convert.ToInt32(fast_forward_txtbox.Text);
                for (int gen = 0; gen < gens; gen++)
                {
                    Logic.Generation_init();
                    int tru_party = 0;
                    for (Logic.current_party = 0; Logic.current_party < Logic.parties_num; Logic.current_party = tru_party)
                    {
                        Logic.Divide_agents();
                        Logic.Position_init(Logic.Current_agents, Logic.PARTY_SIZE * 3);
                        for (int tick = 0; tick < Logic.match_ticks; tick++)
                        {
                            Logic.Excite_agents();
                        }
                        Logic.Finish_simulation();
                        tru_party++;
                    }
                    Logic.Evolve_population();
                }
                Battle_button.Enabled = true;
                Start_button.Enabled = true;
                save_button.Enabled = true;
                load_button.Enabled = true;
                Mutation_txtbox.Enabled = true;
                New_evol_button.Enabled = true;
                speed_txt_box.Enabled = true;
                Match_time_txtbox.Enabled = true;
                collision_chcbox.Enabled = true;
                show_gen_button.Enabled = true;

                Logic.fast_forward = chck_hide_sim.Checked;
            }
        }

        private void Mutation_txtbox_TextChanged(object sender, EventArgs e)
        {
            if (Mutation_txtbox.Text != "")
            {
                try
                {
                    if (Convert.ToInt32(Mutation_txtbox.Text) < 0 || Convert.ToInt32(Mutation_txtbox.Text) > 100)
                        throw new Exception("WrongInput");
                    Genetic_algorithm.MUTATION_RATE_THRESH = Convert.ToInt32(Mutation_txtbox.Text);
                }
                catch
                {
                    MessageBox.Show("Matation number must be between 0 and 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Help_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Click on New Evolution to start Evolution simulation.\n" +
                "Since you can't fit 100 Brabeneces in one window, you\n" +
                "have to divide them into parties." +
                "The parties number serves that purpose and second number\n" +
                "is how many Brabeneces will be in one window.\n" +
                "\n" +
                "You have 3 options to evolve.\n" +
                "1) Manual: Just click Battle and after it finishes, click \n" +
                "           Next Generation\n" +
                "2) Semi-automatic: Click on Start! and the steps above will\n" +
                "                   be looping automatically (You can also\n" +
                "                   hide the simulation during this process)\n" +
                "3) Automatic: You can fast forward specified number of\n" +
                "              generations by stating the number in bottom\n" +
                "              right text box and clicking Fast forward.\n" +
                "              Note that program will be unresponsive during\n" +
                "              the time it takes to finish, so be carefull with\n" +
                "              the number of generations.\n" +
                "\n" +
                "You can change time of individual simulations as well as speed\n" +
                "of simulation.\n" +
                "                         Happy evolving!", "Help",  MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
}
