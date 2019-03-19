using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;


namespace StudyEnglish.Models
{
    public interface IMainModel
    {
        DataTable GetTableRule();
        DataTable GetTableLessons(bool условие = false);
        void AddNewExpression(string ExpEng, string ExpRus, string idRule, string idLesson);
        List<List<string>> GetListExpression();
        List<List<string>> GetListExpression(string lesson);
        string RandomExpression(List<List<string>> listExpression);
        bool CompareExpression(List<List<string>> listExpression, int indexList, string engleashTrasnlate);
    }

    public interface IAllExpressionModel
    {
        DataTable GetAllExpression();
    }

    public class MainModel : OleDbHelper, IMainModel, IAllExpressionModel
    {

        #region IMainModel
        public void AddNewExpression(string ExpEng, string ExpRus, string idRule, string idLesson)
        {
            
            string query = "INSERT INTO tbExpression(ExpressionEng, ExpressionRus, idRule, idLesson) " +
                "VALUES('" + ExpEng + "', '" + ExpRus + "', '" + idRule + "', '"+idLesson+"')";
                        
            ExecuteNonQuery(Authorize.OleDbConStr, query);
        }

        public DataTable GetTableRule()
        {
            DataTable tableRule = new DataTable();

            string query = "SELECT idRule, Subject, Rule, Time " +
                "FROM tbRule " +
                "ORDER BY idRule DESC";

            tableRule.Load(ExecuteReader(Authorize.OleDbConStr, query));

            return tableRule;
        }
        
        public DataTable GetTableLessons(bool условие = false)
        {
            DataTable tableLesson = new DataTable();

            string query = "SELECT idLesson, Lesson " +
                "FROM tbLesson ";

            string where = "WHERE Lesson <> 'Все уроки' ";
            string sort = "ORDER BY Lesson DESC";

            if (условие) query += where;

            query += sort;            

            tableLesson.Load(ExecuteReader(Authorize.OleDbConStr, query));

            return tableLesson;
        }

        public List<List<string>> GetListExpression()
        {
            string query = "SELECT ExpressionEng, ExpressionRus FROM tbExpression";
            OleDbDataReader reader = ExecuteReader(Authorize.OleDbConStr, query);

            List<string> listExpEng = new List<string>();
            List<string> listExpRus = new List<string>();
            List<List<string>> listExpression = new List<List<string>>();

            while (reader.Read())
            {
                listExpEng.Add(reader.GetString(0));
                listExpRus.Add(reader.GetString(1));
            }

            listExpression.Add(listExpEng);
            listExpression.Add(listExpRus);

            return listExpression;
        }

        public List<List<string>> GetListExpression(string lesson)
        {
            string query = "SELECT ExpressionEng, ExpressionRus " +
                "FROM tbExpression e " +
                "inner join tbLesson les on les.idLesson = e.idLesson " +
                "WHERE Lesson='"+lesson+"' ";
            OleDbDataReader reader = ExecuteReader(Authorize.OleDbConStr, query);

            List<string> listExpEng = new List<string>();
            List<string> listExpRus = new List<string>();
            List<List<string>> listExpression = new List<List<string>>();

            while (reader.Read())
            {
                listExpEng.Add(reader.GetString(0));
                listExpRus.Add(reader.GetString(1));
            }

            listExpression.Add(listExpEng);
            listExpression.Add(listExpRus);

            return listExpression;
        }


        public string RandomExpression(List<List<string>> listExpression)
        {
            List<string> listExpEng = new List<string>();
            List<string> listExpRus = new List<string>();

            listExpEng = listExpression[0];
            listExpRus = listExpression[1];

            Random random = new Random(DateTime.Now.Millisecond);
            int index = random.Next(0, listExpRus.Count);

            return index + "," + listExpRus[index];
        }
        
        public bool CompareExpression(List<List<string>> listExpression, int indexList, string engleashTrasnlate)
        {
            List<string> listExpEng = new List<string>();

            listExpEng = listExpression[0];

            if (engleashTrasnlate == listExpEng[indexList]) return true;
            else
                return false;
        }

        

        


        #endregion



        #region IAllExpressionModel
        public DataTable GetAllExpression()
        {
            DataTable tableExpression = new DataTable();

            string query = "SELECT ExpressionEng, ExpressionRus, Subject, Time, Lesson " +
                "FROM (tbExpression e " +
                "inner join tbRule r on r.idRule = e.idRule) " +
                "inner join tbLesson les on les.idLesson = e.idLesson " +
                "ORDER BY e.idLesson";
            tableExpression.Load(ExecuteReader(Authorize.OleDbConStr, query));

            return tableExpression;
        }
        #endregion








    }
}
