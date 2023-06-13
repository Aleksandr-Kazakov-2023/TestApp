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
    public partial class SingleSelectQuizControl : UserControl
    {
        Question question;
        public SingleSelectQuizControl(Question question)
        {
            InitializeComponent();
            this.question = question;
            questionLabel.Text = question.Text;
        }
    }
}
