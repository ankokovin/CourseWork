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
        IQueryable queryable;
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
            comboBox2.Items.Add("");
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

        private void button1_Click(object sender, EventArgs e)
        {
            switch (entityTypes)
            {
                case EntityTypes.Address:
                    break;
                case EntityTypes.City:
                    break;
                case EntityTypes.Company:
                    break;
                case EntityTypes.Customer:
                    break;
                case EntityTypes.House:
                    break;
                case EntityTypes.Meter:
                    break;
                case EntityTypes.MeterType:
                    break;
                case EntityTypes.Order:
                    break;
                case EntityTypes.OrderEntry:
                    break;
                case EntityTypes.Person:
                    break;
                case EntityTypes.Status:
                    break;
                case EntityTypes.Stavka:
                    break;
                case EntityTypes.Street:
                    break;
                case EntityTypes.User:
                    break;
            }
        }

        private void NextAddress()
        {
            switch (comboBox3.Text)
            {
                case ""
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCombobox3Items();
        }
    }
}
