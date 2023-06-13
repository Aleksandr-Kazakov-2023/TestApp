namespace TestApp
{
    partial class TestControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.questionsDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answersDataGridView = new System.Windows.Forms.DataGridView();
            this.addQuestionButton = new System.Windows.Forms.Button();
            this.removeQuestionButton = new System.Windows.Forms.Button();
            this.removeAnswerButton = new System.Windows.Forms.Button();
            this.addAnswerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.questionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(34, 55);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(525, 31);
            this.nameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Название теста";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(803, 445);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(162, 31);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(635, 445);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(162, 31);
            this.addButton.TabIndex = 17;
            this.addButton.Text = "Создать";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // questionsDataGridView
            // 
            this.questionsDataGridView.AllowUserToAddRows = false;
            this.questionsDataGridView.AllowUserToDeleteRows = false;
            this.questionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.questionsDataGridView.Location = new System.Drawing.Point(34, 135);
            this.questionsDataGridView.Name = "questionsDataGridView";
            this.questionsDataGridView.RowHeadersVisible = false;
            this.questionsDataGridView.Size = new System.Drawing.Size(455, 291);
            this.questionsDataGridView.TabIndex = 19;
            this.questionsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.questionsDataGridView_CellClick);
            this.questionsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.questionsDataGridView_CellEndEdit);
            this.questionsDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.questionsDataGridView_EditingControlShowing);
            // 
            // Column1
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "Текст вопроса";
            this.Column1.Name = "Column1";
            this.Column1.Width = 240;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Тип вопроса";
            this.Column2.Items.AddRange(new object[] {
            "Один правильный ответ",
            "Несколько правильных ответов",
            "Написать ответ"});
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Баллы";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // answersDataGridView
            // 
            this.answersDataGridView.AllowUserToAddRows = false;
            this.answersDataGridView.AllowUserToDeleteRows = false;
            this.answersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5});
            this.answersDataGridView.Location = new System.Drawing.Point(526, 135);
            this.answersDataGridView.Name = "answersDataGridView";
            this.answersDataGridView.RowHeadersVisible = false;
            this.answersDataGridView.Size = new System.Drawing.Size(285, 291);
            this.answersDataGridView.TabIndex = 20;
            this.answersDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.answersDataGridView_CellEndEdit);
            // 
            // addQuestionButton
            // 
            this.addQuestionButton.Location = new System.Drawing.Point(333, 106);
            this.addQuestionButton.Name = "addQuestionButton";
            this.addQuestionButton.Size = new System.Drawing.Size(75, 23);
            this.addQuestionButton.TabIndex = 21;
            this.addQuestionButton.Text = "Добавить";
            this.addQuestionButton.UseVisualStyleBackColor = true;
            this.addQuestionButton.Click += new System.EventHandler(this.addQuestionButton_Click);
            // 
            // removeQuestionButton
            // 
            this.removeQuestionButton.Location = new System.Drawing.Point(414, 106);
            this.removeQuestionButton.Name = "removeQuestionButton";
            this.removeQuestionButton.Size = new System.Drawing.Size(75, 23);
            this.removeQuestionButton.TabIndex = 22;
            this.removeQuestionButton.Text = "Удалить";
            this.removeQuestionButton.UseVisualStyleBackColor = true;
            // 
            // removeAnswerButton
            // 
            this.removeAnswerButton.Location = new System.Drawing.Point(736, 106);
            this.removeAnswerButton.Name = "removeAnswerButton";
            this.removeAnswerButton.Size = new System.Drawing.Size(75, 23);
            this.removeAnswerButton.TabIndex = 24;
            this.removeAnswerButton.Text = "Удалить";
            this.removeAnswerButton.UseVisualStyleBackColor = true;
            // 
            // addAnswerButton
            // 
            this.addAnswerButton.Location = new System.Drawing.Point(655, 106);
            this.addAnswerButton.Name = "addAnswerButton";
            this.addAnswerButton.Size = new System.Drawing.Size(75, 23);
            this.addAnswerButton.TabIndex = 23;
            this.addAnswerButton.Text = "Добавить";
            this.addAnswerButton.UseVisualStyleBackColor = true;
            this.addAnswerButton.Click += new System.EventHandler(this.addAnswerButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "Вопросы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(522, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "Ответы";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Text";
            this.Column4.HeaderText = "Текст ответа";
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "IsCorrect";
            this.Column5.HeaderText = "Правильный";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // TestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.removeAnswerButton);
            this.Controls.Add(this.addAnswerButton);
            this.Controls.Add(this.removeQuestionButton);
            this.Controls.Add(this.addQuestionButton);
            this.Controls.Add(this.answersDataGridView);
            this.Controls.Add(this.questionsDataGridView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Name = "TestControl";
            this.Size = new System.Drawing.Size(981, 495);
            ((System.ComponentModel.ISupportInitialize)(this.questionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView questionsDataGridView;
        private System.Windows.Forms.DataGridView answersDataGridView;
        private System.Windows.Forms.Button addQuestionButton;
        private System.Windows.Forms.Button removeQuestionButton;
        private System.Windows.Forms.Button removeAnswerButton;
        private System.Windows.Forms.Button addAnswerButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
    }
}
