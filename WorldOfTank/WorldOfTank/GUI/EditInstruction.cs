using System;
using System.Windows.Forms;
using WorldOfTank.Class.Components;
using WorldOfTank.Class.Model;

namespace WorldOfTank.GUI
{
    public partial class EditInstruction : Form
    {
        public Tank Tank;
        public string ActionName;
        public Instruction Instruction;
        public TreeNodePlus Node;

        public EditInstruction()
        {
            InitializeComponent();
        }

        public void ShowInstructionInformation()
        {
            var value = Instruction.Value;
            comboBoxTypeInstruction.Text = Instruction.Type.ToString();
            switch (Instruction.Type)
            {
                case TypeInstruction.RotateLeft:
                case TypeInstruction.RotateRight:
                    labelValue.Text = "Angle";
                    numericUpDownValue.Minimum = 1;
                    numericUpDownValue.Maximum = 1000;
                    break;
                case TypeInstruction.MoveForward:
                case TypeInstruction.MoveBackward:
                    labelValue.Text = "Distance";
                    numericUpDownValue.Minimum = 1;
                    numericUpDownValue.Maximum = 1000;
                    break;
                case TypeInstruction.Fire:
                    labelValue.Text = "Damage";
                    numericUpDownValue.Minimum = (decimal)Tank.DamageMin;
                    numericUpDownValue.Maximum = (decimal)Tank.DamageMax;
                    break;
            }
            numericUpDownValue.Value = value > (float)numericUpDownValue.Maximum ||
                                       value < (float)numericUpDownValue.Minimum
                                           ? numericUpDownValue.Minimum
                                           : (decimal)value;
            checkBoxInterruptible.Checked = Instruction.Interruptible;
        }

        public void ShowConditionInformation()
        {
            if (Instruction.Condition == null)
            {
                Node = null;
                buttonCondition.Text = "Create";
                treeViewCondition.Nodes.Clear();
            }
            else
            {
                buttonCondition.Text = "Remove";
                treeViewCondition.Nodes.Clear();
                treeViewCondition.Nodes.Add(Instruction.Condition.GetTreeNode());
                treeViewCondition.ExpandAll();
            }

            if (Node == null)
            {
                comboBoxTypeCondition.Enabled = false;
                comboBoxParameter.Enabled = false;
                comboBoxOperator.Enabled = false;
                numericUpDownValue2.Enabled = false;
                buttonAdd.Enabled = false;
                buttonDelete.Enabled = false;
            }
            else
            {
                var condition = Node.Condition;

                comboBoxTypeCondition.Enabled = true;
                comboBoxTypeCondition.Text = condition.Type.ToString();

                buttonAdd.Enabled = condition.Type != TypeCondition.Unique;
                buttonDelete.Enabled = true;

                if (condition.Type == TypeCondition.Unique)
                {
                    comboBoxParameter.Enabled = true;
                    comboBoxParameter.Text = condition.Comparision.Parameter.ToString();

                    comboBoxOperator.Enabled = true;
                    switch (condition.Comparision.Operator)
                    {
                        case TypeOperator.GreaterEqual:
                            comboBoxOperator.Text = ">=";
                            break;
                        case TypeOperator.Greater:
                            comboBoxOperator.Text = ">";
                            break;
                        case TypeOperator.Equal:
                            comboBoxOperator.Text = "==";
                            break;
                        case TypeOperator.Lower:
                            comboBoxOperator.Text = "<";
                            break;
                        case TypeOperator.LowerEqual:
                            comboBoxOperator.Text = "<=";
                            break;
                        case TypeOperator.NotEqual:
                            comboBoxOperator.Text = "!=";
                            break;
                    }

                    numericUpDownValue2.Enabled = true;
                    numericUpDownValue2.Value = (decimal)condition.Comparision.Value;
                }
                else
                {
                    comboBoxParameter.Enabled = false;
                    comboBoxOperator.Enabled = false;
                    numericUpDownValue2.Enabled = false;
                }
            }
        }

        private void comboBoxTypeInstruction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTypeInstruction.Text)
            {
                case "RotateLeft":
                    Instruction.Type = TypeInstruction.RotateLeft;
                    break;
                case "RotateRight":
                    Instruction.Type = TypeInstruction.RotateRight;
                    break;
                case "MoveForward":
                    Instruction.Type = TypeInstruction.MoveForward;
                    break;
                case "MoveBackward":
                    Instruction.Type = TypeInstruction.MoveBackward;
                    break;
                case "Fire":
                    Instruction.Type = TypeInstruction.Fire;
                    break;
                default:
                    break;
            }
            ShowInstructionInformation();
        }

        private void numericUpDownValue_ValueChanged(object sender, EventArgs e)
        {
            Instruction.Value = (float)numericUpDownValue.Value;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Node.Condition.Children.Add(new Condition());
            ShowConditionInformation();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var parent = Node.Parent != null ? ((TreeNodePlus)Node.Parent).Condition : null;
            if (parent != null)
            {
                parent.Children.Remove(Node.Condition);
                if (parent.Children.Count == 0)
                {
                    parent.Type = TypeCondition.Unique;
                    parent.Comparision = new Comparison();
                }
            }
            else
            {
                Instruction.Condition = null;
            }
            Node = null;
            ShowConditionInformation();
        }

        private void treeViewCondition_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Node = (TreeNodePlus)e.Node;
            ShowConditionInformation();
        }

        private void buttonCondition_Click(object sender, EventArgs e)
        {
            Instruction.Condition = buttonCondition.Text == "Create" ? new Condition() : null;
            ShowConditionInformation();
        }

        private void EditInstruction_Load(object sender, EventArgs e)
        {
            if (ActionName == "ActionDetected")
            {
                comboBoxParameter.Items.Add("GetEnemyDistance");
                comboBoxParameter.Items.Add("GetEnemyDifferentAngle");
                comboBoxParameter.Items.Add("GetEnemyCurrentHeal");
            }
            if (ActionName == "ActionBeAttacked")
            {
                comboBoxParameter.Items.Add("GetBulletDifferentAngle");
            }
        }

        private void comboBoxParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var condition = Node.Condition;
            switch (comboBoxParameter.Text)
            {
                case "GetPositionX":
                    condition.Comparision.Parameter = TypeParameter.GetPositionX;
                    break;
                case "GetPositionY":
                    condition.Comparision.Parameter = TypeParameter.GetPositionY;
                    break;
                case "GetDirection":
                    condition.Comparision.Parameter = TypeParameter.GetDirection;
                    break;
                case "GetCurrentHeal":
                    condition.Comparision.Parameter = TypeParameter.GetCurrentHeal;
                    break;
                case "GetEnemyCurrentHeal":
                    condition.Comparision.Parameter = TypeParameter.GetEnemyCurrentHeal;
                    break;
                case "GetEnemyDistance":
                    condition.Comparision.Parameter = TypeParameter.GetEnemyDistance;
                    break;
                case "GetEnemyDifferentAngle":
                    condition.Comparision.Parameter = TypeParameter.GetEnemyDifferentAngle;
                    break;
                case "GetBulletDifferentAngle":
                    condition.Comparision.Parameter = TypeParameter.GetBulletDifferentAngle;
                    break;
                default:
                    break;
            }
            ShowConditionInformation();
        }

        private void comboBoxOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            var condition = Node.Condition;
            switch (comboBoxOperator.Text)
            {
                case ">=":
                    condition.Comparision.Operator = TypeOperator.GreaterEqual;
                    break;
                case ">":
                    condition.Comparision.Operator = TypeOperator.Greater;
                    break;
                case "==":
                    condition.Comparision.Operator = TypeOperator.Equal;
                    break;
                case "<":
                    condition.Comparision.Operator = TypeOperator.Lower;
                    break;
                case "<=":
                    condition.Comparision.Operator = TypeOperator.LowerEqual;
                    break;
                case "!=":
                    condition.Comparision.Operator = TypeOperator.NotEqual;
                    break;
                default:
                    break;
            }
            ShowConditionInformation();
        }

        private void numericUpDownValue2_ValueChanged(object sender, EventArgs e)
        {
            Node.Condition.Comparision.Value = (float)numericUpDownValue2.Value;
            ShowConditionInformation();
        }

        private void comboBoxTypeCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            var condition = Node.Condition;
            switch (comboBoxTypeCondition.Text)
            {
                case "Unique":
                    if (condition.Type == TypeCondition.Unique)
                    {
                        break;
                    }
                    condition.Comparision = new Comparison();
                    condition.Children.Clear();
                    break;
                case "And":
                    condition.Type = TypeCondition.And;
                    if (condition.Children.Count == 0)
                    {
                        condition.Children.Add(new Condition());
                    }
                    break;
                case "Or":
                    condition.Type = TypeCondition.Or;
                    if (condition.Children.Count == 0)
                    {
                        condition.Children.Add(new Condition());
                    }
                    break;
                default:
                    break;
            }
            ShowConditionInformation();
        }

        private void checkBoxInterruptible_CheckedChanged(object sender, EventArgs e)
        {
            Instruction.Interruptible = checkBoxInterruptible.Checked;
        }
    }
}
