using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class OP : Form
    {
        public int Id;
        public ActionMode ActionMode;
        public OP()
        {
            InitializeComponent();
        }
        virtual protected void Act()
        {

        }
        virtual public void Change()
        {

        }
    }
}
