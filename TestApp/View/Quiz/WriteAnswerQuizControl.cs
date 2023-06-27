using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp.View.Quiz
{
    public partial class WriteAnswerQuizControl : UserControl, IQuiz
    {
        private Question question;
        private double result;
        public double Result => this.result;
        Question IQuiz.question => this.question;

        public WriteAnswerQuizControl(Question question)
        {
            InitializeComponent();
            this.question = question;
            questionLabel.Text = question.Text;
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            string userAnswer = answerTextBox.Text.Trim().ToLower();
            result = userAnswer == question.Answers[0].Text ? question.Rank : 0;
            readyButton.Enabled = false;
        }

        private void WriteAnswerQuizControl_Load(object sender, EventArgs e)
        {

        }
    }
}
