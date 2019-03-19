using System;
using System.Data;
using System.Data.OleDb;


namespace StudyEnglish
{
    public class OleDbHelper
    {

        public Int32 ExecuteNonQuery(String connectionString, String commandText)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }



        public OleDbDataReader ExecuteReader(String connectionString, String commandText)
        {
            
            OleDbConnection conn = new OleDbConnection(connectionString);

            using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
            {
                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the   
                // IDataReader is closed.  
                
                OleDbDataReader reader = cmd.ExecuteReader( CommandBehavior.CloseConnection);

                return reader;
            }
        }

        
    }
}
