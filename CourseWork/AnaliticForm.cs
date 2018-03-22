using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Excel = Microsoft.Office.Interop.Excel; 

namespace CourseWork
{
    public partial class AnaliticForm : Form
    {
        public User currentUser;
        public AnaliticForm()
        {
            InitializeComponent();
        }
        public List<object> Calc(object result, out EntityTypes entityTypes)
        {
            List<object> list = new List<object>();
            if (result is IEnumerable<Address> res)
            {
                Operations.cont.AddressSet.Load();
                var a = res.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.Address;
            }
            else if (result is IEnumerable<City> res1)
            {
                var a = res1.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.City;
            }
            else if (result is IEnumerable<Company> res2)
            {
                var a = res2.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.Company;
            }
            else if (result is IEnumerable<Customer> res3)
            {
                var a = res3.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.Customer;
            }
            else if (result is IEnumerable<House> res4)
            {
                var a = res4.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.House;
            }
            else if (result is IEnumerable<Meter> res5)
            {
                var a = res5.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.Meter;
            }
            else if (result is IEnumerable<MeterType> res6)
            {
                var a = res6.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.MeterType;
            }
            else if (result is IEnumerable<Order> res7)
            {
                var a = res7.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.Order;
            }
            else if (result is IEnumerable<Person> res8)
            {
                var a = res8.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.Person;
            }
            else if (result is IEnumerable<Status> res9)
            {
                var a = res9.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.Status;
            }
            else if (result is IEnumerable<Stavka> res10)
            {
                var a = res10.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.Stavka;
            }
            else if (result is IEnumerable<Street> res11)
            {
                var a = res11.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.Street;
            }
            else if (result is IEnumerable<User> res12)
            {
                var a = res12.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.User;
            }
            else if (result is IEnumerable<OrderEntry> res13)
            {
                var a = res13.ToList();
                foreach (var b in a)
                {
                    list.Add(b);
                }
                entityTypes = EntityTypes.OrderEntry;
            }
            else entityTypes = default(EntityTypes);
            
            return list;
        }
        public List<object> results = new List<object>();
        public List<object> arrays = new List<object>();
        int Queries = 0;
        public void ended(object result)
        {
            results.Add(result);
            flowLayoutPanel1.Controls.Add(new TextBox { Text = (++Queries).ToString() + " запрос", ReadOnly = true });
            XmlButton.Enabled = false;
            ExcelButton.Enabled = false;
            button1.Enabled = true;
        }
       

        private void CustomQueryButton_Click(object sender, EventArgs e)
        {
            CustomQueryForm customQueryForm = new CustomQueryForm();
            customQueryForm.Owner = this;
            customQueryForm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Operations.cont.AddressSet.Load();
            Operations.cont.CitySet.Load();
            Operations.cont.HouseSet.Load();
            Operations.cont.MeterSet.Load();
            Operations.cont.MeterTypeSet.Load();
            Operations.cont.OrderEntrySet.Load();
            Operations.cont.OrderSet.Load();
            Operations.cont.PersonSet.Load();
            Operations.cont.StatusSet.Load();
            Operations.cont.StavkaSet.Load();
            Operations.cont.StreetSet.Load();
            Operations.cont.UserSet.Load();
            tabControl1.TabPages.Clear();
            listdgv.Clear();
            int i = 0;
            foreach (var s in  results){
                var b = Calc(s, out EntityTypes entity);
                arrays.Add(b);
                TabPage tabPage = new TabPage();
                tabPage.Text = "Запрос№" + (++i);
                DataGridView dataGridView = new DataGridView
                {
                    MultiSelect = false, ReadOnly = true, AllowUserToAddRows = false, AllowUserToDeleteRows = false, Dock = DockStyle.Fill, 
                    DataSource = b
                };
                tabPage.Controls.Add(dataGridView);
                tabControl1.TabPages.Add(tabPage);
                listdgv.Add(dataGridView);
                Program.HideColumns(ref dataGridView, entity,currentUser);
            };
            XmlButton.Enabled = true;
            ExcelButton.Enabled = true;
        }

        private void XmlButton_Click(object sender, EventArgs e)
        {
            Type type = null;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                int Number = 0;
                foreach (List<object> res in arrays)
                {
                    LessCont nlist1 = new LessCont();
                    if (res[0] is Address)
                    {
                        List<_Address> nlist = new List<_Address>();
                        foreach (Address a in res) nlist.Add(_Address.Trans(a));
                        type = typeof(_Address);
                        nlist1.AddressSet = nlist;
                    }
                    else if (res[0] is City)
                    {
                        List<_City> nlist = new List<_City>();
                        foreach (City a in res) nlist.Add(_City.Trans(a));
                        type = typeof(_City);
                        nlist1.CitySet = nlist;
                    }
                    else if (res[0] is Customer)
                    {
                        List<_Customer> nlist = new List<_Customer>();
                        foreach (Customer a in res) nlist.Add(_Customer.Trans(a));
                        type = typeof(_Customer);
                        nlist1.CustomerSet = nlist;
                    }
                    else if (res[0] is House)
                    {
                        List<_House> nlist = new List<_House>();
                        foreach (House a in res) nlist.Add(_House.Trans(a));
                        type = typeof(_House);
                        nlist1.HouseSet = nlist;
                    }
                    else if (res[0] is Meter)
                    {
                        List<_Meter> nlist = new List<_Meter>();
                        foreach (Meter a in res) nlist.Add(_Meter.Trans(a));
                        type = typeof(_Meter);
                        nlist1.MeterSet = nlist;
                    }
                    else if (res[0] is MeterType)
                    {
                        List<_MeterType> nlist = new List<_MeterType>();
                        foreach (MeterType a in res) nlist.Add(_MeterType.Trans(a));
                        type = typeof(_MeterType);
                        nlist1.MeterTypeSet = nlist;
                    }
                    else if (res[0] is Order)
                    {
                        List<_Order> nlist = new List<_Order>();
                        foreach (Order a in res) nlist.Add(_Order.Trans(a));
                        type = typeof(_Order);
                        nlist1.OrderSet = nlist;
                    }
                    else if (res[0] is OrderEntry)
                    {
                        List<_OrderEntry> nlist = new List<_OrderEntry>();
                        foreach (OrderEntry a in res) nlist.Add(_OrderEntry.Trans(a));
                        type = typeof(_OrderEntry);
                        nlist1.OrderEntrySet = nlist;
                    }
                    else if (res[0] is Person)
                    {
                        List<_Person> nlist = new List<_Person>();
                        foreach (Person a in res) nlist.Add(_Person.Trans(a));
                        type = typeof(_Person); nlist1.PersonSet = nlist;
                    }
                    else if (res[0] is Status)
                    {
                        List<_Status> nlist = new List<_Status>();
                        foreach (Status a in res) nlist.Add(_Status.Trans(a));
                        type = typeof(_Status); nlist1.StatusSet = nlist;
                    }
                    else if (res[0] is Street)
                    {
                        List<_Street> nlist = new List<_Street>();
                        foreach (Street a in res) nlist.Add(_Street.Trans(a));
                        type = typeof(_Street); nlist1.StreetSet = nlist;
                    }
                    else if (res[0] is Stavka)
                    {
                        List<_Stavka> nlist = new List<_Stavka>();
                        foreach (Stavka a in res) nlist.Add(_Stavka.Trans(a));
                        type = typeof(_Stavka); nlist1.StavkaSet = nlist;
                    }
                    else if (res[0] is User)
                    {
                        List<_User> nlist = new List<_User>();
                        foreach (User a in res) nlist.Add(_User.Trans(a));
                        type = typeof(_User); nlist1.UserSet = nlist;
                    }
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(LessCont));
                    using (StreamWriter sw = new StreamWriter(folderBrowserDialog.SelectedPath+'\\' + (++Number) + ".xml"))
                        xmlSerializer.Serialize(sw, nlist1);
                }
            }
        }
        Excel.Application application;
        Excel.Workbook workbook;
        List<DataGridView> listdgv = new List<DataGridView>();
        private void ExcelButton_Click(object sender, EventArgs e)
        {
            application = new Excel.Application();
            int i = 0;
            workbook = application.Workbooks.Add();
            application.Visible = true;
            foreach(DataGridView d in listdgv)
            {
                d.MultiSelect = true;
                d.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                d.SelectAll();
                DataObject dataObject = d.GetClipboardContent();
                if (dataObject != null)
                {
                    Clipboard.SetDataObject(dataObject);
                    Excel.Worksheet worksheet = workbook.Worksheets.Add();
                    worksheet.Name = listdgv.Count - i++ + " запрос";
                    Excel.Range range = (Excel.Range)worksheet.Cells[1, 1];
                    range.Select();
                    worksheet.PasteSpecial(range, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                    worksheet = null;
                }
            }
            workbook.BeforeClose += Workbook_BeforeClose;
        }

        private void Workbook_BeforeClose(ref bool Cancel)
        {
            application.Quit();
            workbook = null;
            application = null;
        }
    }
}
