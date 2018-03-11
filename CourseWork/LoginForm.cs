using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text.Length == 0)
            {
                MessageBox.Show("Введите логин и пароль");
            }else
            {
                var result = Operations.TryEntry(LoginTextBox.Text, PasswordTextBox.Text, out string s);
                MessageBox.Show(s);
                if (result != null)
                {
                    switch (result.UserType)
                    {
                        case UserType.Admin:
                            AdminForm adminForm = new AdminForm();
                            adminForm.FormClosed += BackUp;
                            adminForm.Visible = true;
                            adminForm.Show();
                            break;
                        case UserType.Analitic:
                            AnaliticForm analiticForm = new AnaliticForm();
                            analiticForm.FormClosed += BackUp;
                            analiticForm.Visible = true;
                            analiticForm.Show();
                            break;
                        case UserType.Operator:
                            OperatorForm operatorForm = new OperatorForm();
                            operatorForm.FormClosed += BackUp;
                            operatorForm.Visible = true;
                            operatorForm.Show();
                            break;
                    }
                    Enabled = false;
                    Visible = false;
                }
            }
        }

        private void BackUp(object sender, FormClosedEventArgs e)
        {
            Visible = true;
            Enabled = true;
            Show();
        }
    }
}
