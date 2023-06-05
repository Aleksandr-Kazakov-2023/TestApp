using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class TestControl : UserControl
    {
        Control parent;

        public TestControl(Control parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            questionsDataGridView.Rows.Add();
        }

        private void addAnswerButton_Click(object sender, EventArgs e)
        {
            answersDataGridView.Rows.Add();
        }
    }
}
