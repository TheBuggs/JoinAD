
using System.Collections.Generic;
using System.Windows.Forms;

namespace Join2AD
{
    public partial class Head : Form
    {
        public Head()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void next_Click(object sender, System.EventArgs e)
        {
            Program.RealHostname.SetAll(
                this.txtBoxFirstName.Text,
                this.txtBoxLastName.Text,
                this.txtRoom.Text,
                this.comboBoxType.SelectedIndex,
                this.comboBoxDirectorate.SelectedIndex,
                this.cboBoxLocation.SelectedIndex);

            List<string> res = Program.RealHostname.GenerateHostname();

            const string caption = "Внимание";
            string message = string.Empty;
            
            if (res.Count == 0) {

                message = string.Format("Име: {0}\nОЕ: {1}", Program.RealHostname.Name, Program.OU);
                
                DialogResult dialogResult = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation);
                
                if (dialogResult == DialogResult.Yes)
                {
                    Program.ValidName = true;
                    Program.Hostname = Program.RealHostname.Name;
                    this.Close();
                }
            }
            else {
 
                foreach (string err in res) {
                    message += err + "\n";
                }

                MessageBox.Show(message, caption,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                next.PerformClick();
        }

        private void cboBoxLocation_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}
