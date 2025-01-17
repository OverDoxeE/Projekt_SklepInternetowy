using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace Projekt_SklepInternetowy
{
    public partial class FormGames : Form
    {
        private readonly NpgsqlConnection connection;

        public FormGames(NpgsqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent(); // Ensure this call remains
            LoadGamesData();
        }

        private void LoadGamesData()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Brak połączenia z bazą danych.");
                return;
            }

            try
            {
                //string query = "SELECT game_id, title AS 'Tytuł', description AS 'Opis', price AS 'Cena', platform AS 'Platforma' FROM Games";
                string query = "SELECT game_id, title AS \"Tytuł\", description AS \"Opis\", price AS \"Cena\", platform AS \"Platforma\" FROM Games";
                using var cmd = new NpgsqlCommand(query, connection);
                using var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewGames.DataSource = dt;

                dataGridViewGames.Columns["game_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania danych: {ex.Message}");
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using var addProductForm = new FormAddProduct(connection);
            addProductForm.FormClosed += (s, args) => LoadGamesData();
            addProductForm.ShowDialog();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewGames.SelectedRows.Count == 0 || dataGridViewGames.SelectedRows[0].Cells["game_id"].Value == null)
            {
                MessageBox.Show("Proszę wybrać produkt do edycji.");
                return;
            }

            int productId = Convert.ToInt32(dataGridViewGames.SelectedRows[0].Cells["game_id"].Value);
            using var editProductForm = new FormEditProduct(connection, productId);
            editProductForm.FormClosed += (s, args) => LoadGamesData();
            editProductForm.ShowDialog();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewGames.SelectedRows.Count == 0 || dataGridViewGames.SelectedRows[0].Cells["game_id"].Value == null)
            {
                MessageBox.Show("Proszę wybrać produkt do usunięcia.");
                return;
            }

            int productId = Convert.ToInt32(dataGridViewGames.SelectedRows[0].Cells["game_id"].Value);

            if (MessageBox.Show("Czy na pewno chcesz usunąć ten produkt?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Games WHERE game_id = @gameId";
                    using var cmd = new NpgsqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@gameId", productId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produkt został usunięty.");
                    LoadGamesData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas usuwania produktu: {ex.Message}");
                }
            }
        }
    }
}
