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
    public partial class OPAddress : CourseWork.OP
    {
        public OPAddress()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Act();
        }
        protected override void Act()
        {
            int ind = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            bool ok = int.TryParse(dataGridView1[Program.FindTitle(dataGridView1, "Id"), ind].Value.ToString(), out id);
            if (!ok) return;
            if (ActionMode == ActionMode.Add)
            {
                if (Operations.AddAddress(int.Parse(textBox1.Text), Operations.FindHouse(id), out string Res))
                    Close();
                MessageBox.Show(Res);
            }else
            {
                if (Operations.ChangeAddress(Id,int.Parse(textBox1.Text), Operations.FindHouse(id), out string Res))
                    Close();
                MessageBox.Show(Res);
            }
        }
        public override void Change(object obj)
        {
            ActionMode = ActionMode.Change;
            if (obj is Address adr)
            {
                textBox1.Text = adr.Flat.ToString();
                Program.SelectId(ref dataGridView1, adr.House.Id);
            }
            button1.Text = "Изменить адрес";
        }

        private void OPAddress_Load(object sender, EventArgs e)
        {
            Operations.cont.HouseSet.Load();
            dataGridView1.DataSource = Operations.cont.HouseSet.Local.ToBindingList();
            Program.HideColumns(ref dataGridView1, EntityTypes.House);
        }
    }
}
