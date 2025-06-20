﻿using System;
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
    public partial class StudentControl : UserControl
    {
        public DataGridView TargetGrid { get; set; }


        public StudentControl()
        {
            InitializeComponent();
            FormHelper.ConfigureControl(this, new Size(1311, 159), new Size(1311, 159));
            Label[] labels = { label1, label2, label3, label4, label5, label6, label7 };
            TextBox[] boxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 };
            this.Resize += (s, ev) =>
            {

                int currentTop = 0;
                for (int i = 0; i < labels.Length; i++)
                {
                    LayoutHelper.ComponentCenter(labels[i], currentTop);
                    LayoutHelper.ComponentBelow(boxes[i], labels[i], 10);
                }
            };
        }

        private void StudentControl_Load(object sender, EventArgs e)
        {
            Label[] labels = { label1, label2, label3, label4, label5, label6, label7 };
            TextBox[] boxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 };

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
                    sfd.FileName = "Studenti.pdf";

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
                    sfd.FileName = "Studenti.csv";

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

            StudentDB.InsertStudent(
                textBox2.Text.Trim(),
                textBox3.Text.Trim(),
                textBox4.Text.Trim(),
                string.IsNullOrWhiteSpace(textBox5.Text) ? (decimal?)null : decimal.TryParse(textBox5.Text, out var nota) ? nota : null,
                string.IsNullOrWhiteSpace(textBox6.Text) ? (int?)null : int.TryParse(textBox6.Text, out var facultateId) ? facultateId : null,
                textBox7.Text.Trim()
            );

            AdminForm.UpdateAdmitereStatus();

            var adminForm = this.FindForm() as AdminForm;
            if (adminForm != null)
            {
                adminForm.LoadStudenti();
                adminForm.LoadAdmitereStatus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int id))
            {
                MessageBox.Show("ID-ul studentului este invalid.");
                return;
            }

            StudentDB.UpdateStudent(
                id,
                textBox2.Text.Trim(), // Nume
                textBox3.Text.Trim(), // Prenume
                textBox4.Text.Trim(), // CNP
                string.IsNullOrWhiteSpace(textBox5.Text) ? (decimal?)null : decimal.TryParse(textBox5.Text, out var nota) ? nota : null,
                string.IsNullOrWhiteSpace(textBox6.Text) ? (int?)null : int.TryParse(textBox6.Text, out var facultateId) ? facultateId : null,
                textBox7.Text.Trim() // Optiune
            );

            AdminForm.UpdateAdmitereStatus();

            var adminForm = this.FindForm() as AdminForm;
            if (adminForm != null)
            {
                adminForm.LoadStudenti();
                adminForm.LoadAdmitereStatus();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int id))
            {
                MessageBox.Show("ID invalid pentru ștergere.");
                return;
            }

            var confirm = MessageBox.Show("Ești sigur că vrei să ștergi acest student?", "Confirmare", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                StudentDB.DeleteStudent(id);
                MessageBox.Show("Student șters cu succes.");
            }

            AdminForm.UpdateAdmitereStatus();

            var adminForm = this.FindForm() as AdminForm;
            if (adminForm != null)
            {
                adminForm.LoadStudenti();
                adminForm.LoadAdmitereStatus();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var adminForm = this.FindForm() as AdminForm;
            if (adminForm != null)
            {
                adminForm.LoadStudenti();
            }
        }
    }
}
