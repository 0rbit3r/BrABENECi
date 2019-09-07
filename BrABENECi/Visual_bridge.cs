using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrABENECi
{
    class Visual_bridge
    {
        public static System.Drawing.Pen red_pen;
        static System.Drawing.Pen green_pen;
        static System.Drawing.Pen blue_pen;
        public static System.Drawing.Pen black_pen;
        public static System.Drawing.Pen white_pen;
        public static System.Drawing.Pen gray_pen;
        static System.Drawing.Graphics canvas;

        public static int MIN_RADIUS = 10;
        public static int MAX_RADIUS = 25;

        public static bool SHOW_ID = false;

        public static void Initialize(System.Windows.Forms.PictureBox picture_box)
        {
            canvas = picture_box.CreateGraphics();
            red_pen = new System.Drawing.Pen(System.Drawing.Color.Red);
            green_pen = new System.Drawing.Pen(System.Drawing.Color.Green);
            blue_pen = new System.Drawing.Pen(System.Drawing.Color.Cyan);
            black_pen = new System.Drawing.Pen(System.Drawing.Color.Black);
            white_pen = new System.Drawing.Pen(System.Drawing.Color.White);
            gray_pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(255,20,20,20));
            red_pen.Width = green_pen.Width = blue_pen.Width = black_pen.Width = white_pen.Width = gray_pen.Width = 3;

        }
        
        public static void Draw_circle(int x, int y, int r, System.Drawing.Pen pen)
        {
            canvas.DrawEllipse(pen, x - r, y - r, r * 2, r * 2);
        }

        public static void Write_text(string text, int x, int y, System.Drawing.Pen pen)
        {
            System.Drawing.Font font = new System.Drawing.Font("Arial", 16);

            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(pen.Color);

            canvas.DrawString(text, font, brush, x, y);
        }

        public static void Kill_agent(int x, int y, int health)
        {
            int radius = Health_to_size(health);
            Draw_circle(x, y, radius, gray_pen);
        }

        public static void Draw_dead_bullet(int x1, int y1, double orient)
        {
            if (!Logic.fast_forward)
            {
                int temp_x2 = (int)(Math.Cos(orient) * Agent.FIRING_RANGE * 0.7);
                int temp_y2 = (int)(Math.Sin(orient) * Agent.FIRING_RANGE * 0.7);
                Draw_bullet(x1, y1, x1 + temp_x2, y1 + temp_y2, black_pen);
            }
        }

        public static void Move_agent(int x1, int y1, int x2, int y2, int health, string color, double orient)
        {
            if (Logic.fast_forward == false)
            {
                int radius = Health_to_size(health);
                Draw_circle(x1, y1, radius, black_pen);
                Draw_dead_bullet(x1,y1, orient);
                switch (color)
                {
                    case "BLACK":
                        Draw_circle(x2, y2, radius, black_pen);
                        break;
                    case "RED":
                        Draw_circle(x2, y2, radius, red_pen);
                        break;
                    case "GREEN":
                        Draw_circle(x2, y2, radius, green_pen);
                        break;
                    case "BLUE":
                        Draw_circle(x2, y2, radius, blue_pen);
                        break;
                }
                //Draw_circle(x1, y1, radius, black_pen);
            }
        }

        public static int Health_to_size(int health)
        {
            return ((int)(health / 100.0 * (MAX_RADIUS - MIN_RADIUS)) + MIN_RADIUS);
        }

        public static void Simple_render()
        {
            for (int i = 0; i < Logic.agents_in_race*3; i++)
            {
                Draw_circle(Logic.All_agents[i].pos_X, Logic.All_agents[i].pos_Y, 20, blue_pen);
            }
        }

        public static void Draw_bullet(int x1, int y1, int x2, int y2, System.Drawing.Pen pen)
        {
            if (Logic.fast_forward == false)
            {
                canvas.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        public static void Reset()
        {
            if (!Logic.fast_forward)
                canvas.Clear(System.Drawing.Color.Black);
        }

        public static void Render_genome()
        {
            System.Drawing.Pen gen_pen = new System.Drawing.Pen(System.Drawing.Color.White);
            void Show_race(int R, int G, int B, Agent[] agents, int offset)
            {

                for (int i = 0; i < agents.Length; i++)
                {
                    for (int j = 0; j < Agent.GENOME_LENGTH; j++)
                    {
                        int gen_number = Convert.ToInt32(agents[i].genome[j]) - 48;

                        gen_pen.Color = System.Drawing.Color.FromArgb(255, (int)(R * 255.0 * gen_number / 9.0),
                            (int)(G * 255.0 * gen_number / 9.0), (int)(B * 255.0 * gen_number / 10.0));
                        canvas.FillRectangle(gen_pen.Brush, 2 * j, 2 * i + 2*offset, 2, 2);
                    }
                }
            }
            Show_race(1, 0, 0, Logic.Reds, 0);
            Show_race(0, 1, 0, Logic.Reds, Logic.Reds.Length);
            Show_race(0, 0, 1, Logic.Reds, Logic.Reds.Length * 2);
        }

    }
}
