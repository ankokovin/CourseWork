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
using Excel =  Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Reflection;

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
            Program.HideColumns(ref CustomerDataGridView, EntityTypes.Customer,CurrentUser);
            Program.Rename(ref CustomerDataGridView);
            Operations.cont.MeterSet.Load();
            cities = (from c in Operations.cont.CitySet select c);
            MessageBox.Show("Loaded");
            MeterDataGridView.DataSource = Operations.cont.MeterSet.Local.ToBindingList();
            Program.HideColumns(ref MeterDataGridView, EntityTypes.Meter,CurrentUser);
            Program.Rename(ref MeterDataGridView);
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange((from c in cities select c.ToString()).ToArray());
            CityTextBox.AutoCompleteCustomSource = autoCompleteStringCollection;
            OrderEntryList = new BindingList<_OrderEntry>();
            BindingSource bindingSource = new BindingSource(OrderEntryList,null);
            OrderEntryDataGridView.DataSource = bindingSource;
            Program.HidaColumns(ref OrderEntryDataGridView, new List<string> { "Id","OrderId","StatusId","RegNum","PersonId"});
            Program.Rename(ref OrderEntryDataGridView);
            Operations.cont.OrderSet.Load();
            Operations.cont.OrderEntrySet.Load();
            COrderDataGridView.DataSource = Operations.cont.OrderSet.Local.ToBindingList();
            Program.HideColumns(ref COrderDataGridView, EntityTypes.Order,CurrentUser);
            Program.Rename(ref COrderDataGridView);
            COrderDataGridView.ClearSelection();
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
                if (city == null) return;
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
                if (city == null || street == null) return;
                        HouseChanged = false;
                        house = (from s in houses where s.Number == HouseTextBox.Text select s).FirstOrDefault();
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
                if (!Checker.IsFIO(NameTextBox.Text)){
                    MessageBox.Show("Неверное ФИО заказчика");
                    return;
                }
                if (!Checker.IsPhoneNumber(PhoneNumberTextBox.Text))
                {
                    MessageBox.Show("Неверный номер телефона");
                    return;
                }
                if (!Checker.IsPassportNumber(PassportTextBox.Text))
                {
                    MessageBox.Show("Неверный номер пасспорта");
                    return;
                }
                if (!BCompany) {
                    if (!Operations.AddCustomer(NameTextBox.Text,PassportTextBox.Text,PhoneNumberTextBox.Text, out string Res))
                    {
                        MessageBox.Show(Res);
                        return;
                    }
                    customer = (from c in Operations.cont.CustomerSet where !(c is Company) && c.Passport == PassportTextBox.Text select c).First();
                }else
                {
                    if (!Checker.IsName(CompanyNameTextBox.Text))
                    {
                        MessageBox.Show("Неверная строка названия компании");
                        return;
                    }
                    if (!Checker.IsINN(INNTextBox.Text))
                    {
                        MessageBox.Show("Неверный ИНН компании");
                        return;
                    }
                    if (!Operations.AddCompany(NameTextBox.Text, PassportTextBox.Text, PhoneNumberTextBox.Text, CompanyNameTextBox.Text, INNTextBox.Text, out string Res))
                    {
                        MessageBox.Show(Res);
                        return;
                    }
                    customer = (from c in Operations.cont.CustomerSet where c is Company && (c as Company).INN == INNTextBox.Text select c).First();
                }
            }
            else
            {
                int id = int.Parse(CustomerDataGridView[Program.FindTitle(CustomerDataGridView, "Id"), CustomerDataGridView.SelectedRows[0].Index].Value.ToString());
                if (!BCompany)
                    customer = Operations.FindCustomer(id);
                else
                    customer = Operations.FindCompany(id);
            }
            if (city == null)
            {
                if (!Checker.IsName(CityTextBox.Text))
                {
                    MessageBox.Show("Неверное название города");
                    return;
                }
                if (!Operations.AddCity(CityTextBox.Text, out string Res))
                {
                    MessageBox.Show(Res);
                    return;
                }
                city = (from p in Operations.cont.CitySet where p.Name == CityTextBox.Text select p).First();
            }
            if (street == null)
            {
                if (!Checker.IsName(StreetTextBox.Text))
                {
                    MessageBox.Show("Неверное название улицы");
                    return;
                }
                if (!Operations.AddStreet(StreetTextBox.Text, city, out string Res1)){
                    MessageBox.Show(Res1);
                    return;
                }
                street = (from p in city.Street where p.Name == StreetTextBox.Text select p).First();
            }
            if (house == null)
            {
                if (!Checker.IsHouseNumber(HouseTextBox.Text))
                {
                    MessageBox.Show("Неверный номер дома");
                    return;
                }
                if (!Operations.AddHouse(HouseTextBox.Text, street, out string res2)){
                    MessageBox.Show(res2);
                    return;
                }
                house = (from p in street.House where p.Number == HouseTextBox.Text select p).First();
            }
            if (address == null) {
                if (!Checker.IsNumber(AddressTextBox.Text))
                {
                    MessageBox.Show("Неверный номер квартиры");
                    return;
                }
                if (!Operations.AddAddress(int.Parse(AddressTextBox.Text), house, out string Res4))
                {
                    MessageBox.Show(Res4);
                    return;
                }
                address = (from p in house.Address where p.Flat == int.Parse(AddressTextBox.Text) select p).First();
            }
            if (!Operations.AddOrder(CurrentUser, customer, address, out string res, out int order))
            {
                MessageBox.Show(res);
                return;
            }
            foreach (_OrderEntry o in OrderEntryList)
            {
                if (!Operations.AddOrderEntry(Operations.FindOrder(order), o.startTime, o.endTime, o.RegNum, Operations.FindMeter(o.MeterId), null, Operations.FindStatus(1), out string Res2))
                {
                    MessageBox.Show(Res2);
                    return;
                }
            }
            MessageBox.Show("Успешно добавлен заказ №" + order);
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
                Program.HideColumns(ref CustomerDataGridView, EntityTypes.Customer,CurrentUser);
                Program.Rename(ref CustomerDataGridView);
            }
            else
            {
                BCompany = true;
                CompanyNameTextBox.Enabled = true;
                INNTextBox.Enabled = true;
                CustomerDataGridView.DataSource = CompanyBindingList;
                Program.HideColumns(ref CustomerDataGridView, EntityTypes.Company,CurrentUser);
                Program.Rename(ref CustomerDataGridView);
            }
        }

        private void AddressTextBox_Leave(object sender, EventArgs e)
        {
            if (house!=null)
            {
                address = (from p in house.Address where p.Flat == int.Parse(AddressTextBox.Text) select p).FirstOrDefault();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (OrderEntryDataGridView.SelectedCells[0].OwningColumn.HeaderText)
            {
                case "startTime":
                    OrderEntryList[OrderEntryDataGridView.SelectedCells[0].RowIndex].startTime = dateTimePicker1.Value as DateTime?;
                    break;
                case "endTime":
                    OrderEntryList[OrderEntryDataGridView.SelectedCells[0].RowIndex].endTime = dateTimePicker1.Value as DateTime?;
                    break;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                NameTextBox.Visible = true;
                PassportTextBox.Visible = true;
                INNTextBox.Visible = true;
                CompanyNameTextBox.Visible = true;
                CustomerDataGridView.Visible = false;
            }else
            {
                NameTextBox.Visible = false;
                PassportTextBox.Visible = false;
                INNTextBox.Visible = false;
                CompanyNameTextBox.Visible = false;
                CustomerDataGridView.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (COrderEntryDataGridView.SelectedRows.Count > 0)
            {
                int id = int.Parse(COrderEntryDataGridView[Program.FindTitle(COrderEntryDataGridView, "Id"), COrderEntryDataGridView.SelectedRows[0].Index].Value.ToString());
                OrderEntry orderEntry = (from o in CurrentOrder.OrderEntry where o.Id == id select o).First();
                OPOrderEntry oPOrderEntry = new OPOrderEntry();
                oPOrderEntry.FormClosed += (object s, FormClosedEventArgs args) => COrderEntryDataGridView.Refresh();
                oPOrderEntry.Show();
                oPOrderEntry.Change(orderEntry);
                oPOrderEntry.Id = id;
            }
        }
        Order CurrentOrder;
        private void COrderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (COrderDataGridView.SelectedRows.Count > 0)
            {
                int id = int.Parse(COrderDataGridView[Program.FindTitle(COrderDataGridView, "Идентификационный номер"), COrderDataGridView.SelectedRows[0].Index].Value.ToString());
                CurrentOrder = (from o in Operations.cont.OrderSet where o.Id == id select o).First();
                BindingList<OrderEntry> bindingList = new BindingList<OrderEntry>(CurrentOrder.OrderEntry.ToList());
                COrderEntryDataGridView.DataSource = bindingList;
                Program.HideColumns(ref COrderEntryDataGridView, EntityTypes.OrderEntry, CurrentUser);
                Program.Rename(ref COrderEntryDataGridView);
                COrderEntryDataGridView.Refresh();
                COrderEntryDataGridView.ClearSelection();
            }
        }
        _Address address1;
        _House house1;
        _Street street1;
        _City city1;
        _Customer customer1;
        Excel.Application application = null;
        Excel.Workbook workbook = null;
        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Excel.Worksheet worksheet = null;
                Excel.Range range = null;
                try
                {
                    application = new Excel.Application();
                    workbook = application.Workbooks.Open(openFileDialog1.FileName);
                    application.Visible = true;
                    worksheet = workbook.Worksheets[1];
                    range = worksheet.UsedRange;
                    string CityName = range.Cells[1, 2].Value2.ToString();
                    string StreetName = range.Cells[2, 2].Value2.ToString();
                    string HouseNumber = range.Cells[3, 2].Value2.ToString();
                    string FlatNumber = range.Cells[4, 2].Value2.ToString();
                    string FIO = range.Cells[5, 2].Value2.ToString();
                    string PassportNumber = range.Cells[6, 2].Value2.ToString();
                    string PhoneNumber = range.Cells[7, 2].Value2.ToString();
                    string CompanyName = range.Cells[8, 2].Value2.ToString();
                    string INN = range.Cells[9, 2].Value2.ToString();
                    string ErrorMsg = string.Empty;
                    bool NotCompany = CompanyName.Length == 0 && INN.Length == 0;
                    if (!Checker.IsName(CityName))
                    {
                        ErrorMsg += "Неверная строка в названии города\n";
                    }
                    if (!Checker.IsName(StreetName))
                    {
                        ErrorMsg += "Неверная строка в названии улицы\n";
                    }
                    if (!Checker.IsHouseNumber(HouseNumber))
                    {
                        ErrorMsg += "Неверная строка в номере дома\n";
                    }
                    if (!Checker.IsNumber(FlatNumber))
                    {
                        ErrorMsg += "Неверная строка в номере квартиры\n";
                    }
                    if (!Checker.IsFIO(FIO))
                    {
                        ErrorMsg += "Неверная строка в ФИО\n";
                    }
                    if (!Checker.IsPassportNumber(PassportNumber))
                    {
                        ErrorMsg += "Неверная строка в номере паспорта\n";
                    }
                    if (!Checker.IsPhoneNumber(PhoneNumber))
                    {
                        ErrorMsg += "Неверная строка в номере телефона\n";
                    }
                    if (!Checker.IsName(CompanyName) && !NotCompany)
                    {
                        ErrorMsg += "Неверная строка в названии организации\n";
                    }
                    if (!Checker.IsINN(INN) && !NotCompany)
                    {
                        ErrorMsg += "Неверная строка в ИНН\n";
                    }
                    if (ErrorMsg.Length == 0)
                    {
                        _City _City = new _City { Name = CityName };
                        _Street _Street = new _Street { Name = StreetName };
                        _House _House = new _House { Number = HouseNumber };
                        _Address _Address = new _Address { Flat = int.Parse(FlatNumber) };
                        _Customer _Customer;
                        if (NotCompany)
                        {
                            _Customer = new _Customer() { FIO = FIO, Passport = PassportNumber, PhoneNumber = PhoneNumber };
                        }
                        else _Customer = new _Company() { FIO = FIO, Passport = PassportNumber, PhoneNumber = PhoneNumber, CompanyName = CompanyName, INN = INN };
                        List<_OrderEntry> list = new List<_OrderEntry>();
                        int row = 2;
                        while (range[row, 4] != null && range[row,4].Value2 != null && range[row, 4].Value2.ToString().Length > 0 && ErrorMsg.Length == 0)
                        {
                            string MeterId = range[row, 4].Value2.ToString();
                            if (!Checker.IsNumber(MeterId))
                            {
                                ErrorMsg += "Неверная строка в номере счётчика\n";
                            }
                            DateTime StartTime = default(DateTime), EndTime = default(DateTime);
                            if (range[row, 5] != null && range[row, 5].Value2 != null)
                            {
                                string sStartTime = range[row, 5].Value2.ToString();
                                if (sStartTime.Length > 0 && double.TryParse(sStartTime, out double dstart))
                                {
                                    StartTime = DateTime.FromOADate(dstart);
                                }
                                else
                                {
                                    ErrorMsg += "Неверная строка во времени начала\n";
                                }
                            }
                           
                            if (range[row, 6] != null && range[row, 6].Value2 != null)
                            {
                                string sEndTime = range[row, 6].Value2.ToString();
                                if (sEndTime.Length > 0 && double.TryParse(sEndTime, out double dend))
                                {
                                    EndTime = DateTime.FromOADate(dend);
                                }
                                else
                                {
                                    ErrorMsg += "Неверная строка во времени конца\n";
                                }
                            }
                            if (StartTime != default(DateTime) && EndTime != default(DateTime) && StartTime > EndTime)
                            {
                                ErrorMsg += "Дата начала позже даты конца\n";
                            }
                            if (ErrorMsg.Length == 0)
                            {
                                var ord = new _OrderEntry { MeterId = int.Parse(MeterId) };
                                if (StartTime != default(DateTime)) ord.startTime = StartTime;
                                if (EndTime != default(DateTime)) ord.endTime = EndTime;
                                list.Add(ord);
                                ++row;
                            }
                        }
                        if (ErrorMsg.Length == 0)
                        {
                            try
                            {
                                dataGridView1.DataSource = list;
                                Program.HideColumns(ref dataGridView1, EntityTypes.OrderEntry, CurrentUser);
                                Program.HidaColumns(ref dataGridView1, new List<string> { "Id", "OrderId", "StatusId", "RegNum" });
                                Program.Rename(ref dataGridView1);
                                address1 = _Address;
                                house1 = _House;
                                street1 = _Street;
                                city1 = _City;
                                customer1 = _Customer;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(ErrorMsg);
                        }
                    }
                    else
                    {
                        MessageBox.Show(ErrorMsg);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (range!=null) Marshal.ReleaseComObject(range);
                    if (worksheet!=null) Marshal.ReleaseComObject(worksheet);
                    
                }
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (address1 != null)
            {
                Operations.cont.AddressSet.Load();
                Operations.cont.HouseSet.Load();
                Operations.cont.StreetSet.Load();
                Operations.cont.CitySet.Load();
                Operations.cont.CustomerSet.Load();
                int cityid;
                if (!Operations.SelectCitys((s) => s.Name == city1.Name).Any())
                {
                    if (!Operations.AddCity(city1.Name, out string Res))
                    {
                        MessageBox.Show(Res);
                        return;
                    }
                }
                cityid = Operations.SelectCitys((s) => s.Name == city1.Name).First().Id;
                int streetid;
                if (!Operations.SelectStreets((s)=>s.Name == street1.Name && s.City.Id == cityid).Any())
                {
                    if (!Operations.AddStreet(street1.Name,Operations.FindCity(cityid),out string Res))
                    {
                        MessageBox.Show(Res);
                        return;
                    }
                }
                streetid = Operations.SelectStreets((s) => s.Name == street1.Name && s.City.Id == cityid).First().Id;
                int houseid;
                if (!Operations.SelectHouses((s) => s.Number == house1.Number && s.Street.Id == streetid).Any())
                {
                    if (!Operations.AddHouse(house1.Number, Operations.FindStreet(streetid), out string Res))
                    {
                        MessageBox.Show(Res);
                        return;
                    }
                }
                houseid = Operations.SelectHouses((s) => s.Number == house1.Number && s.Street.Id == streetid).First().Id;
                int addressid;
                if (!Operations.SelectAddresss((s) => s.Flat == address1.Flat && s.House.Id == houseid).Any())
                {
                    if (!Operations.AddAddress(address1.Flat, Operations.FindHouse(houseid), out string Res))
                    {
                        MessageBox.Show(Res);
                        return;
                    }
                }
                addressid = Operations.SelectAddresss((s) => s.Flat == address1.Flat && s.House.Id == houseid).First().Id;
                int customerid;
                if (customer1 is _Company comp)
                {
                    if (!Operations.SelectCustomers((s) => (s is Company) && (s as Company).INN == (comp.INN)).Any())
                        if (!Operations.AddCompany(comp.FIO, comp.Passport,comp.PhoneNumber,comp.CompanyName,comp.INN,out string Res))
                        {
                            MessageBox.Show(Res);
                            return;
                        }
                    customerid = Operations.SelectCustomers((s) => (s is Company) && (s as Company).INN == (comp.INN)).First().Id;
                }
                else
                {
                    if (!Operations.SelectCustomers((s)=>!(s is Company)&&s.Passport == customer1.Passport).Any())
                        if (!Operations.AddCustomer(customer1.FIO, customer1.Passport,customer1.PhoneNumber,out string Res))
                        {
                            MessageBox.Show(Res);
                            return;
                        }
                    customerid = Operations.SelectCustomers((s) => !(s is Company) && s.Passport == customer1.Passport).First().Id;
                }
                if (!Operations.AddOrder(CurrentUser,Operations.FindCustomer(customerid),Operations.FindAddress(addressid),out string Res1, out int orderid)){
                    MessageBox.Show(Res1);
                    return;
                }
                List<_OrderEntry> list = dataGridView1.DataSource as List<_OrderEntry>;
                if (list == null)
                {
                    MessageBox.Show("Не удалось загрузить список заказных позиций");
                    return;
                }
                foreach( _OrderEntry ord in list)
                {
                    Meter meter = Operations.FindMeter(ord.MeterId);
                    if (meter == null)
                    {
                        MessageBox.Show("Не удалось найти счётчик");
                        break;
                    }
                    if (!Operations.AddOrderEntry(Operations.FindOrder(orderid),ord.startTime,ord.endTime,null,meter,null,Operations.FindStatus(1),out string Res))
                    {
                        MessageBox.Show(Res);
                        break;
                    }
                }
                MessageBox.Show("Добавлен заказ номер" + orderid);
            }
        }


        

        private void OperatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workbook != null)
            {
                Marshal.ReleaseComObject(workbook);
            }
            if (application != null)
            { 
                Marshal.ReleaseComObject(application);
            }
        }


    }
}
