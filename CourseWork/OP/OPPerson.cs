using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class OPPerson : CourseWork.OP
    {
        public OPPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Act();
        }

        protected override void Act()
        {
            if (ActionMode == ActionMode.Add)
            {
                if (Operations.AddPerson(textBox1.Text, out string res))
                    Close();
                MessageBox.Show(res);
            }else
            {
                if (Operations.ChangePerson(Id,textBox1.Text, out string res))
                    Close();
                MessageBox.Show(res);
            }
        }

        public override void Change(object obj)
        {
            Text = "Изменение работника ";
            if (obj is Person p)
            {
                textBox1.Text = p.FIO;
                Text += p + " id:" + p.Id;
            }
            ActionMode = ActionMode.Change;
            button1.Text = "Изменить работника";
        }
    }
}
