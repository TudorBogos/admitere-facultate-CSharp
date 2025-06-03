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
            tableLayoutPanel1 = new TableLayoutPanel();
            tabControl1 = new TabControl();
            tabPageStudenti = new TabPage();
            dataGridView1 = new DataGridView();
            tabPageFacultati = new TabPage();
            dataGridView2 = new DataGridView();
            tabPageAdmitereStatus = new TabPage();
            dataGridView3 = new DataGridView();
            panel1 = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageStudenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPageFacultati.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPageAdmitereStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            panel1.SuspendLayout();
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
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(1311, 636);
            splitContainer1.SplitterDistance = 159;
            splitContainer1.TabIndex = 1;
            // 
            // formPanel
            // 
            formPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(0, 0);
            formPanel.Name = "formPanel";
            formPanel.Size = new Size(1311, 159);
            formPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1311, 473);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageStudenti);
            tabControl1.Controls.Add(tabPageFacultati);
            tabControl1.Controls.Add(tabPageAdmitereStatus);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1091, 467);
            tabControl1.TabIndex = 0;
            // 
            // tabPageStudenti
            // 
            tabPageStudenti.Controls.Add(dataGridView1);
            tabPageStudenti.Location = new Point(4, 24);
            tabPageStudenti.Name = "tabPageStudenti";
            tabPageStudenti.Padding = new Padding(3);
            tabPageStudenti.Size = new Size(1083, 439);
            tabPageStudenti.TabIndex = 0;
            tabPageStudenti.Text = "Studenti";
            tabPageStudenti.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1077, 433);
            dataGridView1.TabIndex = 0;
            // 
            // tabPageFacultati
            // 
            tabPageFacultati.Controls.Add(dataGridView2);
            tabPageFacultati.Location = new Point(4, 24);
            tabPageFacultati.Name = "tabPageFacultati";
            tabPageFacultati.Padding = new Padding(3);
            tabPageFacultati.Size = new Size(1083, 439);
            tabPageFacultati.TabIndex = 1;
            tabPageFacultati.Text = "Facultati";
            tabPageFacultati.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(1077, 433);
            dataGridView2.TabIndex = 0;
            // 
            // tabPageAdmitereStatus
            // 
            tabPageAdmitereStatus.Controls.Add(dataGridView3);
            tabPageAdmitereStatus.Location = new Point(4, 24);
            tabPageAdmitereStatus.Name = "tabPageAdmitereStatus";
            tabPageAdmitereStatus.Padding = new Padding(3);
            tabPageAdmitereStatus.Size = new Size(1083, 439);
            tabPageAdmitereStatus.TabIndex = 2;
            tabPageAdmitereStatus.Text = "Admitere Status";
            tabPageAdmitereStatus.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.AllowUserToOrderColumns = true;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView3.Location = new Point(3, 3);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(1077, 433);
            dataGridView3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Location = new Point(1100, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(208, 467);
            panel1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(-2, 225);
            button1.Name = "button1";
            button1.Size = new Size(207, 23);
            button1.TabIndex = 0;
            button1.Text = "Import table Studenti";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageStudenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPageFacultati.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPageAdmitereStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tabPageStudenti;
        private TabPage tabPageFacultati;
        private TabPage tabPageAdmitereStatus;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private Panel formPanel;
        private Button button1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}