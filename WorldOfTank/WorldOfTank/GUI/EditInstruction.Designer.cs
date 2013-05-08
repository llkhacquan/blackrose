namespace WorldOfTank.GUI
{
    partial class EditInstruction
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
            this.labelTypeInstruction = new System.Windows.Forms.Label();
            this.comboBoxTypeInstruction = new System.Windows.Forms.ComboBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.numericUpDownValue = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelCondition = new System.Windows.Forms.Label();
            this.treeViewCondition = new System.Windows.Forms.TreeView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelTypeCondition = new System.Windows.Forms.Label();
            this.comboBoxTypeCondition = new System.Windows.Forms.ComboBox();
            this.labelParameter = new System.Windows.Forms.Label();
            this.labelOperator = new System.Windows.Forms.Label();
            this.labelValue2 = new System.Windows.Forms.Label();
            this.comboBoxParameter = new System.Windows.Forms.ComboBox();
            this.comboBoxOperator = new System.Windows.Forms.ComboBox();
            this.numericUpDownValue2 = new System.Windows.Forms.NumericUpDown();
            this.buttonCondition = new System.Windows.Forms.Button();
            this.labelInterruptible = new System.Windows.Forms.Label();
            this.checkBoxInterruptible = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTypeInstruction
            // 
            this.labelTypeInstruction.AutoSize = true;
            this.labelTypeInstruction.Location = new System.Drawing.Point(12, 9);
            this.labelTypeInstruction.Name = "labelTypeInstruction";
            this.labelTypeInstruction.Size = new System.Drawing.Size(83, 13);
            this.labelTypeInstruction.TabIndex = 0;
            this.labelTypeInstruction.Text = "Type Instruction";
            // 
            // comboBoxTypeInstruction
            // 
            this.comboBoxTypeInstruction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeInstruction.FormattingEnabled = true;
            this.comboBoxTypeInstruction.Items.AddRange(new object[] {
            "RotateLeft",
            "RotateRight",
            "MoveForward",
            "MoveBackward",
            "Fire"});
            this.comboBoxTypeInstruction.Location = new System.Drawing.Point(101, 6);
            this.comboBoxTypeInstruction.Name = "comboBoxTypeInstruction";
            this.comboBoxTypeInstruction.Size = new System.Drawing.Size(174, 21);
            this.comboBoxTypeInstruction.TabIndex = 1;
            this.comboBoxTypeInstruction.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeInstruction_SelectedIndexChanged);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(12, 35);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(34, 13);
            this.labelValue.TabIndex = 2;
            this.labelValue.Text = "Value";
            // 
            // numericUpDownValue
            // 
            this.numericUpDownValue.Location = new System.Drawing.Point(101, 33);
            this.numericUpDownValue.Name = "numericUpDownValue";
            this.numericUpDownValue.Size = new System.Drawing.Size(174, 20);
            this.numericUpDownValue.TabIndex = 3;
            this.numericUpDownValue.ValueChanged += new System.EventHandler(this.numericUpDownValue_ValueChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(70, 375);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(150, 25);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelCondition
            // 
            this.labelCondition.AutoSize = true;
            this.labelCondition.Location = new System.Drawing.Point(12, 84);
            this.labelCondition.Name = "labelCondition";
            this.labelCondition.Size = new System.Drawing.Size(51, 13);
            this.labelCondition.TabIndex = 6;
            this.labelCondition.Text = "Condition";
            // 
            // treeViewCondition
            // 
            this.treeViewCondition.Location = new System.Drawing.Point(15, 108);
            this.treeViewCondition.Name = "treeViewCondition";
            this.treeViewCondition.Size = new System.Drawing.Size(260, 138);
            this.treeViewCondition.TabIndex = 7;
            this.treeViewCondition.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewCondition_NodeMouseClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(15, 252);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(125, 23);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(150, 252);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(125, 23);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelTypeCondition
            // 
            this.labelTypeCondition.AutoSize = true;
            this.labelTypeCondition.Location = new System.Drawing.Point(12, 284);
            this.labelTypeCondition.Name = "labelTypeCondition";
            this.labelTypeCondition.Size = new System.Drawing.Size(78, 13);
            this.labelTypeCondition.TabIndex = 10;
            this.labelTypeCondition.Text = "Type Condition";
            // 
            // comboBoxTypeCondition
            // 
            this.comboBoxTypeCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeCondition.FormattingEnabled = true;
            this.comboBoxTypeCondition.Items.AddRange(new object[] {
            "Unique",
            "And",
            "Or"});
            this.comboBoxTypeCondition.Location = new System.Drawing.Point(101, 281);
            this.comboBoxTypeCondition.Name = "comboBoxTypeCondition";
            this.comboBoxTypeCondition.Size = new System.Drawing.Size(174, 21);
            this.comboBoxTypeCondition.TabIndex = 11;
            this.comboBoxTypeCondition.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeCondition_SelectedIndexChanged);
            // 
            // labelParameter
            // 
            this.labelParameter.AutoSize = true;
            this.labelParameter.Location = new System.Drawing.Point(12, 315);
            this.labelParameter.Name = "labelParameter";
            this.labelParameter.Size = new System.Drawing.Size(55, 13);
            this.labelParameter.TabIndex = 12;
            this.labelParameter.Text = "Parameter";
            // 
            // labelOperator
            // 
            this.labelOperator.AutoSize = true;
            this.labelOperator.Location = new System.Drawing.Point(147, 315);
            this.labelOperator.Name = "labelOperator";
            this.labelOperator.Size = new System.Drawing.Size(48, 13);
            this.labelOperator.TabIndex = 13;
            this.labelOperator.Text = "Operator";
            // 
            // labelValue2
            // 
            this.labelValue2.AutoSize = true;
            this.labelValue2.Location = new System.Drawing.Point(241, 315);
            this.labelValue2.Name = "labelValue2";
            this.labelValue2.Size = new System.Drawing.Size(34, 13);
            this.labelValue2.TabIndex = 14;
            this.labelValue2.Text = "Value";
            // 
            // comboBoxParameter
            // 
            this.comboBoxParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParameter.FormattingEnabled = true;
            this.comboBoxParameter.Items.AddRange(new object[] {
            "GetTimeRemaining",
            "GetNumberTank",
            "GetPositionX",
            "GetPositionY",
            "GetDirection",
            "GetCurrentHeal"});
            this.comboBoxParameter.Location = new System.Drawing.Point(15, 333);
            this.comboBoxParameter.Name = "comboBoxParameter";
            this.comboBoxParameter.Size = new System.Drawing.Size(129, 21);
            this.comboBoxParameter.TabIndex = 15;
            this.comboBoxParameter.SelectedIndexChanged += new System.EventHandler(this.comboBoxParameter_SelectedIndexChanged);
            // 
            // comboBoxOperator
            // 
            this.comboBoxOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperator.FormattingEnabled = true;
            this.comboBoxOperator.Items.AddRange(new object[] {
            ">=",
            ">",
            "==",
            "<",
            "<=",
            "!="});
            this.comboBoxOperator.Location = new System.Drawing.Point(150, 333);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new System.Drawing.Size(48, 21);
            this.comboBoxOperator.TabIndex = 16;
            this.comboBoxOperator.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperator_SelectedIndexChanged);
            // 
            // numericUpDownValue2
            // 
            this.numericUpDownValue2.Location = new System.Drawing.Point(204, 334);
            this.numericUpDownValue2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownValue2.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownValue2.Name = "numericUpDownValue2";
            this.numericUpDownValue2.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownValue2.TabIndex = 17;
            this.numericUpDownValue2.ValueChanged += new System.EventHandler(this.numericUpDownValue2_ValueChanged);
            // 
            // buttonCondition
            // 
            this.buttonCondition.Location = new System.Drawing.Point(101, 79);
            this.buttonCondition.Name = "buttonCondition";
            this.buttonCondition.Size = new System.Drawing.Size(174, 23);
            this.buttonCondition.TabIndex = 18;
            this.buttonCondition.Text = "Create";
            this.buttonCondition.UseVisualStyleBackColor = true;
            this.buttonCondition.Click += new System.EventHandler(this.buttonCondition_Click);
            // 
            // labelInterruptible
            // 
            this.labelInterruptible.AutoSize = true;
            this.labelInterruptible.Location = new System.Drawing.Point(12, 60);
            this.labelInterruptible.Name = "labelInterruptible";
            this.labelInterruptible.Size = new System.Drawing.Size(62, 13);
            this.labelInterruptible.TabIndex = 19;
            this.labelInterruptible.Text = "Interruptible";
            // 
            // checkBoxInterruptible
            // 
            this.checkBoxInterruptible.AutoSize = true;
            this.checkBoxInterruptible.Location = new System.Drawing.Point(101, 59);
            this.checkBoxInterruptible.Name = "checkBoxInterruptible";
            this.checkBoxInterruptible.Size = new System.Drawing.Size(15, 14);
            this.checkBoxInterruptible.TabIndex = 20;
            this.checkBoxInterruptible.UseVisualStyleBackColor = true;
            this.checkBoxInterruptible.CheckedChanged += new System.EventHandler(this.checkBoxInterruptible_CheckedChanged);
            // 
            // EditInstruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 412);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxInterruptible);
            this.Controls.Add(this.labelInterruptible);
            this.Controls.Add(this.buttonCondition);
            this.Controls.Add(this.numericUpDownValue2);
            this.Controls.Add(this.comboBoxOperator);
            this.Controls.Add(this.comboBoxParameter);
            this.Controls.Add(this.labelValue2);
            this.Controls.Add(this.labelOperator);
            this.Controls.Add(this.labelParameter);
            this.Controls.Add(this.comboBoxTypeCondition);
            this.Controls.Add(this.labelTypeCondition);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.treeViewCondition);
            this.Controls.Add(this.labelCondition);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.numericUpDownValue);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.comboBoxTypeInstruction);
            this.Controls.Add(this.labelTypeInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditInstruction";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditInstruction";
            this.Load += new System.EventHandler(this.EditInstruction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTypeInstruction;
        private System.Windows.Forms.ComboBox comboBoxTypeInstruction;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.NumericUpDown numericUpDownValue;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelCondition;
        private System.Windows.Forms.TreeView treeViewCondition;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelTypeCondition;
        private System.Windows.Forms.ComboBox comboBoxTypeCondition;
        private System.Windows.Forms.Label labelParameter;
        private System.Windows.Forms.Label labelOperator;
        private System.Windows.Forms.Label labelValue2;
        private System.Windows.Forms.ComboBox comboBoxParameter;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private System.Windows.Forms.NumericUpDown numericUpDownValue2;
        private System.Windows.Forms.Button buttonCondition;
        private System.Windows.Forms.Label labelInterruptible;
        private System.Windows.Forms.CheckBox checkBoxInterruptible;
    }
}