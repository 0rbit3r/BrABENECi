using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Start_button_Click(object sender, EventArgs e)
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

        private void Sim_timer_Tick(object sender, EventArgs e)
        {
            Logic.Do_sim_tick();
        }

        private void chck_hide_sim_CheckedChanged(object sender, EventArgs e)
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

        private void New_evol_button_Click(object sender, EventArgs e)
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

        public void Update_text()
        {
            generation_label.Text = Convert.ToString(Logic.generation);
            Num_of_agents_txtbox.Text = Convert.ToString(Logic.agents_in_race/Logic.PARTY_SIZE);
            Party_size_txbox.Text = Convert.ToString(Logic.PARTY_SIZE);
            if (!Logic.fast_forward)
                speed_txt_box.Text = Convert.ToString(1000 / (Sim_timer.Interval * 20));
            Match_time_txtbox.Text = Convert.ToString(Logic.match_ticks / 20);

            
        }

        private void Battle_button_Click(object sender, EventArgs e)
        {
            if (Battle_button.Text == "Battle")
            {
                if (Logic.fast_forward == false)
                    sim_form.Show();
                Logic.Simulate_battle();
                Battle_button.Text = "Cancel";
                Match_time_txtbox.Enabled = false;
            }
            else
            {
                Match_time_txtbox.Enabled = true;
                Battle_button.Text = "Battle";
                sim_form.Hide();
                Logic.Cancel_battle();
            }
        }

        public void Simulation_done()
        {
            Battle_button.Text = "Battle";
            Next_gen_button.Enabled = true;
            Match_time_txtbox.Enabled = true;
            progress_label.Text = "Idle";
             Set_stats();
        }

        public void Set_stats()
        {
            best_fit_label.Text = Convert.ToString(Logic.best_fitness);
            avg_fit_label.Text = Convert.ToString(Logic.mean_fitness);
            label_best_R.Text = Convert.ToString(Logic.all_stats[0, 0]);
            label_mean_R.Text = Convert.ToString(Logic.all_stats[0, 1]);
            label_median_R.Text = Convert.ToString(Logic.all_stats[0, 2]);
            label_best_G.Text = Convert.ToString(Logic.all_stats[1, 0]);
            label_mean_G.Text = Convert.ToString(Logic.all_stats[1, 1]);
            label_median_G.Text = Convert.ToString(Logic.all_stats[1, 2]);
            label_best_B.Text = Convert.ToString(Logic.all_stats[2, 0]);
            label_mean_B.Text = Convert.ToString(Logic.all_stats[2, 1]);
            label_median_B.Text = Convert.ToString(Logic.all_stats[2, 2]);
        }

        private void Match_time_txtbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void speed_txt_box_TextChanged(object sender, EventArgs e)
        { 
        }

        private void speed_button_Click(object sender, EventArgs e)
        {
            Sim_timer.Interval = 1000 / (int)(Convert.ToDouble(speed_txt_box.Text) * 20);
        }

        private void Match_time_button_Click(object sender, EventArgs e)
        {
            Logic.match_ticks = 20 * Convert.ToInt32(Match_time_txtbox.Text);
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

        private void show_gen_button_Click(object sender, EventArgs e)
        {
            sim_form.Show();
            Visual_bridge.Reset();
            Visual_bridge.Render_genome();
        }

        private void collision_chcbox_CheckedChanged(object sender, EventArgs e)
        {
            Logic.Collisions = collision_chcbox.Checked;
        }

        private void seed_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Seed_button_Click(object sender, EventArgs e)
        {
            Logic.rand = new Random(Convert.ToInt32(seed_txtbox.Text));
        }

        private void fast_forward_button_Click(object sender, EventArgs e)
        {
            Logic.fast_forward = true;

            int gens = Convert.ToInt32(fast_forward_txtbox.Text);
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

            Logic.fast_forward = chck_hide_sim.Checked;
        }
    }
    
}
