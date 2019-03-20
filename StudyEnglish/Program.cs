using StudyEnglish.BL.Controller;
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
            IEditExpression editExpression = new ExpressionManager(Authorize.OleDbConStr);
            MainPresenter presenter = new MainPresenter(mainForm, editExpression);
            
            Application.Run(mainForm);
        }
    }
}
