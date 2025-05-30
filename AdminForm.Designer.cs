namespace admitere_facultate_C_
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            formPanel = new Panel();
            tabControl1 = new TabControl();
            tabPageStudenti = new TabPage();
            tabPageFacultati = new TabPage();
            tabPageAdmitereStatus = new TabPage();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageStudenti.SuspendLayout();
            tabPageFacultati.SuspendLayout();
            tabPageAdmitereStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(formPanel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(1311, 636);
            splitContainer1.SplitterDistance = 159;
            splitContainer1.TabIndex = 1;
            // 
            // formPanel
            // 
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(0, 0);
            formPanel.Name = "formPanel";
            formPanel.Size = new Size(1311, 159);
            formPanel.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageStudenti);
            tabControl1.Controls.Add(tabPageFacultati);
            tabControl1.Controls.Add(tabPageAdmitereStatus);
            tabControl1.Location = new Point(275, 116);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(463, 229);
            tabControl1.TabIndex = 0;
            // 
            // tabPageStudenti
            // 
            tabPageStudenti.Controls.Add(dataGridView1);
            tabPageStudenti.Location = new Point(4, 24);
            tabPageStudenti.Name = "tabPageStudenti";
            tabPageStudenti.Padding = new Padding(3);
            tabPageStudenti.Size = new Size(455, 201);
            tabPageStudenti.TabIndex = 0;
            tabPageStudenti.Text = "Studenti";
            tabPageStudenti.UseVisualStyleBackColor = true;
            // 
            // tabPageFacultati
            // 
            tabPageFacultati.Controls.Add(dataGridView2);
            tabPageFacultati.Location = new Point(4, 24);
            tabPageFacultati.Name = "tabPageFacultati";
            tabPageFacultati.Padding = new Padding(3);
            tabPageFacultati.Size = new Size(455, 201);
            tabPageFacultati.TabIndex = 1;
            tabPageFacultati.Text = "Facultati";
            tabPageFacultati.UseVisualStyleBackColor = true;
            // 
            // tabPageAdmitereStatus
            // 
            tabPageAdmitereStatus.Controls.Add(dataGridView3);
            tabPageAdmitereStatus.Location = new Point(4, 24);
            tabPageAdmitereStatus.Name = "tabPageAdmitereStatus";
            tabPageAdmitereStatus.Padding = new Padding(3);
            tabPageAdmitereStatus.Size = new Size(455, 201);
            tabPageAdmitereStatus.TabIndex = 2;
            tabPageAdmitereStatus.Text = "Admitere Status";
            tabPageAdmitereStatus.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(449, 195);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(449, 195);
            dataGridView2.TabIndex = 0;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToOrderColumns = true;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView3.Location = new Point(3, 3);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(449, 195);
            dataGridView3.TabIndex = 0;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1311, 636);
            Controls.Add(splitContainer1);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageStudenti.ResumeLayout(false);
            tabPageFacultati.ResumeLayout(false);
            tabPageAdmitereStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tabPageStudenti;
        private TabPage tabPageFacultati;
        private TabPage tabPageAdmitereStatus;
        private Panel formPanel;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
    }
}