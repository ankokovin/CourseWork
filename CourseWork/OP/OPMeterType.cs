using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class OPMeterType : CourseWork.OP
    {
        public OPMeterType()
        {
            InitializeComponent();
        }


        protected override void Act()
        {
            if (ActionMode == ActionMode.Add)
            {
                if (Operations.AddMeterType(textBox1.Text, out string Res))
                    Close();
                MessageBox.Show(Res);
            }
            else
            {
                if (Operations.ChangeMeterType(Id,textBox1.Text, out string Res))
                    Close();
                MessageBox.Show(Res);
            }
        }

        public override void Change(object obj)
        {
            Text = "Изменение прибора учёта ";
            ActionMode = ActionMode.Change;
            if (obj is MeterType mt)
            {
                textBox1.Text = mt.Name;
                Text += mt + " id:" + mt.Id;
            }
            button1.Text = "Изменить тип приборов учёта";
        }

        private void OPMeterType_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Act();
        }
    }
}
