using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Answer
    {
        private long answerId;
        private string text;
        private bool isCorrect = false;
        private Question question;

        public Answer(long answerId, string text, bool isCorrect)
        {
            this.answerId = answerId;
            this.text = text;
            this.isCorrect = isCorrect;
        }

        public Answer()
        {

        }

        public long AnswerId { get => answerId; set => answerId = value; }
        public string Text { get => text; set => text = value; }
        public bool IsCorrect { get => isCorrect; set => isCorrect = value; }
        internal Question Question { get => question; set => question = value; }
    }
}
