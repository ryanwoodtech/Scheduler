
namespace C969
{
    partial class SchedulerLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginSchedulerLabel = new System.Windows.Forms.Label();
            this.LoginUsernameLabel = new System.Windows.Forms.Label();
            this.LoginUsernameInput = new System.Windows.Forms.TextBox();
            this.LoginPasswordInput = new System.Windows.Forms.TextBox();
            this.LoginPasswordLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginIncorrectLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginSchedulerLabel
            // 
            this.LoginSchedulerLabel.AutoSize = true;
            this.LoginSchedulerLabel.Font = new System.Drawing.Font("Adobe Devanagari", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginSchedulerLabel.Location = new System.Drawing.Point(73, 18);
            this.LoginSchedulerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LoginSchedulerLabel.Name = "LoginSchedulerLabel";
            this.LoginSchedulerLabel.Size = new System.Drawing.Size(139, 43);
            this.LoginSchedulerLabel.TabIndex = 0;
            this.LoginSchedulerLabel.Text = "Scheduler";
            // 
            // LoginUsernameLabel
            // 
            this.LoginUsernameLabel.AutoSize = true;
            this.LoginUsernameLabel.Location = new System.Drawing.Point(6, 85);
            this.LoginUsernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LoginUsernameLabel.Name = "LoginUsernameLabel";
            this.LoginUsernameLabel.Size = new System.Drawing.Size(91, 28);
            this.LoginUsernameLabel.TabIndex = 1;
            this.LoginUsernameLabel.Text = "Username";
            // 
            // LoginUsernameInput
            // 
            this.LoginUsernameInput.Font = new System.Drawing.Font("Adobe Devanagari", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginUsernameInput.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LoginUsernameInput.Location = new System.Drawing.Point(11, 115);
            this.LoginUsernameInput.Margin = new System.Windows.Forms.Padding(2);
            this.LoginUsernameInput.Name = "LoginUsernameInput";
            this.LoginUsernameInput.Size = new System.Drawing.Size(253, 29);
            this.LoginUsernameInput.TabIndex = 2;
            this.LoginUsernameInput.Text = "test";
            // 
            // LoginPasswordInput
            // 
            this.LoginPasswordInput.Font = new System.Drawing.Font("Adobe Devanagari", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginPasswordInput.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LoginPasswordInput.Location = new System.Drawing.Point(11, 176);
            this.LoginPasswordInput.Margin = new System.Windows.Forms.Padding(2);
            this.LoginPasswordInput.Name = "LoginPasswordInput";
            this.LoginPasswordInput.Size = new System.Drawing.Size(253, 29);
            this.LoginPasswordInput.TabIndex = 4;
            this.LoginPasswordInput.Text = "test";
            this.LoginPasswordInput.UseSystemPasswordChar = true;
            // 
            // LoginPasswordLabel
            // 
            this.LoginPasswordLabel.AutoSize = true;
            this.LoginPasswordLabel.Location = new System.Drawing.Point(6, 146);
            this.LoginPasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LoginPasswordLabel.Name = "LoginPasswordLabel";
            this.LoginPasswordLabel.Size = new System.Drawing.Size(86, 28);
            this.LoginPasswordLabel.TabIndex = 3;
            this.LoginPasswordLabel.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.Location = new System.Drawing.Point(189, 223);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 34);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginIncorrectLabel
            // 
            this.LoginIncorrectLabel.AutoSize = true;
            this.LoginIncorrectLabel.BackColor = System.Drawing.Color.Red;
            this.LoginIncorrectLabel.Location = new System.Drawing.Point(19, 55);
            this.LoginIncorrectLabel.Name = "LoginIncorrectLabel";
            this.LoginIncorrectLabel.Size = new System.Drawing.Size(245, 28);
            this.LoginIncorrectLabel.TabIndex = 6;
            this.LoginIncorrectLabel.Text = "Invalid username or password";
            this.LoginIncorrectLabel.Visible = false;
            // 
            // SchedulerLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 286);
            this.Controls.Add(this.LoginIncorrectLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.LoginPasswordInput);
            this.Controls.Add(this.LoginPasswordLabel);
            this.Controls.Add(this.LoginUsernameInput);
            this.Controls.Add(this.LoginUsernameLabel);
            this.Controls.Add(this.LoginSchedulerLabel);
            this.Font = new System.Drawing.Font("Adobe Devanagari", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "SchedulerLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduler Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginSchedulerLabel;
        private System.Windows.Forms.Label LoginUsernameLabel;
        private System.Windows.Forms.TextBox LoginUsernameInput;
        private System.Windows.Forms.TextBox LoginPasswordInput;
        private System.Windows.Forms.Label LoginPasswordLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label LoginIncorrectLabel;
    }
}

