using Microsoft.VisualBasic.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_demo2
{
    public partial class Reg_form : Form
    {
        string login;
        string password;
        NpgsqlConnection conn;
        public Reg_form(NpgsqlConnection _conn)
        {
            InitializeComponent();
            conn = _conn;   
        }

        private void Reg_btn_Click(object sender, EventArgs e)
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
            if (Login_check())
            {
                conn.Close();
                MessageBox.Show("Логин занят!");
                return;
            }
            Registration(login, password);

        }
        private bool Login_check()
        {
            using(NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM users WHERE login=@login", conn))
            {
                cmd.Parameters.AddWithValue("@login", login);
                conn.Open();
                using(NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        
                        return true;
                        
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }
        private void Registration(string login, string password)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO users (role_id,login,password) VALUES (@role_id,@login,@password)", conn))
            {
                cmd.Parameters.AddWithValue("@role_id", 1);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно зарегистрировались!");
                    conn.Close() ;
                    Auth_form form = new Auth_form(conn);
                    this.Hide();
                    form.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }
        private void Reg_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
