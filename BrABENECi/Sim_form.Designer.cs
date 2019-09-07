namespace BrABENECi
{
    partial class Sim_form
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
            this.Canvas_PB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas_PB
            // 
            this.Canvas_PB.BackColor = System.Drawing.Color.Black;
            this.Canvas_PB.Location = new System.Drawing.Point(22, 0);
            this.Canvas_PB.Name = "Canvas_PB";
            this.Canvas_PB.Size = new System.Drawing.Size(850, 850);
            this.Canvas_PB.TabIndex = 0;
            this.Canvas_PB.TabStop = false;
            // 
            // Sim_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(884, 861);
            this.Controls.Add(this.Canvas_PB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Sim_form";
            this.Text = "BrABENECi";
            this.Load += new System.EventHandler(this.Sim_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox Canvas_PB;
    }
}