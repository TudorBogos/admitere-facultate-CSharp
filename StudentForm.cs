using System.Data;
using MySql.Data.MySqlClient;

namespace admitere_facultate_C_
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            FormHelper.ConfigureForm(this, new Size(1200, 700), new Size(800, 500), true);

            labelTitle.Text = "Situația Admitere";
            labelTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            labelTitle.AutoSize = true;
            labelTitle.Top = 20;

            this.Resize += (s, ev) =>
            {
                LayoutHelper.CenterHorizontally(labelTitle);
                LayoutHelper.ComponentBelow(dataGridView1, labelTitle);
                LayoutHelper.ComponentBelow(flowLayoutPanel1, dataGridView1);
            };
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            StudentDB.UpdateAdmitereStatus();
            LoadAdmissionStatus();
            LayoutHelper.CenterHorizontally(labelTitle);
            LayoutHelper.ComponentBelow(dataGridView1, labelTitle);
            LayoutHelper.ComponentBelow(flowLayoutPanel1, dataGridView1);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.Title = "Salveaza PDF-ul";
                sfd.FileName = "Situatia_Admitere.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportUtility.ExportDataGridViewToPdf(dataGridView1, sfd.FileName, "Situația Admiterii");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.Title = "Salveaza CSV-ul";
                sfd.FileName = "Situatia_Admitere.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportUtility.ExportDataGridViewToCsv(dataGridView1, sfd.FileName);
                }
            }
        }
        //Functii custom

        private void LoadAdmissionStatus()
        {
            try
            {
                if (!Auth.LoggedInStudentId.HasValue)
                {
                    MessageBox.Show("ID-ul studentului nu este setat.");
                    return;
                }

                DB.openConn();

                // Update label with student ID
                labelTitle.Text = $"Situația Admitere — ID-ul tău: {Auth.LoggedInStudentId}";
                labelTitle.Left = (this.ClientSize.Width - labelTitle.Width) / 2;

                // Full list of all students and their status
                string query = @"
            SELECT 
                s.idStudent,
                f.Nume_Facultate AS Facultate,
                s.status
            FROM 
                admitere_status s
            JOIN facultate f ON s.idFacultate = f.idFacultate;";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, DB.GetConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;

                // Resize/position
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Height = 300; // fixed height to force scrollbars if content exceeds
                dataGridView1.ScrollBars = ScrollBars.Vertical;

                int totalWidth = dataGridView1.RowHeadersVisible ? dataGridView1.RowHeadersWidth : 0;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    totalWidth += col.Width;
                }
                int scrollbarWidth = SystemInformation.VerticalScrollBarWidth;
                dataGridView1.Width = totalWidth + scrollbarWidth + 15;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }

    }

}
