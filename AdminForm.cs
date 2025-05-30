using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace admitere_facultate_C_
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            FormHelper.ConfigureForm(this, new Size(1200, 700), new Size(800, 500), true);
            splitContainer1.Dock = DockStyle.Fill;
            tabControl1.Dock = DockStyle.Fill;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                DB.openConn();

                dataGridView1.DataSource= Selects.GetStudenti();
                dataGridView2.DataSource = Selects.GetFacultati();
                dataGridView3.DataSource = Selects.GetAdmitereStatus();

                LayoutHelper.AutoResizeDataGridView(dataGridView1);
                LayoutHelper.AutoResizeDataGridView(dataGridView2);
                LayoutHelper.AutoResizeDataGridView(dataGridView3);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea datelor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.closeConn();
            }
        }
    }
}
