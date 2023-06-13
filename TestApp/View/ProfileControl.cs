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
        Control parent;
        User user;
        List<Test> tests;
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

            tests = DBController.GetTests(user);
            testsDataGridView.DataSource = tests;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            parent.Controls.Clear();
            parent.Controls.Add(new StartControl(parent));
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
    }
}
