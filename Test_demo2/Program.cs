using Npgsql;

namespace Test_demo2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=demo2;User Id=postgres;Password=123");
            Application.Run(new Master_form());
        }
    }
}