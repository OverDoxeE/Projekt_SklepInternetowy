using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace Projekt_SklepInternetowy
{
    public partial class FormEditUser : Form
    {
        private NpgsqlConnection connection;
        private int userId;

        public FormEditUser(NpgsqlConnection existingConnection, int userId)
        {
            InitializeComponent();
            this.connection = existingConnection;
            this.userId = userId;
            LoadUserData();
        }

        private void LoadUserData()
        {
            string query = "SELECT * FROM Users WHERE user_id = @userId";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@userId", userId);

            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    txtEditUsername.Text = reader["username"].ToString();
                    txtEditEmail.Text = reader["email"].ToString();
                    txtEditPhoneNumber.Text = reader["phone_number"].ToString();
                    lblCreatedAt.Text = $"Data dołączenia: {reader["created_at"]}";
                    lblUpdatedAt.Text = $"Ostatnia aktualizacja: {reader["updated_at"]}";
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string newUsername = txtEditUsername.Text;
            string newEmail = txtEditEmail.Text;
            string newPhoneNumber = txtEditPhoneNumber.Text;

            string query = @"
        UPDATE Users
        SET username = @username,
            email = @email,
            phone_number = @phoneNumber,
            updated_at = @updatedAt
        WHERE user_id = @userId";

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", newUsername);
            cmd.Parameters.AddWithValue("@email", newEmail);
            cmd.Parameters.AddWithValue("@phoneNumber", newPhoneNumber);
            cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@userId", userId);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dane użytkownika zostały zaktualizowane.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd aktualizacji danych: {ex.Message}");
            }
        }

    }
}

