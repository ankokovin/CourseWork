using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class OPOrderEntry : CourseWork.OP
    {
        public OPOrderEntry()
        {
            InitializeComponent();
        }

        private void OPOrderEntry_Load(object sender, EventArgs e)
        {

        }

        protected override void Act()
        {

            if (ActionMode == ActionMode.Add)
            {
                if (Operations.AddOrderEntry())
            }else
            {

            }
        }
    }
}
