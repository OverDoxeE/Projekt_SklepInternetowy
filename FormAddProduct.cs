using System;
using System.Windows.Forms;
using Npgsql;

namespace Projekt_SklepInternetowy
{
    public partial class FormAddProduct : Form
    {
        private readonly NpgsqlConnection connection;

        public FormAddProduct(NpgsqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Brak połączenia z bazą danych.");
                return;
            }

            string title = txtGameTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string platform = txtPlatform.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(priceText) || string.IsNullOrWhiteSpace(platform))
            {
                MessageBox.Show("Uzupełnij wymagane pola: Tytuł, Cena, Platforma.");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Proszę podać prawidłową cenę.");
                return;
            }

            string query = "INSERT INTO Games (title, description, price, platform, created_at, updated_at) VALUES (@title, @description, @price, @platform, @createdAt, @updatedAt)";
            using var cmd = new NpgsqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@platform", platform);
            cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produkt został pomyślnie dodany.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania produktu: {ex.Message}");
            }
        }
    }
}
