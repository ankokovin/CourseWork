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
                op.Change();
                op.Id = id;
                op.Show();
                dataGridView.Refresh();
            }
        }

        private void AddCityButton_Click(object sender, EventArgs e)
        {
            SimpleView CityForm = new SimpleView();
            Operations.cont.CitySet.Load();
            CityForm.Source = Operations.cont.CitySet.Local.ToBindingList();
            Changer<OPCity1> changer = new Changer<OPCity1>();
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
            StreetForm.Add += () =>
            {

            };
            StreetForm.Change += (DataGridView dataGridView) =>
            {

            };
            StreetForm.Remove += (DataGridView dataGridView) =>
            {

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
            UserForm.Add += () =>
            {

            };
            UserForm.Change += (DataGridView dataGridView) =>
            {
                //сравнить с CurrentUser
            };
            UserForm.Remove += (DataGridView dataGridView) =>
            {
                //сравнить с CurrentUser
            };
            UserForm.SetButtonNames("Добавить пользователя", "Удалить пользователя", "Изменить пользователя");
            UserForm.Show();
        }
    }
}
