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
using TestApp.View.Quiz;

namespace TestApp.View
{
    public partial class TestingControl : UserControl
    {
        private Control parent;
        private Test test;
        private int currentQuestion = -1;
        public TestingControl(Control parent, Test test)
        {
            InitializeComponent();
            this.parent = parent;
            this.test = test;
            NextQuestion();
        }

        private void NextQuestion()
        {
            if (currentQuestion < test.Questions.Count)
            {
                currentQuestion++;
                Control quiz = null;
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
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }
    }
}
