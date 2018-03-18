using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AnaliticForm : Form
    {
        public AnaliticForm()
        {
            InitializeComponent();
        }
        public List<object> Calc(object result)
        {
            List<object> list = new List<object>();
            if (result is IEnumerable<Address> res)
            {
                var a = res.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<City> res1)
            {
                var a = res1.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<Company> res2)
            {
                var a = res2.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<Customer> res3)
            {
                var a = res3.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<House> res4)
            {
                var a = res4.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<Meter> res5)
            {
                var a = res5.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<MeterType> res6)
            {
                var a = res6.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<Order> res7)
            {
               var a =  res7.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<Person> res8)
            {
                var a = res8.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<Status> res9)
            {
                var a = res9.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<Stavka> res10)
            {
                var a = res10.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<Street> res11)
            {
                var a = res11.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            else if (result is IEnumerable<User> res12)
            {
                var a = res12.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
            }
            return list;
        }
        public List<object> results = new List<object>();
        public List<object> arrays = new List<object>();
        public void ended(object result)
        {
            results.Add(result);
        }
        

        private void CustomQueryButton_Click(object sender, EventArgs e)
        {
            CustomQueryForm customQueryForm = new CustomQueryForm();
            customQueryForm.Owner = this;
            customQueryForm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           var a = Parallel.ForEach(results, (s) => arrays.Add(Calc(s)));
            while (!a.IsCompleted)
            {
                Thread.Sleep(100);
            }
            XmlButton.Enabled = true;
            ExcelButton.Enabled = true;
        }
    }
}
