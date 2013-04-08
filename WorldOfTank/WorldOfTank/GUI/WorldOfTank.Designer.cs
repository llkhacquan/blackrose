namespace WorldOfTank.GUI
{
    partial class WorldOfTank
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
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxIntroduction = new System.Windows.Forms.PictureBox();
            this.pictureBoxTankCreator = new System.Windows.Forms.PictureBox();
            this.pictureBoxBattlefield = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntroduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTankCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattlefield)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxExit.Location = new System.Drawing.Point(243, 502);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(100, 32);
            this.pictureBoxExit.TabIndex = 0;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.pictureBoxExit_Click);
            // 
            // pictureBoxIntroduction
            // 
            this.pictureBoxIntroduction.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxIntroduction.Location = new System.Drawing.Point(243, 446);
            this.pictureBoxIntroduction.Name = "pictureBoxIntroduction";
            this.pictureBoxIntroduction.Size = new System.Drawing.Size(100, 32);
            this.pictureBoxIntroduction.TabIndex = 1;
            this.pictureBoxIntroduction.TabStop = false;
            // 
            // pictureBoxTankCreator
            // 
            this.pictureBoxTankCreator.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxTankCreator.Location = new System.Drawing.Point(243, 392);
            this.pictureBoxTankCreator.Name = "pictureBoxTankCreator";
            this.pictureBoxTankCreator.Size = new System.Drawing.Size(100, 32);
            this.pictureBoxTankCreator.TabIndex = 2;
            this.pictureBoxTankCreator.TabStop = false;
            this.pictureBoxTankCreator.Click += new System.EventHandler(this.pictureBoxTankCreator_Click);
            // 
            // pictureBoxBattlefield
            // 
            this.pictureBoxBattlefield.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxBattlefield.Location = new System.Drawing.Point(243, 337);
            this.pictureBoxBattlefield.Name = "pictureBoxBattlefield";
            this.pictureBoxBattlefield.Size = new System.Drawing.Size(100, 32);
            this.pictureBoxBattlefield.TabIndex = 3;
            this.pictureBoxBattlefield.TabStop = false;
            this.pictureBoxBattlefield.Click += new System.EventHandler(this.pictureBoxBattlefield_Click);
            // 
            // WorldOfTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.pictureBoxBattlefield);
            this.Controls.Add(this.pictureBoxTankCreator);
            this.Controls.Add(this.pictureBoxIntroduction);
            this.Controls.Add(this.pictureBoxExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "WorldOfTank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorldOfTank";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntroduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTankCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattlefield)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxIntroduction;
        private System.Windows.Forms.PictureBox pictureBoxTankCreator;
        private System.Windows.Forms.PictureBox pictureBoxBattlefield;
    }
}