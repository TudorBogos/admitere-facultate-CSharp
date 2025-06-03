using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace admitere_facultate_C_
{
    public static class CsvImporter
    {
        /// <summary>
        /// Importează studenții dintr-un fișier CSV și îi inserează în baza de date.
        /// </summary>
        /// <param name="filePath">Calea către fișierul CSV</param>
        public static void ImportCsvToDatabase(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Fișierul nu a fost găsit.");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            if (lines.Length <= 1)
            {
                MessageBox.Show("Fișierul este gol sau nu are date valide.");
                return;
            }

            for (int i = 1; i < lines.Length; i++) // skip header
            {
                var row = lines[i].Split(',');
                if (row.Length < 7)
                    continue;

                try
                {
                    string nume = row[1].Trim();
                    string prenume = row[2].Trim();
                    string cnp = row[3].Trim();

                    decimal? nota = null;
                    if (decimal.TryParse(row[4].Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedNota))
                        nota = parsedNota;

                    int? facultateId = null;
                    if (int.TryParse(row[5].Trim(), out var parsedId))
                        facultateId = parsedId;

                    string optiune = row[6].Trim();

                    StudentDB.InsertStudent(nume, prenume, cnp, nota, facultateId, optiune);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la rândul {i + 1}: {ex.Message}");
                }
            }

            MessageBox.Show("Importul s-a efectuat cu succes.");
        }
    }
}
