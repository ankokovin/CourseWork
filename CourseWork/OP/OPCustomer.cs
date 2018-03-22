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
            if (!Checker.IsFIO(textBox1.Text))
            {
                MessageBox.Show("Неверное ФИО");
                return;
            }
            if (!Checker.IsPassportNumber(textBox2.Text))
            {
                MessageBox.Show("Неверный номер паспорта");
                return;
            }
            if (!Checker.IsPhoneNumber(textBox5.Text))
            {
                MessageBox.Show("Неверный номер телефона");
                return;
            }
            if (radioButton1.Checked)
            {
                if (!Checker.IsName(textBox4.Text))
                {
                    MessageBox.Show("Неверная строка названия");
                    return;
                }
                if (!Checker.IsINN(textBox3.Text))
                {
                    MessageBox.Show("Неверный ИНН");
                    return;
                }
                if (ActionMode == ActionMode.Add)
                {
                    if (Operations.AddCompany(textBox1.Text, textBox2.Text,textBox5.Text, textBox4.Text, textBox3.Text, out string Res))
                        Close();
                    MessageBox.Show(Res);
                }
                else
                {
                    if (Operations.ChangeCompany(Id,textBox1.Text, textBox2.Text,textBox5.Text, textBox4.Text, textBox3.Text, out string Res))
                        Close();
                    MessageBox.Show(Res);
                }
            }
            else
            {
                if (ActionMode == ActionMode.Add)
                {
                    if (Operations.AddCustomer(textBox1.Text, textBox2.Text,textBox5.Text, out string Res))
                        Close();
                    MessageBox.Show(Res);
                }
                else
                {
                    if (Operations.ChangeCustomer(Id, textBox1.Text, textBox2.Text,textBox5.Text,out string Res))
                        Close();
                    MessageBox.Show(Res);
                }
            }
        }

        public override void Change(object obj)
        {
            Text = "Изменение заказчика ";
            ActionMode = ActionMode.Change;
            if (obj is Company com)
            {
                textBox1.Text = com.FIO;
                textBox2.Text = com.Passport;
                textBox4.Text = com.CompanyName;
                textBox3.Text = com.INN;
                radioButton1.Checked = true;
                radioButton1.Enabled = false;
                Text += com + " id:" + com.Id;
            }else if (obj is Customer cus)
            {
                textBox1.Text = cus.FIO;
                textBox2.Text = cus.Passport;
                radioButton1.Enabled = false;
                radioButton1.Checked = false;
            }
            button1.Text = "Внести изменение";
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
