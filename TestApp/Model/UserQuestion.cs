using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Model
{
    public class UserQuestion
    {
        private User user;
        private Question question;
        private double score;
        private DateTime date;

        public UserQuestion(User user, Question question, double score, DateTime date)
        {
            this.user = user;
            this.question = question;
            this.score = score;
            this.date = date;
        }

        public User User { get => user; set => user = value; }
        public Question Question { get => question; set => question = value; }
        public double Score { get => score; set => score = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
