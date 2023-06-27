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
    public partial class MultipleSelectQuizControl : UserControl, IQuiz
    {
        private Question question;
        private double result;
        public MultipleSelectQuizControl(Question question)
        {
            InitializeComponent();
            this.question = question;
            questionLabel.Text = question.Text;
            for (int i = 0; i < question.Answers.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Width = 450;
                checkBox.Tag = question.Answers[i].AnswerId;
                checkBox.Text = question.Answers[i].Text;
                checkBox.Location = new Point(15, 20 * i + 10);
                answersGroupBox.Controls.Add(checkBox);
            }
        }

        public double Result => this.result;

        Question IQuiz.question => this.question;

        private void readyButton_Click(object sender, EventArgs e)
        {
            bool rightAnswer = true;
            foreach (CheckBox c in answersGroupBox.Controls)
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
