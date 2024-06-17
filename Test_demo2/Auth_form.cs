using Npgsql;

namespace Test_demo2
{
    public partial class Auth_form : Form
    {
        string login;
        string password;
        NpgsqlConnection conn;
        public Auth_form(NpgsqlConnection _conn)
        {
            InitializeComponent();
            conn = _conn;
        }

        private void Auth_btn_Click(object sender, EventArgs e)
        {
            login = login_box.Text;
            password = pass_box.Text;
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Поле с логином пустое!");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Поле с паролем пустое!");
                return;
            }
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT role_id FROM users WHERE login=@login AND password=@password", conn))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        switch (Convert.ToInt32(reader["role_id"]))
                        {
                            case 1:
                                MessageBox.Show("Пользователь!");
                                break;
                            case 2:
                                MessageBox.Show("Админ!");
                                break;
                        }
                        conn.Close();

                    }
                    else
                    {
                        MessageBox.Show("Пользователя не существует!");
                        conn.Close();
                    }
                }

            }

        }

        private void Reg_btn_Click(object sender, EventArgs e)
        {
            Reg_form form = new Reg_form(conn);
            this.Hide();
            form.Show();
        }
    }
}