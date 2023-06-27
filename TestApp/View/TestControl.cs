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
    /**
     * TODO: Поведение при выборе различного типа вопросов.
     */
    public partial class TestControl : UserControl
    {
        private Control parent;
        private List<Question> questions = new List<Question>();

        public TestControl(Control parent)
        {
            this.parent = parent;
            InitializeComponent();
            answersDataGridView.AutoGenerateColumns = false;
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            questionsDataGridView.Rows.Add();
            questions.Add(new Question());
        }

        private void addAnswerButton_Click(object sender, EventArgs e)
        {
            answersDataGridView.Rows.Add();
            int currentRow = questionsDataGridView.CurrentCell.RowIndex;
            if (currentRow > -1)
                questions[currentRow].Answers.Add(new Answer());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.Name = nameTextBox.Text;
            test.Questions = questions;
            // TODO: Валидация имени теста
            DBController.AddTest(test);
            parent.Controls.Clear();
            parent.Controls.Add(new ProfileControl(this, ((StartControl)parent).User));
        }

        private void questionsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = questionsDataGridView.CurrentCell.RowIndex;
            switch (e.ColumnIndex)
            {
                case 0:
                    questions[currentRow].Text = (string)questionsDataGridView[0, currentRow].Value;
                    break;
                case 1:
                    DataGridViewComboBoxCell cmb = (DataGridViewComboBoxCell)questionsDataGridView.CurrentCell;
                    int index = cmb.Items.IndexOf(cmb.Value);
                    switch (index)
                    {
                        case 0:
                            questions[currentRow].Type = "SingleSelect";
                            break;
                        case 1:
                            questions[currentRow].Type = "MultipleSelect";
                            break;
                        case 2:
                            questions[currentRow].Type = "WriteAnswer";
                            break;
                    }
                    break;
                case 2:
                    double value = Convert.ToDouble(questionsDataGridView[2, currentRow].Value);
                    questions[currentRow].Rank = value;
                    break;
            }
        }

        private void answersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowQuestion = questionsDataGridView.CurrentCell.RowIndex;
            int currentRowAnswer = answersDataGridView.CurrentCell.RowIndex;
            switch (e.ColumnIndex)
            {
                case 0:
                    questions[currentRowQuestion].Answers[currentRowAnswer].Text = (string)answersDataGridView[0, currentRowAnswer].Value;
                    break;
                case 1:
                    DataGridViewCheckBoxCell chkb = (DataGridViewCheckBoxCell)answersDataGridView.CurrentCell;
                    questions[currentRowQuestion].Answers[currentRowAnswer].IsCorrect = (bool)chkb.Value;
                    break;
            }
        }

        private void questionTypeComboBox_SelectedChanged(object sender, EventArgs e)
        {

        }

        private void questionsDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (questionsDataGridView.CurrentCell.ColumnIndex == 1)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= new EventHandler(questionTypeComboBox_SelectedChanged);
                comboBox.SelectedIndexChanged += new EventHandler(questionTypeComboBox_SelectedChanged);
            }
        }

        /// <summary>
        /// Переход между вопросами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void questionsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = questionsDataGridView.CurrentCell.RowIndex;
            int answersCount = questions[currentRow].Answers.Count;
            if (answersDataGridView.RowCount > 0)
                answersDataGridView.Rows.Clear();
            answersDataGridView.RowCount = answersCount;
            for (int i = 0; i < answersCount; i++)
            {
                answersDataGridView[0, i].Value = questions[currentRow].Answers[i].Text;
                answersDataGridView[1, i].Value = questions[currentRow].Answers[i].IsCorrect;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            parent.Controls.Clear();
            parent.Controls.Add(new ProfileControl(parent, ((StartControl)parent).User));
        }
    }
}
