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
            this.buttonAddTank1 = new System.Windows.Forms.Button();
            this.buttonAddTank2 = new System.Windows.Forms.Button();
            this.buttonAddTank3 = new System.Windows.Forms.Button();
            this.buttonAddTank4 = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddTank1
            // 
            this.buttonAddTank1.Location = new System.Drawing.Point(12, 12);
            this.buttonAddTank1.Name = "buttonAddTank1";
            this.buttonAddTank1.Size = new System.Drawing.Size(260, 23);
            this.buttonAddTank1.TabIndex = 0;
            this.buttonAddTank1.Text = "Click here to add a tank";
            this.buttonAddTank1.UseVisualStyleBackColor = true;
            this.buttonAddTank1.Click += new System.EventHandler(this.buttonAddTank1_Click);
            // 
            // buttonAddTank2
            // 
            this.buttonAddTank2.Location = new System.Drawing.Point(12, 41);
            this.buttonAddTank2.Name = "buttonAddTank2";
            this.buttonAddTank2.Size = new System.Drawing.Size(260, 23);
            this.buttonAddTank2.TabIndex = 1;
            this.buttonAddTank2.Text = "Click here to add a tank";
            this.buttonAddTank2.UseVisualStyleBackColor = true;
            this.buttonAddTank2.Click += new System.EventHandler(this.buttonAddTank2_Click);
            // 
            // buttonAddTank3
            // 
            this.buttonAddTank3.Location = new System.Drawing.Point(12, 70);
            this.buttonAddTank3.Name = "buttonAddTank3";
            this.buttonAddTank3.Size = new System.Drawing.Size(260, 23);
            this.buttonAddTank3.TabIndex = 2;
            this.buttonAddTank3.Text = "Click here to add a tank";
            this.buttonAddTank3.UseVisualStyleBackColor = true;
            this.buttonAddTank3.Click += new System.EventHandler(this.buttonAddTank3_Click);
            // 
            // buttonAddTank4
            // 
            this.buttonAddTank4.Location = new System.Drawing.Point(12, 99);
            this.buttonAddTank4.Name = "buttonAddTank4";
            this.buttonAddTank4.Size = new System.Drawing.Size(260, 23);
            this.buttonAddTank4.TabIndex = 3;
            this.buttonAddTank4.Text = "Click here to add a tank";
            this.buttonAddTank4.UseVisualStyleBackColor = true;
            this.buttonAddTank4.Click += new System.EventHandler(this.buttonAddTank4_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 177);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(125, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(147, 177);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(125, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(12, 141);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(140, 13);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "Maximum time for a game (s)";
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Location = new System.Drawing.Point(158, 139);
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
            this.numericUpDownTime.Size = new System.Drawing.Size(114, 20);
            this.numericUpDownTime.TabIndex = 7;
            this.numericUpDownTime.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // SetupGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 212);
            this.ControlBox = false;
            this.Controls.Add(this.numericUpDownTime);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonAddTank4);
            this.Controls.Add(this.buttonAddTank3);
            this.Controls.Add(this.buttonAddTank2);
            this.Controls.Add(this.buttonAddTank1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SetupGame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SetupGame";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddTank1;
        private System.Windows.Forms.Button buttonAddTank2;
        private System.Windows.Forms.Button buttonAddTank3;
        private System.Windows.Forms.Button buttonAddTank4;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;

    }
}