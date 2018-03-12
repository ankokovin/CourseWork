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
