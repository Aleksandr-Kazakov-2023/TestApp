using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.Model;
using TestApp.View.Quiz;

namespace TestApp.View
{
    public partial class TestingControl : UserControl
    {
        private Control parent;
        private Test test;
        private int currentQuestion = 0;
        private double totalResult = 0;
        private double totalSum = 0;
        private Control quiz = null;
        private List<UserQuestion> userQuestions = new List<UserQuestion>();
        public TestingControl(Control parent, Test test)
        {
            InitializeComponent();
            this.parent = parent;
            this.test = test;
            NextQuestion();
        }

        private void NextQuestion()
        {
            if (currentQuestion > 0)
            {
                totalResult += ((IQuiz)quiz).Result;
                userQuestions.Add(new UserQuestion(((StartControl)parent).User, test.Questions[currentQuestion - 1], ((IQuiz)quiz).Result, DateTime.Now));
            }
            if (currentQuestion < test.Questions.Count)
            {

                switch (test.Questions[currentQuestion].Type)
                {
                    case "SingleSelect":
                        quiz = new SingleSelectQuizControl(test.Questions[currentQuestion]);
                        break;
                    case "MultipleSelect":
                        quiz = new MultipleSelectQuizControl(test.Questions[currentQuestion]);
                        break;
                    case "WriteAnswer":
                        quiz = new WriteAnswerQuizControl(test.Questions[currentQuestion]);
                        break;
                }
                splitContainer.Panel1.Controls.Clear();
                splitContainer.Panel1.Controls.Add(quiz);
                totalSum += test.Questions[currentQuestion].Rank;
                currentQuestion++;
            }
            else
            {
                splitContainer.Panel1.Controls.Clear();
                splitContainer.Panel1.Controls.Add(new ResultQuizControl(this.totalResult / totalSum * 100));
                DBController.AddUserTestings(userQuestions);
                nextButton.Enabled = false;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            parent.Controls.Clear();
            parent.Controls.Add(new ProfileControl(parent, ((StartControl)parent).User));
        }

        private void splitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
