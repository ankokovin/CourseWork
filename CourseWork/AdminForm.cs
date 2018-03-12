using System;
using System.Data.Entity;
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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        public User CurrentUser;

        public class Changer<T> 
            where T: OP, new()
        {
            private EntityTypes type;
            public Changer(EntityTypes _type)
            {
                type = _type;
            }
            public void Add()
            {
                T op = new T();
                op.Show();
            }
            public void Change(DataGridView dataGridView, int idColomn)
            {
                int index = dataGridView.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dataGridView[idColomn, index].Value.ToString(), out id);
                if (!ok) return;
                T op = new T();
                Object obj = Find(id);
                op.Change(obj);
                op.Id = id;
                op.Show();
                op.FormClosed +=(object obj1, FormClosedEventArgs arg)=> dataGridView.Refresh(); 
            }
            public object Find(int Id)
            {
                switch (type)
                {
                    case EntityTypes.User:
                        return Operations.FindUser(Id);
                    case EntityTypes.City:
                        return Operations.FindCity(Id);
                    case EntityTypes.Street:
                        return Operations.FindStreet(Id);
                    case EntityTypes.House:
                        return Operations.FindHouse(Id);
                    case EntityTypes.Address:
                        return Operations.FindAddress(Id);
                    case EntityTypes.Order:
                        return Operations.FindOrder(Id);
                    case EntityTypes.OrderEntry:
                        return Operations.FindOrderEntry(Id);
                    case EntityTypes.Status:
                        return Operations.FindStatus(Id);
                    case EntityTypes.Meter:
                        return Operations.FindMeter(Id);
                    case EntityTypes.MeterType:
                        return Operations.FindMeterType(Id);
                    case EntityTypes.Stavka:
                        return Operations.FindStavka(Id);
                    case EntityTypes.Person:
                        return Operations.FindPerson(Id);
                    case EntityTypes.Customer:
                        return Operations.FindCustomer(Id);
                    case EntityTypes.Company:
                        return Operations.FindCompany(Id);
                    default:
                        return null;
                }
            }

        }

        private void AddCityButton_Click(object sender, EventArgs e)
        {
            SimpleView CityForm = new SimpleView();
            Operations.cont.CitySet.Load();
            CityForm.Source = Operations.cont.CitySet.Local.ToBindingList();
            Changer<OPCity1> changer = new Changer<OPCity1>(EntityTypes.City);
            CityForm.Add += changer.Add;
            CityForm.Change +=(DataGridView dgv)=> changer.Change(dgv,1);
            CityForm.Remove += (DataGridView dataGridView) =>
            {
                int index = dataGridView.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dataGridView[1, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveCity(id,out string s);
                MessageBox.Show(s);
            };
            CityForm.SetButtonNames("Добавить город", "Удалить город", "Изменить город");
            CityForm.Show();
        }

        private void AddStreetButton_Click(object sender, EventArgs e)
        {
            SimpleView StreetForm = new SimpleView();
            Operations.cont.StreetSet.Load();
            StreetForm.Source = Operations.cont.StreetSet.Local.ToBindingList();
            Changer<OPStreet> changer = new Changer<OPStreet>(EntityTypes.Street);
            StreetForm.Add += changer.Add;
            StreetForm.Change += (DataGridView dataGridView) => changer.Change(dataGridView, 1);
            StreetForm.Remove += (DataGridView dataGridView) =>
            {
                int index = dataGridView.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dataGridView[1, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveStreet(id, out string s);
                MessageBox.Show(s);
            };
            StreetForm.SetButtonNames("Добавить улицу", "Удалить улицу", "Изменить улицу");
            StreetForm.Show();
        }

        private void AddAddressButton_Click(object sender, EventArgs e)
        {
            SimpleView AddressForm = new SimpleView();
            Operations.cont.AddressSet.Load();
            AddressForm.Source = Operations.cont.AddressSet.Local.ToBindingList();
            AddressForm.Add += () =>
            {

            };
            AddressForm.Change += (DataGridView dataGridView) =>
            {

            };
            AddressForm.Remove += (DataGridView dataGridView) =>
            {

            };
            AddressForm.SetButtonNames("Добавить дом", "Удалить дом", "Изменить дом");
            AddressForm.Show();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            SimpleView UserForm = new SimpleView();
            Operations.cont.UserSet.Load();
            UserForm.Source = Operations.cont.UserSet.Local.ToBindingList();
            Changer<OPUser1> changer = new Changer<OPUser1>(EntityTypes.User);
            UserForm.Add += changer.Add;
            UserForm.Change += (DataGridView dgv) => changer.Change(dgv, 3);
            UserForm.Remove += (DataGridView dataGridView) =>
            {
                int index = dataGridView.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dataGridView[3, index].Value.ToString(), out id);
                if (!ok) return;
                if (CurrentUser.Id == id)
                {
                    MessageBox.Show("Невозможно удалить текущего пользователя");
                    return;
                }
                Operations.RemoveUser(id, out string s);
                MessageBox.Show(s);
            };
            UserForm.SetButtonNames("Добавить пользователя", "Удалить пользователя", "Изменить пользователя");
            UserForm.Show();
        }

        private void AddressButton_Click(object sender, EventArgs e)
        {
            SimpleView simpleView = new SimpleView();
            Operations.cont.AddressSet.Load();
            simpleView.Source = Operations.cont.AddressSet.Local.ToBindingList();
            Changer<OPAddress> changer = new Changer<OPAddress>(EntityTypes.Address);
            simpleView.Add += changer.Add;
            simpleView.Change += (DataGridView dgv) => changer.Change(dgv, 0);
            simpleView.Remove += (DataGridView dgv) =>
            {
                int index = dgv.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dgv[0, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveAddress(id, out string s);
                MessageBox.Show(s);
            };
            simpleView.SetButtonNames("Добавить адрес", "Удалить адрес", "Изменить адрес");
            simpleView.Show();
        }

        private void MeterButton_Click(object sender, EventArgs e)
        {
            SimpleView simpleView = new SimpleView();
            Operations.cont.MeterSet.Load();
            simpleView.Source = Operations.cont.MeterSet.Local.ToBindingList();
            Changer<OPMeter> changer = new Changer<OPMeter>(EntityTypes.Meter);
            simpleView.Add += changer.Add;
            simpleView.Change += (DataGridView dgv) => changer.Change(dgv, 0);
            simpleView.Remove += (DataGridView dgv) =>
            {
                int index = dgv.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dgv[0, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveMeter(id, out string s);
                MessageBox.Show(s);
            };
            simpleView.SetButtonNames("Добавить прибор учёта", "Удалить прибор учёта", "Изменить прибор учёта");
            simpleView.Show();
        }

        private void MeterTypeButton_Click(object sender, EventArgs e)
        {
            SimpleView simpleView = new SimpleView();
            Operations.cont.MeterTypeSet.Load();
            simpleView.Source = Operations.cont.MeterTypeSet.Local.ToBindingList();
            Changer<OPMeterType> changer = new Changer<OPMeterType>(EntityTypes.MeterType);
            simpleView.Add += changer.Add;
            simpleView.Change += (DataGridView dgv) => changer.Change(dgv, 0);
            simpleView.Remove += (DataGridView dgv) =>
            {
                int index = dgv.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dgv[0, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveMeterType(id, out string s);
                MessageBox.Show(s);
            };
            simpleView.SetButtonNames("Добавить тип приборов учёта", "Удалить тип приборов учёта", "Изменить тип приборов учёта");
            simpleView.Show();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            SimpleView simpleView = new SimpleView();
            Operations.cont.OrderSet.Load();
            simpleView.Source = Operations.cont.OrderSet.Local.ToBindingList();
            Changer<OPOrder> changer = new Changer<OPOrder>(EntityTypes.Order);
            simpleView.Add += changer.Add;
            simpleView.Change += (DataGridView dgv) => changer.Change(dgv, 0);
            simpleView.Remove += (DataGridView dgv) =>
            {
                int index = dgv.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dgv[0, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveOrder(id, out string s);
                MessageBox.Show(s);
            };
            simpleView.SetButtonNames("Добавить заказ", "Удалить заказ", "Изменить заказ");
            simpleView.Show();

        }

        private void OrderEntryButton_Click(object sender, EventArgs e)
        {
            SimpleView simpleView = new SimpleView();
            Operations.cont.OrderEntrySet.Load();
            simpleView.Source = Operations.cont.OrderEntrySet.Local.ToBindingList();
            Changer<OPOrderEntry> changer = new Changer<OPOrderEntry>(EntityTypes.OrderEntry);
            simpleView.Add += changer.Add;
            simpleView.Change += (DataGridView dgv) => changer.Change(dgv, 0);
            simpleView.Remove += (DataGridView dgv) =>
            {
                int index = dgv.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dgv[0, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveOrderEntry(id, out string s);
                MessageBox.Show(s);
            };
            simpleView.SetButtonNames("Добавить заказную позицию", "Удалить заказную позицию", "Изменить заказную позицию");
            simpleView.Show();

        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            SimpleView simpleView = new SimpleView();
            Operations.cont.StatusSet.Load();
            simpleView.Source = Operations.cont.StatusSet.Local.ToBindingList();
            Changer<OPStatus> changer = new Changer<OPStatus>(EntityTypes.Status);
            simpleView.Add += changer.Add;
            simpleView.Change += (DataGridView dgv) => changer.Change(dgv, 0);
            simpleView.Remove += (DataGridView dgv) =>
            {
                int index = dgv.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dgv[0, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveStatus(id, out string s);
                MessageBox.Show(s);
            };
            simpleView.SetButtonNames("Добавить статус заказа", "Удалить статус заказа", "Изменить статус заказа");
            simpleView.Show();

        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            SimpleView simpleView = new SimpleView();
            Operations.cont.CustomerSet.Load();
            simpleView.Source = Operations.cont.CustomerSet.Local.ToBindingList();
            Changer<OPCustomer> changer = new Changer<OPCustomer>(EntityTypes.Customer);
            simpleView.Add += changer.Add;
            simpleView.Change += (DataGridView dgv) => changer.Change(dgv, 0);
            simpleView.Remove += (DataGridView dgv) =>
            {
                int index = dgv.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dgv[0, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveCustomer(id, out string s);
                MessageBox.Show(s);
            };
            simpleView.SetButtonNames("Добавить заказчика", "Удалить заказчика", "Изменить заказчика");
            simpleView.Show();

        }
        
        private void PersonButton_Click(object sender, EventArgs e)
        {
            SimpleView simpleView = new SimpleView();
            Operations.cont.PersonSet.Load();
            simpleView.Source = Operations.cont.PersonSet.Local.ToBindingList();
            Changer<OPPerson> changer = new Changer<OPPerson>(EntityTypes.Person);
            simpleView.Add += changer.Add;
            simpleView.Change += (DataGridView dgv) => changer.Change(dgv, 0);
            simpleView.Remove += (DataGridView dgv) =>
            {
                int index = dgv.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dgv[0, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemovePerson(id, out string s);
                MessageBox.Show(s);
            };
            simpleView.SetButtonNames("Добавить работника", "Удалить работника", "Изменить работника");
            simpleView.Show();

        }

        private void StavkaButton_Click(object sender, EventArgs e)
        {
            SimpleView simpleView = new SimpleView();
            Operations.cont.StavkaSet.Load();
            simpleView.Source = Operations.cont.StavkaSet.Local.ToBindingList();
            Changer<OPStavka> changer = new Changer<OPStavka>(EntityTypes.Stavka);
            simpleView.Add += changer.Add;
            simpleView.Change += (DataGridView dgv) => changer.Change(dgv, 0);
            simpleView.Remove += (DataGridView dgv) =>
            {
                int index = dgv.SelectedRows[0].Index;
                int id = 0;
                bool ok = int.TryParse(dgv[0, index].Value.ToString(), out id);
                if (!ok) return;
                Operations.RemoveStavka(id, out string s);
                MessageBox.Show(s);
            };
            simpleView.SetButtonNames("Добавить ставку", "Удалить ставку", "Изменить ставку");
            simpleView.Show();

        }
    }
}
