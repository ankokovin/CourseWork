using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class OPCity : CourseWork.OP
    {
        public OPCity()
        {
            InitializeComponent();
        }
        public override void Change(Object obj)
        {
            Text = "Изменение города";
            ActionMode = ActionMode.Change;
            if (obj is City city) {
                CityNameTextBox.Text = city.Name;
                Text += " " + city + " id:" + city.Id;
            }
            AddCityButton.Text = "Внести изменение";
        }
        private void AddCityButton_Click(object sender, EventArgs e)
        {
            Act();
        }
        override protected void Act()
        {
            if (!Checker.IsName(CityNameTextBox.Text))
            {
                MessageBox.Show("Неверная строка названия");
                return;
            }
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
