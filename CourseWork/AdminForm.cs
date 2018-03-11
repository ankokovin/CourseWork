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
            private string type;
            public Changer(string _type)
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
                    case "User":
                        return Operations.FindUser(Id);
                    case "City":
                        return Operations.FindCity(Id);
                    //TODO: дописать
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
            Changer<OPCity1> changer = new Changer<OPCity1>("City");
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
            Changer<OPUser1> changer = new Changer<OPUser1>("User");
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
    }
}
