using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using WorldOfTank.Class.Model;
using WorldOfTank.Class.Components;

namespace WorldOfTank.GUI
{
    public partial class TankCreatorForm : Form
    {
        public Tank Tank;
        public List<Instruction> ActionInstruction;
        public string ActionName;

        public TankCreatorForm()
        {
            InitializeComponent();
        }

        public void ShowTankInformation()
        {
            pictureBoxTank.Image = Tank.Image;
            richTextBoxTankInfor.Text = String.Format("Tank name: {0}\nDamage: {1} - {2}\nHeal: {3}\nMovement speed: {4}\nRotation speed: {5}\nAttack speed: {6}\nRada range: {7}\nRada angle: {8}", Tank.Name, Tank.DamageMin, Tank.DamageMax, Tank.HealMax, Tank.SpeedMove, Tank.SpeedRotate, Tank.SpeedFire, Tank.RadaRange, Tank.RadaAngle);
        }

        public void ShowInstructionInformationList()
        {
            listViewInstruction.Items.Clear();
            foreach (Instruction instruction in ActionInstruction)
            {
                listViewInstruction.Items.Add(new ListViewItem(new[] { 
                    instruction.Type.ToString(),
                    instruction.Value.ToString(), 
                    instruction.Condition != null ? instruction.Condition.Print() : ""
                }));
            }
        }

        public void ShowInstructionInformationButton()
        {
            toolStripLabelName.Text = ActionName;
            int index = FindIndexInstruction();
            toolStripButtonDelete.Enabled = false;
            toolStripButtonMoveUp.Enabled = false;
            toolStripButtonMoveDown.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            if (index != -1) toolStripButtonDelete.Enabled = true;
            if (index != -1) toolStripButtonEdit.Enabled = true;
            if (index > 0) toolStripButtonMoveUp.Enabled = true;
            if (index >= 0 && index < ActionInstruction.Count - 1) toolStripButtonMoveDown.Enabled = true;
        }

        public int FindIndexInstruction()
        {
            if (!listViewInstruction.Focused) return -1;
            for (int index = 0; index < listViewInstruction.Items.Count; index++)
            {
                if (listViewInstruction.Items[index].Selected)
                    return index;
            }
            return -1;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            var newTank = new ChooseTank();
            if (newTank.ShowDialog() == DialogResult.OK)
            {
                Tank = newTank.Tank;
                panelTank.Visible = true;
                panelAction.Visible = true;
                buttonSave.Enabled = true;
                ShowTankInformation();
                buttonActionNormal_Click(null, null);
                ShowInstructionInformationList();
                ShowInstructionInformationButton();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var saver = new SaveFileDialog
            {
                Title = "Save Tank",
                Filter = "Tank File (*.tank)|*.tank",
                RestoreDirectory = true,
                FileName = Tank.Name
            };
            if (saver.ShowDialog() == DialogResult.OK)
            {
                Tank.Name = saver.FileName.Substring(saver.FileName.LastIndexOf('\\') + 1);
                Tank.Name = Tank.Name.Substring(0, Tank.Name.LastIndexOf('.'));
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saver.FileName, FileMode.Create,
                    FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, Tank);
                stream.Close();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var opener = new OpenFileDialog
            {
                Title = "Open Tank",
                Filter = "Tank File (*.tank)|*.tank",
                RestoreDirectory = true
            };
            if (opener.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(opener.FileName, FileMode.Open,
                        FileAccess.Read, FileShare.Read);
                    Tank = (Tank)formatter.Deserialize(stream);
                    stream.Close();
                    panelTank.Visible = true;
                    panelAction.Visible = true;
                    buttonSave.Enabled = true;
                    ShowTankInformation();
                    buttonActionNormal_Click(null, null);
                    ShowInstructionInformationList();
                    ShowInstructionInformationButton();
                }
                catch
                {
                    MessageBox.Show("Cannot load this file!");
                }
            }
        }

        private void pictureBoxTank_Click(object sender, EventArgs e)
        {
            var newTank = new ChooseTank();
            if (newTank.ShowDialog() == DialogResult.OK)
            {
                Tank temp = Tank;
                Tank = newTank.Tank;
                Tank.Name = temp.Name;
                Tank.ActionBeAttacked = temp.ActionBeAttacked;
                Tank.ActionCannotMoveBackward = temp.ActionCannotMoveBackward;
                Tank.ActionCannotMoveForward = temp.ActionCannotMoveForward;
                Tank.ActionDetected = temp.ActionDetected;
                Tank.ActionNormal = temp.ActionNormal;
                ShowTankInformation();
            }
        }

        private void buttonActionNormal_Click(object sender, EventArgs e)
        {
            ActionInstruction = Tank.ActionNormal;
            ActionName = "ActionNormal";
            ShowInstructionInformationList();
            ShowInstructionInformationButton();
        }

        private void buttonActionCannotMoveForward_Click(object sender, EventArgs e)
        {
            ActionInstruction = Tank.ActionCannotMoveForward;
            ActionName = "ActionCannotMoveForward";
            ShowInstructionInformationList();
            ShowInstructionInformationButton();
        }

        private void buttonActionCannotMoveBackward_Click(object sender, EventArgs e)
        {
            ActionInstruction = Tank.ActionCannotMoveBackward;
            ActionName = "ActionCannotMoveBackward";
            ShowInstructionInformationList();
            ShowInstructionInformationButton();
        }

        private void buttonActionDetected_Click(object sender, EventArgs e)
        {
            ActionInstruction = Tank.ActionDetected;
            ActionName = "ActionDetected";
            ShowInstructionInformationList();
            ShowInstructionInformationButton();
        }

        private void buttonActionBeAttacked_Click(object sender, EventArgs e)
        {
            ActionInstruction = Tank.ActionBeAttacked;
            ActionName = "ActionBeAttacked";
            ShowInstructionInformationList();
            ShowInstructionInformationButton();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            ActionInstruction.Add(new Instruction());
            ShowInstructionInformationList();
            int leng = ActionInstruction.Count;
            listViewInstruction.Focus();
            listViewInstruction.Items[leng - 1].Selected = true;
            listViewInstruction.Items[leng - 1].Focused = true;
            listViewInstruction.Items[leng - 1].EnsureVisible();
            ShowInstructionInformationButton();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            int index = FindIndexInstruction();
            ActionInstruction.RemoveAt(index);
            ShowInstructionInformationList();
            if (index >= ActionInstruction.Count) index--;
            if (index >= 0)
            {
                listViewInstruction.Focus();
                listViewInstruction.Items[index].Selected = true;
                listViewInstruction.Items[index].Focused = true;
                listViewInstruction.Items[index].EnsureVisible();
            }
            ShowInstructionInformationButton();
        }

        private void toolStripButtonMoveUp_Click(object sender, EventArgs e)
        {
            int index = FindIndexInstruction();
            Instruction temp = ActionInstruction[index];
            ActionInstruction[index] = ActionInstruction[index - 1];
            ActionInstruction[index - 1] = temp;
            index--;
            ShowInstructionInformationList();
            listViewInstruction.Focus();
            listViewInstruction.Items[index].Selected = true;
            listViewInstruction.Items[index].Focused = true;
            listViewInstruction.Items[index].EnsureVisible();
            ShowInstructionInformationButton();
        }

        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            int index = FindIndexInstruction();
            Instruction temp = ActionInstruction[index];
            ActionInstruction[index] = ActionInstruction[index + 1];
            ActionInstruction[index + 1] = temp;
            index++;
            ShowInstructionInformationList();
            listViewInstruction.Focus();
            listViewInstruction.Items[index].Selected = true;
            listViewInstruction.Items[index].Focused = true;
            listViewInstruction.Items[index].EnsureVisible();
            ShowInstructionInformationButton();
        }

        private void listViewInstruction_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ShowInstructionInformationButton();
        }

        private void listViewInstruction_Leave(object sender, EventArgs e)
        {
            toolStripButtonDelete.Enabled = false;
            toolStripButtonMoveUp.Enabled = false;
            toolStripButtonMoveDown.Enabled = false;
            toolStripButtonEdit.Enabled = false;
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            int index = FindIndexInstruction();
            using (var editInstruction = new EditInstruction { Tank = Tank, ActionName = ActionName, Instruction = ActionInstruction[index] })
            {
                editInstruction.ShowInstructionInformation();
                editInstruction.ShowConditionInformation();
                editInstruction.ShowDialog();
            }
            ShowInstructionInformationList();
            listViewInstruction.Focus();
            listViewInstruction.Items[index].Selected = true;
            listViewInstruction.Items[index].Focused = true;
            listViewInstruction.Items[index].EnsureVisible();
            ShowInstructionInformationButton();
        }

        private void listViewInstruction_ItemActivate(object sender, EventArgs e)
        {
            toolStripButtonEdit_Click(null, null);
        }
    }
}
