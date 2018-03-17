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
        BindingList<Customer> CustomerBindingList;
        BindingList<Company> CompanyBindingList;
        private void OperatorForm_Load(object sender, EventArgs e)
        {
            Text = CurrentUser.Login;
            Operations.cont.CustomerSet.Load();
            var customers = from c in Operations.cont.CustomerSet where !(c is Company) select c;
            var companies = from c in Operations.cont.CustomerSet where c is Company select c as Company;
            CustomerBindingList = new BindingList<Customer>(customers.ToList());
            CompanyBindingList = new BindingList<Company>(companies.ToList());
            CustomerDataGridView.DataSource = CustomerBindingList;
            Program.HideColumns(ref CustomerDataGridView, EntityTypes.Customer);
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
            Program.HidaColumns(ref OrderEntryDataGridView, new List<string> { "Id","OrderId","StatusId","RegNum","PersonId"});
        }

        private BindingList<_OrderEntry> OrderEntryList;

        private void button1_Click(object sender, EventArgs e)
        {
            _OrderEntry order = new _OrderEntry();
            order.MeterId = int.Parse(MeterDataGridView[Program.FindTitle(MeterDataGridView,"Id"), MeterDataGridView.SelectedRows[0].Index].Value.ToString());
            OrderEntryList.Add(order);

            OrderEntryDataGridView.Refresh();
        }
        City city;
        private void StreetTextBox_Enter(object sender, EventArgs e)
        {
            if (CityChanged) {
                CityChanged = false;
                   city = (from c in cities where c.Name == CityTextBox.Text select c).FirstOrDefault();
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
        Street street;
        private void HouseTextBox_Enter(object sender, EventArgs e)
        {
            if (StreetChanged)
            {
 
                        StreetChanged = false;
                        street = (from s in streets where s.Name == StreetTextBox.Text select s).FirstOrDefault();
                        if (street == null) return;
                        houses = street.House;
                        AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                        autoCompleteStringCollection.AddRange((from h in houses select h.Number).ToArray());
                        HouseTextBox.AutoCompleteCustomSource = autoCompleteStringCollection;
                    
                
            }
        }
        House house;
        private void AddressTextBox_Enter(object sender, EventArgs e)
        {
            if (HouseChanged)
            {

                        HouseChanged = false;
                        house = (from s in houses where s.Number == StreetTextBox.Text select s).FirstOrDefault();
                        if (house == null) return;
                        addresses = house.Address;
                        AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                        autoCompleteStringCollection.AddRange((from a in addresses select a.Flat.ToString()).ToArray());
                        AddressTextBox.AutoCompleteCustomSource = autoCompleteStringCollection;

               
            }
        }
        Address address;

        private void button2_Click(object sender, EventArgs e)
        {
            Customer customer;
            if (radioButton2.Checked)
            {
                if (BCompany) {
                    Operations.AddCustomer(NameTextBox.Text,PassportTextBox.Text,out string Res);
                    customer = (from c in Operations.cont.CustomerSet where !(c is Company) && c.Passport == PassportTextBox.Text select c).First();
                }else
                {
                    Operations.AddCompany(NameTextBox.Text, PassportTextBox.Text, CompanyNameTextBox.Text, INNTextBox.Text, out string Res);
                    customer = (from c in Operations.cont.CustomerSet where c is Company && (c as Company).INN == INNTextBox.Text select c).First();
                }
            }
            else
            {
                if (BCompany)
                    customer = Operations.FindCustomer(int.Parse(CustomerDataGridView[Program.FindTitle(CustomerDataGridView, "Id"), CustomerDataGridView.SelectedRows[0].Index].Value.ToString()));
                else
                    customer = Operations.FindCompany(int.Parse(CustomerDataGridView[Program.FindTitle(CustomerDataGridView, "Id"), CustomerDataGridView.SelectedRows[0].Index].Value.ToString()));
            }
            if (city == null)
            {
                Operations.AddCity(CityTextBox.Text, out string Res);
                city = (from p in Operations.cont.CitySet where p.Name == CityTextBox.Text select p).First();
            }
            if (street == null)
            {
                Operations.AddStreet(StreetTextBox.Text, city, out string Res1);
                street = (from p in city.Street where p.Name == StreetTextBox.Text select p).First();
            }
            if (house == null)
            {
                Operations.AddHouse(HouseTextBox.Text, street, out string res2);
                house = (from p in street.House where p.Number == HouseTextBox.Text select p).First();
            }
            if (address == null) {
                Operations.AddAddress(int.Parse(AddressTextBox.Text), house, out string Res4);
                address = (from p in house.Address where p.Flat == int.Parse(AddressTextBox.Text) select p).First();
            }
            Operations.AddOrder(CurrentUser, customer, address, out string res, out Order order);
            foreach (_OrderEntry o in OrderEntryList)
            {
                Operations.AddOrderEntry(order, o.startTime, o.endTime, o.RegNum, Operations.FindMeter(o.MeterId), null, Operations.FindStatus(0), out string Res2);
            }
        }
        bool BCompany = false;

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (BCompany)
            {
                BCompany = false;
                CompanyNameTextBox.Enabled = false;
                INNTextBox.Enabled = false;
                CustomerDataGridView.DataSource = CustomerBindingList;
                Program.HideColumns(ref CustomerDataGridView, EntityTypes.Customer);
               
            }
            else
            {
                BCompany = true;
                CompanyNameTextBox.Enabled = true;
                INNTextBox.Enabled = true;
                CustomerDataGridView.DataSource = CompanyBindingList;
                Program.HideColumns(ref CustomerDataGridView, EntityTypes.Company);
            }
        }

        private void AddressTextBox_Leave(object sender, EventArgs e)
        {
            if (house!=null)
            {
                address = (from p in house.Address where p.Flat == int.Parse(AddressTextBox.Text) select p).FirstOrDefault();
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
