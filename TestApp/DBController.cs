using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Model;
using static System.Net.Mime.MediaTypeNames;

namespace TestApp
{
    internal class DBController
    {
        static SQLiteConnection connection = new SQLiteConnection("Integrated Security = SSPI; Data Source = ../../TestAppDB.db; Version=3; MultipleActiveResultSets=True; foreign keys=True");

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
            reader.Close();
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

        public static List<Test> GetTests(User user)
        {
            List<Test> tests = new List<Test>();

            connection.Open();


            string getUserTestsQuery = "SELECT TestID, Name, IFNULL(( " +
                     "  SELECT SUM(IFNULL(Score, 0)) FROM UserQuestion " +
                     "  INNER JOIN Question " +
                     "  ON UserQuestion.Question = Question.QuestionID " +
                     "  WHERE UserQuestion.User = 2 AND Question.Test = TestID" +
                     "), 0) S " +
                     "FROM Test";
            SQLiteParameter[] getUserTestsParameters = { new SQLiteParameter("@userId", user.UserID) };

            string getTestQuestionQuery = "SELECT QuestionID, Text, Type, Rank, IFNULL(Photo, \"\"), Test FROM Question " +
                                          "WHERE Test = @testId";
            string getQuestionAnswersQuery = "SELECT AnswerID, Text, IsCorrect, Question FROM Answer " +
                                        "WHERE Question = @questionId";

            SQLiteCommand command = new SQLiteCommand(getUserTestsQuery, connection);
            command.Parameters.AddRange(getUserTestsParameters);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Test test = null;
                    if (user.Role == "user")
                        test = new UserTest(reader.GetInt64(0), reader.GetString(1), reader.GetDouble(2), false);
                    else
                        test = new Test(reader.GetInt64(0), reader.GetString(1));

                    SQLiteParameter[] getTestQuestionParameters = { new SQLiteParameter("@testId", test.TestID) };
                    SQLiteCommand getTestQuestionCommand = new SQLiteCommand(getTestQuestionQuery, connection);
                    getTestQuestionCommand.Parameters.AddRange(getTestQuestionParameters);
                    SQLiteDataReader getTestQuestionReader = getTestQuestionCommand.ExecuteReader();

                    while (getTestQuestionReader.Read())
                    {
                        Question question = new Question(getTestQuestionReader.GetInt64(0), getTestQuestionReader.GetString(1), getTestQuestionReader.GetString(2),
                            getTestQuestionReader.GetDouble(3), getTestQuestionReader.GetString(4));

                        SQLiteParameter[] getQuestionAnswersParameters = { new SQLiteParameter("@questionId", question.QuestionId) };
                        SQLiteCommand getQuestionAnswersCommand = new SQLiteCommand(getQuestionAnswersQuery, connection);
                        getQuestionAnswersCommand.Parameters.AddRange(getQuestionAnswersParameters);
                        SQLiteDataReader getQuestionAnswersReader = getQuestionAnswersCommand.ExecuteReader();

                        while (getQuestionAnswersReader.Read())
                        {
                            question.Answers.Add(new Answer(getQuestionAnswersReader.GetInt64(0), getQuestionAnswersReader.GetString(1), getQuestionAnswersReader.GetBoolean(2)));
                        }

                        test.Questions.Add(question);
                    }

                    tests.Add(test);
                }
            }
            reader.Close();
            connection.Close();
            return tests;
        }

        public static void AddTest(Test test)
        {
            connection.Open();
            string insertTestQuery = "INSERT INTO Test (Name) VALUES (@name)";
            string lastInsertedIdQuery = "SELECT last_insert_rowid()";
            string insertQuestionQuery = "INSERT INTO Question (Text, Type, Rank, Photo, Test) " +
                                         "VALUES (@text, @type, @rank, @photo, @test)";
            string insertAnswerQuery = "INSERT INTO Answer (Question, Text, IsCorrect) VALUES (@question, @text, @isCorrect)";

            SQLiteCommand insertTestCommand = new SQLiteCommand(insertTestQuery, connection);
            SQLiteParameter[] insertTestParameters = { new SQLiteParameter("@name", test.Name) };
            insertTestCommand.Parameters.AddRange(insertTestParameters);
            insertTestCommand.ExecuteNonQuery();

            SQLiteCommand lastInsertedIdCommand = new SQLiteCommand(lastInsertedIdQuery, connection);
            long testId = (long)lastInsertedIdCommand.ExecuteScalar();

            foreach (Question question in test.Questions)
            {
                SQLiteCommand insertQuestionCommand = new SQLiteCommand(insertQuestionQuery, connection);
                SQLiteParameter[] insertQuestionParameters = { new SQLiteParameter("@text", question.Text),
                    new SQLiteParameter("@type", question.Type), new SQLiteParameter("@rank", question.Rank),
                    new SQLiteParameter("@photo", question.Photo), new SQLiteParameter("@test", testId) };
                insertQuestionCommand.Parameters.AddRange(insertQuestionParameters);
                insertQuestionCommand.ExecuteNonQuery();
                long questionId = (long)lastInsertedIdCommand.ExecuteScalar();

                foreach (Answer answer in question.Answers)
                {
                    SQLiteCommand insertAnswerCommand = new SQLiteCommand(insertAnswerQuery, connection);
                    SQLiteParameter[] insertAnswerParameters = { new SQLiteParameter("@question", questionId),
                    new SQLiteParameter("@isCorrect", answer.IsCorrect), new SQLiteParameter("@text", answer.Text) };
                    insertAnswerCommand.Parameters.AddRange(insertAnswerParameters);
                    insertAnswerCommand.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void AddUserTestings(List<UserQuestion> userQuestions)
        {
            connection.Open();

            string query = "INSERT INTO UserQuestion (User, Question, Score, Date) VALUES (@user, @question, @score, @date)";
            foreach (UserQuestion question in userQuestions)
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteParameter[] parameters = { new SQLiteParameter("@user", question.User.UserID),
                    new SQLiteParameter("@question", question.Question.QuestionId), new SQLiteParameter("@score", question.Score), new SQLiteParameter("@date", question.Date) };
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        public static void DeleteTest(long testId)
        {
            connection.Open();

            string query = "DELETE FROM Test WHERE TestID = @testId";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteParameter[] parameters = { new SQLiteParameter("@testId", testId) };
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
