﻿using System;
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
    public partial class ProfileControl : UserControl
    {
        Control parent;
        User user;
        public ProfileControl(Control parent, User user)
        {
            InitializeComponent();
            this.parent = parent;
            this.user = user;
            if (user.Role == "admin")
            {
                editButton.Enabled = true;
                deleteButton.Enabled = true;
                addButton.Enabled = true;
            }

            firstNameTextBox.Text = user.FirstName;
            lastNameTextBox.Text = user.LastName;
            middleNameTextBox.Text = user.MiddleName;
            emailTextBox.Text = user.Email;
            phoneTextBox.Text = user.Phone;

            // TODO: Запрос по результатам
            // testsDataGridView.DataSource = DBController.GetTests(user);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
