using StudyEnglish.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyEnglish
{
    public interface IMainForm
    {
        void CloseForm();
        void MinimizeForm();
        void MaximizeForm();
        DataTable DgvRuleDataSource { set; }
        
        string ExpressionEngText { get; set; }
        string ExpressionRusText { get; set; }
        string IdRule { get; }
        void СнятьВыделение();        
        bool TabControlMainVisible { set; }
        void ПоказатьОднуВкладку(int numPage);
        void SetFocusedExpressionEng();
        void SetFocusedExpRus();

        #region ComboBoxs        
        DataTable CmbLessonDataSource { set; }
        DataTable CmbLessonTestDataSource { set; }

        int CmbLessonTestSelectedIndex { get; set; }
        int CmbLessonSelectedIndex { get; set; }

        string CmbLessonValueMember { set; }
        string CmbLessonTestValueMember { set; }

        string CmbLessonDisplayMember { set; }
        string CmbLessonTestDisplayMember { set; }

        string CmbLessonTestText { get; }
        string CmbLessonSelectedValue { get; }
        #endregion

        string RussianTest { get; set; }
        string EnglishTranslate { get; set; }

        void SetFocusedEnglishTranslate();


        int NumExpression { get; set; }
        int NumCorrect { get; set; }
        int NumError { get; set; }


        void ЗаглавнаяБуква(string nameTextBox);

        string Version { set; }

        void FormSizeDefault();
        void Часики();
        
        event EventHandler btnAddExpressionClick;
        event EventHandler btnTestEngClick;        
        event EventHandler btnAllExpressionClick;                
        event EventHandler btnAlphabetClick;
        event EventHandler btnTableTimeClick;
        event EventHandler btnUpdateExpressionClick;
        
        event EventHandler btnCloseFormClick;
        event EventHandler btnMaximizeClick;
        event EventHandler btnMinimizeClick;
        
        event EventHandler DgvRuleCellMouseClick;
        event EventHandler btnBackClick;
        event EventHandler btnSaveClick;
        
        event EventHandler btnCheckClick;
        

        event KeyPressEventHandler txtExpRusKeyPress;
        event KeyPressEventHandler txtExpEngKeyPress;
        event KeyPressEventHandler EnglishTranslateKeyPress;

        event EventHandler txtExpEngEnter;
        event EventHandler txtExpRusEnter;
        event EventHandler txtEnglishTranslateEnter;

        event EventHandler txtExpEngTextChanged;

        event EventHandler FormLoad;
        event EventHandler CmbLessonTestSelectionChangeCommitted;
    }




    public partial class FormMain : Form, IMainForm
    {        
        public FormMain()
        {
            InitializeComponent();

            Load += FormMain_Load;

            btnAddExpression.Click += BtnAddExpression_Click;
            btnTestEng.Click += BtnTestEng_Click;
            btnAllExpression.Click += BtnAllExpression_Click;
            btnAlphabet.Click += BtnAlphabet_Click;
            btnTableTime.Click += BtnTableTime_Click;
            btnUpdateExpression.Click += BtnUpdateExpression_Click;


            btnCloseForm.Click += BtnCloseForm_Click;
            btnMinimize.Click += BtnMinimize_Click;

            dgvRule.CellMouseClick += DgvRule_CellMouseClick;
            dgvRuleCopy.CellMouseClick += DgvRule_CellMouseClick;
            btnBack.Click += BtnBack_Click;
            btnSave.Click += BtnSave_Click;

            btnBackTestEng.Click += BtnBack_Click;
            btnCheck.Click += BtnCheck_Click;

            txtEnglishTranslate.KeyPress += TxtEnglishTranslate_KeyPress;
            txtExpEng.KeyPress += TxtExpEng_KeyPress;
            txtExpRus.KeyPress += TxtExpRus_KeyPress;

            txtExpEng.Enter += TxtExpEng_Enter;
            txtExpRus.Enter += TxtExpRus_Enter;
            txtEnglishTranslate.Enter += TxtEnglishTranslate_Enter;

            txtExpEng.TextChanged += TxtExpEng_TextChanged;
            txtExpRus.TextChanged += TxtExpEng_TextChanged;
            txtEnglishTranslate.TextChanged += TxtExpEng_TextChanged;
            btnMaximize.Click += BtnMaximize_Click;
            btnMaximize2.Click += BtnMaximize_Click;

            cmbLessonTest.SelectionChangeCommitted += CmbLessonTest_SelectionChangeCommitted;                        
        }




        #region ПробросСобытий  
        private void CmbLessonTest_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbLessonTestSelectionChangeCommitted != null) CmbLessonTestSelectionChangeCommitted(this, EventArgs.Empty);
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (btnMaximizeClick != null) btnMaximizeClick(this, EventArgs.Empty);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            if (FormLoad != null) FormLoad(this, EventArgs.Empty);
        }

        private void BtnUpdateExpression_Click(object sender, EventArgs e)
        {
            if (btnUpdateExpressionClick != null) btnUpdateExpressionClick(this, EventArgs.Empty);
        }

        private void TxtExpEng_TextChanged(object sender, EventArgs e)
        {
            if (txtExpEngTextChanged != null) txtExpEngTextChanged(this, EventArgs.Empty);
        }

        private void TxtEnglishTranslate_Enter(object sender, EventArgs e)
        {
            if (txtEnglishTranslateEnter != null) txtEnglishTranslateEnter(this, EventArgs.Empty);
        }

        private void TxtExpRus_Enter(object sender, EventArgs e)
        {
            if (txtExpRusEnter != null) txtExpRusEnter(this, EventArgs.Empty);
        }

        private void TxtExpEng_Enter(object sender, EventArgs e)
        {
            if (txtExpEngEnter != null) txtExpEngEnter(this, EventArgs.Empty);
        }

        private void TxtExpRus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtExpRusKeyPress != null) txtExpRusKeyPress(this, e);
        }
        private void TxtExpEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtExpEngKeyPress != null) txtExpEngKeyPress(this, e);
        }
        private void BtnAllExpression_Click(object sender, EventArgs e)
        {
            if (btnAllExpressionClick != null) btnAllExpressionClick(this, EventArgs.Empty);
        }
        private void BtnAlphabet_Click(object sender, EventArgs e)
        {
            if (btnAlphabetClick != null) btnAlphabetClick(this, EventArgs.Empty);
        }
        private void BtnTableTime_Click(object sender, EventArgs e)
        {
            if (btnTableTimeClick != null) btnTableTimeClick(this, EventArgs.Empty);
        }

        private void BtnCloseForm_Click(object sender, EventArgs e)
        {
            if (btnCloseFormClick != null) btnCloseFormClick(this, EventArgs.Empty);
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            if (btnMinimizeClick != null) btnMinimizeClick(this, EventArgs.Empty);
        }

        private void BtnAddExpression_Click(object sender, EventArgs e)
        {
            if (btnAddExpressionClick != null) btnAddExpressionClick(this, EventArgs.Empty);
        }

        private void DgvRule_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DgvRuleCellMouseClick != null) DgvRuleCellMouseClick(this, DataGridViewCellMouseEventArgs.Empty);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (btnBackClick != null) btnBackClick(this, EventArgs.Empty);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (btnSaveClick != null) btnSaveClick(this, EventArgs.Empty);
        }

        private void BtnTestEng_Click(object sender, EventArgs e)
        {
            if (btnTestEngClick != null) btnTestEngClick(this, EventArgs.Empty);
        }
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (btnCheckClick != null) btnCheckClick(this, EventArgs.Empty);
        }

        private void TxtEnglishTranslate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnglishTranslateKeyPress != null) EnglishTranslateKeyPress(this, e);
        }
        #endregion



        #region IMainForm

        public void CloseForm()
        {
            this.Close();
        }

        public void MinimizeForm()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void MaximizeForm()
        {
            if (Height == SystemInformation.PrimaryMonitorSize.Height - 40)
            {//свернуть
                Width = 1241;
                Height = 590;

                StartPosition = FormStartPosition.CenterScreen;
                WindowState = FormWindowState.Normal;

                int x = (SystemInformation.PrimaryMonitorSize.Width / 2) - (Width / 2);
                int y = (SystemInformation.PrimaryMonitorSize.Height / 2) - ((Height + 40) / 2);
                Location = new Point(x, y);

                btnMaximize.ImageIndex = 4;
                btnMaximize2.ImageIndex = 4;
            }
            else
            {//развернуть
                Width = 1241;
                Height = SystemInformation.PrimaryMonitorSize.Height - 40;

                StartPosition = FormStartPosition.CenterScreen;
                WindowState = FormWindowState.Normal;

                int x = (SystemInformation.PrimaryMonitorSize.Width / 2) - (Width / 2);
                Location = new Point(x, 0);

                btnMaximize.ImageIndex = 0;
                btnMaximize2.ImageIndex = 0;
            }

        }

        public void FormSizeDefault()
        {
            Width = 1241;
            Height = 590;
        }



        /// <summary>
        /// Все свойства ComboBoxs
        /// </summary>
        #region ComboBoxs
        public string CmbLessonSelectedValue { get => cmbLesson.SelectedValue.ToString(); }
        public string CmbLessonTestText { get => cmbLessonTest.Text; }
        public string CmbLessonDisplayMember { set => cmbLesson.DisplayMember = value; }
        public string CmbLessonTestDisplayMember { set => cmbLessonTest.DisplayMember = value; }
        public string CmbLessonValueMember { set => cmbLesson.ValueMember = value; }
        public string CmbLessonTestValueMember { set => cmbLessonTest.ValueMember = value; }
        public int CmbLessonSelectedIndex { get => cmbLesson.SelectedIndex; set => cmbLesson.SelectedIndex = value; }
        public int CmbLessonTestSelectedIndex { get => cmbLessonTest.SelectedIndex; set => cmbLessonTest.SelectedIndex = value; }
        public DataTable CmbLessonDataSource { set => cmbLesson.DataSource = value; }
        public DataTable CmbLessonTestDataSource { set => cmbLessonTest.DataSource = value; }
        #endregion
        

        public DataTable DgvRuleDataSource { set => dgvRule.DataSource = dgvRuleCopy.DataSource = value; }
        public string ExpressionEngText { get => txtExpEng.Text.Trim(); set => txtExpEng.Text = value; }
        public string ExpressionRusText { get => txtExpRus.Text.Trim(); set => txtExpRus.Text = value; }
        public string IdRule
        {
            get
            {
                if (dgvRule.Rows.Count < 1) return "";

                try
                {
                    for (int i = 0; i < dgvRule.Rows.Count; i++)
                    {
                        if ((bool)dgvRule.Rows[i].Cells[0].Value == true)
                            return dgvRule.Rows[i].Cells[1].Value.ToString();
                    }
                    return "";
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }

        }
        public bool TabControlMainVisible { set => tabControlMain.Visible = value; }
        public string RussianTest { get => txtRussianTest.Text.Trim(); set => txtRussianTest.Text = value; }
        public string EnglishTranslate { get => txtEnglishTranslate.Text.Trim(); set => txtEnglishTranslate.Text = value; }


        public int NumExpression { get => (int)numExpression.Value; set => numExpression.Value = value; }
        public int NumCorrect { get => (int)numCorrect.Value; set => numCorrect.Value = value; }
        public int NumError { get => (int)numError.Value; set => numError.Value = value; }
        
        public string Version { set => lblVersion.Text = value; }
                        
        public void СнятьВыделение()
        {
            if (dgvRule.Rows.Count < 1 && dgvRuleCopy.Rows.Count < 1) return;

            if (dgvRule.Rows.Count >= 1)
            {
                for (int i = 0; i < dgvRule.Rows.Count; i++)
                    dgvRule.Rows[i].Cells[0].Value = false;
            }

            if (dgvRuleCopy.Rows.Count >= 1)
            {
                for (int i = 0; i < dgvRuleCopy.Rows.Count; i++)
                    dgvRuleCopy.Rows[i].Cells[0].Value = false;
            }
        }
        public void ПоказатьОднуВкладку(int numPage)
        {
            tabControlMain.TabPages.Remove(tabPageAddExpression);
            tabControlMain.TabPages.Remove(tabPageTestEnglish);

            switch (numPage)
            {
                case 1:
                    tabControlMain.TabPages.Add(tabPageAddExpression);
                    break;
                case 2:
                    tabControlMain.TabPages.Add(tabPageTestEnglish);
                    break;
            }
        }
        public void SetFocusedExpressionEng() => txtExpEng.Focus();
        public void SetFocusedEnglishTranslate() => txtEnglishTranslate.Focus();
        public void SetFocusedExpRus() => txtExpRus.Focus();
        public void ЗаглавнаяБуква(string nameTextBox)
        {
            switch (nameTextBox)
            {
                case "txtExpEng":
                    txtExpEng.Text = txtExpEng.Text.ToUpper();
                    txtExpEng.Select(txtExpEng.Text.Length, 0);                    
                    break;

                case "txtExpRus":
                    txtExpRus.Text = txtExpRus.Text.ToUpper();
                    txtExpRus.Select(txtExpRus.Text.Length, 0);
                    break;

                case "txtEnglishTranslate":
                    txtEnglishTranslate.Text = txtEnglishTranslate.Text.ToUpper();
                    txtEnglishTranslate.Select(txtEnglishTranslate.Text.Length, 0);
                    break;                    
            }
        }
        public void Часики()
        {
            Action action = () =>
            {
                while (true)
                {
                    Invoke((Action)(() =>
                    {
                        lblTime.Text = DateTime.Now.ToLongTimeString();
                        //if (lblTime.Text == "10:12:30") MessageBox.Show("Круто...");
                    }
                    ));
                    Thread.Sleep(1000);
                }
            };

            Task task = new Task(action);
            task.Start();
        }

        public event EventHandler btnCloseFormClick;
        public event EventHandler btnAddExpressionClick;
        public event EventHandler DgvRuleCellMouseClick;
        public event EventHandler btnBackClick;
        public event EventHandler btnSaveClick;
        public event EventHandler btnTestEngClick;
        public event EventHandler btnCheckClick;        
        public event KeyPressEventHandler EnglishTranslateKeyPress;
        public event EventHandler btnMinimizeClick;
        public event EventHandler btnTableTimeClick;
        public event EventHandler btnAlphabetClick;
        public event EventHandler btnAllExpressionClick;
        public event KeyPressEventHandler txtExpEngKeyPress;
        public event KeyPressEventHandler txtExpRusKeyPress;
        public event EventHandler txtExpEngEnter;
        public event EventHandler txtExpRusEnter;
        public event EventHandler txtEnglishTranslateEnter;
        public event EventHandler txtExpEngTextChanged;
        public event EventHandler btnUpdateExpressionClick;
        public event EventHandler FormLoad;
        public event EventHandler btnMaximizeClick;
        public event EventHandler CmbLessonTestSelectionChangeCommitted;

        #endregion


    }
}
