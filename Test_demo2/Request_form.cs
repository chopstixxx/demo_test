﻿using Npgsql;
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
    public partial class Request_form : Form
    {
        List<Request> all_requests = new List<Request>();
        int current_page = 1;
        int max_products_per_page = 5;

        public Request_form()
        {
            InitializeComponent();
        }
        public void Load_requests()
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
                                Date = reader.GetDateTime("date")



                            };
                            all_requests.Add(request);
                        }
                    }
                }
            }
        }
        public string Get_place_name(int place_id)
        {
            using (DB db = new DB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT name FROM place WHERE id=@place_id", db.Get_conn()))
                {
                    cmd.Parameters.AddWithValue("@place_id", place_id);
                    db.Open_conn();
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["name"].ToString();
                        }
                        return "";
                    }

                }
            }
        }
        public string Get_status_name(int status_id)
        {
            using (DB db = new DB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT name FROM status WHERE id=@status_id", db.Get_conn()))
                {
                    cmd.Parameters.AddWithValue("@status_id", status_id);
                    db.Open_conn();
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["name"].ToString();
                        }
                        return "";
                    }

                }
            }
        }
        private void Request_form_Load(object sender, EventArgs e)
        {
            Load_requests();
            Display_page();
        }
        public void Display_page()
        {
            int start_index = (current_page - 1) * max_products_per_page;
            int end_index = Math.Min(start_index + max_products_per_page, all_requests.Count);
            for (int i = 0; i < max_products_per_page; i++)
            {
                Panel current_panel = (Panel)Controls.Find("panel" + i, true)[0];
                if (i < end_index - start_index)
                {
                    current_panel.Visible = true;
                    Label id_lbl = (Label)current_panel.Controls["id" + i];
                    id_lbl.Text = all_requests[start_index + i].Id.ToString();
                    Label place_name_lbl = (Label)current_panel.Controls["place" + i];
                    place_name_lbl.Text = all_requests[start_index + i].Place_name;
                    Label date_lbl = (Label)current_panel.Controls["date" + i];
                    string date = all_requests[start_index + i].Date.ToString("d");
                    date_lbl.Text = date;
                    Label status_name_lbl = (Label)current_panel.Controls["status" + i];
                    status_name_lbl.Text = all_requests[start_index + i].Status;
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
            if ((current_page * max_products_per_page) < all_requests.Count)
            {
                current_page++;
                Display_page();
            }
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel selected_panel = (Panel)contextMenuStrip1.SourceControl;
            int panel_index = Convert.ToInt32(selected_panel.Name.Replace("panel", ""));
            Request selected_request = all_requests[(current_page - 1) * max_products_per_page + panel_index];
            MessageBox.Show(selected_request.Place_name);
        }
    }
}
