using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal class DBController
    {
        static SQLiteConnection connection = new SQLiteConnection("Integrated Security = SSPI; Data Source = TestAppDB.db");

        public static long Authorize(string login, string password)
        {
            long id = -1;
            connection.Open();
            string query = "SELECT * FROM User WHERE EMail = @email AND Password = @password";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteParameter[] parameters = { new SQLiteParameter("@email", login), new SQLiteParameter("@password", password) };
            command.Parameters.AddRange(parameters);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetInt64(0);
            }
            connection.Close();
            return id;
        }

        public static void AddUser(User user)
        {
            connection.Open();
            string query = "INSERT INTO User (FirstName, LastName, MiddleName, EMail, Phone, Password) " +
                           "VALUES (@firstName, @lastName, @middleName, @email, @phone, @password)";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteParameter[] parameters = { new SQLiteParameter("@firstName", user.FirstName), new SQLiteParameter("@lastName", user.LastName),
                new SQLiteParameter("@middleName", user.MiddleName), new SQLiteParameter("@email", user.Email), new SQLiteParameter("@phone", user.Phone),
                new SQLiteParameter("@password", user.Password) };
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
