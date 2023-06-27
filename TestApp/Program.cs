using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    internal static class Program
    {
        /// <summary>
        /// Расширенные функции следующей версии:
        /// 1. Возвращение к предыдущим вопросам для редактирования ответов.
        /// 2. Продолжение тестирования после прекращения работы приложения.
        /// 3. Редактирование тестов
        /// 4. Хранение истории тестирований
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
