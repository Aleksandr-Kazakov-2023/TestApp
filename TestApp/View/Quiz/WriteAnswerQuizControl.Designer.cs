namespace TestApp.View.Quiz
{
    partial class WriteAnswerQuizControl
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
            this.readyButton = new System.Windows.Forms.Button();
            this.questionLabel = new System.Windows.Forms.Label();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // readyButton
            // 
            this.readyButton.Location = new System.Drawing.Point(410, 264);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(162, 31);
            this.readyButton.TabIndex = 20;
            this.readyButton.Text = "Ответить";
            this.readyButton.UseVisualStyleBackColor = true;
            this.readyButton.Click += new System.EventHandler(this.readyButton_Click);
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(37, 31);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(44, 13);
            this.questionLabel.TabIndex = 19;
            this.questionLabel.Text = "Вопрос";
            // 
            // answerTextBox
            // 
            this.answerTextBox.Location = new System.Drawing.Point(40, 176);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(351, 20);
            this.answerTextBox.TabIndex = 21;
            // 
            // WriteAnswerQuizControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.questionLabel);
            this.Name = "WriteAnswerQuizControl";
            this.Size = new System.Drawing.Size(867, 327);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readyButton;
        protected System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.TextBox answerTextBox;
    }
}
