namespace WorldOfTank.GUI
{
    partial class TankCreatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TankCreatorForm));
            this.panelControl = new System.Windows.Forms.Panel();
            this.groupBoxInformation = new System.Windows.Forms.GroupBox();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.panelView = new System.Windows.Forms.Panel();
            this.panelAction = new System.Windows.Forms.Panel();
            this.listViewInstruction = new System.Windows.Forms.ListView();
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCondition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripActionControl = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMoveUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelName = new System.Windows.Forms.ToolStripLabel();
            this.panelTank = new System.Windows.Forms.Panel();
            this.buttonActionBeAttacked = new System.Windows.Forms.Button();
            this.buttonActionDetected = new System.Windows.Forms.Button();
            this.buttonActionCannotMoveBackward = new System.Windows.Forms.Button();
            this.buttonActionCannotMoveForward = new System.Windows.Forms.Button();
            this.buttonActionNormal = new System.Windows.Forms.Button();
            this.richTextBoxTankInfor = new System.Windows.Forms.RichTextBox();
            this.pictureBoxTank = new System.Windows.Forms.PictureBox();
            this.panelControl.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.panelView.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.toolStripActionControl.SuspendLayout();
            this.panelTank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTank)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelControl.Controls.Add(this.groupBoxInformation);
            this.panelControl.Controls.Add(this.groupBoxControl);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl.Location = new System.Drawing.Point(600, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(200, 600);
            this.panelControl.TabIndex = 0;
            // 
            // groupBoxInformation
            // 
            this.groupBoxInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInformation.Location = new System.Drawing.Point(0, 150);
            this.groupBoxInformation.Name = "groupBoxInformation";
            this.groupBoxInformation.Size = new System.Drawing.Size(200, 450);
            this.groupBoxInformation.TabIndex = 5;
            this.groupBoxInformation.TabStop = false;
            this.groupBoxInformation.Text = "Information";
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.buttonSave);
            this.groupBoxControl.Controls.Add(this.buttonExit);
            this.groupBoxControl.Controls.Add(this.buttonNew);
            this.groupBoxControl.Controls.Add(this.buttonOpen);
            this.groupBoxControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxControl.Location = new System.Drawing.Point(0, 0);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(200, 150);
            this.groupBoxControl.TabIndex = 4;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Control";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(64, 80);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(64, 109);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(64, 22);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 0;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(64, 51);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // panelView
            // 
            this.panelView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelView.BackgroundImage = global::WorldOfTank.Properties.Resources.MainBackground;
            this.panelView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Controls.Add(this.panelAction);
            this.panelView.Controls.Add(this.panelTank);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 0);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(600, 600);
            this.panelView.TabIndex = 1;
            // 
            // panelAction
            // 
            this.panelAction.BackColor = System.Drawing.SystemColors.Control;
            this.panelAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAction.Controls.Add(this.listViewInstruction);
            this.panelAction.Controls.Add(this.toolStripActionControl);
            this.panelAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAction.Location = new System.Drawing.Point(0, 149);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(598, 449);
            this.panelAction.TabIndex = 1;
            this.panelAction.Visible = false;
            // 
            // listViewInstruction
            // 
            this.listViewInstruction.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listViewInstruction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderType,
            this.columnHeaderValue,
            this.columnHeaderCondition});
            this.listViewInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInstruction.FullRowSelect = true;
            this.listViewInstruction.GridLines = true;
            this.listViewInstruction.Location = new System.Drawing.Point(0, 47);
            this.listViewInstruction.MultiSelect = false;
            this.listViewInstruction.Name = "listViewInstruction";
            this.listViewInstruction.ShowItemToolTips = true;
            this.listViewInstruction.Size = new System.Drawing.Size(596, 400);
            this.listViewInstruction.TabIndex = 1;
            this.listViewInstruction.UseCompatibleStateImageBehavior = false;
            this.listViewInstruction.View = System.Windows.Forms.View.Details;
            this.listViewInstruction.ItemActivate += new System.EventHandler(this.listViewInstruction_ItemActivate);
            this.listViewInstruction.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewInstruction_ItemSelectionChanged);
            this.listViewInstruction.Leave += new System.EventHandler(this.listViewInstruction_Leave);
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "TypeInstruction";
            this.columnHeaderType.Width = 100;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 50;
            // 
            // columnHeaderCondition
            // 
            this.columnHeaderCondition.Text = "Condition";
            this.columnHeaderCondition.Width = 450;
            // 
            // toolStripActionControl
            // 
            this.toolStripActionControl.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStripActionControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripActionControl.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStripActionControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDelete,
            this.toolStripButtonMoveUp,
            this.toolStripButtonMoveDown,
            this.toolStripButtonEdit,
            this.toolStripSeparator1,
            this.toolStripLabelName});
            this.toolStripActionControl.Location = new System.Drawing.Point(0, 0);
            this.toolStripActionControl.Name = "toolStripActionControl";
            this.toolStripActionControl.Size = new System.Drawing.Size(596, 47);
            this.toolStripActionControl.TabIndex = 0;
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::WorldOfTank.Properties.Resources.Add;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(44, 44);
            this.toolStripButtonAdd.Text = "Add Instruction";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = global::WorldOfTank.Properties.Resources.Delete;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(44, 44);
            this.toolStripButtonDelete.Text = "Delete Instruction";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripButtonMoveUp
            // 
            this.toolStripButtonMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMoveUp.Image = global::WorldOfTank.Properties.Resources.MoveUp;
            this.toolStripButtonMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveUp.Name = "toolStripButtonMoveUp";
            this.toolStripButtonMoveUp.Size = new System.Drawing.Size(44, 44);
            this.toolStripButtonMoveUp.Text = "Move Up";
            this.toolStripButtonMoveUp.Click += new System.EventHandler(this.toolStripButtonMoveUp_Click);
            // 
            // toolStripButtonMoveDown
            // 
            this.toolStripButtonMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMoveDown.Image = global::WorldOfTank.Properties.Resources.MoveDown;
            this.toolStripButtonMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveDown.Name = "toolStripButtonMoveDown";
            this.toolStripButtonMoveDown.Size = new System.Drawing.Size(44, 44);
            this.toolStripButtonMoveDown.Text = "Move Down";
            this.toolStripButtonMoveDown.Click += new System.EventHandler(this.toolStripButtonMoveDown_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEdit.Image = global::WorldOfTank.Properties.Resources.Edit;
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(44, 44);
            this.toolStripButtonEdit.Text = "Edit Instruction";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripLabelName
            // 
            this.toolStripLabelName.Name = "toolStripLabelName";
            this.toolStripLabelName.Size = new System.Drawing.Size(56, 44);
            this.toolStripLabelName.Text = "<action>";
            // 
            // panelTank
            // 
            this.panelTank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTank.Controls.Add(this.buttonActionBeAttacked);
            this.panelTank.Controls.Add(this.buttonActionDetected);
            this.panelTank.Controls.Add(this.buttonActionCannotMoveBackward);
            this.panelTank.Controls.Add(this.buttonActionCannotMoveForward);
            this.panelTank.Controls.Add(this.buttonActionNormal);
            this.panelTank.Controls.Add(this.richTextBoxTankInfor);
            this.panelTank.Controls.Add(this.pictureBoxTank);
            this.panelTank.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTank.Location = new System.Drawing.Point(0, 0);
            this.panelTank.Name = "panelTank";
            this.panelTank.Size = new System.Drawing.Size(598, 149);
            this.panelTank.TabIndex = 0;
            this.panelTank.Visible = false;
            // 
            // buttonActionBeAttacked
            // 
            this.buttonActionBeAttacked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonActionBeAttacked.Location = new System.Drawing.Point(350, 116);
            this.buttonActionBeAttacked.Name = "buttonActionBeAttacked";
            this.buttonActionBeAttacked.Size = new System.Drawing.Size(246, 31);
            this.buttonActionBeAttacked.TabIndex = 7;
            this.buttonActionBeAttacked.Text = "ActionBeAttacked";
            this.buttonActionBeAttacked.UseVisualStyleBackColor = true;
            this.buttonActionBeAttacked.Click += new System.EventHandler(this.buttonActionBeAttacked_Click);
            // 
            // buttonActionDetected
            // 
            this.buttonActionDetected.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonActionDetected.Location = new System.Drawing.Point(350, 87);
            this.buttonActionDetected.Name = "buttonActionDetected";
            this.buttonActionDetected.Size = new System.Drawing.Size(246, 29);
            this.buttonActionDetected.TabIndex = 6;
            this.buttonActionDetected.Text = "ActionDetected";
            this.buttonActionDetected.UseVisualStyleBackColor = true;
            this.buttonActionDetected.Click += new System.EventHandler(this.buttonActionDetected_Click);
            // 
            // buttonActionCannotMoveBackward
            // 
            this.buttonActionCannotMoveBackward.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonActionCannotMoveBackward.Location = new System.Drawing.Point(350, 58);
            this.buttonActionCannotMoveBackward.Name = "buttonActionCannotMoveBackward";
            this.buttonActionCannotMoveBackward.Size = new System.Drawing.Size(246, 29);
            this.buttonActionCannotMoveBackward.TabIndex = 5;
            this.buttonActionCannotMoveBackward.Text = "ActionCannotMoveBackward";
            this.buttonActionCannotMoveBackward.UseVisualStyleBackColor = true;
            this.buttonActionCannotMoveBackward.Click += new System.EventHandler(this.buttonActionCannotMoveBackward_Click);
            // 
            // buttonActionCannotMoveForward
            // 
            this.buttonActionCannotMoveForward.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonActionCannotMoveForward.Location = new System.Drawing.Point(350, 29);
            this.buttonActionCannotMoveForward.Name = "buttonActionCannotMoveForward";
            this.buttonActionCannotMoveForward.Size = new System.Drawing.Size(246, 29);
            this.buttonActionCannotMoveForward.TabIndex = 4;
            this.buttonActionCannotMoveForward.Text = "ActionCannotMoveForward";
            this.buttonActionCannotMoveForward.UseVisualStyleBackColor = true;
            this.buttonActionCannotMoveForward.Click += new System.EventHandler(this.buttonActionCannotMoveForward_Click);
            // 
            // buttonActionNormal
            // 
            this.buttonActionNormal.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonActionNormal.Location = new System.Drawing.Point(350, 0);
            this.buttonActionNormal.Name = "buttonActionNormal";
            this.buttonActionNormal.Size = new System.Drawing.Size(246, 29);
            this.buttonActionNormal.TabIndex = 3;
            this.buttonActionNormal.Text = "ActionNormal";
            this.buttonActionNormal.UseVisualStyleBackColor = true;
            this.buttonActionNormal.Click += new System.EventHandler(this.buttonActionNormal_Click);
            // 
            // richTextBoxTankInfor
            // 
            this.richTextBoxTankInfor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.richTextBoxTankInfor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxTankInfor.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBoxTankInfor.Location = new System.Drawing.Point(100, 0);
            this.richTextBoxTankInfor.Name = "richTextBoxTankInfor";
            this.richTextBoxTankInfor.ReadOnly = true;
            this.richTextBoxTankInfor.Size = new System.Drawing.Size(250, 147);
            this.richTextBoxTankInfor.TabIndex = 1;
            this.richTextBoxTankInfor.Text = "";
            // 
            // pictureBoxTank
            // 
            this.pictureBoxTank.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxTank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTank.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxTank.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTank.Name = "pictureBoxTank";
            this.pictureBoxTank.Size = new System.Drawing.Size(100, 147);
            this.pictureBoxTank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxTank.TabIndex = 0;
            this.pictureBoxTank.TabStop = false;
            this.pictureBoxTank.Click += new System.EventHandler(this.pictureBoxTank_Click);
            // 
            // TankCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TankCreatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TankCreator";
            this.panelControl.ResumeLayout(false);
            this.groupBoxControl.ResumeLayout(false);
            this.panelView.ResumeLayout(false);
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.toolStripActionControl.ResumeLayout(false);
            this.toolStripActionControl.PerformLayout();
            this.panelTank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.GroupBox groupBoxInformation;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.Panel panelTank;
        private System.Windows.Forms.RichTextBox richTextBoxTankInfor;
        private System.Windows.Forms.PictureBox pictureBoxTank;
        private System.Windows.Forms.Button buttonActionBeAttacked;
        private System.Windows.Forms.Button buttonActionDetected;
        private System.Windows.Forms.Button buttonActionCannotMoveBackward;
        private System.Windows.Forms.Button buttonActionCannotMoveForward;
        private System.Windows.Forms.Button buttonActionNormal;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.ToolStrip toolStripActionControl;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveUp;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelName;
        private System.Windows.Forms.ListView listViewInstruction;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.ColumnHeader columnHeaderCondition;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
    }
}