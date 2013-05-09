namespace WorldOfTank.GUI
{
    partial class SetupGame
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
            this.buttonAddTank0 = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            this.buttonAddTank3 = new System.Windows.Forms.Button();
            this.buttonAddTank5 = new System.Windows.Forms.Button();
            this.buttonAddTank1 = new System.Windows.Forms.Button();
            this.buttonAddTank2 = new System.Windows.Forms.Button();
            this.buttonAddTank4 = new System.Windows.Forms.Button();
            this.buttonAddTank7 = new System.Windows.Forms.Button();
            this.buttonAddTank6 = new System.Windows.Forms.Button();
            this.labelSize = new System.Windows.Forms.Label();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.labelBackground = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddTank0
            // 
            this.buttonAddTank0.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddTank0.Location = new System.Drawing.Point(12, 216);
            this.buttonAddTank0.Name = "buttonAddTank0";
            this.buttonAddTank0.Size = new System.Drawing.Size(100, 70);
            this.buttonAddTank0.TabIndex = 0;
            this.buttonAddTank0.Text = "Add a tank";
            this.buttonAddTank0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAddTank0.UseVisualStyleBackColor = false;
            this.buttonAddTank0.Click += new System.EventHandler(this.buttonAddTank0_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 377);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(212, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(236, 377);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(212, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(15, 76);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(97, 13);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "Time for a game (s)";
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Location = new System.Drawing.Point(124, 74);
            this.numericUpDownTime.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTime.Name = "numericUpDownTime";
            this.numericUpDownTime.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownTime.TabIndex = 7;
            this.numericUpDownTime.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // buttonAddTank3
            // 
            this.buttonAddTank3.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddTank3.Location = new System.Drawing.Point(348, 216);
            this.buttonAddTank3.Name = "buttonAddTank3";
            this.buttonAddTank3.Size = new System.Drawing.Size(100, 70);
            this.buttonAddTank3.TabIndex = 8;
            this.buttonAddTank3.Text = "Add a tank";
            this.buttonAddTank3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAddTank3.UseVisualStyleBackColor = false;
            this.buttonAddTank3.Click += new System.EventHandler(this.buttonAddTank3_Click);
            // 
            // buttonAddTank5
            // 
            this.buttonAddTank5.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddTank5.Location = new System.Drawing.Point(124, 292);
            this.buttonAddTank5.Name = "buttonAddTank5";
            this.buttonAddTank5.Size = new System.Drawing.Size(100, 70);
            this.buttonAddTank5.TabIndex = 9;
            this.buttonAddTank5.Text = "Add a tank";
            this.buttonAddTank5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAddTank5.UseVisualStyleBackColor = false;
            this.buttonAddTank5.Click += new System.EventHandler(this.buttonAddTank5_Click);
            // 
            // buttonAddTank1
            // 
            this.buttonAddTank1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddTank1.Location = new System.Drawing.Point(124, 216);
            this.buttonAddTank1.Name = "buttonAddTank1";
            this.buttonAddTank1.Size = new System.Drawing.Size(100, 70);
            this.buttonAddTank1.TabIndex = 10;
            this.buttonAddTank1.Text = "Add a tank";
            this.buttonAddTank1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAddTank1.UseVisualStyleBackColor = false;
            this.buttonAddTank1.Click += new System.EventHandler(this.buttonAddTank1_Click);
            // 
            // buttonAddTank2
            // 
            this.buttonAddTank2.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddTank2.Location = new System.Drawing.Point(236, 216);
            this.buttonAddTank2.Name = "buttonAddTank2";
            this.buttonAddTank2.Size = new System.Drawing.Size(100, 70);
            this.buttonAddTank2.TabIndex = 11;
            this.buttonAddTank2.Text = "Add a tank";
            this.buttonAddTank2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAddTank2.UseVisualStyleBackColor = false;
            this.buttonAddTank2.Click += new System.EventHandler(this.buttonAddTank2_Click);
            // 
            // buttonAddTank4
            // 
            this.buttonAddTank4.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddTank4.Location = new System.Drawing.Point(12, 292);
            this.buttonAddTank4.Name = "buttonAddTank4";
            this.buttonAddTank4.Size = new System.Drawing.Size(100, 70);
            this.buttonAddTank4.TabIndex = 12;
            this.buttonAddTank4.Text = "Add a tank";
            this.buttonAddTank4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAddTank4.UseVisualStyleBackColor = false;
            this.buttonAddTank4.Click += new System.EventHandler(this.buttonAddTank4_Click);
            // 
            // buttonAddTank7
            // 
            this.buttonAddTank7.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddTank7.Location = new System.Drawing.Point(348, 292);
            this.buttonAddTank7.Name = "buttonAddTank7";
            this.buttonAddTank7.Size = new System.Drawing.Size(100, 70);
            this.buttonAddTank7.TabIndex = 13;
            this.buttonAddTank7.Text = "Add a tank";
            this.buttonAddTank7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAddTank7.UseVisualStyleBackColor = false;
            this.buttonAddTank7.Click += new System.EventHandler(this.buttonAddTank7_Click);
            // 
            // buttonAddTank6
            // 
            this.buttonAddTank6.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddTank6.Location = new System.Drawing.Point(236, 292);
            this.buttonAddTank6.Name = "buttonAddTank6";
            this.buttonAddTank6.Size = new System.Drawing.Size(100, 70);
            this.buttonAddTank6.TabIndex = 14;
            this.buttonAddTank6.Text = "Add a tank";
            this.buttonAddTank6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAddTank6.UseVisualStyleBackColor = false;
            this.buttonAddTank6.Click += new System.EventHandler(this.buttonAddTank6_Click);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(15, 103);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(87, 13);
            this.labelSize.TabIndex = 15;
            this.labelSize.Text = "Size of battlefield";
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Items.AddRange(new object[] {
            "600 x 600",
            "800 x 600",
            "1000 x 600"});
            this.comboBoxSize.Location = new System.Drawing.Point(124, 100);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(100, 21);
            this.comboBoxSize.TabIndex = 16;
            this.comboBoxSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxSize_SelectedIndexChanged);
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBackground.Location = new System.Drawing.Point(236, 25);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(212, 153);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackground.TabIndex = 18;
            this.pictureBoxBackground.TabStop = false;
            // 
            // labelBackground
            // 
            this.labelBackground.AutoSize = true;
            this.labelBackground.Location = new System.Drawing.Point(233, 9);
            this.labelBackground.Name = "labelBackground";
            this.labelBackground.Size = new System.Drawing.Size(65, 13);
            this.labelBackground.TabIndex = 19;
            this.labelBackground.Text = "Background";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(236, 184);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(100, 23);
            this.buttonBack.TabIndex = 20;
            this.buttonBack.Text = "<< Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(348, 184);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(100, 23);
            this.buttonNext.TabIndex = 21;
            this.buttonNext.Text = "Next >>";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // SetupGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 412);
            this.ControlBox = false;
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelBackground);
            this.Controls.Add(this.pictureBoxBackground);
            this.Controls.Add(this.comboBoxSize);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.buttonAddTank6);
            this.Controls.Add(this.buttonAddTank7);
            this.Controls.Add(this.buttonAddTank4);
            this.Controls.Add(this.buttonAddTank2);
            this.Controls.Add(this.buttonAddTank1);
            this.Controls.Add(this.buttonAddTank5);
            this.Controls.Add(this.buttonAddTank3);
            this.Controls.Add(this.numericUpDownTime);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonAddTank0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SetupGame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SetupGame";
            this.Load += new System.EventHandler(this.SetupGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddTank0;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;
        private System.Windows.Forms.Button buttonAddTank3;
        private System.Windows.Forms.Button buttonAddTank5;
        private System.Windows.Forms.Button buttonAddTank1;
        private System.Windows.Forms.Button buttonAddTank2;
        private System.Windows.Forms.Button buttonAddTank4;
        private System.Windows.Forms.Button buttonAddTank7;
        private System.Windows.Forms.Button buttonAddTank6;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.Label labelBackground;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonNext;

    }
}