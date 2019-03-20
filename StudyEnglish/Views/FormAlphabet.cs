using System;
using System.Windows.Forms;

namespace StudyEnglish.Views
{
    public partial class FormAlphabet : Form
    {
        public FormAlphabet()
        {
            InitializeComponent();
        }

        private void BtnCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else this.WindowState = FormWindowState.Normal;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
