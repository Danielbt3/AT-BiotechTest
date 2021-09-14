using ATBiotechTest.Dtos;
using ATBiotechTest.Services.Database.Interfaces;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ATBiotechTest.Services.Database
{
    public class ContactsRepository : SQLiteService, IContactsRepository
    {
        private string tableName = "contacts";
        public string TableName { get { return tableName; } }


        #region CRUD
        public void Create(ContactDto input)
        {
            using SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={DBName}.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = $"insert into {TableName} (name,address) values ('{input.Name}','{input.Address}')";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        public List<ContactDto> GetContacts(ContactQueryDto query)
        {
            using SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={DBName}.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = $"select * from {TableName}";

            sql += query.Id != 0 ? $" {whereOrAnd(sql)} id = {query.Id}" : string.Empty;
            sql += !string.IsNullOrEmpty(query.Name) ? $" {whereOrAnd(sql)} name = '{query.Name}'" : string.Empty;
            sql += !string.IsNullOrEmpty(query.Address) ? $" {whereOrAnd(sql)} address = '{query.Address}'" : string.Empty;

            sql += $" limit {query.maxItemsPerPage} offset {query.skipPage}";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            var reader = command.ExecuteReader();

            List<ContactDto> resuls = new List<ContactDto>();
            while (reader.Read())
            {
                resuls.Add(new ContactDto((long)reader["id"], (string)reader["name"], (string)reader["address"]));
            }
            m_dbConnection.Close();
            return resuls;
        }

        public void UpdateContacts(ContactDto input, long id)
        {
            using SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={DBName}.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = $"update {TableName} set";

            sql += !string.IsNullOrEmpty(input.Name) ? $" name = '{input.Name}'," : "name = ' ',";
            sql += !string.IsNullOrEmpty(input.Address) ? $" address = '{input.Address}'" : "address = ' '";

            sql += $" where id = {id}";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            var reader = command.ExecuteNonQuery();
        }

        public void DeleteContacts(long id)
        {
            using SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={DBName}.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = $"delete from {TableName} where id = {id}";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            var reader = command.ExecuteNonQuery();
        }
        #endregion

        private string whereOrAnd(string sql)
        {
            return sql.Contains("where") ? "and" : "where";
        }
    }
}
