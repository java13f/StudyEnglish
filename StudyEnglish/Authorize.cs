using System.Windows.Forms;

namespace StudyEnglish
{
    public static class Authorize
    {
        private static readonly string pathDatabase = Application.StartupPath + "\\DbStudyEnglish.mdb";
        private static readonly string oleDbConStr= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathDatabase + ";Jet OLEDB:Database Password=\"\"";  //Jet OLEDB:Database Password=\"1234\"";

        public static string OleDbConStr => oleDbConStr;        
    }
}
