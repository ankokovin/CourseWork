using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Common;

namespace CourseWork
{

    static class Program
    {
        /// <summary>
        /// Заголовки столбцов, которые требуется скрыть при помощи <see cref="HideColumns(ref DataGridView, EntityTypes)"/>
        /// </summary>
        static Dictionary<EntityTypes, List<String>> HideableColumns = new Dictionary<EntityTypes, List<string>>
            {
                { EntityTypes.City, new List<string> { "Street" } },
                { EntityTypes.Street, new List<string>{"House" } },
                { EntityTypes.House, new List<string>{"Address" } },
                { EntityTypes.Address, new List<string>{"Order" } },
                { EntityTypes.MeterType, new List<string>{"Meter","Stavka"} },
                { EntityTypes.Meter, new List<string>{"OrderEntry" } },
                { EntityTypes.Order, new List<string>{"OrderEntry" } },
                { EntityTypes.OrderEntry, new List<string>{"PersonId"} },
                { EntityTypes.Status, new List<string>{"OrderEntry" } },
                { EntityTypes.Customer, new List<string>{"Order" } },
                { EntityTypes.Company, new List<string>{"Order" } },
                { EntityTypes.Person, new List<string>{"Stavka","OrderEntry" } },
                { EntityTypes.User, new List<string>{"Order"} }
            };
        /// <summary>
        /// Скрыть столбцы в соответствии с типом сущности и <see cref="HideableColumns"/>
        /// </summary>
        /// <param name="dgv">Искомая таблица <see cref="DataGridView"/></param>
        /// <param name="entity">Тип сущности в таблице</param>
        public static void HideColumns(ref DataGridView dgv, EntityTypes entity, User currentUser)
        {
            if (HideableColumns.ContainsKey(entity))
            { 
                HidaColumns(ref dgv, HideableColumns[entity]);
            }
            if (entity == EntityTypes.User && currentUser.UserType != UserType.Admin)
                HidaColumns(ref dgv, new List<String> { "Password" });
        }

        public static void HidaColumns(ref DataGridView dgv, ICollection<string> names)
        {
            foreach(string s in names)
            {
                int col = FindTitle(dgv, s);
                if (col!=-1)
                    dgv.Columns[col].Visible = false;
            }
        }

        public static void Rename(ref DataGridView dgv)
        {
            Rename(ref dgv, "Id", "Идентификационный номер");
            Rename(ref dgv, "Name", "Название");
            Rename(ref dgv, "Address", "Адрес");
            Rename(ref dgv, "City", "Город");
            Rename(ref dgv, "House", "Дом");
            Rename(ref dgv, "Street", "Улица");
            Rename(ref dgv, "Order", "Заказ");
            Rename(ref dgv, "OrderEntry", "Заказная позиция");
            Rename(ref dgv, "Status", "Статус");
            Rename(ref dgv, "Stavka", "Ставка");
            Rename(ref dgv, "Customer", "Заказчик");
            Rename(ref dgv, "Company", "Компания-заказчик");
            Rename(ref dgv, "UserType", "Тип пользователя");
            Rename(ref dgv, "User", "Создавший пользователь");
            Rename(ref dgv, "Meter", "Счётчик");
            Rename(ref dgv, "MeterType", "Тип счётчика");
            Rename(ref dgv, "RegNumer", "Регистрационный номер");
            Rename(ref dgv, "MeterId", "Номер счётчика");
            Rename(ref dgv, "Person", "Исполнитель");
            Rename(ref dgv, "StartTime", "Время начала");
            Rename(ref dgv, "EndTime", "Время конца");
            Rename(ref dgv, "startTime", "Удобное время начала");
            Rename(ref dgv, "endTime", "Удобное время конца");
            Rename(ref dgv, "Flat", "Номер квартиры");
            Rename(ref dgv, "Number", "Номер дома");
            Rename(ref dgv, "PhoneNumber", "Номер телефона");
            Rename(ref dgv, "FIO", "ФИО");
            Rename(ref dgv, "CompanyName", "Название компании");
            Rename(ref dgv, "Passport", "Номер паспорта");
        }

        public static void Rename(ref DataGridView dgv, string Old, string New)
        {
            int idx = FindTitle(dgv, Old);
            if (idx != -1)
            {
                dgv.Columns[idx].HeaderText = New;
            }
        }

        public static void HideRows(ref DataGridView dgv, Predicate<DataGridViewRow> predicate)
        {
            dgv.CurrentCell = null;
            for (int i = 0; i < dgv.RowCount; ++i)
            {
                dgv.Rows[i].Visible = predicate(dgv.Rows[i]);
            }
        }

        /// <summary>
        /// Найти номер столбца <see cref="DataGridView"/> с данным заголовком
        /// </summary>
        /// <param name="dgv">Искомый объект</param>
        /// <param name="name">Заголовок столбца</param>
        /// <returns>Номер столбца (с нуля, если не найдено = -1)</returns>
        public static int FindTitle(DataGridView dgv, string name)
        {
            for (int i = 0; i < dgv.Columns.Count; ++i)
                if (dgv.Columns[i].HeaderText == name) return i;
            return -1;
        }
        /// <summary>
        /// Выделяет строку <see cref="DataGridView"/> с данным значением Id
        /// </summary>
        /// <param name="dgv"><see cref="DataGridView"/> в котором выделяем</param>
        /// <param name="Id">Идентификационный номер записи выделяемой строки</param>
        public static void SelectId(ref DataGridView dgv, int Id)
        {
            int idColomn = FindTitle(dgv, "Id");
            dgv.ClearSelection();
            for (int i = 0; i < dgv.RowCount; ++i)
            {
                if (int.TryParse(dgv[idColomn,i].Value.ToString(), out int rId) && rId == Id)
                {
                    dgv.Rows[i].Selected = true;
                    return;
                }
            }
            
        }
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Operations.AttentionMessage += (s) => MessageBox.Show(s,"Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
