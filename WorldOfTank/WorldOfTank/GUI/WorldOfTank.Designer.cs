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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldOfTank));
            this.pictureBoxBattlefield = new System.Windows.Forms.PictureBox();
            this.pictureBoxTankCreator = new System.Windows.Forms.PictureBox();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattlefield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTankCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBattlefield
            // 
            this.pictureBoxBattlefield.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBattlefield.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBattlefield.Image = global::WorldOfTank.Properties.Resources.Font_Battlefield;
            this.pictureBoxBattlefield.Location = new System.Drawing.Point(210, 350);
            this.pictureBoxBattlefield.Name = "pictureBoxBattlefield";
            this.pictureBoxBattlefield.Size = new System.Drawing.Size(200, 40);
            this.pictureBoxBattlefield.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBattlefield.TabIndex = 3;
            this.pictureBoxBattlefield.TabStop = false;
            this.pictureBoxBattlefield.Click += new System.EventHandler(this.pictureBoxBattlefield_Click);
            this.pictureBoxBattlefield.MouseEnter += new System.EventHandler(this.pictureBoxBattlefield_MouseEnter);
            this.pictureBoxBattlefield.MouseLeave += new System.EventHandler(this.pictureBoxBattlefield_MouseLeave);
            // 
            // pictureBoxTankCreator
            // 
            this.pictureBoxTankCreator.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTankCreator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTankCreator.Image = global::WorldOfTank.Properties.Resources.Font_TankCreator;
            this.pictureBoxTankCreator.Location = new System.Drawing.Point(190, 400);
            this.pictureBoxTankCreator.Name = "pictureBoxTankCreator";
            this.pictureBoxTankCreator.Size = new System.Drawing.Size(240, 40);
            this.pictureBoxTankCreator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTankCreator.TabIndex = 2;
            this.pictureBoxTankCreator.TabStop = false;
            this.pictureBoxTankCreator.Click += new System.EventHandler(this.pictureBoxTankCreator_Click);
            this.pictureBoxTankCreator.MouseEnter += new System.EventHandler(this.pictureBoxTankCreator_MouseEnter);
            this.pictureBoxTankCreator.MouseLeave += new System.EventHandler(this.pictureBoxTankCreator_MouseLeave);
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExit.Image = global::WorldOfTank.Properties.Resources.Font_Exit;
            this.pictureBoxExit.Location = new System.Drawing.Point(270, 450);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(80, 40);
            this.pictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExit.TabIndex = 0;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.pictureBoxExit_Click);
            this.pictureBoxExit.MouseEnter += new System.EventHandler(this.pictureBoxExit_MouseEnter);
            this.pictureBoxExit.MouseLeave += new System.EventHandler(this.pictureBoxExit_MouseLeave);
            // 
            // WorldOfTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WorldOfTank.Properties.Resources.MainBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxBattlefield);
            this.Controls.Add(this.pictureBoxTankCreator);
            this.Controls.Add(this.pictureBoxExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WorldOfTank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorldOfTank";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattlefield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTankCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxTankCreator;
        private System.Windows.Forms.PictureBox pictureBoxBattlefield;
    }
}