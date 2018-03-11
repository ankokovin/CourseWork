﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class SimpleView : Form
    {
        public SimpleView()
        {
            InitializeComponent();
        }
        public void SetButtonNames(string Add, string Del, string Change)
        {
            AddButton.Text = Add;
            ChangeButton.Text = Change;
            RemoveButton.Text = Del;
        }
        private void CityForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Source;
        }
        public object Source;
        public Action Add;
        public Action<DataGridView> Change;
        public Action<DataGridView> Remove;

        private void AddButton_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            Change(dataGridView1);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Remove(dataGridView1);
        }
    }
}