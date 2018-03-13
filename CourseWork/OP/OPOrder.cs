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
    public partial class OPOrder : CourseWork.OP
    {
        public OPOrder()
        {
            InitializeComponent();
        }

        private void OPOrder_Load(object sender, EventArgs e)
        {
            Operations.cont.AddressSet.Load();
            Operations.cont.CustomerSet.Load();
            dataGridView1.DataSource = Operations.cont.AddressSet.Local.ToBindingList();
            dataGridView2.DataSource = Operations.cont.CustomerSet.Local.ToBindingList();
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
                if (Operations.AddOrder((Owner as AdminForm).CurrentUser,Operations.FindCustomer(id2), Operations.FindAddress(id1), out string Res))
                    Close();
                MessageBox.Show(Res);
            }
            else
            {

                if (Operations.ChangeOrder(Id, Operations.FindCustomer(id2), Operations.FindAddress(id1), out string Res))
                    Close();
                MessageBox.Show(Res);
            }
        }

        public override void Change(object obj)
        {
            ActionMode = ActionMode.Change;
            button1.Text = "Изменить заказ";
            if (obj is Order ord)
            {
                Program.SelectId(ref dataGridView1, ord.Address.Id);
                Program.SelectId(ref dataGridView2, ord.Customer.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Act();
        }
    }
}
