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
    public partial class OPStavka : CourseWork.OP
    {
        public OPStavka()
        {
            InitializeComponent();
        }

        private void OPStavka_Load(object sender, EventArgs e)
        {
            Operations.cont.PersonSet.Load();
            dataGridView1.DataSource = Operations.cont.PersonSet.Local.ToBindingList();
            Operations.cont.MeterTypeSet.Load();
            dataGridView2.DataSource = Operations.cont.MeterTypeSet.Local.ToBindingList();
        }

        protected override void Act()
        {
            int idx1 = dataGridView1.SelectedRows[0].Index;
            int id1 = 0;
            bool ok = int.TryParse(dataGridView1[Program.FindTitle(dataGridView1, "Id"), idx1].Value.ToString(), out id1);
            if (!ok) return;
            int idx2 = dataGridView2.SelectedRows[0].Index;
            int id2 = 0;
            ok = int.TryParse(dataGridView2[Program.FindTitle(dataGridView2, "Id"), idx2].Value.ToString(), out id2);
            if (!ok) return;
            if (ActionMode == ActionMode.Add)
            {
                if (Operations.AddStavka(Operations.FindMeterType(id2), Operations.FindPerson(id1), out string Res))
                    Close();
                MessageBox.Show(Res);
            }
            else
            {

                if (Operations.ChangeStavka(Id,Operations.FindMeterType(id2), Operations.FindPerson(id1), out string Res))
                    Close();
                MessageBox.Show(Res);
            }
        }

        public override void Change(object obj)
        {
            ActionMode = ActionMode.Add;
            button1.Text = "Изменить ставку";
            if (obj is Stavka st)
            {
                Program.SelectId(ref dataGridView1, st.Person.Id);
                Program.SelectId(ref dataGridView2, st.MeterType.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Act();
        }
    }
}
