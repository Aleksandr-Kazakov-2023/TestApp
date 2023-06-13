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
    public partial class WriteAnswerQuizControl : UserControl
    {
        Question question;
        public WriteAnswerQuizControl(Question question)
        {
            InitializeComponent();
            this.question = question;
            questionLabel.Text = question.Text;
        }

        private void readyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
