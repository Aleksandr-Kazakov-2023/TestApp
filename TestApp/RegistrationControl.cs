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
    public partial class RegistrationControl : UserControl
    {
        Control parent;
        public RegistrationControl(Control parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            parent.Controls.Clear();
            parent.Controls.Add(new StartControl(parent));
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string middleName = middleNameTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            // TODO: Обработка правильности повторнения пароля
            // TODO: Exception

            DBController.AddUser(new User(firstName, lastName, middleName, email, phone, password, "user"));

            parent.Controls.Clear();
            parent.Controls.Add(new StartControl(parent));
        }
    }
}
