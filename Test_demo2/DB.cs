using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_demo2
{
    public class DB : IDisposable
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=demo2;User Id=postgres;Password=123");
        public NpgsqlConnection Get_conn()
        {
            return conn;
        }

        public void Open_conn()
        {
            conn.Open();
        }
        public void Close_conn()
        {
            conn.Open();
        }
        public void Dispose()
        {
            conn.Dispose();
        }
    }
}
