using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class OPCustomer : CourseWork.OP
    {
        public OPCustomer()
        {
            InitializeComponent();
        }

        private void OPCustomer_Load(object sender, EventArgs e)
        {

        }

        protected override void Act()
        {
            if (radioButton1.Checked)
            {
                if (ActionMode == ActionMode.Add)
                {
                    if (Operations.AddCompany(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text, out string Res))
                        Close();
                    MessageBox.Show(Res);
                }
                else
                {
                    if (Operations.ChangeCompany(Id,textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text, out string Res))
                        Close();
                    MessageBox.Show(Res);
                }
            }
            else
            {
                if (ActionMode == ActionMode.Add)
                {
                    if (Operations.AddCustomer(textBox1.Text, textBox2.Text, out string Res))
                        Close();
                    MessageBox.Show(Res);
                }
                else
                {
                    if (Operations.ChangeCustomer(Id, textBox1.Text, textBox2.Text,out string Res))
                        Close();
                    MessageBox.Show(Res);
                }
            }
        }

        public override void Change(object obj)
        {
            ActionMode = ActionMode.Change;
            if (obj is Company com)
            {
                textBox1.Text = com.Name;
                textBox2.Text = com.Passport;
                textBox4.Text = com.CompanyName;
                textBox3.Text = com.INN;
                radioButton1.Checked = true;
                radioButton1.Enabled = false;
            }else if (obj is Customer cus)
            {
                textBox1.Text = cus.Name;
                textBox2.Text = cus.Passport;
                radioButton1.Enabled = false;
                radioButton1.Checked = false;
            }
            button1.Text = "Изменить заказчика";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }else
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Act();
        }
    }
}
