using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace admitere_facultate_C_
{
    public static class Selects
    {
        /// <summary>
        /// Returneaza toti studentii din tabela 'student'.
        /// </summary>
        public static DataTable GetStudenti()
        {
            string query = "SELECT * FROM student;";
            return ExecuteSelectQuery(query);
        }

        /// <summary>
        /// Returneaza toate facultatile din tabela 'facultate'.
        /// </summary>
        public static DataTable GetFacultati()
        {
            string query = "SELECT * FROM facultate;";
            return ExecuteSelectQuery(query);
        }

        /// <summary>
        /// Returneaza statusul admiterii pentru toti studentii,
        /// inclusiv numele, prenumele si facultatea aleasa.
        /// </summary>
        public static DataTable GetAdmitereStatus()
        {
            string query = @"
                SELECT 
                    s.idStudent,
                    s.Nume,
                    s.Prenume,
                    f.Nume_Facultate,
                    a.status
                FROM 
                    admitere_status a
                JOIN facultate f ON a.idFacultate = f.idFacultate
                JOIN student s ON a.idStudent = s.idStudent;
            ";

            return ExecuteSelectQuery(query);
        }

        /// <summary>
        /// Executa o interogare SELECT si returneaza rezultatul ca DataTable.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private static DataTable ExecuteSelectQuery(string query)
        {
            var table = new DataTable();

            try
            {
                DB.openConn();
                using var adapter = new MySqlDataAdapter(query, DB.GetConnection());
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcarea datelor: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }

            return table;
        }
    }
}
