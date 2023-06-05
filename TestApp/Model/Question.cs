using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Question
    {
        private long questionId;
        private string text;
        private string type;
        private double rank;
        private string photo;
        private Test test;
        private List<Answer> answers = new List<Answer>();

        public Question(long questionId, string text, string type, double rank, string photo)
        {
            this.questionId = questionId;
            this.text = text;
            this.type = type;
            this.rank = rank;
            this.photo = photo;
        }

        public Question()
        {

        }

        public long QuestionId { get => questionId; set => questionId = value; }
        public string Text { get => text; set => text = value; }
        public string Type { get => type; set => type = value; }
        public double Rank { get => rank; set => rank = value; }
        public string Photo { get => photo; set => photo = value; }
        public Test Test { get => test; set => test = value; }
        public List<Answer> Answers { get => answers; set => answers = value; }
    }
}
