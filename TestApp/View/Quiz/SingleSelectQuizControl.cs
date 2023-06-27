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
    public partial class SingleSelectQuizControl : UserControl, IQuiz
    {
        private Question question;
        private double result;
        public double Result => this.result;
        Question IQuiz.question => this.question;

        public SingleSelectQuizControl(Question question)
        {
            InitializeComponent();
            this.question = question;
            questionLabel.Text = question.Text;
            for (int i = 0; i < question.Answers.Count; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Width = 450;
                radioButton.Tag = question.Answers[i].AnswerId;
                radioButton.Text = question.Answers[i].Text;
                radioButton.Location = new Point(15, 20 * i + 10);
                answersGroupBox.Controls.Add(radioButton);
            }
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            bool rightAnswer = false;
            foreach (RadioButton c in answersGroupBox.Controls)
            {
                Answer answer = question.Answers.Find(o => o.AnswerId == (long)c.Tag);
                if (c.Checked != answer.IsCorrect)
                {
                    c.ForeColor = Color.Red;
                }
                rightAnswer = rightAnswer && c.Checked == answer.IsCorrect;
            }
            result = rightAnswer ? question.Rank : 0;
            readyButton.Enabled = false;
        }
    }
}
