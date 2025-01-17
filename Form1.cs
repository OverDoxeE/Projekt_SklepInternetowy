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

        // Obs�uga zdarzenia �adowania formularza
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Witaj! Zaloguj si�, aby po��czy� si� z baz� danych.");
        }

        // Funkcja logowania do bazy danych
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Prosz� poda� nazw� u�ytkownika i has�o.");
                return;
            }

            string connectionString = $"Host=localhost;Port=5432;Username={username};Password={password};Database=Game_shop";

            connection = new NpgsqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("Po��czenie z baz� danych zosta�o nawi�zane pomy�lnie!");
                LoadUsersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B��d po��czenia: {ex.Message}");
            }
        }

        // Funkcja �adowania danych z tabeli Users
        private void LoadUsersData()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Brak po��czenia z baz� danych.");
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


        // Klikni�cie podw�jnie w kom�rk� tabeli
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value);

                // Otw�rz formularz do edycji u�ytkownika
                FormEditUser formEditUser = new FormEditUser(connection, userId);
                formEditUser.ShowDialog();

                // Od�wie� dane po zamkni�ciu formularza edycji
                LoadUsersData();
            }
        }

        // Obs�uga przycisku otwieraj�cego nowe okno do dodawania u�ytkownika
        private void btnOpenAddUserForm_Click(object sender, EventArgs e)
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Po��czenie z baz� danych nie jest aktywne.");
                return;
            }

            // Otw�rz nowe okno Form2 i przeka� istniej�ce po��czenie
            Form2 addUserForm = new Form2(connection);
            addUserForm.ShowDialog(); // Otwiera nowe okno jako modalne

            // Od�wie� dane w tabeli
            LoadUsersData();
        }

        // Obs�uga przycisku edycji u�ytkownika
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Prosz� wybra� u�ytkownika do edycji.");
                return;
            }

            int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["user_id"].Value);

            // Otw�rz formularz edycji u�ytkownika
            FormEditUser formEditUser = new FormEditUser(connection, userId);
            formEditUser.ShowDialog();

            // Od�wie� dane po zamkni�ciu formularza edycji
            LoadUsersData();
        }

        // Obs�uga przycisku usuwania u�ytkownika
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Prosz� wybra� u�ytkownika do usuni�cia.");
                return;
            }

            int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["user_id"].Value);

            DialogResult result = MessageBox.Show("Czy na pewno chcesz usun�� tego u�ytkownika?", "Potwierdzenie", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Users WHERE user_id = @userId";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userId", userId);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("U�ytkownik zosta� usuni�ty.");
                    LoadUsersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"B��d usuwania u�ytkownika: {ex.Message}");
                }
            }
        }

        // Obs�uga przycisku otwieraj�cego okno z baz� gier
        private void btnShowGames_Click(object sender, EventArgs e)
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Po��czenie z baz� danych nie jest aktywne.");
                return;
            }

            FormGames formGames = new FormGames(connection);
            formGames.ShowDialog();
        }
    }
}
