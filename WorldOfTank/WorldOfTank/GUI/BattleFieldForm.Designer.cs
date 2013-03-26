namespace WorldOfTank.GUI
{
    partial class BattleFieldForm
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
            this.panelControl = new System.Windows.Forms.Panel();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelView = new System.Windows.Forms.Panel();
            this.timerControl = new System.Windows.Forms.Timer(this.components);
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelControl.Controls.Add(this.buttonPause);
            this.panelControl.Controls.Add(this.buttonStart);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl.Location = new System.Drawing.Point(600, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(200, 600);
            this.panelControl.TabIndex = 0;
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(64, 54);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 1;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(64, 25);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelView
            // 
            this.panelView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 0);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(600, 600);
            this.panelView.TabIndex = 1;
            // 
            // timerControl
            // 
            this.timerControl.Interval = 25;
            this.timerControl.Tick += new System.EventHandler(this.timerControl_Tick);
            // 
            // BattleFieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelControl);
            this.Name = "BattleFieldForm";
            this.Text = "BattleField";
            this.Load += new System.EventHandler(this.BattleFieldForm_Load);
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timerControl;
        private System.Windows.Forms.Button buttonPause;
    }
}