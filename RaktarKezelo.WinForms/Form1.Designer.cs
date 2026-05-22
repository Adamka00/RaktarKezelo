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
            statusStrip1 = new StatusStrip();
            lblStatusIdo = new ToolStripStatusLabel();
            oraTimer = new System.Windows.Forms.Timer(components);
            dgvTermekek = new DataGridView();
            label1 = new Label();
            txtKereses = new TextBox();
            btnKereses = new Button();
            panel1 = new Panel();
            btnMentes = new Button();
            txtUjKategoriaId = new TextBox();
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
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTermekek).BeginInit();
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
            dgvTermekek.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTermekek.Location = new Point(0, 33);
            dgvTermekek.Name = "dgvTermekek";
            dgvTermekek.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTermekek.Size = new Size(625, 395);
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
            // btnKereses
            // 
            btnKereses.FlatStyle = FlatStyle.Flat;
            btnKereses.Location = new Point(272, 4);
            btnKereses.Name = "btnKereses";
            btnKereses.Size = new Size(75, 23);
            btnKereses.TabIndex = 4;
            btnKereses.Text = "Keresés";
            btnKereses.UseVisualStyleBackColor = true;
            btnKereses.Click += btnKereses_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnMentes);
            panel1.Controls.Add(txtUjKategoriaId);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtUjKeszlet);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtUjAr);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtUjCikkszam);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtUjNev);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(631, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(169, 390);
            panel1.TabIndex = 5;
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
            // txtUjKategoriaId
            // 
            txtUjKategoriaId.Location = new Point(7, 225);
            txtUjKategoriaId.Name = "txtUjKategoriaId";
            txtUjKategoriaId.Size = new Size(159, 23);
            txtUjKategoriaId.TabIndex = 10;
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
            btnTorles.Location = new Point(512, 7);
            btnTorles.Name = "btnTorles";
            btnTorles.Size = new Size(113, 23);
            btnTorles.TabIndex = 6;
            btnTorles.Text = "Termék törlése";
            btnTorles.UseVisualStyleBackColor = false;
            btnTorles.Click += btnTorles_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTorles);
            Controls.Add(panel1);
            Controls.Add(btnKereses);
            Controls.Add(txtKereses);
            Controls.Add(label1);
            Controls.Add(dgvTermekek);
            Controls.Add(statusStrip1);
            Name = "Form1";
            Text = "Raktárkezelő";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTermekek).EndInit();
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
        private Button btnKereses;
        private Panel panel1;
        private Label label2;
        private TextBox txtUjNev;
        private Label label3;
        private TextBox txtUjKeszlet;
        private Label label5;
        private TextBox txtUjAr;
        private Label label6;
        private TextBox txtUjCikkszam;
        private Label label4;
        private TextBox txtUjKategoriaId;
        private Label label7;
        private Button btnMentes;
        private Button btnTorles;
    }
}
