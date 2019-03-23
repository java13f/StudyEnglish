using StudyEnglish.BL.Controller;
using StudyEnglish.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudyEnglish.Presenters
{
    public class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IEditExpression _editExpression;
        private readonly MessageService _message;

        private List<List<string>> _listExpression;
        private int _indexList;
        private List<int> _indexListПройденныхВыражений;

                
        public MainPresenter(IMainForm view, IEditExpression editExpression)
        {
            _view = view;
            _editExpression = editExpression;
            _message = new MessageService();

            _indexListПройденныхВыражений = new List<int>();
                        
            _view.FormLoad += _view_FormLoad;
            _view.BtnCloseFormClick += _view_btnCloseFormClick;
            _view.BtnMinimizeClick += _view_btnMinimizeClick;
            _view.BtnMaximizeClick += _view_btnMaximizeClick;

            _view.BtnAddExpressionClick += _view_btnAddExpressionClick;
            _view.BtnTestEngClick += _view_btnTestEngClick;
            _view.BtnAllExpressionClick += _view_btnAllExpressionClick;
            _view.BtnAlphabetClick += _view_btnAlphabetClick;
            _view.BtnTableTimeClick += _view_btnTableTimeClick;
            _view.BtnUpdateExpressionClick += _view_btnUpdateExpressionClick;

            _view.DgvRuleCellMouseClick += _view_DgvRuleCellMouseClick;
            _view.BtnBackClick += _view_BtnBackClick;
            _view.BtnSaveClick += _view_btnSaveClick;
                        
            _view.BtnCheckClick += _view_btnCheckClick;            
            _view.EnglishTranslateKeyPress += _view_EnglishTranslateKeyPress;
                                    
            _view.TxtExpEngKeyPress += _view_txtExpEngKeyPress;
            _view.TxtExpRusKeyPress += _view_txtExpRusKeyPress;
            _view.TxtExpEngEnter += _view_txtExpEngEnter;
            _view.TxtExpRusEnter += _view_txtExpRusEnter;
            _view.TxtEnglishTranslateEnter += _view_txtEnglishTranslateEnter;
            _view.TxtExpEngTextChanged += _view_txtExpEngTextChanged;                       
            
            _view.CmbLessonTestSelectionChangeCommitted += _view_CmbLessonTestSelectionChangeCommitted;
        }

        

        private void _view_btnMaximizeClick(object sender, EventArgs e)
        {
            _view.MaximizeForm();
        }

        private void _view_FormLoad(object sender, EventArgs e)
        {
            _view.Version = "Version: " + Application.ProductVersion;
            _view.FormSizeDefault();
            _view.Часики();
        }


        private void _view_btnAddExpressionClick(object sender, EventArgs e)
        {
            _view.ExpressionEngText = "";
            _view.ExpressionRusText = "";

            _view.ПоказатьОднуВкладку(1);
            _view.TabControlMainVisible = true;
            _view.DgvRuleDataSource = _editExpression.GetTableRule();

            _view.CmbLessonValueMember = "idLesson";            
            _view.CmbLessonDisplayMember = "Lesson";
            _view.CmbLessonDataSource = _editExpression.GetTableLessons(true);

            _view.CmbLessonSelectedIndex = -1;            
        }

        private void _view_btnTestEngClick(object sender, EventArgs e)
        {                      
            ОчиститьПоляПередТестированием();

            _view.ПоказатьОднуВкладку(2);
            _view.TabControlMainVisible = true;
            _view.DgvRuleDataSource = _editExpression.GetTableRule();
            _view.SetFocusedEnglishTranslate();

            _listExpression = _editExpression.GetListExpression();
            _view.NumExpression = _listExpression[0].Count;

            ViewRandomExpression();
            
            _view.CmbLessonTestValueMember = "idLesson";
            _view.CmbLessonTestDisplayMember = "Lesson";            
            _view.CmbLessonTestDataSource = _editExpression.GetTableLessons();

            _view.CmbLessonTestSelectedIndex = -1;            
        }

        private void _view_btnUpdateExpressionClick(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog() { Filter = "Database files(*.mdb)|*.mdb|All files(*.*)|*.*" };
            //openFile.Filter = "Database files(*.mdb)|*.mdb|All files(*.*)|*.*";

            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (!openFile.FileName.Contains("DbStudyEnglish.mdb")) throw new Exception("Неверный фомат файла!"); 
                                                            
                    FileInfo f = new FileInfo(openFile.FileName);
                    f.CopyTo(Application.StartupPath + "\\DbStudyEnglish.mdb", true);
                    _message.ShowMessage("База данных выражений обновлена!");
                }                
            }
            catch (Exception ex)
            {
                _message.ShowError("Произошел сбой при обновлении базы данных выражений: " + ex.Message);                
            }            
        }

        

        private void _view_txtExpEngTextChanged(object sender, EventArgs e)
        {
            if (_view.ExpressionEngText.Length == 1) _view.ЗаглавнаяБуква("txtExpEng");
            if (_view.ExpressionRusText.Length == 1) _view.ЗаглавнаяБуква("txtExpRus");
            if (_view.EnglishTranslate.Length == 1) _view.ЗаглавнаяБуква("txtEnglishTranslate");
        }

        private void _view_txtEnglishTranslateEnter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
        }
  
        private void _view_txtExpRusEnter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));
        }

        private void _view_txtExpEngEnter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
        }

        private void _view_txtExpRusKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _view_btnSaveClick(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void _view_EnglishTranslateKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _view_btnCheckClick(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void _view_txtExpEngKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)            
                _view.SetFocusedExpRus();
            
        }

        private void _view_btnAllExpressionClick(object sender, EventArgs e)
        {
            if (Application.OpenForms.Cast<Form>().Any(f => f.Name == "AllExpression")) return;
            else
            {               
                FormAllExpression frmAllExpression = new FormAllExpression();
                IAllExpression allExpression = new ExpressionManager(Authorize.OleDbConStr);
                AllExpressionPresenter presenterAllExpression = new AllExpressionPresenter(frmAllExpression, allExpression);
                frmAllExpression.Name = "AllExpression";
                frmAllExpression.Show();
            }                                                   
                        
        }


        private void _view_btnAlphabetClick(object sender, EventArgs e)
        {
            if (Application.OpenForms.Cast<Form>().Any(f => f.Name == "Alphabet")) return;
            else
            {
                FormAlphabet frmAlphabet = new FormAlphabet() { Name = "Alphabet" };                
                frmAlphabet.Show();
            }                
        }

        private void _view_btnTableTimeClick(object sender, EventArgs e)
        {
            if (Application.OpenForms.Cast<Form>().Any(f => f.Name == "Times")) return;
            else
            {
                FormTimes frmTimes = new FormTimes() { Name = "Times" };                
                frmTimes.Show();
            }
                
        }

        private void _view_btnMinimizeClick(object sender, EventArgs e)
        {
            _view.MinimizeForm();
        }
                
        
        private void _view_btnCheckClick(object sender, EventArgs e)
        {            
            if (!_editExpression.CompareExpression(_listExpression, _indexList, _view.EnglishTranslate))
            {
                _message.ShowExclamation("Ошибка перевода");
                _view.NumError++;
                return;
            }
            else _view.NumCorrect++;
            
            _indexListПройденныхВыражений.Add(_indexList);
            
            while (true)
            {
                _view.EnglishTranslate = "";
                string[] expressionRussian = _editExpression.RandomExpression(_listExpression).Split(',');

                _indexList = Convert.ToInt32(expressionRussian[0]);
                                
                if (_indexListПройденныхВыражений.Count == _listExpression[0].Count)
                {
                    _message.ShowMessage("Тест пройден!");
                    _view_btnTestEngClick(this, EventArgs.Empty);

                    _view.CmbLessonTestSelectedIndex = -1;
                                        
                    return;
                }

                if (_indexListПройденныхВыражений.Contains(_indexList)) continue;                              
                                             
                _view.RussianTest = expressionRussian[1];
                
                return;
            }
           
        }

        private void _view_CmbLessonTestSelectionChangeCommitted(object sender, EventArgs e)
        {
            ОчиститьПоляПередТестированием();
                        
            string lesson = _view.CmbLessonTestText;

            if (lesson == "Все уроки")
               _listExpression = _editExpression.GetListExpression();
            else _listExpression = _editExpression.GetListExpression(lesson);

            _view.NumExpression = _listExpression[0].Count;
            ViewRandomExpression();
        }

        

        private void ViewRandomExpression()
        {
            string[] expressionRussian = _editExpression.RandomExpression(_listExpression).Split(',');

            _indexList = Convert.ToInt32(expressionRussian[0]);
            _view.RussianTest = expressionRussian[1];
        }

        private void ОчиститьПоляПередТестированием()
        {
            _indexListПройденныхВыражений.Clear();
            _view.NumCorrect = 0;
            _view.NumError = 0;
            _view.EnglishTranslate = string.Empty;
        }
                        

        private void _view_btnSaveClick(object sender, EventArgs e)
        {            
            if (_view.ExpressionEngText=="" || _view.ExpressionRusText=="" || _view.IdRule=="" || _view.CmbLessonSelectedIndex == -1) 
            {
                _message.ShowError("Введите данные!");
                return;
            }                          


            try
            {
                _editExpression.AddNewExpression(_view.ExpressionEngText, _view.ExpressionRusText, _view.IdRule, _view.CmbLessonSelectedValue);
                _message.ShowMessage("Выполнено!");
            }
            catch (Exception ex)
            {
                _message.ShowExclamation(ex.Message);
                return;
            }

            _view.ExpressionEngText = "";
            _view.ExpressionRusText = "";
            _view.SetFocusedExpressionEng();
        }

        private void _view_BtnBackClick(object sender, EventArgs e)
        {
            _view.TabControlMainVisible = false;
        }

        private void _view_DgvRuleCellMouseClick(object sender, EventArgs e)
        {
            _view.СнятьВыделение();            
        }

        

        private void _view_btnCloseFormClick(object sender, EventArgs e)
        {
            _view.CloseForm();
        }
    }
}
