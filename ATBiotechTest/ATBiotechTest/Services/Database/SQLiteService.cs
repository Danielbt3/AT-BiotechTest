using System.Data.SQLite;
using System.IO;

namespace ATBiotechTest.Services.Database
{
    public abstract class SQLiteService
    {
        private string dbName = "ATBiotechDB";
        public string DBName { get { return dbName; } }
        public SQLiteService()
        {
            SetupDatabase();
        }

        private void SetupDatabase()
        {
            if (!File.Exists($"{DBName}.sqlite"))
            {
                SQLiteConnection.CreateFile($"{DBName}.sqlite");

                using SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={DBName}.sqlite;Version=3;");
                m_dbConnection.Open();

                string sql = "create table contacts (id integer primary key , name varchar(500),address varchar(500))";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
            }
        }
    }
}
