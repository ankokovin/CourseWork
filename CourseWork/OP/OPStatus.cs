using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class OPStatus : CourseWork.OP
    {
        public OPStatus()
        {
            InitializeComponent();
        }

        private void AddStatusButton_Click(object sender, EventArgs e)
        {
            Act();
        }
        protected override void Act()
        {
            if (ActionMode == ActionMode.Add)
            {
                if (Operations.AddStatus(StatusTextBox.Text, out string Res))
                    Close();
                MessageBox.Show(Res);
            }
            else
            {
                if (Operations.ChangeStatus(Id,StatusTextBox.Text, out string Res))
                    Close();
                MessageBox.Show(Res);
            }
        }
        public override void Change(object obj)
        {
            Text = "Изменение статуса ";
            if (obj is Status st)
            {
                StatusTextBox.Text = st.Name;
                Text += st + " id:" + st.Id;
            }
            ActionMode = ActionMode.Change;
            AddStatusButton.Text = "Изменить статус";
        }
    }
}
