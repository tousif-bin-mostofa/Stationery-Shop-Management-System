using System.Data.SqlClient;

namespace StationeryShopManagementSystem.Helpers
{
    /// <summary>
    /// DatabaseHelper provides a single place to manage the SQL Server connection string.
    /// All forms use this class to get a connection, so you only need to change
    /// the connection string here if your SQL Server instance name is different.
    /// </summary>
    public static class DatabaseHelper
    {
        // ---------------------------------------------------------------
        // CONNECTION STRING — change the server name if needed.
        //
        // Common server names:
        //   "."                  — default local instance
        //   ".\SQLEXPRESS"       — SQL Server Express local instance
        //   "localhost"          — local instance by hostname
        //   "DESKTOP-ABC\SQLEXPRESS" — named instance on a specific machine
        //
        // If you are unsure of your instance name, open SQL Server
        // Management Studio and check the server name shown at login.
        // ---------------------------------------------------------------
        private static readonly string ConnectionString =
            @"Server=.\SQLEXPRESS;Database=StationeryShopDB;Integrated Security=True;";

        /// <summary>
        /// Returns a new, open SqlConnection to StationeryShopDB.
        /// The caller is responsible for closing/disposing it.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
