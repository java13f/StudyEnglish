﻿using StudyEnglish.Models;
using StudyEnglish.Views;
using System.Data;

namespace StudyEnglish.Presenters
{
    public class AllExpressionPresenter
    {
        IFormAllExpression _view;
        IAllExpressionModel _model;

        public AllExpressionPresenter(IFormAllExpression view, IAllExpressionModel model)
        {
            _view = view;
            _model = model;

            _view.FormLoad += _view_FormLoad;
            _view.btnCloseFormClick += _view_btnCloseFormClick;
            _view.btnMinimizeClick += _view_btnMinimizeClick;
            _view.btnMaximizeClick += _view_btnMaximizeClick;
        }

        private void _view_FormLoad(object sender, System.EventArgs e)
        {
            DataTable tableExpression = _model.GetAllExpression();
            _view.DgvExpressionDataSource = tableExpression;
            _view.lblCountRec = tableExpression.Rows.Count.ToString();
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