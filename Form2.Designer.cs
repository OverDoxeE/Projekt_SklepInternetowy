namespace Projekt_SklepInternetowy
{
    partial class Form2
    {
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.TextBox txtNewEmail;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtNewPhoneNumber;
        private System.Windows.Forms.Button btnSaveUser;

        // Inicjalizacja komponentów
        private void InitializeComponent()
        {
            txtNewUsername = new TextBox();
            txtNewEmail = new TextBox();
            txtNewPassword = new TextBox();
            txtNewPhoneNumber = new TextBox();
            btnSaveUser = new Button();
            SuspendLayout();
            // 
            // txtNewUsername
            // 
            txtNewUsername.Location = new Point(30, 30);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.Size = new Size(300, 31);
            txtNewUsername.TabIndex = 0;
            txtNewUsername.Text = "nazwa";
            // 
            // txtNewEmail
            // 
            txtNewEmail.Location = new Point(30, 80);
            txtNewEmail.Name = "txtNewEmail";
            txtNewEmail.Size = new Size(300, 31);
            txtNewEmail.TabIndex = 1;
            txtNewEmail.Text = "e-mail";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(30, 130);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(300, 31);
            txtNewPassword.TabIndex = 2;
            txtNewPassword.Text = "haslo";
            // 
            // txtNewPhoneNumber
            // 
            txtNewPhoneNumber.Location = new Point(30, 180);
            txtNewPhoneNumber.Name = "txtNewPhoneNumber";
            txtNewPhoneNumber.Size = new Size(300, 31);
            txtNewPhoneNumber.TabIndex = 3;
            txtNewPhoneNumber.Text = "numer telefonu";
            // 
            // btnSaveUser
            // 
            btnSaveUser.Location = new Point(30, 230);
            btnSaveUser.Name = "btnSaveUser";
            btnSaveUser.Size = new Size(300, 40);
            btnSaveUser.TabIndex = 4;
            btnSaveUser.Text = "Dodaj użytkownika";
            btnSaveUser.UseVisualStyleBackColor = true;
            btnSaveUser.Click += btnSaveUser_Click;
            // 
            // Form2
            // 
            ClientSize = new Size(400, 300);
            Controls.Add(txtNewUsername);
            Controls.Add(txtNewEmail);
            Controls.Add(txtNewPassword);
            Controls.Add(txtNewPhoneNumber);
            Controls.Add(btnSaveUser);
            Name = "Form2";
            Text = "Dodaj użytkownika";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
