﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class OPStreet : CourseWork.OP
    {
        public OPStreet() : base()
        {
            InitializeComponent();
        }

        private void OPStreet_Load(object sender, EventArgs e)
        {
            Operations.cont.CitySet.Load();
            dataGridView1.DataSource = Operations.cont.CitySet.Local.ToBindingList();
            Program.HideColumns(ref dataGridView1, EntityTypes.City);
        }
        protected override void Act()
        {
            if (ActionMode == ActionMode.Add)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dataGridView1[1, index].Value.ToString(), out id);
                if (!ok) return;
                if (Operations.AddStreet(StreetTextBox.Text,Operations.FindCity(id),out string s))
                {
                    Close();
                }
                MessageBox.Show(s);
            }else
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dataGridView1[1, index].Value.ToString(), out id);
                if (!ok) return;
                if (Operations.ChangeStreet(Id,StreetTextBox.Text, Operations.FindCity(id), out string s))
                {
                    Close();
                }
                MessageBox.Show(s);
            }
        }
        public override void Change(object obj)
        {
            if (obj is Street street)
            {
                StreetTextBox.Text = street.Name;
                Program.SelectId(ref dataGridView1, street.Id);
            }
            ActionMode = ActionMode.Change;
            ActButton.Text = "Изменить улицу";
        }

        private void ActButton_Click(object sender, EventArgs e)
        {
            Act();
        }
    }
}
