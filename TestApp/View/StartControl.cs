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
        Control parent;
        public StartControl(Control parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = /*loginTextBox.Text*/"sidor@gmail.com";
            string pass = /*passwordTextBox.Text*/"admin";
            User user = DBController.Authorize(login, pass);
            if (user != null)
            {
                parent.Controls.Clear();
                parent.Controls.Add(new ProfileControl(parent, user));
            }
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            RegistrationControl registrationControl = new RegistrationControl(parent);
            parent.Controls.Clear();
            parent.Controls.Add(registrationControl);
        }
    }
}
