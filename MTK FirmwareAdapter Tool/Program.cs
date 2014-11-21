using System;
using System.Windows.Forms;

namespace MTFAT
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AppendPrivatePath(@"Bin");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
