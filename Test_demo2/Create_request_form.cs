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
    public partial class Create_request_form : Form
    {
        int current_page = 1;
        int max_per_page = 5;
        List<Place> all_places = new List<Place>();
        NpgsqlConnection conn;
        public Create_request_form(NpgsqlConnection _conn)
        {
            InitializeComponent();
            conn = _conn;
        }
        private void Get_places()
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM place", conn))
            {
                conn.Open();
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Place place = new Place()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["name"].ToString(),
                            Price = Convert.ToInt32(reader["price"])


                        };
                        all_places.Add(place);

                    }

                }
            }
        }
        private void Display_page()
        {
            int start_index = (current_page - 1) * max_per_page;
            int end_index = Math.Min(start_index + max_per_page, all_places.Count);
            for (int i = 0; i < max_per_page; i++)
            {
                Panel current_panel = (Panel)Controls.Find("panel" + i, true)[0];
                if (i < end_index - start_index)
                {
                    current_panel.Visible = true;
                    Label name_label = (Label)current_panel.Controls["place" + i];
                    name_label.Text = all_places[start_index + i].Name;
                    Label price_label = (Label)current_panel.Controls["price" + i];
                    price_label.Text = all_places[start_index + i].Price.ToString();


                }
                else
                {
                    current_panel.Visible = false;

                }
            }
        }
        private void Create_request_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Create_request_form_Load(object sender, EventArgs e)
        {
            Get_places();
            Display_page();
        }

        private void back_page_Click(object sender, EventArgs e)
        {
            if (current_page > 1)
            {
                current_page--;
                Display_page();
            }
        }

        private void next_page_Click(object sender, EventArgs e)
        {
            if ((current_page * max_per_page) < all_places.Count)
            {
                current_page++;
                Display_page();
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {

        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel selected_panel = (Panel)contextMenuStrip1.SourceControl;
            int panel_index = Convert.ToInt32(selected_panel.Name.Replace("panel", ""));
            Place selected_place = all_places[(current_page - 1) * max_per_page + panel_index];


        }
    }
}
