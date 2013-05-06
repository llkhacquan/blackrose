namespace WorldOfTank.GUI
{
    partial class ChooseTank
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
            this.richTextBoxInfor = new System.Windows.Forms.RichTextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBoxRedTank = new System.Windows.Forms.PictureBox();
            this.pictureBoxYellowTank = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlueTank = new System.Windows.Forms.PictureBox();
            this.pictureBoxGreenTank = new System.Windows.Forms.PictureBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYellowTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlueTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenTank)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxInfor
            // 
            this.richTextBoxInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxInfor.Location = new System.Drawing.Point(12, 78);
            this.richTextBoxInfor.Name = "richTextBoxInfor";
            this.richTextBoxInfor.ReadOnly = true;
            this.richTextBoxInfor.Size = new System.Drawing.Size(258, 143);
            this.richTextBoxInfor.TabIndex = 6;
            this.richTextBoxInfor.Text = "Please choose a tank";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 227);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(126, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // pictureBoxRedTank
            // 
            this.pictureBoxRedTank.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRedTank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRedTank.Image = global::WorldOfTank.Properties.Resources.Tank_D;
            this.pictureBoxRedTank.Location = new System.Drawing.Point(210, 12);
            this.pictureBoxRedTank.Name = "pictureBoxRedTank";
            this.pictureBoxRedTank.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxRedTank.TabIndex = 3;
            this.pictureBoxRedTank.TabStop = false;
            this.pictureBoxRedTank.Click += new System.EventHandler(this.pictureBoxRedTank_Click);
            this.pictureBoxRedTank.MouseEnter += new System.EventHandler(this.pictureBoxRedTank_MouseEnter);
            this.pictureBoxRedTank.MouseLeave += new System.EventHandler(this.pictureBoxRedTank_MouseLeave);
            // 
            // pictureBoxYellowTank
            // 
            this.pictureBoxYellowTank.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxYellowTank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxYellowTank.Image = global::WorldOfTank.Properties.Resources.Tank_C;
            this.pictureBoxYellowTank.Location = new System.Drawing.Point(144, 12);
            this.pictureBoxYellowTank.Name = "pictureBoxYellowTank";
            this.pictureBoxYellowTank.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxYellowTank.TabIndex = 2;
            this.pictureBoxYellowTank.TabStop = false;
            this.pictureBoxYellowTank.Click += new System.EventHandler(this.pictureBoxYellowTank_Click);
            this.pictureBoxYellowTank.MouseEnter += new System.EventHandler(this.pictureBoxYellowTank_MouseEnter);
            this.pictureBoxYellowTank.MouseLeave += new System.EventHandler(this.pictureBoxYellowTank_MouseLeave);
            // 
            // pictureBoxBlueTank
            // 
            this.pictureBoxBlueTank.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBlueTank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBlueTank.Image = global::WorldOfTank.Properties.Resources.Tank_B;
            this.pictureBoxBlueTank.Location = new System.Drawing.Point(78, 12);
            this.pictureBoxBlueTank.Name = "pictureBoxBlueTank";
            this.pictureBoxBlueTank.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxBlueTank.TabIndex = 1;
            this.pictureBoxBlueTank.TabStop = false;
            this.pictureBoxBlueTank.Click += new System.EventHandler(this.pictureBoxBlueTank_Click);
            this.pictureBoxBlueTank.MouseEnter += new System.EventHandler(this.pictureBoxBlueTank_MouseEnter);
            this.pictureBoxBlueTank.MouseLeave += new System.EventHandler(this.pictureBoxBlueTank_MouseLeave);
            // 
            // pictureBoxGreenTank
            // 
            this.pictureBoxGreenTank.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGreenTank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGreenTank.Image = global::WorldOfTank.Properties.Resources.Tank_A;
            this.pictureBoxGreenTank.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxGreenTank.Name = "pictureBoxGreenTank";
            this.pictureBoxGreenTank.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxGreenTank.TabIndex = 0;
            this.pictureBoxGreenTank.TabStop = false;
            this.pictureBoxGreenTank.Click += new System.EventHandler(this.pictureBoxGreenTank_Click);
            this.pictureBoxGreenTank.MouseEnter += new System.EventHandler(this.pictureBoxGreenTank_MouseEnter);
            this.pictureBoxGreenTank.MouseLeave += new System.EventHandler(this.pictureBoxGreenTank_MouseLeave);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(144, 227);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // ChooseTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.richTextBoxInfor);
            this.Controls.Add(this.pictureBoxRedTank);
            this.Controls.Add(this.pictureBoxYellowTank);
            this.Controls.Add(this.pictureBoxBlueTank);
            this.Controls.Add(this.pictureBoxGreenTank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChooseTank";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChooseTank";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYellowTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlueTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenTank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGreenTank;
        private System.Windows.Forms.PictureBox pictureBoxBlueTank;
        private System.Windows.Forms.PictureBox pictureBoxYellowTank;
        private System.Windows.Forms.PictureBox pictureBoxRedTank;
        private System.Windows.Forms.RichTextBox richTextBoxInfor;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}