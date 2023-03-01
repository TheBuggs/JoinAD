using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Join2AD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK.PerformClick();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK.PerformClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if ((this.txtUsername.Text).Length > 2 && (this.txtPassword.Text).Length > 0)
            {
                bool isExistNewName = false;
                bool hasError = false;
                Http req = null;

                try
                {
                    // Send main data to phonebook.mon.bg and check computername is exist in AD
                    req = new Http(Program.Hostname, this.txtUsername.Text);
                    Dictionary<string, string> dict = req.sendJSON();

                    string exist;
                    if(!dict.TryGetValue("\"exist\"", out exist)) {
                        hasError = true;
                    }

                    if (Int32.Parse(exist) == 1) {
                        isExistNewName = true;
                    }
                }
                catch (Exception ex)
                {
                    hasError = true;
                }

                if (isExistNewName)
                {
                    MessageBox.Show("Компютър с това име съществува в активната директория.\nТрябва да опитайте с друго!", "Внимание", MessageBoxButtons.OK,
                                      MessageBoxIcon.Asterisk);

                    try
                    {
                        if (req != null)
                        {
                            req.removeRecordJSON();
                        }
                    }
                    catch (Exception ex)
                    {
                        hasError = true;
                    }

                    Application.Exit();
                }
                else
                {
                    if (hasError)
                    {
                        DialogResult errorQuestion = MessageBox.Show("Не можа да се установи дали съществува компютър с такова име.\nЖелаете ли да продължите?", "Грешка",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                        if (errorQuestion == DialogResult.Yes)
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        try
                        {
                           JoinComputerDomain computer = new JoinComputerDomain(Program.Hostname, Program.Domain, Regex.Unescape(this.txtPassword.Text), this.txtUsername.Text, Program.OU);
                           
                            if (computer.JoinAndSetName(req))
                            {
                              
                                if (hasError) {
                                    MessageBox.Show("Не можа да бъде изпратена информация за успрешно преименуване!", "Внимание", MessageBoxButtons.OK,
                                     MessageBoxIcon.Asterisk);
                                }

                                string message = "Успешно добавихте машината в домайна!\n\n Рестартиране!\n\n";
                                string caption = "Информация";

                                DialogResult dialogResult = MessageBox.Show(message, caption, MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Asterisk);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    Process.Start("shutdown", "/r /t 0");
                                }
                                else {
                                    Application.Exit();
                                }
                            }
                            else 
                            {
                                DialogResult result =  MessageBox.Show("Възникна грешка при опит за добавяне или преименуване на машината.\nЖелаете ли да затворите приложението или ще опитате с друг потребител или парола?", "Грешка", 
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                                if (result == DialogResult.Yes) {
                                    Application.Exit();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Грешка: " + ex.Message + "\n", "Фатална грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }   
            }
            else
            {
                MessageBox.Show("Имате непопълнена информация!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
