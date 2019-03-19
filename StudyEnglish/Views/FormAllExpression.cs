using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyEnglish.Views
{
    public interface IFormAllExpression
    {
        void CloseForm();
        void MinimizeForm();
        void MaximizeForm();

        DataTable DgvExpressionDataSource { set; }
        string lblCountRec { set; }

        event EventHandler FormLoad;
        event EventHandler btnCloseFormClick;
        event EventHandler btnMinimizeClick;
        event EventHandler btnMaximizeClick;
    }



    public partial class FormAllExpression : Form, IFormAllExpression
    {
        

        public FormAllExpression()
        {
            InitializeComponent();

            Load += FormAllExpression_Load;
            btnCloseForm.Click += BtnCloseForm_Click;
            btnMinimize.Click += BtnMinimize_Click;
            btnMaximize.Click += BtnMaximize_Click;
        }

        
        
        #region ПробросСобытий

        private void FormAllExpression_Load(object sender, EventArgs e)
        {
            if (FormLoad != null) FormLoad(this, EventArgs.Empty);            
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (btnMaximizeClick != null) btnMaximizeClick(this, EventArgs.Empty);            
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            if (btnMinimizeClick != null) btnMinimizeClick(this, EventArgs.Empty);                        
        }

        private void BtnCloseForm_Click(object sender, EventArgs e)
        {
            if (btnCloseFormClick != null) btnCloseFormClick(this, EventArgs.Empty);           
        }
        #endregion



        #region IFormAllExpression
        public void CloseForm() => Close();

        public void MinimizeForm()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void MaximizeForm()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else this.WindowState = FormWindowState.Normal;
        }

        public DataTable DgvExpressionDataSource { set => dgvExpression.DataSource = value; }
        public string lblCountRec { set => lblCount.Text = value; }

        public event EventHandler btnCloseFormClick;
        public event EventHandler btnMinimizeClick;
        public event EventHandler btnMaximizeClick;
        public event EventHandler FormLoad;
        #endregion



    }
}
