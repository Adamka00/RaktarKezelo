namespace RaktarKezelo.WinForms
{
    partial class DashboardForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            lblTeljesErtek = new Label();
            label1 = new Label();
            panel2 = new Panel();
            lblKritikusDb = new Label();
            label3 = new Label();
            panel3 = new Panel();
            lblCikkekDb = new Label();
            label5 = new Label();
            label2 = new Label();
            dgvKritikusKeszlet = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKritikusKeszlet).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(8, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.Size = new Size(611, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOliveGreen;
            panel1.Controls.Add(lblTeljesErtek);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(197, 114);
            panel1.TabIndex = 0;
            // 
            // lblTeljesErtek
            // 
            lblTeljesErtek.AutoSize = true;
            lblTeljesErtek.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTeljesErtek.ForeColor = Color.White;
            lblTeljesErtek.Location = new Point(6, 28);
            lblTeljesErtek.Name = "lblTeljesErtek";
            lblTeljesErtek.Size = new Size(50, 30);
            lblTeljesErtek.TabIndex = 1;
            lblTeljesErtek.Text = "0 Ft";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 7);
            label1.Name = "label1";
            label1.Size = new Size(94, 21);
            label1.TabIndex = 0;
            label1.Text = "Raktár érték";
            // 
            // panel2
            // 
            panel2.BackColor = Color.IndianRed;
            panel2.Controls.Add(lblKritikusDb);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(206, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(197, 114);
            panel2.TabIndex = 1;
            // 
            // lblKritikusDb
            // 
            lblKritikusDb.AutoSize = true;
            lblKritikusDb.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKritikusDb.ForeColor = Color.White;
            lblKritikusDb.Location = new Point(3, 28);
            lblKritikusDb.Name = "lblKritikusDb";
            lblKritikusDb.Size = new Size(59, 30);
            lblKritikusDb.TabIndex = 3;
            lblKritikusDb.Text = "0 Db";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 6);
            label3.Name = "label3";
            label3.Size = new Size(131, 21);
            label3.TabIndex = 2;
            label3.Text = "Kritikus termékek";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Highlight;
            panel3.Controls.Add(lblCikkekDb);
            panel3.Controls.Add(label5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(409, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(199, 114);
            panel3.TabIndex = 2;
            // 
            // lblCikkekDb
            // 
            lblCikkekDb.AutoSize = true;
            lblCikkekDb.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCikkekDb.ForeColor = Color.White;
            lblCikkekDb.Location = new Point(3, 28);
            lblCikkekDb.Name = "lblCikkekDb";
            lblCikkekDb.Size = new Size(59, 30);
            lblCikkekDb.TabIndex = 5;
            lblCikkekDb.Text = "0 Db";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 7);
            label5.Name = "label5";
            label5.Size = new Size(104, 21);
            label5.TabIndex = 4;
            label5.Text = "Cikkek száma";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(8, 108);
            label2.Margin = new Padding(3, 20, 3, 10);
            label2.Name = "label2";
            label2.Size = new Size(611, 40);
            label2.TabIndex = 1;
            label2.Text = "5 legkisebb készletű termék (Rendelési lista)";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvKritikusKeszlet
            // 
            dgvKritikusKeszlet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKritikusKeszlet.Dock = DockStyle.Fill;
            dgvKritikusKeszlet.Location = new Point(8, 148);
            dgvKritikusKeszlet.Name = "dgvKritikusKeszlet";
            dgvKritikusKeszlet.Size = new Size(611, 229);
            dgvKritikusKeszlet.TabIndex = 2;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 385);
            Controls.Add(dgvKritikusKeszlet);
            Controls.Add(label2);
            Controls.Add(tableLayoutPanel1);
            Name = "DashboardForm";
            Padding = new Padding(8);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Raktár Statisztikák";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKritikusKeszlet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label lblTeljesErtek;
        private Label label1;
        private Label lblKritikusDb;
        private Label label3;
        private Label lblCikkekDb;
        private Label label5;
        private Label label2;
        private DataGridView dgvKritikusKeszlet;
    }
}