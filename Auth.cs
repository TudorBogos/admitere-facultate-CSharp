using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace admitere_facultate_C_
{

    public static class Auth
    {
        public static int? LoggedInStudentId { get; private set; } = null;
        public static bool Login(string user, string pass, bool isStudent)
        {
            DB.openConn();

            try
            {
                if (isStudent)
                {
                    // Expecting user = "Nume,Prenume", pass = CNP
                    var parts = user.Split(',');
                    if (parts.Length != 2)
                    {
                        MessageBox.Show("Introduceți numele și prenumele separate prin virgulă.");
                        return false;
                    }

                    string nume = parts[0].Trim();
                    string prenume = parts[1].Trim();

                    string query = "SELECT * FROM student WHERE Nume = @nume AND Prenume = @prenume AND CNP = @cnp";
                    using (var cmd = new MySqlCommand(query, DB.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@nume", nume);
                        cmd.Parameters.AddWithValue("@prenume", prenume);
                        cmd.Parameters.AddWithValue("@cnp", pass);



                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LoggedInStudentId = Convert.ToInt32(reader["idStudent"]);
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    // Admin login
                    string query = "SELECT * FROM admin WHERE username = @username AND password = @password";
                    using (var cmd = new MySqlCommand(query, DB.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@username", user);
                        cmd.Parameters.AddWithValue("@password", pass);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["idAdmin"]);
                                reader.Close();

                                UpdateLastLogin(id);
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la autentificare: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }

            return false;
        }

        private static void UpdateLastLogin(int adminId)
        {
            string query = "UPDATE admin SET last_login = NOW() WHERE idAdmin = @id";
            using (var cmd = new MySqlCommand(query, DB.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@id", adminId);
                cmd.ExecuteNonQuery();
            }
        }
    }

}
