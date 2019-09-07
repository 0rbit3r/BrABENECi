using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrABENECi
{
    class Agent
    {
        public static int SIGHT_LENGTH = 250;
        public static int FIRING_RANGE = 60;
        public static int GENOME_LENGTH = 182;
        public static int GEN_AI_START = 12;
        public static int DAMAGE_MULTIPLIER = 1;
        public static int SENSOR_NUM = 9;
        public static int EYES_NUM = 8;
        public static int OUTPUT_NUM = 3;


        public int color;
        public string color_string;

        public int pos_X;
        public int pos_Y;
        public double orient;
        public int max_health;
        public int health;
        public int speed;
        public int damage;
        public int reload_time;
        public double[] eyes;
        public int time_to_fire;
        public bool alive;
        public bool attacking;

        public double[] input;

        public char[] genome;
        public Neural_network brain;
        public int id;
        public int fitness;
        public int enemies_killed;
        

        public Agent(int id, int color)
        {
            this.id = id;
            this.color = color;
            Generate_genome();
            orient = Logic.rand.Next(0, 628) / 100.0;
            Get_fenotype();
            switch (color)
            {
                case 0:
                    color_string = "RED";
                    break;
                case 1:
                    color_string = "GREEN";
                    break;
                case 2:
                    color_string = "BLUE";
                    break;
            }

        }

        public Agent(Agent mother, Agent father)
        {
            Agent[] parents = { mother, father };
            genome = new char[GENOME_LENGTH];
            for (int i = 0; i < GENOME_LENGTH; i++)
            {
                int parent_choice= Logic.rand.Next(0, 2);
                genome[i] = parents[parent_choice].genome[i]; //Udělat to po větších kusech?
                int mutation_flip = Logic.rand.Next(1, 101);
                if (mutation_flip < Genetic_algorithm.MUTATION_RATE_THRESH)
                {
                    genome[i] = (char)(Logic.rand.Next(10) + 48);
                }
            }
            Get_fenotype();
            color = father.color;
            switch (color)
            {
                case 0:
                    color_string = "RED";
                    break;
                case 1:
                    color_string = "GREEN";
                    break;
                case 2:
                    color_string = "BLUE";
                    break;
            }
        }

        void Generate_genome()
        {
            genome = new char[GENOME_LENGTH];
            for (int i = 0; i < GENOME_LENGTH; i++)
            {
                genome[i] = (char)(Logic.rand.Next(10) + 48);
            }
        }

        public void Get_fenotype()
        {
            max_health = Convert.ToInt32(Convert.ToString(genome[0]) + Convert.ToString(genome[1]));
            if (max_health == 0)
                max_health = 5;
            speed = 10 - max_health/10; 
            damage = Convert.ToInt32(Convert.ToString(genome[2]) + Convert.ToString(genome[3]))* DAMAGE_MULTIPLIER;
            if (damage == 0)
                damage = 5;
            reload_time = (int)(Convert.ToInt32(Convert.ToString(genome[2]) + Convert.ToString(genome[3]))*0.6);//Zkus to nějak biasovat
            if (reload_time == 0)
                reload_time = 1;
            eyes = new double[SENSOR_NUM];
            for (int i = 0; i < EYES_NUM; i++)
            {
                eyes[i] = Convert.ToInt32(Convert.ToString(genome[4 + 2*i]) + Convert.ToString(genome[5 + 2*i]));
                eyes[i] = (eyes[i] / 99.0) * 6.28;
            }
            brain = new Neural_network(genome, SENSOR_NUM, OUTPUT_NUM, GEN_AI_START );
        }

        public void Make_decision()
        {
            brain.Propagate(input);
            //Output je uložen v mozku
        }

        public void Commit_move()
        {
            int old_X = 0;
            int old_Y = 0;
            if (brain.output[0] != 0)
            {
                old_X = pos_X;
                old_Y = pos_Y;
                if (brain.output[0] > 0)
                    Move_forward(speed * brain.output[0]);
                if (pos_X >= 850)
                    pos_X = 850;
                if (pos_X <= 0)
                    pos_X = 0;
                if (pos_Y >= 850)
                    pos_Y = 850;
                if (pos_Y <= 0)
                    pos_Y = 0;
                if (!Logic.fast_forward)
                    Visual_bridge.Move_agent(old_X, old_Y, pos_X, pos_Y, max_health, color_string, orient);
            }
            Turn(brain.output[1] * 1);//Tady najít vhodnou konstantu!
            if ((brain.output[2] > 0.5) && (time_to_fire == 0))
                attacking = true;

            if ((old_X == pos_X) && (old_Y == pos_Y))
                fitness--;
        }

        public void Turn(double degs)
        {
            orient += degs;
            Logic.Normalize_angle(ref orient);
        }

        public void Move_forward(double dist)
        {
            pos_X += (int)(Math.Cos(orient) * dist);
            pos_Y += (int)(Math.Sin(orient) * dist);
        }

    }

}
/*
 * Genome design:
 * length: 182
 *              = 2*(hp + rps + eyes + ( (sensors + 1) * 6 + (6+1) * outputs ) ) 
 * 0 - 1 HP             (2)
 * 2 - 3 RPS            (2)
 * 4 - 11 EYES          (8)
 * 12 - 181 Synapses            (162) 
 * 
 * Network design:
 * 5,7,4 (4+1,6+1,4)
 * First:
 *      4 sensors + bias
 * Second:
 *      6 neurons + bias
 * Third:
 *      4 outputs (Forward, left/right, unused node and fire)
 */

