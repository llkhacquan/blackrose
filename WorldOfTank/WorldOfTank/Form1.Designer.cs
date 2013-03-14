namespace WorldOfTank
{
    partial class Form1
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelControl = new System.Windows.Forms.Panel();
            this.panelConsole = new System.Windows.Forms.Panel();
            this.timerControl = new System.Windows.Forms.Timer(this.components);
            this.imageTankDemo = new System.Windows.Forms.PictureBox();
            this.panelControl.SuspendLayout();
            this.panelConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTankDemo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(37, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControl.Controls.Add(this.buttonStart);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl.Location = new System.Drawing.Point(437, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(147, 361);
            this.panelControl.TabIndex = 1;
            // 
            // panelConsole
            // 
            this.panelConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConsole.Controls.Add(this.imageTankDemo);
            this.panelConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConsole.Location = new System.Drawing.Point(0, 0);
            this.panelConsole.Name = "panelConsole";
            this.panelConsole.Size = new System.Drawing.Size(437, 361);
            this.panelConsole.TabIndex = 2;
            // 
            // timerControl
            // 
            this.timerControl.Interval = 20;
            this.timerControl.Tick += new System.EventHandler(this.timerControl_Tick);
            // 
            // imageTankDemo
            // 
            this.imageTankDemo.Location = new System.Drawing.Point(20, 20);
            this.imageTankDemo.Name = "imageTankDemo";
            this.imageTankDemo.Size = new System.Drawing.Size(40, 40);
            this.imageTankDemo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageTankDemo.TabIndex = 0;
            this.imageTankDemo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panelConsole);
            this.Controls.Add(this.panelControl);
            this.Name = "Form1";
            this.Text = "Battle Field";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelControl.ResumeLayout(false);
            this.panelConsole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTankDemo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel panelConsole;
        private System.Windows.Forms.PictureBox imageTankDemo;
        private System.Windows.Forms.Timer timerControl;
    }
}

