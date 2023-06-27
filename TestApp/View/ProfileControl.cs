using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.View;

namespace TestApp
{
    public partial class ProfileControl : UserControl
    {
        private Control parent;
        private User user;
        private List<Test> tests;

        public ProfileControl(Control parent, User user)
        {
            InitializeComponent();
            this.parent = parent;
            this.user = user;
            if (user.Role == "admin")
            {
                editButton.Visible = true;
                deleteButton.Visible = true;
                addTestButton.Visible = true;
            }

            firstNameTextBox.Text = user.FirstName;
            lastNameTextBox.Text = user.LastName;
            middleNameTextBox.Text = user.MiddleName;
            emailTextBox.Text = user.Email;
            phoneTextBox.Text = user.Phone;

            testsDataGridView.AutoGenerateColumns = false;
            tests = DBController.GetTests(user);
            testsDataGridView.DataSource = tests;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            parent.Controls.Clear();
            parent.Controls.Add(new StartControl());
        }

        private void addTestButton_Click(object sender, EventArgs e)
        {
            parent.Controls.Clear();
            parent.Controls.Add(new TestControl(parent));
        }

        private void testsDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentRow = testsDataGridView.CurrentCell.RowIndex;
            if (currentRow != -1)
            {
                parent.Controls.Clear();
                parent.Controls.Add(new TestingControl(parent, tests[currentRow]));
            }
        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int currentRow = testsDataGridView.CurrentCell.RowIndex;
            if (currentRow != -1)
            {
                DBController.DeleteTest(tests[currentRow].TestID);
                testsDataGridView.DataSource = null;
                tests = DBController.GetTests(user);
                testsDataGridView.DataSource = tests;
            }
        }
    }
}
