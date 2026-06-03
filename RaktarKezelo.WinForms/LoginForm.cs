using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaktarKezelo.WinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnBelepes_Click(object sender, EventArgs e)
        {
            string felhasznalonev = txtFelhasznalonev.Text;
            string jelszo = txtJelszo.Text;

            if (felhasznalonev == "admin" && jelszo == "admin")
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                MessageBox.Show("Hibás felhasználónév vagy jelszó!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJelszo.Clear();
                txtJelszo.Focus();
            }
        }
    }
}
