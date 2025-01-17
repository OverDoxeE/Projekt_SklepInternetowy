using System;
using System.Windows.Forms;
using Npgsql;

namespace Projekt_SklepInternetowy
{
    public partial class Form2 : Form
    {
        private NpgsqlConnection connection;

        public Form2(NpgsqlConnection existingConnection)
        {
            InitializeComponent();
            connection = existingConnection;
        }

        // Funkcja obsługująca przycisk "Dodaj użytkownika"
        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text;
            string newEmail = txtNewEmail.Text;
            string newPassword = txtNewPassword.Text;
            string newPhoneNumber = txtNewPhoneNumber.Text;

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newEmail) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newPhoneNumber))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.");
                return;
            }

            if (!newEmail.Contains("@"))
            {
                MessageBox.Show("Podaj poprawny adres e-mail.");
                return;
            }

            try
            {
                string query = @"
                    INSERT INTO users (username, email, password_hash, phone_number, created_at, updated_at)
                    VALUES (@username, @password, @email, @phoneNumber, @createdAt, @updatedAt)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", newUsername);
                    cmd.Parameters.AddWithValue("@email", newEmail);
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    cmd.Parameters.AddWithValue("@phoneNumber", newPhoneNumber);
                    cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Użytkownik został pomyślnie dodany!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd dodawania użytkownika: {ex.Message}");
            }
        }
    }
}
