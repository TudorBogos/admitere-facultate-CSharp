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
        private StudentControl studentControl;
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

            studentControl.TargetGrid = dataGridView1;


            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                DB.openConn();

                dataGridView1.DataSource = Selects.GetStudenti();
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

                    // If you add other user controls like FacultateControl, etc:
                    // case "tabFacultati":
                    //     facultateControl.Visible = true;
                    //     break;
            }
        }
    }
}
