using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace Projekt_SklepInternetowy
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        // Obs³uga zdarzenia ³adowania formularza
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Witaj! Zaloguj siê, aby po³¹czyæ siê z baz¹ danych.");
        }

        // Funkcja logowania do bazy danych
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Proszê podaæ nazwê u¿ytkownika i has³o.");
                return;
            }

            string connectionString = $"Host=localhost;Port=5432;Username={username};Password={password};Database=Game_shop";

            connection = new NpgsqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("Po³¹czenie z baz¹ danych zosta³o nawi¹zane pomyœlnie!");
                LoadUsersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d po³¹czenia: {ex.Message}");
            }
        }

        // Funkcja ³adowania danych z tabeli Users
        private void LoadUsersData()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Brak po³¹czenia z baz¹ danych.");
                return;
            }

            // Pobieranie wszystkich danych z tabeli Users
            string query = "SELECT user_id, username, email, phone_number, created_at, updated_at FROM Users";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        // Klikniêcie podwójnie w komórkê tabeli
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value);

                // Otwórz formularz do edycji u¿ytkownika
                FormEditUser formEditUser = new FormEditUser(connection, userId);
                formEditUser.ShowDialog();

                // Odœwie¿ dane po zamkniêciu formularza edycji
                LoadUsersData();
            }
        }

        // Obs³uga przycisku otwieraj¹cego nowe okno do dodawania u¿ytkownika
        private void btnOpenAddUserForm_Click(object sender, EventArgs e)
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Po³¹czenie z baz¹ danych nie jest aktywne.");
                return;
            }

            // Otwórz nowe okno Form2 i przeka¿ istniej¹ce po³¹czenie
            Form2 addUserForm = new Form2(connection);
            addUserForm.ShowDialog(); // Otwiera nowe okno jako modalne

            // Odœwie¿ dane w tabeli
            LoadUsersData();
        }

        // Obs³uga przycisku edycji u¿ytkownika
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszê wybraæ u¿ytkownika do edycji.");
                return;
            }

            int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["user_id"].Value);

            // Otwórz formularz edycji u¿ytkownika
            FormEditUser formEditUser = new FormEditUser(connection, userId);
            formEditUser.ShowDialog();

            // Odœwie¿ dane po zamkniêciu formularza edycji
            LoadUsersData();
        }

        // Obs³uga przycisku usuwania u¿ytkownika
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszê wybraæ u¿ytkownika do usuniêcia.");
                return;
            }

            int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["user_id"].Value);

            DialogResult result = MessageBox.Show("Czy na pewno chcesz usun¹æ tego u¿ytkownika?", "Potwierdzenie", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Users WHERE user_id = @userId";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userId", userId);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("U¿ytkownik zosta³ usuniêty.");
                    LoadUsersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"B³¹d usuwania u¿ytkownika: {ex.Message}");
                }
            }
        }

        // Obs³uga przycisku otwieraj¹cego okno z baz¹ gier
        private void btnShowGames_Click(object sender, EventArgs e)
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Po³¹czenie z baz¹ danych nie jest aktywne.");
                return;
            }

            FormGames formGames = new FormGames(connection);
            formGames.ShowDialog();
        }
    }
}
