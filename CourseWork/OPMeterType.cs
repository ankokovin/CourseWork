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
    public partial class OPMeterType : CourseWork.OP
    {
        public OPMeterType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Act();
        }

        protected override void Act()
        {
            base.Act();
        }

        public override void Change(object obj)
        {
            base.Change(obj);
        }

        private void OPMeterType_Load(object sender, EventArgs e)
        {
            Operations.cont.MeterTypeSet.Load();
            dataGridView1.DataSource = Operations.cont.MeterTypeSet.Local.ToBindingList();
        }
    }
}