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
    public partial class CustomQueryForm : Form
    {
        public CustomQueryForm()
        {
            InitializeComponent();
        }

        private void CustomQueryForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(EntityTypes));
            Loaded = true;
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        bool Loaded = false;
        object CurrentCol;
        EntityTypes entityTypes;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loaded && comboBox1.SelectedIndex != -1)
            {
                flowLayoutPanel1.Controls.Clear();
                button1.Enabled = true;
                TextBox textBox = new TextBox();
                entityTypes = (EntityTypes)Enum.Parse(typeof(EntityTypes), comboBox1.SelectedValue.ToString());
                textBox.Text = entityTypes.ToString();
                textBox.ReadOnly = true;
                flowLayoutPanel1.Controls.Add(textBox);
                GetCombobox2Items();
                comboBox1.Enabled = false;
            }
        }

        private void GetCombobox3Items()
        {
            comboBox3.Items.Clear();
            switch (comboBox2.Text)
            {
                case "Name":
                case "CompanyName":
                case "Number":
                case "INN":
                case "Passport":
                case "Login":
                case "UserType":
                case "FIO":
                    comboBox3.Items.Add("Равно");
                    comboBox3.Items.Add("Неравно");
                    break;
                case "StartTime":
                case "EndTime":
                    comboBox3.Items.Add("Задано");
                    comboBox3.Items.Add("Незадано");
                    comboBox3.Items.Add("Больше");
                    comboBox3.Items.Add("Меньше");
                    comboBox3.Items.Add("Небольше");
                    comboBox3.Items.Add("Неменьше");
                    comboBox3.Items.Add("Равно");
                    comboBox3.Items.Add("Неравно");
                    break;
                case "Flat":
                case "Id":
                    comboBox3.Items.Add("Больше");
                    comboBox3.Items.Add("Меньше");
                    comboBox3.Items.Add("Равно");
                    comboBox3.Items.Add("Небольше");
                    comboBox3.Items.Add("Неменьше");
                    comboBox3.Items.Add("Неравно");
                    break;
                case "Person":
                    comboBox3.Items.Add("Вход");
                    comboBox3.Items.Add("Задано");
                    comboBox3.Items.Add("Незадано");
                    break;
                default:
                    comboBox3.Items.Add("Вход");
                    break;
            }
        }

        private void GetCombobox2Items()
        {
            comboBox2.Items.Clear();
            switch (entityTypes)
            {
                case EntityTypes.Address:
                    comboBox2.Items.Add("Flat");
                    comboBox2.Items.Add("House");
                    break;
                case EntityTypes.City:
                    comboBox2.Items.Add("Name");
                    break;
                case EntityTypes.Company:
                    comboBox2.Items.Add("Name");
                    comboBox2.Items.Add("Passport");
                    comboBox2.Items.Add("CompanyName");
                    comboBox2.Items.Add("INN");
                    break;
                case EntityTypes.Customer:
                    comboBox2.Items.Add("Name");
                    comboBox2.Items.Add("Passport");
                    break;
                case EntityTypes.CustomerOrCompany:
                    comboBox2.Items.Add("Name");
                    comboBox2.Items.Add("Passport");
                    break;
                case EntityTypes.House:
                    comboBox2.Items.Add("Number");
                    comboBox2.Items.Add("Street");
                    break;
                case EntityTypes.Meter:
                    comboBox2.Items.Add("Name");
                    comboBox2.Items.Add("MeterType");
                    break;
                case EntityTypes.MeterType:
                    comboBox2.Items.Add("Name");
                    break;
                case EntityTypes.Order:
                    comboBox2.Items.Add("Id");
                    comboBox2.Items.Add("User");
                    comboBox2.Items.Add("Customer");
                    comboBox2.Items.Add("Company");
                    comboBox2.Items.Add("CustomerOrCompany");
                    break;
                case EntityTypes.OrderEntry:
                    comboBox2.Items.Add("Meter");
                    comboBox2.Items.Add("Person");
                    comboBox2.Items.Add("StartTime");
                    comboBox2.Items.Add("EndTime");
                    comboBox2.Items.Add("Status");
                    comboBox2.Items.Add("Order");
                    break;
                case EntityTypes.Person:
                    comboBox2.Items.Add("FIO");
                    break;
                case EntityTypes.Status:
                    comboBox2.Items.Add("Name");
                    break;
                case EntityTypes.Stavka:
                    comboBox2.Items.Add("Person");
                    comboBox2.Items.Add("MeterType");
                    break;
                case EntityTypes.Street:
                    comboBox2.Items.Add("Name");
                    comboBox2.Items.Add("City");
                    break;
                case EntityTypes.User:
                    comboBox2.Items.Add("Login");
                    comboBox2.Items.Add("UserType");
                    break;
            }
        }
        private bool DeepOp;
        private void button1_Click(object sender, EventArgs e)
        {
            DeepOp = false;
            switch (entityTypes)
            {
                case EntityTypes.Address:
                    NextAddress();
                    break;
                case EntityTypes.City:
                    NextCity();
                    break;
                case EntityTypes.Company:
                    NextCompany();
                    break;
                case EntityTypes.Customer:
                    NextCustomer();
                    break;
                case EntityTypes.CustomerOrCompany:
                    NextCustomerOrCompany();
                    break;
                case EntityTypes.House:
                    NextHouse();
                    break;
                case EntityTypes.Meter:
                    NextMeter();
                    break;
                case EntityTypes.MeterType:
                    NextMeterType();
                    break;
                case EntityTypes.Order:
                    NextOrder();
                    break;
                case EntityTypes.OrderEntry:
                    NextOrderEntry();
                    break;
                case EntityTypes.Person:
                    NextPerson();
                    break;
                case EntityTypes.Status:
                    NextStatus();
                    break;
                case EntityTypes.Stavka:
                    NextStavka();
                    break;
                case EntityTypes.Street:
                    NextStreet();
                    break;
                case EntityTypes.User:
                    NextUser();
                    break;
            }
            if (TypeOfOperations.ContainsKey(entityTypes) && !DeepOp)
                Merge();
            GetCombobox2Items();
        }
        private Stack<EntityTypes> stack = new Stack<EntityTypes>();
        private TextBox textb (string Message)
        {
            Size size = TextRenderer.MeasureText(Message, textBox1.Font);
            return new TextBox()
            {
                Text = Message,
                ReadOnly = true,
                Width = size.Width,
                Height = size.Height,
                Font = textBox1.Font
            };
        }
        private void NextAddress()
        {
            if (comboBox2.Text == "Flat")
            {
                Func<Address, bool> pred=null;
                switch (comboBox3.Text)
                {
                    case "Больше":
                        pred = (Address a) => a.Flat > int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Flat>" + textBox1.Text });
                        break;
                    case "Меньше":
                        pred = (Address a) => a.Flat < int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Flat<" + textBox1.Text });
                        break;
                    case "Равно":
                        pred = (Address a) => a.Flat == int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Flat==" + textBox1.Text });
                        break;
                    case "Небольше":
                        pred = (Address a) => a.Flat <= int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Flat<=" + textBox1.Text });
                        break;
                    case "Неменьше":
                        pred = (Address a) => a.Flat >= int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Flat>=" + textBox1.Text });
                        break;
                    case "Неравно":
                        pred = (Address a) => a.Flat != int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Flat!=" + textBox1.Text });
                        break;
                }
                CurrentCol = Operations.SelectAddresss(pred, (a) => a);
            }else
            {
                stack.Push(entityTypes);
                entityTypes = EntityTypes.House;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;
            }
        }
        private void NextCity()
        {
            Func<City, bool> pred = null;
            switch (comboBox3.Text)
            {
                case "Равно":
                    pred = (City c) => c.Name == textBox1.Text;
                    flowLayoutPanel1.Controls.Add(textb("Name==" + textBox1.Text ));
                    break;
                case "Неравно":
                    pred = (City c) => c.Name != textBox1.Text;
                    flowLayoutPanel1.Controls.Add(textb("Name!=" + textBox1.Text));

                    break;
            }
            CurrentCol = Operations.SelectCitys(pred, (c) => c);
        }
        private void NextCompany()
        {
            Func<Customer, bool> pred = null;
            if (comboBox2.Text == "Name")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) =>c is Company &&  c.Name == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name==" + textBox1.Text));
                        break;
                    case "Неравно":
                        pred = (Customer c) => c is Company && c.Name != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name!=" + textBox1.Text));

                        break;
                }
            }else if (comboBox2.Text == "Passport")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => c is Company && c.Passport == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Passport==" + textBox1.Text));

                        break;
                    case "Неравно":
                        pred = (Customer c) => c is Company && c.Passport != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Passport!=" + textBox1.Text));
                        break;
                }
            }
            else if (comboBox2.Text == "CompanyName")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => c is Company && (c as Company).CompanyName == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("CompanyName==" + textBox1.Text));

                        break;
                    case "Неравно":
                        pred = (Customer c) => c is Company && (c as Company).CompanyName != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("CompanyName!=" + textBox1.Text));

                        break;
                }
            }
            else if (comboBox2.Text == "INN")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => c is Company && (c as Company).INN == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("INN==" + textBox1.Text));

                        break;
                    case "Неравно":
                        pred = (Customer c) => c is Company && (c as Company).INN != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("INN!=" + textBox1.Text));

                        break;
                }
            }
            CurrentCol = Operations.SelectCustomers(pred, (c) => c);
        }
        private void NextCustomer()
        {
            Func<Customer, bool> pred = null;
            if (comboBox2.Text == "Name")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => !(c is Company) && c.Name == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name==" + textBox1.Text));

                        break;
                    case "Неравно":
                        pred = (Customer c) => !(c is Company) && c.Name != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name!=" + textBox1.Text));

                        break;
                }
            }
            else if (comboBox2.Text == "Passport")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => !(c is Company) && c.Passport == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Passport==" + textBox1.Text ));

                        break;
                    case "Неравно":
                        pred = (Customer c) => !(c is Company) && c.Passport != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Passport!=" + textBox1.Text));

                        break;
                }
            }
            CurrentCol = Operations.SelectCustomers(pred, (c) => c);
        }
        private void NextCustomerOrCompany()
        {
            Func<Customer, bool> pred = null;
            if (comboBox2.Text == "Name")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) =>  c.Name == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name==" + textBox1.Text ));

                        break;
                    case "Неравно":
                        pred = (Customer c) =>  c.Name != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name!=" + textBox1.Text ));

                        break;
                }
            }
            else if (comboBox2.Text == "Passport")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => c.Passport == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Passport==" + textBox1.Text));

                        break;
                    case "Неравно":
                        pred = (Customer c) => c.Passport != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Passport!=" + textBox1.Text));

                        break;                                    
                }
            }
            CurrentCol = Operations.SelectCustomers(pred, (c) => c);
        }
        private void NextHouse()
        {
            if (comboBox2.Text == "Number")
            {
                Func<House, bool> pred = null;
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (a) => a.Number == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Number==" + textBox1.Text));

                        break;
                    case "Неравно":
                        pred = (a) => a.Number != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Number!=" + textBox1.Text));

                        break;
                }
                CurrentCol = Operations.SelectHouses(pred, (a) => a);
            }else
            {
                stack.Push(EntityTypes.House);
                entityTypes = EntityTypes.Street;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));

                DeepOp = true;
            }
        }
        private void NextMeter()
        {
            if (comboBox2.Text == "Name")
            {
                Func<Meter, bool> pred = null;
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (a) => a.Name == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name==" + textBox1.Text));
                        break;
                    case "Неравно":
                        pred = (a) => a.Name != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name!=" + textBox1.Text));
                        break;
                }
                CurrentCol = Operations.SelectMeters(pred, (a) => a);
            }
            else
            {
                stack.Push(EntityTypes.Meter);
                entityTypes = EntityTypes.MeterType;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
        }
        private void NextMeterType()
        {
            Func<MeterType, bool> pred = null;
            switch (comboBox3.Text)
            {
                case "Равно":
                    pred = (MeterType c) => c.Name == textBox1.Text;
                    flowLayoutPanel1.Controls.Add(textb("Name==" + textBox1.Text));
                    break;
                case "Неравно":
                    pred = (MeterType c) => c.Name != textBox1.Text;
                    flowLayoutPanel1.Controls.Add(textb("Name!=" + textBox1.Text));
                    break;
            }
            CurrentCol = Operations.SelectMeterTypes(pred, (c) => c);
        }
        private void NextOrder()
        {
            if (comboBox2.Text == "Id")
            {
                Func<Order, bool> pred = null;
                switch (comboBox3.Text)
                {
                    case "Больше":
                        pred = (Order a) => a.Id > int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("Id>" + textBox1.Text ));
                        break;
                    case "Меньше":
                        pred = (Order a) => a.Id < int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("Id<" + textBox1.Text));

                        break;
                    case "Равно":
                        pred = (Order a) => a.Id == int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("Id==" + textBox1.Text));

                        break;
                    case "Небольше":
                        pred = (Order a) => a.Id <= int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("Id<=" + textBox1.Text));

                        break;
                    case "Неменьше":
                        pred = (Order a) => a.Id >= int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("Id>" + textBox1.Text));

                        break;
                    case "Неравно":
                        pred = (Order a) => a.Id != int.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("Id!=" + textBox1.Text));

                        break;
                }
                CurrentCol = Operations.SelectOrders(pred, (c) => c);
            }else if (comboBox2.Text == "User")
            {
                stack.Push(EntityTypes.Order);
                entityTypes = EntityTypes.User;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Customer")
            {
                stack.Push(EntityTypes.Order);
                entityTypes = EntityTypes.Customer;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Company")
            {
                stack.Push(EntityTypes.Order);
                entityTypes = EntityTypes.Company;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "CustomerOrCompany")
            {
                stack.Push(EntityTypes.Order);
                entityTypes = EntityTypes.CustomerOrCompany;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
        }
        private void NextOrderEntry()
        {
            if (comboBox2.Text == "Meter")
            {
                stack.Push(EntityTypes.OrderEntry);
                entityTypes = EntityTypes.Meter;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Person")
            {
                switch (comboBox3.Text)
                {
                    case "Вход":
                        stack.Push(EntityTypes.OrderEntry);
                        entityTypes = EntityTypes.Person;
                        break;
                    case "Задано":
                        Func<OrderEntry, bool> pred = (c) => c.PersonId != null;
                        CurrentCol = Operations.SelectOrderEntrys(pred, (c) => c);
                        flowLayoutPanel1.Controls.Add(textb("PersonId задано"));
                        break;
                    case "Незадано":
                        pred = (c) => c.PersonId == null;
                        CurrentCol = Operations.SelectOrderEntrys(pred, (c) => c);
                        flowLayoutPanel1.Controls.Add(textb("PersonId незадано"));

                        break;
                }
            }else if (comboBox2.Text == "StartTime")
            {
                Func<OrderEntry, bool> pred = null;
                switch (comboBox3.Text)
                {
                    case "Задано":
                        pred = (c) => c.StartTime != null;
                        flowLayoutPanel1.Controls.Add(textb("StartTime задано"));
                        break;
                    case "Незадано":
                        pred = (c) => c.StartTime == null;
                        flowLayoutPanel1.Controls.Add(textb("StartTime незадано"));
                        break;
                    case "Больше":
                        pred = (c) => c.StartTime > DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("StartTime>" + textBox1.Text));
                        break;
                    case "Меньше":
                        pred = (c) => c.StartTime < DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("StartTime<" + textBox1.Text));
                        break;
                    case "Равно":
                        pred = (c) => c.StartTime !=  DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("StartTime==" + textBox1.Text));

                        break;
                    case "Небольше":
                        pred = (c) => c.StartTime <= DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("StartTime<=" + textBox1.Text));

                        break;
                    case "Неменьше":
                        pred = (c) => c.StartTime >= DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("StartTime>=" + textBox1.Text));

                        break;
                    case "Неравно":
                        pred = (c) => c.StartTime != DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("StartTime !=" + textBox1.Text));
                        break;
                }
                CurrentCol = Operations.SelectOrderEntrys(pred, (c) => c);
            }else if (comboBox2.Text == "EndTime")
            {
                Func<OrderEntry, bool> pred = null;
                switch (comboBox3.Text)
                {
                    case "Задано":
                        pred = (c) => c.EndTime != null;
                        flowLayoutPanel1.Controls.Add(textb("EndTime задано"));
                        break;
                    case "Незадано":
                        pred = (c) => c.EndTime == null;
                        flowLayoutPanel1.Controls.Add(textb("EndTime незадано"));
                        break;
                    case "Больше":
                        pred = (c) => c.EndTime > DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("EndTime>" + textBox1.Text));
                        break;
                    case "Меньше":
                        pred = (c) => c.EndTime < DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("EndTime<" + textBox1.Text));
                        break;
                    case "Равно":
                        pred = (c) => c.EndTime != DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("EndTime==" + textBox1.Text));
                        break;
                    case "Небольше":
                        pred = (c) => c.EndTime <= DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("EndTime<=" + textBox1.Text));
                        break;
                    case "Неменьше":
                        pred = (c) => c.EndTime >= DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("EndTime>=" + textBox1.Text));
                        break;
                    case "Неравно":
                        pred = (c) => c.EndTime != DateTime.Parse(textBox1.Text);
                        flowLayoutPanel1.Controls.Add(textb("EndTime !=" + textBox1.Text));
                        break;
                }
                CurrentCol = Operations.SelectOrderEntrys(pred, (c) => c);
            }else if (comboBox2.Text == "Status")
            {
                stack.Push(EntityTypes.OrderEntry);
                entityTypes = EntityTypes.Status;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Order")
            {
                stack.Push(EntityTypes.OrderEntry);
                entityTypes = EntityTypes.Order;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
        }
        private void NextPerson()
        {
            Func<Person, bool> pred = null;
            switch (comboBox3.Text)
            {
                case "Равно":
                    pred = (Person c) => c.FIO == textBox1.Text;
                    flowLayoutPanel1.Controls.Add(textb("FIO==" + textBox1.Text ));
                    break;
                case "Неравно":
                    pred = (Person c) => c.FIO != textBox1.Text;
                    flowLayoutPanel1.Controls.Add(textb("FIO!=" + textBox1.Text));
                    break;
            }
            CurrentCol = Operations.SelectPersons(pred, (c) => c);
        }
        private void NextStatus()
        {
            Func<Status, bool> pred = null;
            switch (comboBox3.Text)
            {
                case "Равно":
                    pred = (Status c) => c.Name == textBox1.Text;
                    flowLayoutPanel1.Controls.Add(textb("Name==" + textBox1.Text));
                    break;
                case "Неравно":
                    pred = (Status c) => c.Name != textBox1.Text;
                    flowLayoutPanel1.Controls.Add(textb("Name!=" + textBox1.Text));
                    break;
            }
            CurrentCol = Operations.SelectStatuss(pred, (c) => c);
        }
        private void NextStavka()
        {
            if (comboBox2.Text == "MeterType")
            {
                stack.Push(EntityTypes.Stavka);
                entityTypes = EntityTypes.MeterType;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else
            {
                stack.Push(EntityTypes.Stavka);
                entityTypes = EntityTypes.Person;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
        }
        private void NextStreet()
        {
            if (comboBox2.Text == "Name")
            {
                Func<Street, bool> pred = null;
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (a) => a.Name == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name==" + textBox1.Text));
                        break;
                    case "Неравно":
                        pred = (a) => a.Name != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Name!=" + textBox1.Text));
                        break;
                }
                CurrentCol = Operations.SelectStreets(pred, (a) => a);
            }else
            {
                stack.Push(EntityTypes.Street);
                entityTypes = EntityTypes.City;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
        }
        private void NextUser()
        {
            Func<User, bool> pred = null;
            if (comboBox2.Text == "Login")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (a) => a.Login == textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Login==" + textBox1.Text));
                        break;
                    case "Неравно":
                        pred = (a) => a.Login != textBox1.Text;
                        flowLayoutPanel1.Controls.Add(textb("Login!=" + textBox1.Text));
                        break;
                }
            }else
            {
                UserType userType;
                if (Enum.TryParse(textBox1.Text, out userType))
                {
                    switch (comboBox3.Text)
                    {
                        case "Равно":
                            pred = (a) => a.UserType == userType;
                            flowLayoutPanel1.Controls.Add(textb("UserType==" + userType));
                            break;
                        case "Неравно":
                            pred = (a) => a.UserType != userType;
                            flowLayoutPanel1.Controls.Add(textb("UserType!=" + userType));
                            break;
                    }
                }
            }
            CurrentCol = Operations.SelectUsers(pred, (a) => a);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCombobox3Items();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (stack.Count == 0) return;
            EntityTypes entityTypes1 = stack.Pop();
            switch (entityTypes1)
            {
                case EntityTypes.Address:
                    var PrevCol = CurrentCol as IEnumerable<House>;
                    CurrentCol = Operations.SelectAddresss((Address a) => PrevCol.Contains(a.House), a => a);
                    break;
                case EntityTypes.House:
                    var PrevCol1 = CurrentCol as IEnumerable<Street>;
                    CurrentCol = Operations.SelectHouses((House s) => PrevCol1.Contains(s.Street), a => a);
                    break;
                case EntityTypes.Meter:
                    var PrevCol2 = CurrentCol as IEnumerable<MeterType>;
                    CurrentCol = Operations.SelectMeters((Meter m) => PrevCol2.Contains(m.MeterType), a => a);
                break;
                case EntityTypes.Order:
                    if (entityTypes == EntityTypes.User)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<User>;
                        CurrentCol = Operations.SelectOrders((Order o) => PrevCol3.Contains(o.User), a => a);
                    }else if (entityTypes == EntityTypes.Customer||entityTypes==EntityTypes.Company|| entityTypes == EntityTypes.CustomerOrCompany)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Customer>;
                        CurrentCol = Operations.SelectOrders((Order s) => PrevCol3.Contains(s.Customer), a => a);
                    }else if (entityTypes == EntityTypes.Address)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Address>;
                        CurrentCol = Operations.SelectOrders((Order s) => PrevCol3.Contains(s.Address), a => a);
                    }
                    break;
                case EntityTypes.OrderEntry:
                    if (entityTypes == EntityTypes.Order)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Order>;
                        CurrentCol = Operations.SelectOrderEntrys((OrderEntry o) => PrevCol3.Contains(o.Order), a => a);
                    }else if (entityTypes == EntityTypes.Meter)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Meter>;
                        CurrentCol = Operations.SelectOrderEntrys((OrderEntry o) => PrevCol3.Contains(o.Meter), a => a);
                    }else if (entityTypes == EntityTypes.Person)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Person>;
                        CurrentCol = Operations.SelectOrderEntrys((OrderEntry o) => PrevCol3.Contains(o.Person), a => a);
                    }else if (entityTypes == EntityTypes.Status)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Status>;
                        CurrentCol = Operations.SelectOrderEntrys((OrderEntry o) => PrevCol3.Contains(o.Status), a => a);
                    }
                    break;
                case EntityTypes.Stavka:
                    if (entityTypes == EntityTypes.MeterType)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<MeterType>;
                        CurrentCol = Operations.SelectStavkas((Stavka o) => PrevCol3.Contains(o.MeterType), a => a);
                    }else if (entityTypes == EntityTypes.Person)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Person>;
                        CurrentCol = Operations.SelectStavkas((Stavka o) => PrevCol3.Contains(o.Person), a => a);
                    }
                    break;
                case EntityTypes.Street:
                    var PrevCol4 = CurrentCol as IEnumerable<City>;
                    CurrentCol = Operations.SelectStreets((Street o) => PrevCol4.Contains(o.City), a => a);
                    break;
            }
            entityTypes = entityTypes1;
            if (TypeOfOperations.ContainsKey(entityTypes))
            {
                Merge();
            }
            GetCombobox2Items();
            flowLayoutPanel1.Controls.Add(textb(")"));
        }
        private void Merge()
        {
            switch (entityTypes)
            {
                case EntityTypes.Address:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Address>).Union(TempCols[entityTypes] as IEnumerable<Address>);
                    }else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Address>).Intersect(TempCols[entityTypes] as IEnumerable<Address>);
                    }
                    break;
                case EntityTypes.City:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<City>).Union(TempCols[entityTypes] as IEnumerable<City>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<City>).Intersect(TempCols[entityTypes] as IEnumerable<City>);
                    }
                    break;
                case EntityTypes.Company:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Customer>).Union(TempCols[entityTypes] as IEnumerable<Customer>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Customer>).Intersect(TempCols[entityTypes] as IEnumerable<Customer>);
                    }
                    break;
                case EntityTypes.Customer:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Customer>).Union(TempCols[entityTypes] as IEnumerable<Customer>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Customer>).Intersect(TempCols[entityTypes] as IEnumerable<Customer>);
                    }
                    break;
                case EntityTypes.CustomerOrCompany:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Customer>).Union(TempCols[entityTypes] as IEnumerable<Customer>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Customer>).Intersect(TempCols[entityTypes] as IEnumerable<Customer>);
                    }
                    break;
                case EntityTypes.House:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<House>).Union(TempCols[entityTypes] as IEnumerable<House>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<House>).Intersect(TempCols[entityTypes] as IEnumerable<House>);
                    }
                    break;
                case EntityTypes.Meter:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Meter>).Union(TempCols[entityTypes] as IEnumerable<Meter>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Meter>).Intersect(TempCols[entityTypes] as IEnumerable<Meter>);
                    }
                    break;
                case EntityTypes.MeterType:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<MeterType>).Union(TempCols[entityTypes] as IEnumerable<MeterType>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<MeterType>).Intersect(TempCols[entityTypes] as IEnumerable<MeterType>);
                    }
                    break;
                case EntityTypes.Order:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Order>).Union(TempCols[entityTypes] as IEnumerable<Order>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Order>).Intersect(TempCols[entityTypes] as IEnumerable<Order>);
                    }
                    break;
                case EntityTypes.OrderEntry:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<OrderEntry>).Union(TempCols[entityTypes] as IEnumerable<OrderEntry>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<OrderEntry>).Intersect(TempCols[entityTypes] as IEnumerable<OrderEntry>);
                    }
                    break;
                case EntityTypes.Person:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Person>).Union(TempCols[entityTypes] as IEnumerable<Person>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Person>).Intersect(TempCols[entityTypes] as IEnumerable<Person>);
                    }
                    break;
                case EntityTypes.Status:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Status>).Union(TempCols[entityTypes] as IEnumerable<Status>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Status>).Intersect(TempCols[entityTypes] as IEnumerable<Status>);
                    }
                    break;
                case EntityTypes.Stavka:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Stavka>).Union(TempCols[entityTypes] as IEnumerable<Stavka>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Stavka>).Intersect(TempCols[entityTypes] as IEnumerable<Stavka>);
                    }
                    break;
                case EntityTypes.Street:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Street>).Union(TempCols[entityTypes] as IEnumerable<Street>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<Street>).Intersect(TempCols[entityTypes] as IEnumerable<Street>);
                    }
                    break;
                case EntityTypes.User:
                    if (TypeOfOperations[entityTypes])
                    {
                        CurrentCol = (CurrentCol as IEnumerable<User>).Union(TempCols[entityTypes] as IEnumerable<User>);
                    }
                    else
                    {
                        CurrentCol = (CurrentCol as IEnumerable<User>).Intersect(TempCols[entityTypes] as IEnumerable<User>);
                    }
                    break;
            }
            TempCols.Remove(entityTypes);
            TypeOfOperations.Remove(entityTypes);
        }
        private Dictionary<EntityTypes, object> TempCols = new Dictionary<EntityTypes, object>();
        private Dictionary<EntityTypes, bool> TypeOfOperations = new Dictionary<EntityTypes, bool>();
        private void AndButton_Click(object sender, EventArgs e)
        {
            if (CurrentCol == null) return;
            TempCols.Add(entityTypes, CurrentCol);
            TypeOfOperations.Add(entityTypes, false);
            flowLayoutPanel1.Controls.Add(textb(" И "));
        }

        private void OrButton_Click(object sender, EventArgs e)
        {
            if (CurrentCol == null) return;
            TempCols.Add(entityTypes, CurrentCol);
            TypeOfOperations.Add(entityTypes, true);
            flowLayoutPanel1.Controls.Add(textb(" ИЛИ "));
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            flowLayoutPanel1.Controls.Clear();
            TempCols = new Dictionary<EntityTypes, object>();
            TypeOfOperations = new Dictionary<EntityTypes, bool>();
            CurrentCol = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (Owner as AnaliticForm).ended(CurrentCol);
            Close();
        }
    }
}
