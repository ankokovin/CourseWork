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
            Loaded = true;
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
                entityTypes = Parse(comboBox1.Text);
                textBox.Text = comboBox1.Text;
                textBox.ReadOnly = true;
                flowLayoutPanel1.Controls.Add(textBox);
                GetCombobox2Items();
                comboBox1.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
            }
        }

        private void GetCombobox3Items()
        {
            dateTimePicker1.Visible = false;
            comboBox3.Items.Clear();
            switch (comboBox2.Text)
            {
                case "Название":
                case "Название компании":
                case "Номер дома":
                case "ИНН":
                case "Номер паспорта":
                case "Login":
                case "Тип пользователя":
                case "ФИО":
                case "Номер телефона":
                    comboBox3.Items.Add("Равно");
                    comboBox3.Items.Add("Неравно");
                    break;
                case "Время начала":
                case "Время конца":
                    dateTimePicker1.Visible = true;
                    comboBox3.Items.Add("Задано");
                    comboBox3.Items.Add("Незадано");
                    comboBox3.Items.Add("Больше");
                    comboBox3.Items.Add("Меньше");
                    comboBox3.Items.Add("Небольше");
                    comboBox3.Items.Add("Неменьше");
                    comboBox3.Items.Add("Равно");
                    comboBox3.Items.Add("Неравно");
                    break;
                case "Номер квартиры":
                case "Номер заказа":
                    comboBox3.Items.Add("Больше");
                    comboBox3.Items.Add("Меньше");
                    comboBox3.Items.Add("Равно");
                    comboBox3.Items.Add("Небольше");
                    comboBox3.Items.Add("Неменьше");
                    comboBox3.Items.Add("Неравно");
                    break;
                case "Исполнитель":
                    comboBox3.Items.Add("Вход");
                    comboBox3.Items.Add("Задано");
                    comboBox3.Items.Add("Незадано");
                    break;
                default:
                    comboBox3.Items.Add("Вход");
                    break;
            }
            if (comboBox2.Text == "Тип пользователя")
            {
                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                textBox1.AutoCompleteCustomSource.AddRange(new string[] {"Admin","Analitic","Operator" });
                
            }
            else
            {
                textBox1.AutoCompleteMode = AutoCompleteMode.None;
            }
            comboBox3.Refresh();
        }

        private void GetCombobox2Items()
        {
            comboBox2.Items.Clear();
            switch (entityTypes)
            {
                case EntityTypes.Address:
                    comboBox2.Items.Add("Номер квартиры");
                    comboBox2.Items.Add("Дом");
                    break;
                case EntityTypes.City:
                    comboBox2.Items.Add("Название");
                    break;
                case EntityTypes.Company:
                    comboBox2.Items.Add("Название");
                    comboBox2.Items.Add("Номер паспорта");
                    comboBox2.Items.Add("Номер телефона");
                    comboBox2.Items.Add("Название компании");
                    comboBox2.Items.Add("ИНН");
                    break;
                case EntityTypes.Customer:
                    comboBox2.Items.Add("ФИО");
                    comboBox2.Items.Add("Номер паспорта");
                    comboBox2.Items.Add("Номер телефона");
                    break;
                case EntityTypes.CustomerOrCompany:
                    comboBox2.Items.Add("ФИО");
                    comboBox2.Items.Add("Номер паспорта");
                    break;
                case EntityTypes.House:
                    comboBox2.Items.Add("Номер дома");
                    comboBox2.Items.Add("Street");
                    break;
                case EntityTypes.Meter:
                    comboBox2.Items.Add("Название");
                    comboBox2.Items.Add("Тип счётчиков");
                    break;
                case EntityTypes.MeterType:
                    comboBox2.Items.Add("Название");
                    break;
                case EntityTypes.Order:
                    comboBox2.Items.Add("Номер заказа");
                    comboBox2.Items.Add("Пользователь");
                    comboBox2.Items.Add("Заказчик");
                    comboBox2.Items.Add("Компания");
                    comboBox2.Items.Add("Частный заказчик");
                    comboBox2.Items.Add("Адрес");
                    break;
                case EntityTypes.OrderEntry:
                    comboBox2.Items.Add("Счётчик");
                    comboBox2.Items.Add("Исполнитель");
                    comboBox2.Items.Add("Время начала");
                    comboBox2.Items.Add("Время конца");
                    comboBox2.Items.Add("Статус заказной позиции");
                    comboBox2.Items.Add("Заказ");
                    break;
                case EntityTypes.Person:
                    comboBox2.Items.Add("ФИО");
                    break;
                case EntityTypes.Status:
                    comboBox2.Items.Add("Название");
                    break;
                case EntityTypes.Stavka:
                    comboBox2.Items.Add("Исполнитель");
                    comboBox2.Items.Add("Тип счётчиков");
                    break;
                case EntityTypes.Street:
                    comboBox2.Items.Add("Название");
                    comboBox2.Items.Add("Город");
                    break;
                case EntityTypes.User:
                    comboBox2.Items.Add("Login");
                    comboBox2.Items.Add("Тип пользователя");
                    break;
            }
            comboBox2.Refresh();
        }
        private bool DeepOp;
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Length == 0 || comboBox3.Text.Length == 0) return;
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
            comboBox2.Text = string.Empty;
            comboBox3.Items.Clear();
            comboBox3.Text = string.Empty;
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
        #region NextEnity
        private void NextAddress()
        {
            string copy = textBox1.Text;
            if (comboBox2.Text == "Номер квартиры")
            {
                if (!Checker.IsNumber(copy))
                {
                    MessageBox.Show("Неверный номер квартиры");
                    return;
                }
                Func<Address, bool> pred=null;
                switch (comboBox3.Text)
                {
                    case "Больше":
                        pred = (Address a) => a.Flat > int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Номер квартиры>" + copy });
                        break;
                    case "Меньше":
                        pred = (Address a) => a.Flat < int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Номер квартиры<" + copy });
                        break;
                    case "Равно":
                        pred = (Address a) => a.Flat == int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Номер квартиры==" + copy });
                        break;
                    case "Небольше":
                        pred = (Address a) => a.Flat <= int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Номер квартиры<=" + copy });
                        break;
                    case "Неменьше":
                        pred = (Address a) => a.Flat >= int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Номер квартиры>=" + copy });
                        break;
                    case "Неравно":
                        pred = (Address a) => a.Flat != int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(new TextBox {  ReadOnly = true,Text = "Номер квартиры!=" + copy });
                        break;
                }
                CurrentCol = Operations.SelectAddresss(pred);
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
            string copy = textBox1.Text;
            if (!Checker.IsName(copy))
            {
                MessageBox.Show("Неверная строка названии города");
                return;
            }
            Func<City, bool> pred = null;
            switch (comboBox3.Text)
            {
                case "Равно":
                    pred = (City c) => c.Name == copy;
                    flowLayoutPanel1.Controls.Add(textb("Название==" + copy ));
                    break;
                case "Неравно":
                    pred = (City c) => c.Name != copy;
                    flowLayoutPanel1.Controls.Add(textb("Название!=" + copy));

                    break;
            }
            CurrentCol = Operations.SelectCitys(pred);
        }
        private void NextCompany()
        {
            string copy = textBox1.Text;
            Func<Customer, bool> pred = null;
            if (comboBox2.Text == "ФИО")
            {
                if (!Checker.IsFIO(copy))
                {
                    MessageBox.Show("Неверное ФИО заказчика");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) =>c is Company &&  c.FIO == copy;
                        flowLayoutPanel1.Controls.Add(textb("ФИО==" + copy));
                        break;
                    case "Неравно":
                        pred = (Customer c) => c is Company && c.FIO != copy;
                        flowLayoutPanel1.Controls.Add(textb("ФИО!=" + copy));

                        break;
                }
            }
            else if (comboBox2.Text == "Номер паспорта")
            {
                if (!Checker.IsPassportNumber(copy))
                {
                    MessageBox.Show("Неверный номер паспорта");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => c is Company && c.Passport == copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер паспорта==" + copy));

                        break;
                    case "Неравно":
                        pred = (Customer c) => c is Company && c.Passport != copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер паспорта!=" + copy));
                        break;
                }
            }
            else if (comboBox2.Text == "Название компании")
            {
                if (!Checker.IsName(copy))
                {
                    MessageBox.Show("Неверное имя компании");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => c is Company && (c as Company).CompanyName == copy;
                        flowLayoutPanel1.Controls.Add(textb("Название компании==" + copy));

                        break;
                    case "Неравно":
                        pred = (Customer c) => c is Company && (c as Company).CompanyName != copy;
                        flowLayoutPanel1.Controls.Add(textb("Название компании!=" + copy));

                        break;
                }
            }
            else if (comboBox2.Text == "ИНН")
            {
                if (!Checker.IsINN(copy))
                {
                    MessageBox.Show("Неверный ИНН");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => c is Company && (c as Company).INN == copy;
                        flowLayoutPanel1.Controls.Add(textb("ИНН==" + copy));

                        break;
                    case "Неравно":
                        pred = (Customer c) => c is Company && (c as Company).INN != copy;
                        flowLayoutPanel1.Controls.Add(textb("ИНН!=" + copy));

                        break;
                }
            }
            else if (comboBox2.Text == "Номер телефона")
            {
                if (!Checker.IsPassportNumber(copy))
                {
                    MessageBox.Show("Неверный номер телефона");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => c is Company && c.PhoneNumber == copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер телефона==" + copy));

                        break;
                    case "Неравно":
                        pred = (Customer c) => c is Company && c.PhoneNumber != copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер телефона!=" + copy));

                        break;
                }
            }
            CurrentCol = Operations.SelectCustomers(pred);
        }
        private void NextCustomer()
        {
            string copy = textBox1.Text;
            Func<Customer, bool> pred = null;
            if (comboBox2.Text == "ФИО")
            {
                if (!Checker.IsFIO(copy))
                {
                    MessageBox.Show("Неверное ФИО заказчика");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => !(c is Company) && c.FIO == copy;
                        flowLayoutPanel1.Controls.Add(textb("ФИО==" + copy));

                        break;
                    case "Неравно":
                        pred = (Customer c) => !(c is Company) && c.FIO != copy;
                        flowLayoutPanel1.Controls.Add(textb("ФИО!=" + copy));

                        break;
                }
            }
            else if (comboBox2.Text == "Номер паспорта")
            {
                if (!Checker.IsPassportNumber(copy))
                {
                    MessageBox.Show("Неверный номер паспорта");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => !(c is Company) && c.Passport == copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер паспорта==" + copy ));

                        break;
                    case "Неравно":
                        pred = (Customer c) => !(c is Company) && c.Passport != copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер паспорта!=" + copy));

                        break;
                }
            }
            CurrentCol = Operations.SelectCustomers(pred);
        }
        private void NextCustomerOrCompany()
        {
            string copy = textBox1.Text;
            Func<Customer, bool> pred = null;
            if (comboBox2.Text == "ФИО")
            {
                if (!Checker.IsFIO(copy))
                {
                    MessageBox.Show("Неверное ФИО заказчика");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) =>  c.FIO == copy;
                        flowLayoutPanel1.Controls.Add(textb("ФИО==" + copy ));

                        break;
                    case "Неравно":
                        pred = (Customer c) =>  c.FIO != copy;
                        flowLayoutPanel1.Controls.Add(textb("ФИО!=" + copy ));

                        break;
                }
            }
            else if (comboBox2.Text == "Номер паспорта")
            {
                if (!Checker.IsPassportNumber(copy))
                {
                    MessageBox.Show("Неверный номер паспорта");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (Customer c) => c.Passport == copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер паспорта==" + copy));

                        break;
                    case "Неравно":
                        pred = (Customer c) => c.Passport != copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер паспорта!=" + copy));

                        break;                                    
                }
            }
            CurrentCol = Operations.SelectCustomers(pred);
        }
        private void NextHouse()
        {
            string copy = textBox1.Text;
            if (comboBox2.Text == "Номер дома")
            {
                if (!Checker.IsHouseNumber(copy))
                {
                    MessageBox.Show("Неверный номер дома");
                    return;
                }
                Func<House, bool> pred = null;
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (a) => a.Number == copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер дома==" + copy));

                        break;
                    case "Неравно":
                        pred = (a) => a.Number != copy;
                        flowLayoutPanel1.Controls.Add(textb("Номер дома!=" + copy));

                        break;
                }
                CurrentCol = Operations.SelectHouses(pred);
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
            string copy = textBox1.Text;
            if (comboBox2.Text == "Название")
            {
                if (!Checker.IsName(copy))
                {
                    MessageBox.Show("Неверная строка названия счётчика");
                    return;
                }
                Func<Meter, bool> pred = null;
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (a) => a.Name == copy;
                        flowLayoutPanel1.Controls.Add(textb("Название==" + copy));
                        break;
                    case "Неравно":
                        pred = (a) => a.Name != copy;
                        flowLayoutPanel1.Controls.Add(textb("Название!=" + copy));
                        break;
                }
                CurrentCol = Operations.SelectMeters(pred);
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
            string copy = textBox1.Text;
            if (!Checker.IsName(copy))
            {
                MessageBox.Show("Неверная строка названия типа счётчика");
                return;
            }
            Func<MeterType, bool> pred = null;
            switch (comboBox3.Text)
            {
                case "Равно":
                    pred = (MeterType c) => c.Name == copy;
                    flowLayoutPanel1.Controls.Add(textb("Название==" + copy));
                    break;
                case "Неравно":
                    pred = (MeterType c) => c.Name != copy;
                    flowLayoutPanel1.Controls.Add(textb("Название!=" + copy));
                    break;
            }
            CurrentCol = Operations.SelectMeterTypes(pred);
        }
        private void NextOrder()
        {
            string copy = textBox1.Text;
            if (comboBox2.Text == "Номер заказа")
            {
                Func<Order, bool> pred = null;
                if (!Checker.IsNumber(copy))
                {
                    MessageBox.Show("Неверный номер заказа");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Больше":
                        pred = (Order a) => a.Id > int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(textb("Номер заказа>" + copy ));
                        break;
                    case "Меньше":
                        pred = (Order a) => a.Id < int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(textb("Номер заказа<" + copy));

                        break;
                    case "Равно":
                        pred = (Order a) => a.Id == int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(textb("Номер заказа==" + copy));

                        break;
                    case "Небольше":
                        pred = (Order a) => a.Id <= int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(textb("Номер заказа<=" + copy));

                        break;
                    case "Неменьше":
                        pred = (Order a) => a.Id >= int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(textb("Номер заказа>" + copy));

                        break;
                    case "Неравно":
                        pred = (Order a) => a.Id != int.Parse(copy);
                        flowLayoutPanel1.Controls.Add(textb("Номер заказа!=" + copy));

                        break;
                }
                CurrentCol = Operations.SelectOrders(pred);
            }
            else if (comboBox2.Text == "Пользователь")
            {
                stack.Push(EntityTypes.Order);
                entityTypes = EntityTypes.User;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Частный заказчик")
            {
                stack.Push(EntityTypes.Order);
                entityTypes = EntityTypes.Customer;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Компания")
            {
                stack.Push(EntityTypes.Order);
                entityTypes = EntityTypes.Company;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Заказчик")
            {
                stack.Push(EntityTypes.Order);
                entityTypes = EntityTypes.CustomerOrCompany;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Адрес")
            {
                stack.Push(EntityTypes.Order);
                entityTypes = EntityTypes.Address;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;
            }
        }
        private void NextOrderEntry()
        {
            DateTime dateTime = dateTimePicker1.Value;
            if (comboBox2.Text == "Счётчик")
            {
                stack.Push(EntityTypes.OrderEntry);
                entityTypes = EntityTypes.Meter;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Исполнитель")
            {
                switch (comboBox3.Text)
                {
                    case "Вход":
                        stack.Push(EntityTypes.OrderEntry);
                        entityTypes = EntityTypes.Person;
                        flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                        break;
                    case "Задано":
                        Func<OrderEntry, bool> pred = (c) => c.PersonId != null;
                        CurrentCol = Operations.SelectOrderEntrys(pred);
                        flowLayoutPanel1.Controls.Add(textb("PersonId задано"));
                        break;
                    case "Незадано":
                        pred = (c) => c.PersonId == null;
                        CurrentCol = Operations.SelectOrderEntrys(pred);
                        flowLayoutPanel1.Controls.Add(textb("PersonId незадано"));

                        break;
                }
            }
            else if (comboBox2.Text == "Время начала")
            {
                Func<OrderEntry, bool> pred = null;

                switch (comboBox3.Text)
                {
                    case "Задано":
                        pred = (c) => c.StartTime != null;
                        flowLayoutPanel1.Controls.Add(textb("Время начала задано"));
                        break;
                    case "Незадано":
                        pred = (c) => c.StartTime == null;
                        flowLayoutPanel1.Controls.Add(textb("Время начала незадано"));
                        break;
                    case "Больше":
                        pred = (c) => c.StartTime > dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время начала>" + dateTime));
                        break;
                    case "Меньше":
                        pred = (c) => c.StartTime < dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время начала<" + dateTime));
                        break;
                    case "Равно":
                        pred = (c) => c.StartTime !=  dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время начала==" + dateTime));

                        break;
                    case "Небольше":
                        pred = (c) => c.StartTime <= dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время начала<=" + dateTime));

                        break;
                    case "Неменьше":
                        pred = (c) => c.StartTime >= dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время начала>=" + dateTime));

                        break;
                    case "Неравно":
                        pred = (c) => c.StartTime != dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время начала !=" + dateTime));
                        break;
                }
                CurrentCol = Operations.SelectOrderEntrys(pred);
            }
            else if (comboBox2.Text == "Время конца")
            {
                Func<OrderEntry, bool> pred = null;
                switch (comboBox3.Text)
                {
                    case "Задано":
                        pred = (c) => c.EndTime != null;
                        flowLayoutPanel1.Controls.Add(textb("Время конца задано"));
                        break;
                    case "Незадано":
                        pred = (c) => c.EndTime == null;
                        flowLayoutPanel1.Controls.Add(textb("Время конца незадано"));
                        break;
                    case "Больше":
                        pred = (c) => c.EndTime > dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время конца>" + dateTime));
                        break;
                    case "Меньше":
                        pred = (c) => c.EndTime < dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время конца<" + dateTime));
                        break;
                    case "Равно":
                        pred = (c) => c.EndTime != dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время конца==" + dateTime));
                        break;
                    case "Небольше":
                        pred = (c) => c.EndTime <= dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время конца<=" + dateTime));
                        break;
                    case "Неменьше":
                        pred = (c) => c.EndTime >= dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время конца>=" + dateTime));
                        break;
                    case "Неравно":
                        pred = (c) => c.EndTime != dateTime;
                        flowLayoutPanel1.Controls.Add(textb("Время конца!=" + dateTime));
                        break;
                }
                CurrentCol = Operations.SelectOrderEntrys(pred);
            }
            else if (comboBox2.Text == "Статус заказной позиции")
            {
                stack.Push(EntityTypes.OrderEntry);
                entityTypes = EntityTypes.Status;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
            else if (comboBox2.Text == "Заказ")
            {
                stack.Push(EntityTypes.OrderEntry);
                entityTypes = EntityTypes.Order;
                flowLayoutPanel1.Controls.Add(textb("(" + comboBox2.Text));
                DeepOp = true;

            }
        }
        private void NextPerson()
        {
            string copy = textBox1.Text;
            if (!Checker.IsFIO(copy))
            {
                MessageBox.Show("Неверное ФИО");
                return;
            }
            Func<Person, bool> pred = null;
            switch (comboBox3.Text)
            {
                case "Равно":
                    pred = (Person c) => c.FIO == copy;
                    flowLayoutPanel1.Controls.Add(textb("ФИО==" + copy ));
                    break;
                case "Неравно":
                    pred = (Person c) => c.FIO != copy;
                    flowLayoutPanel1.Controls.Add(textb("ФИО!=" + copy));
                    break;
            }
            CurrentCol = Operations.SelectPersons(pred);
        }
        private void NextStatus()
        {
            string copy = textBox1.Text;
            if (!Checker.IsName(copy))
            {
                MessageBox.Show("Неверная строка названия статуса");
                return;
            }
            Func<Status, bool> pred = null;
            switch (comboBox3.Text)
            {
                case "Равно":
                    pred = (Status c) => c.Name == copy;
                    flowLayoutPanel1.Controls.Add(textb("Название==" + copy));
                    break;
                case "Неравно":
                    pred = (Status c) => c.Name != copy;
                    flowLayoutPanel1.Controls.Add(textb("Название!=" + copy));
                    break;
            }
            CurrentCol = Operations.SelectStatuss(pred);
        }
        private void NextStavka()
        {
            string copy = textBox1.Text;
            if (comboBox2.Text == "Тип счётчиков")
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
            string copy = textBox1.Text;
            if (comboBox2.Text == "Название")
            {
                Func<Street, bool> pred = null;
                if (!Checker.IsName(copy))
                {
                    MessageBox.Show("Неверная строка названия улицы");
                    return;
                }
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (a) => a.Name == copy;
                        flowLayoutPanel1.Controls.Add(textb("Название==" + copy));
                        break;
                    case "Неравно":
                        pred = (a) => a.Name != copy;
                        flowLayoutPanel1.Controls.Add(textb("Название!=" + copy));
                        break;
                }
                CurrentCol = Operations.SelectStreets(pred);
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
            string copy = textBox1.Text;
            Func<User, bool> pred = null;
            if (comboBox2.Text == "Login")
            {
                switch (comboBox3.Text)
                {
                    case "Равно":
                        pred = (a) => a.Login == copy;
                        flowLayoutPanel1.Controls.Add(textb("Login==" + copy));
                        break;
                    case "Неравно":
                        pred = (a) => a.Login != copy;
                        flowLayoutPanel1.Controls.Add(textb("Login!=" + copy));
                        break;
                }
            }else
            {
                UserType userType;
                if (Enum.TryParse(copy, out userType))
                {
                    switch (comboBox3.Text)
                    {
                        case "Равно":
                            pred = (a) => a.UserType == userType;
                            flowLayoutPanel1.Controls.Add(textb("Тип пользователя==" + userType));
                            break;
                        case "Неравно":
                            pred = (a) => a.UserType != userType;
                            flowLayoutPanel1.Controls.Add(textb("Тип пользователя!=" + userType));
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный тип пользователя");
                }
            }
            CurrentCol = Operations.SelectUsers(pred);
        }
        #endregion NextEntity
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCombobox3Items();
        }
        private EntityTypes Parse(string s)
        {
            switch (s)
            {
                case "Заказ": return EntityTypes.Order;
                case "Заказная позиция": return EntityTypes.OrderEntry;
                case "Город": return EntityTypes.City;
                case "Улица": return EntityTypes.Street;
                case "Дом": return EntityTypes.House;
                case "Адрес": return EntityTypes.Address;
                case "Счётчик": return EntityTypes.Meter;
                case "Тип счётчиков": return EntityTypes.MeterType;
                case "Статус заказной позиции": return EntityTypes.Status;
                case "Заказчик": return EntityTypes.CustomerOrCompany;
                case "Частный заказчик": return EntityTypes.Customer;
                case "Компания": return EntityTypes.Company;
                case "Исполнитель": return EntityTypes.Person;
                case "Ставка": return EntityTypes.Stavka;
                case "Пользователь": return EntityTypes.User;
            }
            return default(EntityTypes);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (stack.Count == 0) return;
            EntityTypes entityTypes1 = stack.Pop();
            switch (entityTypes1)
            {
                case EntityTypes.Address:
                    var PrevCol = CurrentCol as IEnumerable<House>;
                    CurrentCol = Operations.SelectAddresss((Address a) => PrevCol.Contains(a.House));
                    break;
                case EntityTypes.House:
                    var PrevCol1 = CurrentCol as IEnumerable<Street>;
                    CurrentCol = Operations.SelectHouses((House s) => PrevCol1.Contains(s.Street));
                    break;
                case EntityTypes.Meter:
                    var PrevCol2 = CurrentCol as IEnumerable<MeterType>;
                    CurrentCol = Operations.SelectMeters((Meter m) => PrevCol2.Contains(m.MeterType));
                break;
                case EntityTypes.Order:
                    if (entityTypes == EntityTypes.User)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<User>;
                        CurrentCol = Operations.SelectOrders((Order o) => PrevCol3.Contains(o.User));
                    }else if (entityTypes == EntityTypes.Customer||entityTypes==EntityTypes.Company|| entityTypes == EntityTypes.CustomerOrCompany)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Customer>;
                        CurrentCol = Operations.SelectOrders((Order s) => PrevCol3.Contains(s.Customer));
                    }else if (entityTypes == EntityTypes.Address)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Address>;
                        CurrentCol = Operations.SelectOrders((Order s) => PrevCol3.Contains(s.Address));
                    }
                    break;
                case EntityTypes.OrderEntry:
                    if (entityTypes == EntityTypes.Order)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Order>;
                        CurrentCol = Operations.SelectOrderEntrys((OrderEntry o) => PrevCol3.Contains(o.Order));
                    }else if (entityTypes == EntityTypes.Meter)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Meter>;
                        CurrentCol = Operations.SelectOrderEntrys((OrderEntry o) => PrevCol3.Contains(o.Meter));
                    }else if (entityTypes == EntityTypes.Person)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Person>;
                        CurrentCol = Operations.SelectOrderEntrys((OrderEntry o) => PrevCol3.Contains(o.Person));
                    }else if (entityTypes == EntityTypes.Status)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Status>;
                        CurrentCol = Operations.SelectOrderEntrys((OrderEntry o) => PrevCol3.Contains(o.Status));
                    }
                    break;
                case EntityTypes.Stavka:
                    if (entityTypes == EntityTypes.MeterType)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<MeterType>;
                        CurrentCol = Operations.SelectStavkas((Stavka o) => PrevCol3.Contains(o.MeterType));
                    }else if (entityTypes == EntityTypes.Person)
                    {
                        var PrevCol3 = CurrentCol as IEnumerable<Person>;
                        CurrentCol = Operations.SelectStavkas((Stavka o) => PrevCol3.Contains(o.Person));
                    }
                    break;
                case EntityTypes.Street:
                    var PrevCol4 = CurrentCol as IEnumerable<City>;
                    CurrentCol = Operations.SelectStreets((Street o) => PrevCol4.Contains(o.City));
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
            comboBox2.Items.Clear();
            comboBox2.Enabled = false;
            comboBox3.Items.Clear();
            comboBox3.Enabled = false;
            flowLayoutPanel1.Controls.Clear();
            button1.Enabled = false;
            TempCols = new Dictionary<EntityTypes, object>();
            TypeOfOperations = new Dictionary<EntityTypes, bool>();
            stack.Clear();
            CurrentCol = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentCol == null)
            {
                switch (entityTypes)
                {
                    case EntityTypes.Address:
                        CurrentCol = Operations.SelectAddresss((s) => true);
                        break;
                    case EntityTypes.Company:
                        CurrentCol = Operations.SelectCustomers((s) => s is Company);
                        break;
                    case EntityTypes.Customer:
                        CurrentCol = Operations.SelectCustomers((s) => !(s is Company));
                        break;
                    case EntityTypes.CustomerOrCompany:
                        CurrentCol = Operations.SelectCustomers((s) => true);
                        break;
                    case EntityTypes.House:
                        CurrentCol = Operations.SelectHouses((s) => true);
                        break;
                    case EntityTypes.Meter:
                        CurrentCol = Operations.SelectMeters((s) => true);
                        break;
                    case EntityTypes.MeterType:
                        CurrentCol = Operations.SelectMeterTypes((s) => true);
                        break;
                    case EntityTypes.Order:
                        CurrentCol = Operations.SelectOrders((s) => true);
                        break;
                    case EntityTypes.OrderEntry:
                        CurrentCol = Operations.SelectOrderEntrys((s) => true);
                        break;
                    case EntityTypes.Stavka:
                        CurrentCol = Operations.SelectStavkas((s) => true);
                        break;
                    case EntityTypes.Street:
                        CurrentCol = Operations.SelectStreets((s) => true);
                        break;
                    case EntityTypes.Status:
                        CurrentCol = Operations.SelectStatuss((s) => true);
                        break;
                    case EntityTypes.User:
                        CurrentCol = Operations.SelectUsers((s) => true);
                        break;
                }
            }
             (Owner as AnaliticForm).ended(CurrentCol);
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker1.Text;
        }
    }
}
