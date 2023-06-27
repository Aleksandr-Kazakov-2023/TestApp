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
    public partial class StartControl : UserControl
    {
        private User user = null;
        public StartControl()
        {
            InitializeComponent();
        }

        public User User { get => user; }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string pass = passwordTextBox.Text;
            user = DBController.Authorize(login, pass);
            if (user != null)
            {
                this.Controls.Clear();
                this.Controls.Add(new ProfileControl(this, user));
            }
            else
            {
                MessageBox.Show("Неверно введена пара Логин Пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            RegistrationControl registrationControl = new RegistrationControl(this);
            this.Controls.Clear();
            this.Controls.Add(registrationControl);
        }
    }
}
