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
        /// Updatează statusurile de admitere pentru toți studenții.
        /// </summary>
        public static void UpdateAdmitereStatus()
        {
            string sql = @"
            UPDATE admitere_status a
            JOIN (
                SELECT
                    a.idStudent,
                    a.idFacultate,
                    IF(
                        RANK() OVER (PARTITION BY a.idFacultate ORDER BY s.Nota DESC) <= f.numar_locuri,
                        'admis',
                        'respins'
                    ) AS new_status
                FROM admitere_status a
                JOIN facultate f ON a.idFacultate = f.idFacultate
                JOIN student s ON a.idStudent = s.idStudent
            ) ranked_status
            ON a.idStudent = ranked_status.idStudent AND a.idFacultate = ranked_status.idFacultate
            SET a.status = ranked_status.new_status;
        ";

            try
            {
                DB.openConn();
                using var cmd = new MySqlCommand(sql, DB.GetConnection());
                cmd.ExecuteNonQuery(); // you can remove this return if you don't care about affected rows
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la actualizarea statusurilor de admitere: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }
    }
}
