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
            Program.HideColumns(ref dataGridView1, EntityTypes.MeterType,CurrentUser);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Act();
        }
        protected override void Act()
        {
            if (!Checker.IsName(textBox1.Text))
            {
                MessageBox.Show("Неверная строка имени");
                return;
            }
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
            Text = "Изменение прибора учёта ";
            ActionMode = ActionMode.Change;
            if (obj is Meter m)
            {
                textBox1.Text = m.Name;
                Program.SelectId(ref dataGridView1, m.MeterType.Id);
                Text += m + "id: " + m.Id;
            }
            button1.Text = "Внести изменение";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Act();
        }
    }
}
