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
    public partial class Master_form : Form
    {
        int current_page = 1;
        int max_per_page = 5;
        List<Request> all_requests = new List<Request>();
        public Master_form()
        {
            InitializeComponent();
        }

        private void Master_form_Load(object sender, EventArgs e)
        {
            Requests_load();
            Display_page();
        }
        private void Requests_load()
        {
            using (DB db = new DB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM request", db.Get_conn()))
                {
                    db.Open_conn();
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string _place_name = Get_place_name(reader.GetInt32("place_id"));
                            string _status_name = Get_status_name(reader.GetInt32("status_id"));
                            Request request = new Request
                            {
                                Id = reader.GetInt32("id"),
                                Place_name = _place_name,
                                Status = _status_name,
                                Date = reader.GetDateTime("date"),
                                Comment = reader.GetString("comment")
                            };
                            all_requests.Add(request);
                        }
                    }
                }


            }
        }
        public string Get_place_name(int place_id)
        {
            using (DB dB = new DB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT name FROM place WHERE id=@place_id", dB.Get_conn()))
                {
                    cmd.Parameters.AddWithValue("@place_id", place_id);
                    dB.Open_conn();
                    using (NpgsqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            return r.GetString("name");

                        }
                        return "";
                    }
                }
            }
        }
        public string Get_status_name(int status_id)
        {
            using (DB dB = new DB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT name FROM status WHERE id=@status_id", dB.Get_conn()))
                {
                    cmd.Parameters.AddWithValue("@status_id", status_id);
                    dB.Open_conn();
                    using (NpgsqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            return r.GetString("name");

                        }
                        return "";
                    }
                }
            }
        }
        private void Display_page()
        {
            int start_index = (current_page - 1) * max_per_page;
            int end_index = Math.Min(start_index + max_per_page, all_requests.Count);
            for (int i = 0; i < max_per_page; i++)
            {
                Panel current_panel = (Panel)Controls.Find("panel" + i, true)[0];
                if (i < end_index - start_index)
                {
                    current_panel.Visible = true;
                    Label id_label = (Label)current_panel.Controls["id" + i];
                    id_label.Text = all_requests[start_index + i].Id.ToString();

                    Label place_label = (Label)current_panel.Controls["place" + i];
                    place_label.Text = all_requests[start_index + i].Place_name;

                    Label date_label = (Label)current_panel.Controls["date" + i];
                    date_label.Text = all_requests[start_index + i].Date.ToString("d");

                    Label status_label = (Label)current_panel.Controls["status" + i];
                    status_label.Text = all_requests[start_index + i].Status;

                }
                else
                {
                    current_panel.Visible = false;
                }
            }
        }
        private void prev_page_Click(object sender, EventArgs e)
        {
            if (current_page > 1)
            {
                current_page--;
                Display_page();
            }
        }

        private void next_page_Click(object sender, EventArgs e)
        {
            if ((current_page * max_per_page) < all_requests.Count)
            {
                current_page++;
                Display_page();
            }
        }

        private void подробнееToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel selected_panel = (Panel)contextMenuStrip1.SourceControl;
            int selected_panel_index = Convert.ToInt32(selected_panel.Name.Replace("panel", ""));
            Request request_sel = all_requests[((current_page - 1) * max_per_page) + selected_panel_index];
            MessageBox.Show(request_sel.Place_name);

        }
    }
}
