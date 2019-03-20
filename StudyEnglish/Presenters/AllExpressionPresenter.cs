using StudyEnglish.BL.Controller;
using StudyEnglish.Views;
using System.Data;

namespace StudyEnglish.Presenters
{
    public class AllExpressionPresenter
    {
        IFormAllExpression _view;
        IAllExpression _expressionController;

        public AllExpressionPresenter(IFormAllExpression view, IAllExpression expressionController)
        {
            _view = view;
            _expressionController = expressionController;

            _view.FormLoad += _view_FormLoad;
            _view.BtnCloseFormClick += _view_btnCloseFormClick;
            _view.BtnMinimizeClick += _view_btnMinimizeClick;
            _view.BtnMaximizeClick += _view_btnMaximizeClick;
        }

        private void _view_FormLoad(object sender, System.EventArgs e)
        {
            DataTable tableExpression = _expressionController.GetAllExpression();
            _view.DgvExpressionDataSource = tableExpression;
            _view.LblCountRec = tableExpression.Rows.Count.ToString();
        }

        private void _view_btnMaximizeClick(object sender, System.EventArgs e)
        {
            _view.MaximizeForm();
        }

        private void _view_btnMinimizeClick(object sender, System.EventArgs e)
        {
            _view.MinimizeForm();
        }

        private void _view_btnCloseFormClick(object sender, System.EventArgs e)
        {
            _view.CloseForm();
        }





    }
}
