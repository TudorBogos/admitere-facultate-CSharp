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

namespace admitere_facultate_C_
{
    public partial class AdminForm : Form
    {
        private StudentControl studentControl;
        private FacultatiControl facultatiControl;
        private AdmitereStatusControl admitereStatusControl;
        public AdminForm()
        {
            InitializeComponent();
            FormHelper.ConfigureForm(this, new Size(1320, 700), new Size(1320, 700), true);
            splitContainer1.Dock = DockStyle.Fill;
            tabControl1.Dock = DockStyle.Fill;

            studentControl = new StudentControl();
            studentControl.Dock = DockStyle.Fill;
            studentControl.Visible = true;
            formPanel.Controls.Add(studentControl);

            facultatiControl = new FacultatiControl();
            facultatiControl.Dock = DockStyle.Fill;
            facultatiControl.Visible = false;
            formPanel.Controls.Add(facultatiControl);

            admitereStatusControl = new AdmitereStatusControl();
            admitereStatusControl.Dock = DockStyle.Fill;
            admitereStatusControl.Visible = false;
            formPanel.Controls.Add(admitereStatusControl);

            studentControl.TargetGrid = dataGridView1;
            facultatiControl.TargetGrid = dataGridView2;
            admitereStatusControl.TargetGrid = dataGridView3;

            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LayoutHelper.CenterControlsVertically(button1);
            LoadStudenti();
            LoadFacultati();
            LoadAdmitereStatus();
        }

        /// <summary>
        /// Handles the tab selection change event to show the appropriate user control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: clear or hide all controls first
            foreach (Control ctrl in formPanel.Controls)
                ctrl.Visible = false;

            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPageStudenti":
                    studentControl.Visible = true;
                    break;

                case "tabPageFacultati":
                    facultatiControl.Visible = true;
                    break;

                case "tabPageAdmitereStatus":
                    admitereStatusControl.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Loads the students data into the DataGridView.
        /// </summary>
        public void LoadStudenti()
        {
            try
            {
                DB.openConn();
                dataGridView1.DataSource = Selects.GetStudenti();
                LayoutHelper.ResizeDataGridView(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcarea studentilor: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }

        /// <summary>
        /// Loads the faculties data into the DataGridView.
        /// </summary>
        public void LoadFacultati()
        {
            try
            {
                DB.openConn();
                dataGridView2.DataSource = Selects.GetFacultati();
                LayoutHelper.ResizeDataGridView(dataGridView2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcarea facultatilor: " + ex.Message);
            }
            finally
            {
                DB.closeConn();
            }
        }

        /// <summary>
        /// Loads the admission status data into the DataGridView.
        /// </summary>
        public void LoadAdmitereStatus()
        {
            try
            {
                DB.openConn();
                dataGridView3.DataSource = Selects.GetAdmitereStatus();
                LayoutHelper.ResizeDataGridView(dataGridView3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcarea statusurilor de admitere: " + ex.Message);
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv";
                ofd.Title = "Selectează fișierul CSV";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    CsvImporter.ImportCsvToDatabase(ofd.FileName);

                    // Refresh table after import
                    var adminForm = this.FindForm() as AdminForm;
                    adminForm?.LoadStudenti();
                    adminForm?.LoadAdmitereStatus();
                }
            }
        }
    }
}
