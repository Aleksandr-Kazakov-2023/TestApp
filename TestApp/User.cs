using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class User
    {
        private long userID;
        private string firstName;
        private string lastName;
        private string middleName;
        private string email;
        private string phone;
        private string password;
        private string role;

        public User(long userID, string firstName, string lastName, string middleName, string email, string phone, string password, string role)
        {
            this.UserID = userID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Email = email;
            this.Phone = phone;
            this.Password = password;
            this.role = role;
        }

        public User(string firstName, string lastName, string middleName, string email, string phone, string password, string role) :
            this(0, firstName, lastName, middleName, email, phone, password, role)
        { }

        public long UserID { get => userID; set => userID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
    }
}
