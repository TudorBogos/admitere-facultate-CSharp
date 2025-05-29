using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

/// <summary>
/// Clasa pentru deschiderea si inchiderea conexiunii
/// </summary>
public static class DB
{
    private static MySqlConnection conn = null;
    private static readonly string connString = "server=localhost;user=root;password=root;database=admitere_facultate";

    public static void openConn()
    {
        if (conn == null)
            conn = new MySqlConnection(connString);

        if (conn.State != System.Data.ConnectionState.Open)
            conn.Open();
    }

    public static void closeConn()
    {
        if (conn != null && conn.State == System.Data.ConnectionState.Open)
            conn.Close();
    }

    public static MySqlConnection GetConnection()
    {
        return conn;
    }
}
