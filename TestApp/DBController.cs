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
        static SQLiteConnection connection = new SQLiteConnection("Integrated Security = SSPI; Data Source = ../../TestAppDB.db");

        public static User Authorize(string login, string password)
        {
            User user = null;
            connection.Open();
            string query = "SELECT * FROM User WHERE EMail = @email AND Password = @password";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteParameter[] parameters = { new SQLiteParameter("@email", login), new SQLiteParameter("@password", password) };
            command.Parameters.AddRange(parameters);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                user = new User(reader.GetInt64(0), reader.GetString(1), reader.GetString(2),
                    reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
                    reader.GetString(7));
            }
            connection.Close();
            return user;
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

        public static List<UserTest> GetTests(User user)
        {
            List<UserTest> tests = new List<UserTest>();

            connection.Open();
            string query = "SELECT * FROM Test ";
            SQLiteParameter[] parameters = { };

            if (user.Role == "user")
            {
                query += "WHERE TestID IN ( " +
                         "SELECT Test FROM Question " +
                         "INNER JOIN UserQuestion " +
                         "ON Question.QuestionID = UserQuestion.Question " +
                         "WHERE UserQuestion.User = @userId " +
                         ")";
                parameters.Append(new SQLiteParameter("@userId", user.UserID));
            }

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddRange(parameters);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tests.Add(new UserTest(reader.GetInt64(0), reader.GetString(1), 0, false));
                }
            }

            return tests;
        }
    }
}
