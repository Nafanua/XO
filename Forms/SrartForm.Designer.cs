namespace XO.Forms
{
    partial class StartForm
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
            this.PvP = new System.Windows.Forms.Button();
            this.PvA = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PvP
            // 
            this.PvP.Location = new System.Drawing.Point(38, 27);
            this.PvP.Name = "PvP";
            this.PvP.Size = new System.Drawing.Size(109, 23);
            this.PvP.TabIndex = 0;
            this.PvP.Text = "Player vs Player\r\n";
            this.PvP.UseVisualStyleBackColor = true;
            this.PvP.Click += new System.EventHandler(this.PvP_Click);
            // 
            // PvA
            // 
            this.PvA.Location = new System.Drawing.Point(38, 56);
            this.PvA.Name = "PvA";
            this.PvA.Size = new System.Drawing.Size(109, 23);
            this.PvA.TabIndex = 1;
            this.PvA.Text = "Player vs Easy AI";
            this.PvA.UseVisualStyleBackColor = true;
            this.PvA.Click += new System.EventHandler(this.PvA_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Player vs Hard AI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(38, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Player vs Middle Ai";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(38, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 178);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PvA);
            this.Controls.Add(this.PvP);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PvP;
        private System.Windows.Forms.Button PvA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

