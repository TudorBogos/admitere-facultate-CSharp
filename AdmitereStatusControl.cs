using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace admitere_facultate_C_
{
    public partial class AdmitereStatusControl : UserControl
    {
        public DataGridView TargetGrid { get; set; }

        public AdmitereStatusControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TargetGrid != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.Title = "Salveaza PDF-ul";
                    sfd.FileName = "Situatie_Admitere.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportUtility.ExportDataGridViewToPdf(TargetGrid, sfd.FileName, "Baza de date studenti");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nu există un grid țintă setat pentru export.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TargetGrid != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv";
                    sfd.Title = "Salveaza CSV-ul";
                    sfd.FileName = "Situatia_Admitere.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportUtility.ExportDataGridViewToCsv(TargetGrid, sfd.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nu există un grid țintă setat pentru export.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DB.openConn();

                string query = @"
            SELECT 
                f.Nume_Facultate,
                s.status,
                COUNT(*) AS Total
            FROM admitere_status s
            JOIN facultate f ON s.idFacultate = f.idFacultate
            GROUP BY f.Nume_Facultate, s.status;
        ";

                var cmd = new MySqlCommand(query, DB.GetConnection());
                var reader = cmd.ExecuteReader();

                var data = new Dictionary<string, Dictionary<string, int>>();

                while (reader.Read())
                {
                    string facultate = reader.GetString("Nume_Facultate");
                    string status = reader.GetString("status");
                    int total = reader.GetInt32("Total");

                    if (!data.ContainsKey(facultate))
                        data[facultate] = new Dictionary<string, int>();

                    data[facultate][status] = total;
                }

                reader.Close();

                foreach (var facultate in data.Keys)
                {
                    // Create chart dynamically
                    var chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
                    chart.Size = new Size(500, 400);
                    chart.ChartAreas.Add("Main");

                    var series = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                        ChartArea = "Main",
                        IsValueShownAsLabel = true
                    };

                    foreach (var status in data[facultate])
                    {
                        series.Points.AddXY(status.Key, status.Value);
                    }

                    chart.Series.Add(series);
                    chart.Titles.Add($"Statutul Admiterii — {facultate}");

                    // Render to bitmap
                    Bitmap bmp = new Bitmap(500, 400);
                    chart.DrawToBitmap(bmp, new Rectangle(0, 0, 500, 400));

                    // Show in popup
                    Form popup = new Form();
                    popup.Text = facultate;
                    popup.Size = new Size(520, 440);

                    var pictureBox = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        Image = bmp,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    popup.Controls.Add(pictureBox);
                    popup.ShowDialog(); // blocks until closed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la generarea graficului: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }

    }
}
