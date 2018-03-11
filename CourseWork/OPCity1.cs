using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class OPCity1 : CourseWork.OP
    {
        public OPCity1()
        {
            InitializeComponent();
        }
        public override void Change()
        {
            ActionMode = ActionMode.Change;
            AddCityButton.Text = "Изменить город";
        }
        private void AddCityButton_Click(object sender, EventArgs e)
        {
            Act();
        }
        override protected void Act()
        {
            if (ActionMode == ActionMode.Add)
            {
                if (Operations.AddCity(CityNameTextBox.Text, out string s))
                {
                    Close();
                }
                MessageBox.Show(s);
            }
            else
            {
                if (Operations.ChangeCity(Id, CityNameTextBox.Text, out string s))
                {
                    Close();
                }
                MessageBox.Show(s);
            }
        }
    }
}
