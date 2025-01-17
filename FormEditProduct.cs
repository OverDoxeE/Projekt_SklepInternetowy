using System;
using System.Windows.Forms;
using Npgsql;

namespace Projekt_SklepInternetowy
{
    public partial class FormEditProduct : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly int productId;

        public FormEditProduct(NpgsqlConnection connection, int productId)
        {
            InitializeComponent();
            this.connection = connection;
            this.productId = productId;
            LoadProductData();
        }

        private void LoadProductData()
        {
            // Ensure the connection is open
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Brak połączenia z bazą danych.");
                return;
            }

            string query = "SELECT * FROM Games WHERE game_id = @gameId";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@gameId", productId);

            try
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtGameTitle.Text = reader["title"].ToString();
                        txtDescription.Text = reader["description"].ToString();
                        txtPrice.Text = reader["price"].ToString();
                        txtPlatform.Text = reader["platform"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania danych produktu: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtGameTitle.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtPlatform.Text))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.");
                return;
            }

            // Parse price input safely
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Proszę podać prawidłową cenę.");
                return;
            }

            string query = @"
                UPDATE Games 
                SET title = @title, 
                    description = @description, 
                    price = @price, 
                    platform = @platform 
                WHERE game_id = @gameId";

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@title", txtGameTitle.Text);
            cmd.Parameters.AddWithValue("@description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@platform", txtPlatform.Text);
            cmd.Parameters.AddWithValue("@gameId", productId);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produkt został zaktualizowany.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd aktualizacji produktu: {ex.Message}");
            }
        }
    }
}
