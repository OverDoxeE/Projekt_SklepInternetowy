namespace Projekt_SklepInternetowy
{
    partial class FormEditUser
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtEditUsername;
        private System.Windows.Forms.TextBox txtEditEmail;
        private System.Windows.Forms.TextBox txtEditPhoneNumber;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label lblCreatedAt; // Dodano
        private System.Windows.Forms.Label lblUpdatedAt; // Dodano

        private void InitializeComponent()
        {
            this.txtEditUsername = new System.Windows.Forms.TextBox();
            this.txtEditEmail = new System.Windows.Forms.TextBox();
            this.txtEditPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.lblCreatedAt = new System.Windows.Forms.Label(); // Dodano
            this.lblUpdatedAt = new System.Windows.Forms.Label(); // Dodano

            this.SuspendLayout();

            // txtEditUsername
            this.txtEditUsername.Location = new System.Drawing.Point(30, 30);
            this.txtEditUsername.Name = "txtEditUsername";
            this.txtEditUsername.Size = new System.Drawing.Size(300, 31);
            this.txtEditUsername.TabIndex = 0;

            // txtEditEmail
            this.txtEditEmail.Location = new System.Drawing.Point(30, 80);
            this.txtEditEmail.Name = "txtEditEmail";
            this.txtEditEmail.Size = new System.Drawing.Size(300, 31);
            this.txtEditEmail.TabIndex = 1;

            // txtEditPhoneNumber
            this.txtEditPhoneNumber.Location = new System.Drawing.Point(30, 130);
            this.txtEditPhoneNumber.Name = "txtEditPhoneNumber";
            this.txtEditPhoneNumber.Size = new System.Drawing.Size(300, 31);
            this.txtEditPhoneNumber.TabIndex = 2;

            // lblCreatedAt
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Location = new System.Drawing.Point(30, 180);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(150, 25);
            this.lblCreatedAt.TabIndex = 3;
            this.lblCreatedAt.Text = "Data dołączenia:";

            // lblUpdatedAt
            this.lblUpdatedAt.AutoSize = true;
            this.lblUpdatedAt.Location = new System.Drawing.Point(30, 210);
            this.lblUpdatedAt.Name = "lblUpdatedAt";
            this.lblUpdatedAt.Size = new System.Drawing.Size(180, 25);
            this.lblUpdatedAt.TabIndex = 4;
            this.lblUpdatedAt.Text = "Ostatnia aktualizacja:";

            // btnSaveChanges
            this.btnSaveChanges.Location = new System.Drawing.Point(30, 260);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(300, 40);
            this.btnSaveChanges.TabIndex = 5;
            this.btnSaveChanges.Text = "Zapisz zmiany";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);

            // FormEditUser
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.txtEditUsername);
            this.Controls.Add(this.txtEditEmail);
            this.Controls.Add(this.txtEditPhoneNumber);
            this.Controls.Add(this.lblCreatedAt);
            this.Controls.Add(this.lblUpdatedAt);
            this.Controls.Add(this.btnSaveChanges);
            this.Name = "FormEditUser";
            this.Text = "Edytuj użytkownika";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
