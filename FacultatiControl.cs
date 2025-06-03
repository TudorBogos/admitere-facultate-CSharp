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
    public partial class FacultatiControl : UserControl
    {
        public DataGridView TargetGrid { get; set; }

        public FacultatiControl()
        {
            InitializeComponent();
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            Label[] labels = { label1, label2, label3, label4 };
            TextBox[] boxes = { textBox1, textBox2, textBox3, textBox4 };

            int currentTop = 0;
            for (int i = 0; i < labels.Length; i++)
            {
                LayoutHelper.ComponentCenter(labels[i], currentTop);
                LayoutHelper.ComponentBelow(boxes[i], labels[i], 10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TargetGrid != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.Title = "Salveaza PDF-ul";
                    sfd.FileName = "Facultati.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportUtility.ExportDataGridViewToPdf(TargetGrid, sfd.FileName, "Baza de date facultati");
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
                    sfd.FileName = "Facultati.csv";

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
            FacultateDB.InsertFacultate(
                textBox2.Text.Trim(), // Nume_Facultate
                textBox3.Text.Trim(), // Adresa
                string.IsNullOrWhiteSpace(textBox4.Text) ? (int?)null : int.Parse(textBox4.Text) // numar_locuri
            );

            AdminForm.UpdateAdmitereStatus();

            var adminForm = this.FindForm() as AdminForm;
            if (adminForm != null)
            {
                adminForm.LoadFacultati();
                adminForm.LoadAdmitereStatus();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("ID-ul facultății este necesar pentru actualizare.");
                return;
            }

            FacultateDB.UpdateFacultate(
                int.Parse(textBox1.Text),
                textBox2.Text.Trim(), // Nume_Facultate
                textBox3.Text.Trim(), // Adresa
                string.IsNullOrWhiteSpace(textBox4.Text) ? (int?)null : int.Parse(textBox4.Text) // numar_locuri
            );

            AdminForm.UpdateAdmitereStatus();

            var adminForm = this.FindForm() as AdminForm;
            if (adminForm != null)
            {
                adminForm.LoadFacultati();
                adminForm.LoadAdmitereStatus();
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("ID-ul facultății este necesar pentru ștergere.");
                return;
            }

            var confirm = MessageBox.Show("Sigur vrei să ștergi această facultate?", "Confirmare", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                FacultateDB.DeleteFacultate(int.Parse(textBox1.Text));
            }

            AdminForm.UpdateAdmitereStatus();

            var adminForm = this.FindForm() as AdminForm;
            if (adminForm != null)
            {
                adminForm.LoadFacultati();
                adminForm.LoadAdmitereStatus();
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            var adminForm = this.FindForm() as AdminForm;
            adminForm?.LoadFacultati();
            adminForm?.LoadAdmitereStatus();
        }
    }
}
