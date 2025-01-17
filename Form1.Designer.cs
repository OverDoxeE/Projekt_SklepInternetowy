namespace Projekt_SklepInternetowy
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            btnOpenAddUserForm = new Button();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            btnShowGames = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.GradientActiveCaption;
            dataGridView1.Location = new Point(114, 264);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1119, 266);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(319, 137);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(309, 31);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(698, 137);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(309, 31);
            txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 109);
            label1.Name = "label1";
            label1.Size = new Size(213, 25);
            label1.TabIndex = 3;
            label1.Text = "Podaj nazwę użytkownika";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(800, 109);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 4;
            label2.Text = "Podaj hasło";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(611, 197);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Zaloguj";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnOpenAddUserForm
            // 
            btnOpenAddUserForm.Location = new Point(341, 561);
            btnOpenAddUserForm.Name = "btnOpenAddUserForm";
            btnOpenAddUserForm.Size = new Size(150, 67);
            btnOpenAddUserForm.TabIndex = 6;
            btnOpenAddUserForm.Text = "Dodaj użytkownika";
            btnOpenAddUserForm.UseVisualStyleBackColor = true;
            btnOpenAddUserForm.Click += btnOpenAddUserForm_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(511, 561);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(150, 67);
            btnEditUser.TabIndex = 7;
            btnEditUser.Text = "Edytuj użytkownika";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(679, 561);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(150, 67);
            btnDeleteUser.TabIndex = 8;
            btnDeleteUser.Text = "Usuń użytkownika";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnShowGames
            // 
            btnShowGames.Location = new Point(850, 561);
            btnShowGames.Name = "btnShowGames";
            btnShowGames.Size = new Size(150, 67);
            btnShowGames.TabIndex = 9;
            btnShowGames.Text = "Pokaż baze gier";
            btnShowGames.UseVisualStyleBackColor = true;
            btnShowGames.Click += btnShowGames_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1342, 865);
            Controls.Add(btnShowGames);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnEditUser);
            Controls.Add(btnOpenAddUserForm);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Grywalizacja - baza sklepu";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Button btnLogin;
        private Button btnOpenAddUserForm;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnShowGames;
    }
}
