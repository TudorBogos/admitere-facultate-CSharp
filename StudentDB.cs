using MySql.Data.MySqlClient;

namespace admitere_facultate_C_
{
    public static class StudentDB
    {
        /// <summary>
        /// Inserează un nou student în baza de date.
        /// Doar câmpurile care nu sunt goale/null vor fi incluse în interogare.
        /// </summary>
        public static void InsertStudent(string nume, string prenume, string cnp, decimal? nota, int? facultateId, string optiune)
        {
            var columns = new List<string>();
            var values = new List<string>();
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(nume))
            {
                columns.Add("Nume");
                values.Add("@nume");
                parameters.Add(new MySqlParameter("@nume", nume));
            }

            if (!string.IsNullOrWhiteSpace(prenume))
            {
                columns.Add("Prenume");
                values.Add("@prenume");
                parameters.Add(new MySqlParameter("@prenume", prenume));
            }

            if (!string.IsNullOrWhiteSpace(cnp))
            {
                columns.Add("CNP");
                values.Add("@cnp");
                parameters.Add(new MySqlParameter("@cnp", cnp));
            }

            if (nota.HasValue)
            {
                columns.Add("Nota");
                values.Add("@nota");
                parameters.Add(new MySqlParameter("@nota", nota.Value));
            }

            if (facultateId.HasValue)
            {
                columns.Add("idFacultateOptiune");
                values.Add("@facultateId");
                parameters.Add(new MySqlParameter("@facultateId", facultateId.Value));
            }

            if (!string.IsNullOrWhiteSpace(optiune))
            {
                columns.Add("Optiune");
                values.Add("@optiune");
                parameters.Add(new MySqlParameter("@optiune", optiune));
            }

            if (columns.Count == 0)
            {
                MessageBox.Show("Niciun câmp nu a fost furnizat pentru inserare.");
                return;
            }

            string sql = $@"
            INSERT INTO student ({string.Join(", ", columns)})
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
                MessageBox.Show("Eroare la inserare student: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }

        /// <summary>
        /// Actualizează un student existent în baza de date pe baza ID-ului.
        /// Doar câmpurile care nu sunt goale/null vor fi incluse în actualizare.
        /// </summary>
        public static void UpdateStudent(int id, string nume, string prenume, string cnp, decimal? nota, int? facultateId, string optiune)
        {
            var updates = new List<string>();
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(nume))
            {
                updates.Add("Nume = @nume");
                parameters.Add(new MySqlParameter("@nume", nume));
            }

            if (!string.IsNullOrWhiteSpace(prenume))
            {
                updates.Add("Prenume = @prenume");
                parameters.Add(new MySqlParameter("@prenume", prenume));
            }

            if (!string.IsNullOrWhiteSpace(cnp))
            {
                updates.Add("CNP = @cnp");
                parameters.Add(new MySqlParameter("@cnp", cnp));
            }

            if (nota.HasValue)
            {
                updates.Add("Nota = @nota");
                parameters.Add(new MySqlParameter("@nota", nota.Value));
            }

            if (facultateId.HasValue)
            {
                updates.Add("idFacultateOptiune = @facultateId");
                parameters.Add(new MySqlParameter("@facultateId", facultateId.Value));
            }

            if (!string.IsNullOrWhiteSpace(optiune))
            {
                updates.Add("Optiune = @optiune");
                parameters.Add(new MySqlParameter("@optiune", optiune));
            }

            if (updates.Count == 0)
            {
                MessageBox.Show("Niciun câmp nu a fost furnizat pentru actualizare.");
                return;
            }

            string sql = $@"
            UPDATE student
            SET {string.Join(", ", updates)}
            WHERE idStudent = @id;
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
                MessageBox.Show("Eroare la actualizarea studentului: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }

        /// <summary>
        /// Șterge un student din baza de date pe baza ID-ului.
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteStudent(int id)
        {
            try
            {
                DB.openConn();
                var sql = "DELETE FROM student WHERE idStudent = @id";
                using var cmd = new MySqlCommand(sql, DB.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la stergerea studentului: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }
    }
}
