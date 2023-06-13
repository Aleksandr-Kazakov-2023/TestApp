namespace TestApp.View.Quiz
{
    partial class SingleSelectQuizControl
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
            this.questionLabel = new System.Windows.Forms.Label();
            this.answersGroupBox = new System.Windows.Forms.GroupBox();
            this.readyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(25, 28);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(44, 13);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "Вопрос";
            // 
            // answersGroupBox
            // 
            this.answersGroupBox.Location = new System.Drawing.Point(28, 118);
            this.answersGroupBox.Name = "answersGroupBox";
            this.answersGroupBox.Size = new System.Drawing.Size(604, 115);
            this.answersGroupBox.TabIndex = 1;
            this.answersGroupBox.TabStop = false;
            // 
            // readyButton
            // 
            this.readyButton.Location = new System.Drawing.Point(398, 261);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(162, 31);
            this.readyButton.TabIndex = 18;
            this.readyButton.Text = "Ответить";
            this.readyButton.UseVisualStyleBackColor = true;
            // 
            // SingleSelectQuizControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.answersGroupBox);
            this.Controls.Add(this.questionLabel);
            this.Name = "SingleSelectQuizControl";
            this.Size = new System.Drawing.Size(895, 306);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox answersGroupBox;
        private System.Windows.Forms.Button readyButton;
        protected System.Windows.Forms.Label questionLabel;
    }
}
