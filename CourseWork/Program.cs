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
                { EntityTypes.Status, new List<string>{"OrderEntry" } },
                { EntityTypes.Customer, new List<string>{"Order" } },
                { EntityTypes.Person, new List<string>{"Worker" } },
                { EntityTypes.User, new List<string>{"Order"} }
            };
        /// <summary>
        /// Скрыть столбцы в соответствии с типом сущности и <see cref="HideableColumns"/>
        /// </summary>
        /// <param name="dgv">Искомая таблица <see cref="DataGridView"/></param>
        /// <param name="entity">Тип сущности в таблице</param>
        public static void HideColumns(ref DataGridView dgv, EntityTypes entity)
        {
            if (HideableColumns.ContainsKey(entity))
            {
                foreach (string s in HideableColumns[entity])
                {
                    dgv.Columns[FindTitle(dgv, s)].Visible = false;
                }
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
                    dgv.Rows[Id].Selected = true;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
