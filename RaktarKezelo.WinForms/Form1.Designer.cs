namespace RaktarKezelo.WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            statusStrip1 = new StatusStrip();
            lblStatusIdo = new ToolStripStatusLabel();
            oraTimer = new System.Windows.Forms.Timer(components);
            dgvTermekek = new DataGridView();
            label1 = new Label();
            txtKereses = new TextBox();
            pnlOldalsav = new Panel();
            cmbKategoria = new ComboBox();
            btnMentes = new Button();
            label7 = new Label();
            txtUjKeszlet = new TextBox();
            label5 = new Label();
            txtUjAr = new TextBox();
            label6 = new Label();
            txtUjCikkszam = new TextBox();
            label4 = new Label();
            txtUjNev = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnTorles = new Button();
            btnDashboard = new Button();
            btnOldalsavToggle = new Button();
            panel1 = new Panel();
            btnCsvExport = new Button();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTermekek).BeginInit();
            pnlOldalsav.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatusIdo });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusIdo
            // 
            lblStatusIdo.Name = "lblStatusIdo";
            lblStatusIdo.Size = new Size(84, 17);
            lblStatusIdo.Text = "Idő betöltése...";
            // 
            // oraTimer
            // 
            oraTimer.Enabled = true;
            oraTimer.Interval = 1000;
            oraTimer.Tick += oraTimer_Tick_1;
            // 
            // dgvTermekek
            // 
            dataGridViewCellStyle1.BackColor = SystemColors.ScrollBar;
            dgvTermekek.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTermekek.BackgroundColor = Color.White;
            dgvTermekek.BorderStyle = BorderStyle.None;
            dgvTermekek.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTermekek.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTermekek.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTermekek.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTermekek.Dock = DockStyle.Fill;
            dgvTermekek.GridColor = Color.Silver;
            dgvTermekek.Location = new Point(0, 30);
            dgvTermekek.Name = "dgvTermekek";
            dgvTermekek.RowHeadersVisible = false;
            dgvTermekek.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvTermekek.RowTemplate.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvTermekek.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTermekek.RowTemplate.Height = 28;
            dgvTermekek.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTermekek.Size = new Size(800, 398);
            dgvTermekek.TabIndex = 1;
            dgvTermekek.CellDoubleClick += dgvTermekek_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 7);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "Keresés: ";
            // 
            // txtKereses
            // 
            txtKereses.Location = new Point(69, 4);
            txtKereses.Name = "txtKereses";
            txtKereses.Size = new Size(188, 23);
            txtKereses.TabIndex = 3;
            txtKereses.TextChanged += txtKereses_TextChanged;
            // 
            // pnlOldalsav
            // 
            pnlOldalsav.Controls.Add(cmbKategoria);
            pnlOldalsav.Controls.Add(btnMentes);
            pnlOldalsav.Controls.Add(label7);
            pnlOldalsav.Controls.Add(txtUjKeszlet);
            pnlOldalsav.Controls.Add(label5);
            pnlOldalsav.Controls.Add(txtUjAr);
            pnlOldalsav.Controls.Add(label6);
            pnlOldalsav.Controls.Add(txtUjCikkszam);
            pnlOldalsav.Controls.Add(label4);
            pnlOldalsav.Controls.Add(txtUjNev);
            pnlOldalsav.Controls.Add(label3);
            pnlOldalsav.Controls.Add(label2);
            pnlOldalsav.Dock = DockStyle.Right;
            pnlOldalsav.Location = new Point(631, 30);
            pnlOldalsav.Name = "pnlOldalsav";
            pnlOldalsav.Size = new Size(169, 398);
            pnlOldalsav.TabIndex = 5;
            // 
            // cmbKategoria
            // 
            cmbKategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategoria.FormattingEnabled = true;
            cmbKategoria.Location = new Point(9, 240);
            cmbKategoria.Name = "cmbKategoria";
            cmbKategoria.Size = new Size(157, 23);
            cmbKategoria.TabIndex = 12;
            // 
            // btnMentes
            // 
            btnMentes.FlatStyle = FlatStyle.Flat;
            btnMentes.Location = new Point(7, 277);
            btnMentes.Name = "btnMentes";
            btnMentes.Size = new Size(159, 47);
            btnMentes.TabIndex = 11;
            btnMentes.Text = "Termék Mentése";
            btnMentes.UseVisualStyleBackColor = true;
            btnMentes.Click += btnMentes_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 207);
            label7.Name = "label7";
            label7.Size = new Size(74, 15);
            label7.TabIndex = 9;
            label7.Text = "Kategória ID:";
            // 
            // txtUjKeszlet
            // 
            txtUjKeszlet.Location = new Point(6, 181);
            txtUjKeszlet.Name = "txtUjKeszlet";
            txtUjKeszlet.Size = new Size(160, 23);
            txtUjKeszlet.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 163);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 7;
            label5.Text = "Készlet:";
            // 
            // txtUjAr
            // 
            txtUjAr.Location = new Point(6, 137);
            txtUjAr.Name = "txtUjAr";
            txtUjAr.Size = new Size(160, 23);
            txtUjAr.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 119);
            label6.Name = "label6";
            label6.Size = new Size(22, 15);
            label6.TabIndex = 5;
            label6.Text = "Ár:";
            // 
            // txtUjCikkszam
            // 
            txtUjCikkszam.Location = new Point(5, 93);
            txtUjCikkszam.Name = "txtUjCikkszam";
            txtUjCikkszam.Size = new Size(161, 23);
            txtUjCikkszam.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 75);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 3;
            label4.Text = "Cikkszám:";
            // 
            // txtUjNev
            // 
            txtUjNev.Location = new Point(5, 49);
            txtUjNev.Name = "txtUjNev";
            txtUjNev.Size = new Size(161, 23);
            txtUjNev.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 31);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 1;
            label3.Text = "Név:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 16);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 0;
            label2.Text = "Új termék felvétele";
            // 
            // btnTorles
            // 
            btnTorles.BackColor = Color.DarkOrange;
            btnTorles.FlatStyle = FlatStyle.Flat;
            btnTorles.Location = new Point(512, 4);
            btnTorles.Name = "btnTorles";
            btnTorles.Size = new Size(113, 23);
            btnTorles.TabIndex = 6;
            btnTorles.Text = "Termék törlése";
            btnTorles.UseVisualStyleBackColor = false;
            btnTorles.Click += btnTorles_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Location = new Point(390, 3);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(116, 23);
            btnDashboard.TabIndex = 7;
            btnDashboard.Text = "Műszerfal";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnOldalsavToggle
            // 
            btnOldalsavToggle.FlatStyle = FlatStyle.Flat;
            btnOldalsavToggle.Location = new Point(631, 3);
            btnOldalsavToggle.Name = "btnOldalsavToggle";
            btnOldalsavToggle.Size = new Size(166, 23);
            btnOldalsavToggle.TabIndex = 8;
            btnOldalsavToggle.Text = "Oldalsáv megjelenítése";
            btnOldalsavToggle.UseVisualStyleBackColor = true;
            btnOldalsavToggle.Click += btnOldalsavToggle_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCsvExport);
            panel1.Controls.Add(btnOldalsavToggle);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnTorles);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(txtKereses);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 30);
            panel1.TabIndex = 9;
            // 
            // btnCsvExport
            // 
            btnCsvExport.FlatStyle = FlatStyle.Flat;
            btnCsvExport.Location = new Point(263, 3);
            btnCsvExport.Name = "btnCsvExport";
            btnCsvExport.Size = new Size(95, 23);
            btnCsvExport.TabIndex = 9;
            btnCsvExport.Text = "CSV Exportálás";
            btnCsvExport.UseVisualStyleBackColor = true;
            btnCsvExport.Click += btnCsvExport_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlOldalsav);
            Controls.Add(dgvTermekek);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Raktárkezelő";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTermekek).EndInit();
            pnlOldalsav.ResumeLayout(false);
            pnlOldalsav.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatusIdo;
        private System.Windows.Forms.Timer oraTimer;
        private DataGridView dgvTermekek;
        private Label label1;
        private TextBox txtKereses;
        private Panel pnlOldalsav;
        private Label label2;
        private TextBox txtUjNev;
        private Label label3;
        private TextBox txtUjKeszlet;
        private Label label5;
        private TextBox txtUjAr;
        private Label label6;
        private TextBox txtUjCikkszam;
        private Label label4;
        private Label label7;
        private Button btnMentes;
        private Button btnTorles;
        private Button btnDashboard;
        private Button btnOldalsavToggle;
        private Panel panel1;
        private Button btnCsvExport;
        private ComboBox cmbKategoria;
    }
}
