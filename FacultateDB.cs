using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace admitere_facultate_C_
{
    public static class FacultateDB
    {
        /// <summary>
        /// Insereaza o noua facultate in baza de date.
        /// Doar campurile care nu sunt goale/null vor fi incluse in interogare.
        /// </summary>
        public static void InsertFacultate(string nume, string adresa, int? numarLocuri)
        {
            var columns = new List<string>();
            var values = new List<string>();
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(nume))
            {
                columns.Add("Nume_Facultate");
                values.Add("@nume");
                parameters.Add(new MySqlParameter("@nume", nume));
            }

            if (!string.IsNullOrWhiteSpace(adresa))
            {
                columns.Add("Adresa");
                values.Add("@adresa");
                parameters.Add(new MySqlParameter("@adresa", adresa));
            }

            if (numarLocuri.HasValue)
            {
                columns.Add("numar_locuri");
                values.Add("@locuri");
                parameters.Add(new MySqlParameter("@locuri", numarLocuri.Value));
            }

            if (columns.Count == 0)
            {
                MessageBox.Show("Niciun camp nu a fost furnizat pentru inserare.");
                return;
            }

            string sql = $@"
                INSERT INTO facultate ({string.Join(", ", columns)})
                VALUES ({string.Join(", ", values)});
            ";

            try
            {
                DB.openConn();
                using var cmd = new MySqlCommand(sql, DB.GetConnection());
                cmd.Parameters.AddRange(parameters.ToArray());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la inserarea facultatii: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }

        /// <summary>
        /// Actualizeaza o facultate existenta dupa ID.
        /// Doar campurile care nu sunt goale/null vor fi incluse in actualizare.
        /// </summary>
        public static void UpdateFacultate(int id, string nume, string adresa, int? numarLocuri)
        {
            var updates = new List<string>();
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(nume))
            {
                updates.Add("Nume_Facultate = @nume");
                parameters.Add(new MySqlParameter("@nume", nume));
            }

            if (!string.IsNullOrWhiteSpace(adresa))
            {
                updates.Add("Adresa = @adresa");
                parameters.Add(new MySqlParameter("@adresa", adresa));
            }

            if (numarLocuri.HasValue)
            {
                updates.Add("numar_locuri = @locuri");
                parameters.Add(new MySqlParameter("@locuri", numarLocuri.Value));
            }

            if (updates.Count == 0)
            {
                MessageBox.Show("Niciun camp nu a fost furnizat pentru actualizare.");
                return;
            }

            string sql = $@"
                UPDATE facultate
                SET {string.Join(", ", updates)}
                WHERE idFacultate = @id;
            ";

            parameters.Add(new MySqlParameter("@id", id));

            try
            {
                DB.openConn();
                using var cmd = new MySqlCommand(sql, DB.GetConnection());
                cmd.Parameters.AddRange(parameters.ToArray());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la actualizarea facultatii: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }

        /// <summary>
        /// Returneaza toate facultatile din baza de date.
        /// </summary>
        public static DataTable GetFacultati()
        {
            var table = new DataTable();
            string sql = "SELECT * FROM facultate";

            try
            {
                DB.openConn();
                using var adapter = new MySqlDataAdapter(sql, DB.GetConnection());
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcarea facultatilor: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }

            return table;
        }

        /// <summary>
        /// Sterge o facultate pe baza ID-ului.
        /// </summary>
        public static void DeleteFacultate(int id)
        {
            string sql = "DELETE FROM facultate WHERE idFacultate = @id";

            try
            {
                DB.openConn();
                using var cmd = new MySqlCommand(sql, DB.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la ștergerea facultății: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }
    }
}
