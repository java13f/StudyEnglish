using System;
using System.Data;
using System.Windows.Forms;

namespace StudyEnglish.Views
{
    public interface IFormAllExpression
    {
        void CloseForm();
        void MinimizeForm();
        void MaximizeForm();

        DataTable DgvExpressionDataSource { set; }
        string LblCountRec { set; }

        event EventHandler FormLoad;
        event EventHandler BtnCloseFormClick;
        event EventHandler BtnMinimizeClick;
        event EventHandler BtnMaximizeClick;
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
            FormLoad?.Invoke(this, EventArgs.Empty);            
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            BtnMaximizeClick?.Invoke(this, EventArgs.Empty);            
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            BtnMinimizeClick?.Invoke(this, EventArgs.Empty);                        
        }

        private void BtnCloseForm_Click(object sender, EventArgs e)
        {
            BtnCloseFormClick?.Invoke(this, EventArgs.Empty);           
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
        public string LblCountRec { set => lblCount.Text = value; }

        public event EventHandler BtnCloseFormClick;
        public event EventHandler BtnMinimizeClick;
        public event EventHandler BtnMaximizeClick;
        public event EventHandler FormLoad;
        #endregion



    }
}
