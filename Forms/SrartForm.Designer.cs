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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.PvP = new System.Windows.Forms.Button();
            this.PvA = new System.Windows.Forms.Button();
            this.Unreal = new System.Windows.Forms.Button();
            this.MiddleAi = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
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
            // Unreal
            // 
            this.Unreal.Location = new System.Drawing.Point(38, 115);
            this.Unreal.Name = "Unreal";
            this.Unreal.Size = new System.Drawing.Size(109, 23);
            this.Unreal.TabIndex = 2;
            this.Unreal.Text = "Player vs Unreal AI";
            this.Unreal.UseVisualStyleBackColor = true;
            this.Unreal.Click += new System.EventHandler(this.Unreal_Click);
            // 
            // MiddleAi
            // 
            this.MiddleAi.Location = new System.Drawing.Point(38, 86);
            this.MiddleAi.Name = "MiddleAi";
            this.MiddleAi.Size = new System.Drawing.Size(109, 23);
            this.MiddleAi.TabIndex = 3;
            this.MiddleAi.Text = "Player vs Middle Ai";
            this.MiddleAi.UseVisualStyleBackColor = true;
            this.MiddleAi.Click += new System.EventHandler(this.MiddleAi_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(38, 143);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(109, 23);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 178);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.MiddleAi);
            this.Controls.Add(this.Unreal);
            this.Controls.Add(this.PvA);
            this.Controls.Add(this.PvP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PvP;
        private System.Windows.Forms.Button PvA;
        private System.Windows.Forms.Button Unreal;
        private System.Windows.Forms.Button MiddleAi;
        private System.Windows.Forms.Button Exit;
    }
}

