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
                        ExportUtility.ExportDataGridViewToPdf(TargetGrid, sfd.FileName, "Situația Admiterii");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nu există un grid țintă setat pentru export.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
    }
}
