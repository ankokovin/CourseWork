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
    public partial class OPMeter : CourseWork.OP
    {
        public OPMeter()
        {
            InitializeComponent();
        }

        private void OPMeter_Load(object sender, EventArgs e)
        {
            Operations.cont.MeterTypeSet.Load();
            dataGridView1.DataSource = Operations.cont.MeterTypeSet.Local.ToBindingList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Act();
        }
        protected override void Act()
        {
            int index = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            bool ok = int.TryParse(dataGridView1[Program.FindTitle(dataGridView1, "Id"), index].Value.ToString(), out id);
            if (!ok) return;
            if (ActionMode == ActionMode.Add)
            {
                if (Operations.AddMeter(textBox1.Text, Operations.FindMeterType(id), out string Res))
                    Close();
                MessageBox.Show(Res);
            }
            else
            {
                if (Operations.ChangeMeter(Id, textBox1.Text, Operations.FindMeterType(id), out string Res))
                    Close();
                MessageBox.Show(Res);
            }
        }
        public override void Change(object obj)
        {
            ActionMode = ActionMode.Change;
            if (obj is Meter m)
            {
                textBox1.Text = m.Name;
            }
            button1.Text = "Изменить прибор учёта";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Act();
        }
    }
}
