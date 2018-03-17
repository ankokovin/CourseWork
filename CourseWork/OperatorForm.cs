using System;
using System.Data.Entity;
using System.Threading;
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
    public partial class OperatorForm : Form
    {
        public OperatorForm()
        {
            InitializeComponent();
        }

        public User CurrentUser;
        IEnumerable<City> cities;
        IEnumerable<Street> streets;
        IEnumerable<House> houses;
        IEnumerable<Address> addresses;
        bool CityChanged = true;
        bool StreetChanged = true;
        bool HouseChanged = true;
        bool AddressChanged = true;
        private void OperatorForm_Load(object sender, EventArgs e)
        {
            var a = tabControl1.TabPages[0];
            tabControl1.TabPages.Remove(a);
            tabControl1.TabPages.Add(a);
            Text = CurrentUser.Login;
            Operations.cont.CustomerSet.Load();
            Operations.cont.MeterSet.Load();
            cities = (from c in Operations.cont.CitySet select c);
            MessageBox.Show("Loaded");
            MeterDataGridView.DataSource = Operations.cont.MeterSet.Local.ToBindingList();
            Program.HideColumns(ref MeterDataGridView, EntityTypes.Meter);
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange((from c in cities select c.ToString()).ToArray());
            CityTextBox.AutoCompleteCustomSource = autoCompleteStringCollection;
            OrderEntryList = new BindingList<_OrderEntry>();
            BindingSource bindingSource = new BindingSource(OrderEntryList,null);
            OrderEntryDataGridView.DataSource = bindingSource;
            
        }

        private BindingList<_OrderEntry> OrderEntryList;

        private void button1_Click(object sender, EventArgs e)
        {
            _OrderEntry order = new _OrderEntry();
            order.MeterId = int.Parse(MeterDataGridView[Program.FindTitle(MeterDataGridView,"Id"), MeterDataGridView.SelectedRows[0].Index].Value.ToString());
            OrderEntryList.Add(order);

            OrderEntryDataGridView.Refresh();
        }
        private void StreetTextBox_Enter(object sender, EventArgs e)
        {
            if (CityChanged) {
                CityChanged = false;
                   City city = (from c in cities where c.Name == CityTextBox.Text select c).FirstOrDefault();
                   if (city == null) return;
                   streets = city.Street;
                   AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                   autoCompleteStringCollection.AddRange((from s in streets select s.Name).ToArray());
                   StreetTextBox.AutoCompleteCustomSource = autoCompleteStringCollection;
            }
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            CityChanged = true;   
        }

        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            StreetChanged = true;
        }

        private void HouseTextBox_TextChanged(object sender, EventArgs e)
        {
            HouseChanged = true;
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            AddressChanged = true;
        }

        private void HouseTextBox_Enter(object sender, EventArgs e)
        {
            if (StreetChanged)
            {
 
                        StreetChanged = false;
                        Street street = (from s in streets where s.Name == StreetTextBox.Text select s).FirstOrDefault();
                        if (street == null) return;
                        houses = street.House;
                        AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                        autoCompleteStringCollection.AddRange((from h in houses select h.Number).ToArray());
                        HouseTextBox.AutoCompleteCustomSource = autoCompleteStringCollection;
                    
                
            }
        }

        private void AddressTextBox_Enter(object sender, EventArgs e)
        {
            if (HouseChanged)
            {

                        HouseChanged = false;
                        House house = (from s in houses where s.Number == StreetTextBox.Text select s).FirstOrDefault();
                        if (house == null) return;
                        addresses = house.Address;
                        AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                        autoCompleteStringCollection.AddRange((from a in addresses select a.Flat.ToString()).ToArray());
                        AddressTextBox.AutoCompleteCustomSource = autoCompleteStringCollection;

               
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
