namespace BrABENECi
{
    partial class Menu_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Start_button = new System.Windows.Forms.Button();
            this.Sim_timer = new System.Windows.Forms.Timer(this.components);
            this.chck_hide_sim = new System.Windows.Forms.CheckBox();
            this.Save_load_group = new System.Windows.Forms.GroupBox();
            this.load_txt_box = new System.Windows.Forms.TextBox();
            this.load_button = new System.Windows.Forms.Button();
            this.save_txt_box = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.speed_txt_box = new System.Windows.Forms.TextBox();
            this.speed_label = new System.Windows.Forms.Label();
            this.statistics_group = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_mean_B = new System.Windows.Forms.Label();
            this.label_best_B = new System.Windows.Forms.Label();
            this.label_mean_G = new System.Windows.Forms.Label();
            this.label_best_G = new System.Windows.Forms.Label();
            this.label_mean_R = new System.Windows.Forms.Label();
            this.label_best_R = new System.Windows.Forms.Label();
            this.avg_fit_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.best_fit_label = new System.Windows.Forms.Label();
            this.generation_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Sim_control_group = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fast_forward_txtbox = new System.Windows.Forms.TextBox();
            this.fast_forward_button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Match_time_txtbox = new System.Windows.Forms.TextBox();
            this.Battle_button = new System.Windows.Forms.Button();
            this.Next_gen_button = new System.Windows.Forms.Button();
            this.Setup_group = new System.Windows.Forms.GroupBox();
            this.seed_txtbox = new System.Windows.Forms.TextBox();
            this.Seed_button = new System.Windows.Forms.Button();
            this.New_evol_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Party_size_txbox = new System.Windows.Forms.TextBox();
            this.Num_of_agents_txtbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Evol_control_group = new System.Windows.Forms.GroupBox();
            this.collision_chcbox = new System.Windows.Forms.CheckBox();
            this.show_gen_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Mutation_txtbox = new System.Windows.Forms.TextBox();
            this.ticks_label = new System.Windows.Forms.Label();
            this.progress_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Help_button = new System.Windows.Forms.Button();
            this.Save_load_group.SuspendLayout();
            this.statistics_group.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Sim_control_group.SuspendLayout();
            this.Setup_group.SuspendLayout();
            this.Evol_control_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_button
            // 
            this.Start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Start_button.Location = new System.Drawing.Point(12, 150);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(248, 56);
            this.Start_button.TabIndex = 0;
            this.Start_button.Text = "Start!";
            this.Start_button.UseVisualStyleBackColor = true;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // Sim_timer
            // 
            this.Sim_timer.Interval = 50;
            this.Sim_timer.Tick += new System.EventHandler(this.Sim_timer_Tick);
            // 
            // chck_hide_sim
            // 
            this.chck_hide_sim.AutoSize = true;
            this.chck_hide_sim.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chck_hide_sim.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chck_hide_sim.Location = new System.Drawing.Point(6, 75);
            this.chck_hide_sim.Name = "chck_hide_sim";
            this.chck_hide_sim.Size = new System.Drawing.Size(163, 29);
            this.chck_hide_sim.TabIndex = 1;
            this.chck_hide_sim.Text = "Hide simulation";
            this.chck_hide_sim.UseVisualStyleBackColor = true;
            this.chck_hide_sim.CheckedChanged += new System.EventHandler(this.chck_hide_sim_CheckedChanged);
            // 
            // Save_load_group
            // 
            this.Save_load_group.Controls.Add(this.load_txt_box);
            this.Save_load_group.Controls.Add(this.load_button);
            this.Save_load_group.Controls.Add(this.save_txt_box);
            this.Save_load_group.Controls.Add(this.save_button);
            this.Save_load_group.Location = new System.Drawing.Point(401, 71);
            this.Save_load_group.Name = "Save_load_group";
            this.Save_load_group.Size = new System.Drawing.Size(286, 123);
            this.Save_load_group.TabIndex = 2;
            this.Save_load_group.TabStop = false;
            this.Save_load_group.Text = "Saving and loading";
            // 
            // load_txt_box
            // 
            this.load_txt_box.Location = new System.Drawing.Point(96, 82);
            this.load_txt_box.Name = "load_txt_box";
            this.load_txt_box.Size = new System.Drawing.Size(163, 20);
            this.load_txt_box.TabIndex = 4;
            // 
            // load_button
            // 
            this.load_button.Location = new System.Drawing.Point(6, 69);
            this.load_button.Name = "load_button";
            this.load_button.Size = new System.Drawing.Size(84, 44);
            this.load_button.TabIndex = 3;
            this.load_button.Text = "Load from";
            this.load_button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.load_button.UseVisualStyleBackColor = true;
            this.load_button.Click += new System.EventHandler(this.load_button_Click);
            // 
            // save_txt_box
            // 
            this.save_txt_box.Location = new System.Drawing.Point(96, 32);
            this.save_txt_box.Name = "save_txt_box";
            this.save_txt_box.Size = new System.Drawing.Size(163, 20);
            this.save_txt_box.TabIndex = 1;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(6, 19);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(84, 44);
            this.save_button.TabIndex = 0;
            this.save_button.Text = "Save as:";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // speed_txt_box
            // 
            this.speed_txt_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.speed_txt_box.Location = new System.Drawing.Point(201, 16);
            this.speed_txt_box.Name = "speed_txt_box";
            this.speed_txt_box.Size = new System.Drawing.Size(58, 30);
            this.speed_txt_box.TabIndex = 3;
            this.speed_txt_box.Text = "1";
            this.speed_txt_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.speed_txt_box.TextChanged += new System.EventHandler(this.speed_txt_box_TextChanged);
            // 
            // speed_label
            // 
            this.speed_label.AutoSize = true;
            this.speed_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.speed_label.Location = new System.Drawing.Point(6, 19);
            this.speed_label.Name = "speed_label";
            this.speed_label.Size = new System.Drawing.Size(168, 25);
            this.speed_label.TabIndex = 4;
            this.speed_label.Text = "Simulation speed:";
            // 
            // statistics_group
            // 
            this.statistics_group.Controls.Add(this.groupBox1);
            this.statistics_group.Controls.Add(this.generation_label);
            this.statistics_group.Controls.Add(this.label1);
            this.statistics_group.Location = new System.Drawing.Point(12, 71);
            this.statistics_group.Name = "statistics_group";
            this.statistics_group.Size = new System.Drawing.Size(383, 211);
            this.statistics_group.TabIndex = 5;
            this.statistics_group.TabStop = false;
            this.statistics_group.Text = "Evolution statistics";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_mean_B);
            this.groupBox1.Controls.Add(this.label_best_B);
            this.groupBox1.Controls.Add(this.label_mean_G);
            this.groupBox1.Controls.Add(this.label_best_G);
            this.groupBox1.Controls.Add(this.label_mean_R);
            this.groupBox1.Controls.Add(this.label_best_R);
            this.groupBox1.Controls.Add(this.avg_fit_label);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.best_fit_label);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(27, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 130);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fitness";
            // 
            // label_mean_B
            // 
            this.label_mean_B.AutoSize = true;
            this.label_mean_B.ForeColor = System.Drawing.Color.Aqua;
            this.label_mean_B.Location = new System.Drawing.Point(286, 79);
            this.label_mean_B.Name = "label_mean_B";
            this.label_mean_B.Size = new System.Drawing.Size(18, 20);
            this.label_mean_B.TabIndex = 8;
            this.label_mean_B.Text = "0";
            // 
            // label_best_B
            // 
            this.label_best_B.AutoSize = true;
            this.label_best_B.ForeColor = System.Drawing.Color.Aqua;
            this.label_best_B.Location = new System.Drawing.Point(286, 37);
            this.label_best_B.Name = "label_best_B";
            this.label_best_B.Size = new System.Drawing.Size(18, 20);
            this.label_best_B.TabIndex = 8;
            this.label_best_B.Text = "0";
            // 
            // label_mean_G
            // 
            this.label_mean_G.AutoSize = true;
            this.label_mean_G.ForeColor = System.Drawing.Color.Lime;
            this.label_mean_G.Location = new System.Drawing.Point(227, 79);
            this.label_mean_G.Name = "label_mean_G";
            this.label_mean_G.Size = new System.Drawing.Size(18, 20);
            this.label_mean_G.TabIndex = 8;
            this.label_mean_G.Text = "0";
            // 
            // label_best_G
            // 
            this.label_best_G.AutoSize = true;
            this.label_best_G.ForeColor = System.Drawing.Color.Lime;
            this.label_best_G.Location = new System.Drawing.Point(227, 37);
            this.label_best_G.Name = "label_best_G";
            this.label_best_G.Size = new System.Drawing.Size(18, 20);
            this.label_best_G.TabIndex = 8;
            this.label_best_G.Text = "0";
            // 
            // label_mean_R
            // 
            this.label_mean_R.AutoSize = true;
            this.label_mean_R.ForeColor = System.Drawing.Color.Red;
            this.label_mean_R.Location = new System.Drawing.Point(168, 79);
            this.label_mean_R.Name = "label_mean_R";
            this.label_mean_R.Size = new System.Drawing.Size(18, 20);
            this.label_mean_R.TabIndex = 8;
            this.label_mean_R.Text = "0";
            // 
            // label_best_R
            // 
            this.label_best_R.AutoSize = true;
            this.label_best_R.ForeColor = System.Drawing.Color.Red;
            this.label_best_R.Location = new System.Drawing.Point(168, 37);
            this.label_best_R.Name = "label_best_R";
            this.label_best_R.Size = new System.Drawing.Size(18, 20);
            this.label_best_R.TabIndex = 8;
            this.label_best_R.Text = "0";
            // 
            // avg_fit_label
            // 
            this.avg_fit_label.AutoSize = true;
            this.avg_fit_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.avg_fit_label.Location = new System.Drawing.Point(107, 79);
            this.avg_fit_label.Name = "avg_fit_label";
            this.avg_fit_label.Size = new System.Drawing.Size(18, 20);
            this.avg_fit_label.TabIndex = 5;
            this.avg_fit_label.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(17, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Average:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(17, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Best:";
            // 
            // best_fit_label
            // 
            this.best_fit_label.AutoSize = true;
            this.best_fit_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.best_fit_label.Location = new System.Drawing.Point(107, 37);
            this.best_fit_label.Name = "best_fit_label";
            this.best_fit_label.Size = new System.Drawing.Size(18, 20);
            this.best_fit_label.TabIndex = 3;
            this.best_fit_label.Text = "0";
            // 
            // generation_label
            // 
            this.generation_label.AutoSize = true;
            this.generation_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generation_label.Location = new System.Drawing.Point(224, 26);
            this.generation_label.Name = "generation_label";
            this.generation_label.Size = new System.Drawing.Size(29, 31);
            this.generation_label.TabIndex = 1;
            this.generation_label.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(104, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generation:";
            // 
            // Sim_control_group
            // 
            this.Sim_control_group.Controls.Add(this.label10);
            this.Sim_control_group.Controls.Add(this.fast_forward_txtbox);
            this.Sim_control_group.Controls.Add(this.fast_forward_button);
            this.Sim_control_group.Controls.Add(this.label9);
            this.Sim_control_group.Controls.Add(this.Match_time_txtbox);
            this.Sim_control_group.Controls.Add(this.Battle_button);
            this.Sim_control_group.Controls.Add(this.Next_gen_button);
            this.Sim_control_group.Controls.Add(this.chck_hide_sim);
            this.Sim_control_group.Controls.Add(this.speed_label);
            this.Sim_control_group.Controls.Add(this.speed_txt_box);
            this.Sim_control_group.Controls.Add(this.Start_button);
            this.Sim_control_group.Enabled = false;
            this.Sim_control_group.Location = new System.Drawing.Point(401, 200);
            this.Sim_control_group.Name = "Sim_control_group";
            this.Sim_control_group.Size = new System.Drawing.Size(286, 248);
            this.Sim_control_group.TabIndex = 6;
            this.Sim_control_group.TabStop = false;
            this.Sim_control_group.Text = "Simulation control";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(198, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "generations";
            // 
            // fast_forward_txtbox
            // 
            this.fast_forward_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fast_forward_txtbox.Location = new System.Drawing.Point(144, 217);
            this.fast_forward_txtbox.Name = "fast_forward_txtbox";
            this.fast_forward_txtbox.Size = new System.Drawing.Size(48, 23);
            this.fast_forward_txtbox.TabIndex = 14;
            // 
            // fast_forward_button
            // 
            this.fast_forward_button.Location = new System.Drawing.Point(12, 212);
            this.fast_forward_button.Name = "fast_forward_button";
            this.fast_forward_button.Size = new System.Drawing.Size(126, 32);
            this.fast_forward_button.TabIndex = 13;
            this.fast_forward_button.Text = "Fast forward:";
            this.fast_forward_button.UseVisualStyleBackColor = true;
            this.fast_forward_button.Click += new System.EventHandler(this.fast_forward_button_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(7, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Match time:";
            // 
            // Match_time_txtbox
            // 
            this.Match_time_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Match_time_txtbox.Location = new System.Drawing.Point(201, 49);
            this.Match_time_txtbox.Name = "Match_time_txtbox";
            this.Match_time_txtbox.Size = new System.Drawing.Size(58, 26);
            this.Match_time_txtbox.TabIndex = 9;
            this.Match_time_txtbox.Text = "20";
            this.Match_time_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Match_time_txtbox.TextChanged += new System.EventHandler(this.Match_time_txtbox_TextChanged);
            // 
            // Battle_button
            // 
            this.Battle_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Battle_button.Location = new System.Drawing.Point(12, 105);
            this.Battle_button.Name = "Battle_button";
            this.Battle_button.Size = new System.Drawing.Size(88, 39);
            this.Battle_button.TabIndex = 8;
            this.Battle_button.Text = "Battle";
            this.Battle_button.UseVisualStyleBackColor = true;
            this.Battle_button.Click += new System.EventHandler(this.Battle_button_Click);
            // 
            // Next_gen_button
            // 
            this.Next_gen_button.Enabled = false;
            this.Next_gen_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Next_gen_button.Location = new System.Drawing.Point(106, 105);
            this.Next_gen_button.Name = "Next_gen_button";
            this.Next_gen_button.Size = new System.Drawing.Size(154, 39);
            this.Next_gen_button.TabIndex = 7;
            this.Next_gen_button.Text = "Next generation";
            this.Next_gen_button.UseVisualStyleBackColor = true;
            this.Next_gen_button.Click += new System.EventHandler(this.Next_gen_button_Click);
            // 
            // Setup_group
            // 
            this.Setup_group.Controls.Add(this.seed_txtbox);
            this.Setup_group.Controls.Add(this.Seed_button);
            this.Setup_group.Controls.Add(this.New_evol_button);
            this.Setup_group.Controls.Add(this.label6);
            this.Setup_group.Controls.Add(this.Party_size_txbox);
            this.Setup_group.Controls.Add(this.Num_of_agents_txtbox);
            this.Setup_group.Controls.Add(this.label5);
            this.Setup_group.Location = new System.Drawing.Point(12, 12);
            this.Setup_group.Name = "Setup_group";
            this.Setup_group.Size = new System.Drawing.Size(675, 48);
            this.Setup_group.TabIndex = 7;
            this.Setup_group.TabStop = false;
            this.Setup_group.Text = "Setup";
            // 
            // seed_txtbox
            // 
            this.seed_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.seed_txtbox.Location = new System.Drawing.Point(106, 15);
            this.seed_txtbox.Name = "seed_txtbox";
            this.seed_txtbox.Size = new System.Drawing.Size(46, 26);
            this.seed_txtbox.TabIndex = 5;
            this.seed_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.seed_txtbox.TextChanged += new System.EventHandler(this.seed_txtbox_TextChanged);
            // 
            // Seed_button
            // 
            this.Seed_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Seed_button.Location = new System.Drawing.Point(6, 14);
            this.Seed_button.Name = "Seed_button";
            this.Seed_button.Size = new System.Drawing.Size(86, 28);
            this.Seed_button.TabIndex = 4;
            this.Seed_button.Text = "Set seed:";
            this.Seed_button.UseVisualStyleBackColor = true;
            this.Seed_button.Click += new System.EventHandler(this.Seed_button_Click);
            // 
            // New_evol_button
            // 
            this.New_evol_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.New_evol_button.Location = new System.Drawing.Point(548, 13);
            this.New_evol_button.Name = "New_evol_button";
            this.New_evol_button.Size = new System.Drawing.Size(121, 29);
            this.New_evol_button.TabIndex = 3;
            this.New_evol_button.Text = "New evolution";
            this.New_evol_button.UseVisualStyleBackColor = true;
            this.New_evol_button.Click += new System.EventHandler(this.New_evol_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(477, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "x";
            // 
            // Party_size_txbox
            // 
            this.Party_size_txbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Party_size_txbox.Location = new System.Drawing.Point(495, 14);
            this.Party_size_txbox.Name = "Party_size_txbox";
            this.Party_size_txbox.Size = new System.Drawing.Size(47, 26);
            this.Party_size_txbox.TabIndex = 1;
            this.Party_size_txbox.Text = "15";
            this.Party_size_txbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Num_of_agents_txtbox
            // 
            this.Num_of_agents_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Num_of_agents_txtbox.Location = new System.Drawing.Point(422, 14);
            this.Num_of_agents_txtbox.Name = "Num_of_agents_txtbox";
            this.Num_of_agents_txtbox.Size = new System.Drawing.Size(47, 26);
            this.Num_of_agents_txtbox.TabIndex = 1;
            this.Num_of_agents_txtbox.Text = "3";
            this.Num_of_agents_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(171, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Parties x race members per battle:";
            // 
            // Evol_control_group
            // 
            this.Evol_control_group.Controls.Add(this.collision_chcbox);
            this.Evol_control_group.Controls.Add(this.show_gen_button);
            this.Evol_control_group.Controls.Add(this.label8);
            this.Evol_control_group.Controls.Add(this.label7);
            this.Evol_control_group.Controls.Add(this.Mutation_txtbox);
            this.Evol_control_group.Enabled = false;
            this.Evol_control_group.Location = new System.Drawing.Point(182, 288);
            this.Evol_control_group.Name = "Evol_control_group";
            this.Evol_control_group.Size = new System.Drawing.Size(213, 160);
            this.Evol_control_group.TabIndex = 8;
            this.Evol_control_group.TabStop = false;
            this.Evol_control_group.Text = "Evolution control";
            // 
            // collision_chcbox
            // 
            this.collision_chcbox.AutoSize = true;
            this.collision_chcbox.Checked = true;
            this.collision_chcbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.collision_chcbox.Location = new System.Drawing.Point(115, 73);
            this.collision_chcbox.Name = "collision_chcbox";
            this.collision_chcbox.Size = new System.Drawing.Size(69, 17);
            this.collision_chcbox.TabIndex = 4;
            this.collision_chcbox.Text = "Collisions";
            this.collision_chcbox.UseVisualStyleBackColor = true;
            this.collision_chcbox.CheckedChanged += new System.EventHandler(this.collision_chcbox_CheckedChanged);
            // 
            // show_gen_button
            // 
            this.show_gen_button.Location = new System.Drawing.Point(10, 64);
            this.show_gen_button.Name = "show_gen_button";
            this.show_gen_button.Size = new System.Drawing.Size(86, 32);
            this.show_gen_button.TabIndex = 3;
            this.show_gen_button.Text = "Show genome";
            this.show_gen_button.UseVisualStyleBackColor = true;
            this.show_gen_button.Click += new System.EventHandler(this.show_gen_button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(158, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mutation rate:";
            // 
            // Mutation_txtbox
            // 
            this.Mutation_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mutation_txtbox.Location = new System.Drawing.Point(115, 23);
            this.Mutation_txtbox.Name = "Mutation_txtbox";
            this.Mutation_txtbox.Size = new System.Drawing.Size(37, 26);
            this.Mutation_txtbox.TabIndex = 0;
            this.Mutation_txtbox.Text = "4";
            this.Mutation_txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Mutation_txtbox.TextChanged += new System.EventHandler(this.Mutation_txtbox_TextChanged);
            // 
            // ticks_label
            // 
            this.ticks_label.AutoSize = true;
            this.ticks_label.Location = new System.Drawing.Point(73, 430);
            this.ticks_label.Name = "ticks_label";
            this.ticks_label.Size = new System.Drawing.Size(13, 13);
            this.ticks_label.TabIndex = 9;
            this.ticks_label.Text = "0";
            // 
            // progress_label
            // 
            this.progress_label.AutoSize = true;
            this.progress_label.Location = new System.Drawing.Point(12, 430);
            this.progress_label.Name = "progress_label";
            this.progress_label.Size = new System.Drawing.Size(24, 13);
            this.progress_label.TabIndex = 10;
            this.progress_label.Text = "Idle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "By Aleš Kakos";
            // 
            // Help_button
            // 
            this.Help_button.Location = new System.Drawing.Point(30, 347);
            this.Help_button.Name = "Help_button";
            this.Help_button.Size = new System.Drawing.Size(107, 37);
            this.Help_button.TabIndex = 12;
            this.Help_button.Text = "Help";
            this.Help_button.UseVisualStyleBackColor = true;
            this.Help_button.Click += new System.EventHandler(this.Help_button_Click);
            // 
            // Menu_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 452);
            this.Controls.Add(this.Help_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progress_label);
            this.Controls.Add(this.ticks_label);
            this.Controls.Add(this.Evol_control_group);
            this.Controls.Add(this.Setup_group);
            this.Controls.Add(this.Sim_control_group);
            this.Controls.Add(this.Save_load_group);
            this.Controls.Add(this.statistics_group);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu_form";
            this.Text = "BrABENECi";
            this.Load += new System.EventHandler(this.Menu_form_Load);
            this.Save_load_group.ResumeLayout(false);
            this.Save_load_group.PerformLayout();
            this.statistics_group.ResumeLayout(false);
            this.statistics_group.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Sim_control_group.ResumeLayout(false);
            this.Sim_control_group.PerformLayout();
            this.Setup_group.ResumeLayout(false);
            this.Setup_group.PerformLayout();
            this.Evol_control_group.ResumeLayout(false);
            this.Evol_control_group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chck_hide_sim;
        private System.Windows.Forms.GroupBox Save_load_group;
        private System.Windows.Forms.TextBox load_txt_box;
        private System.Windows.Forms.Button load_button;
        private System.Windows.Forms.TextBox save_txt_box;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.TextBox speed_txt_box;
        private System.Windows.Forms.Label speed_label;
        private System.Windows.Forms.GroupBox statistics_group;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label avg_fit_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label best_fit_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Sim_control_group;
        private System.Windows.Forms.GroupBox Setup_group;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button New_evol_button;
        private System.Windows.Forms.GroupBox Evol_control_group;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Match_time_txtbox;
        public System.Windows.Forms.Timer Sim_timer;
        public System.Windows.Forms.Button Battle_button;
        public System.Windows.Forms.Button Start_button;
        public System.Windows.Forms.Button Next_gen_button;
        private System.Windows.Forms.Label label_mean_B;
        private System.Windows.Forms.Label label_best_B;
        private System.Windows.Forms.Label label_mean_G;
        private System.Windows.Forms.Label label_best_G;
        private System.Windows.Forms.Label label_mean_R;
        private System.Windows.Forms.Label label_best_R;
        public System.Windows.Forms.Label generation_label;
        public System.Windows.Forms.Label ticks_label;
        public System.Windows.Forms.Label progress_label;
        public System.Windows.Forms.TextBox Party_size_txbox;
        public System.Windows.Forms.TextBox Num_of_agents_txtbox;
        public System.Windows.Forms.TextBox Mutation_txtbox;
        private System.Windows.Forms.Button show_gen_button;
        private System.Windows.Forms.CheckBox collision_chcbox;
        private System.Windows.Forms.TextBox seed_txtbox;
        private System.Windows.Forms.Button Seed_button;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fast_forward_txtbox;
        private System.Windows.Forms.Button fast_forward_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Help_button;
    }
}

