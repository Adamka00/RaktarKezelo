namespace RaktarKezelo.WinForms
{
    partial class LoginForm
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
            label1 = new Label();
            label2 = new Label();
            txtFelhasznalonev = new TextBox();
            txtJelszo = new TextBox();
            btnBelepes = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 35);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Felhasználónév";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 107);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Jelszó";
            // 
            // txtFelhasznalonev
            // 
            txtFelhasznalonev.Location = new Point(93, 53);
            txtFelhasznalonev.Name = "txtFelhasznalonev";
            txtFelhasznalonev.Size = new Size(199, 23);
            txtFelhasznalonev.TabIndex = 2;
            // 
            // txtJelszo
            // 
            txtJelszo.Location = new Point(93, 125);
            txtJelszo.Name = "txtJelszo";
            txtJelszo.PasswordChar = '●';
            txtJelszo.Size = new Size(199, 23);
            txtJelszo.TabIndex = 3;
            // 
            // btnBelepes
            // 
            btnBelepes.FlatStyle = FlatStyle.Flat;
            btnBelepes.Location = new Point(95, 184);
            btnBelepes.Name = "btnBelepes";
            btnBelepes.Size = new Size(197, 55);
            btnBelepes.TabIndex = 4;
            btnBelepes.Text = "Bejelentkezés";
            btnBelepes.UseVisualStyleBackColor = true;
            btnBelepes.Click += btnBelepes_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 266);
            Controls.Add(btnBelepes);
            Controls.Add(txtJelszo);
            Controls.Add(txtFelhasznalonev);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bejelentkzés";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtFelhasznalonev;
        private TextBox txtJelszo;
        private Button btnBelepes;
    }
}