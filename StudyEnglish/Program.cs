using StudyEnglish.Models;
using StudyEnglish.Presenters;
using System;
using System.Windows.Forms;

namespace StudyEnglish
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormMain mainForm = new FormMain();
            IMainModel model = new MainModel();
            MainPresenter presenter = new MainPresenter(mainForm, model);
            
            Application.Run(mainForm);
        }
    }
}
