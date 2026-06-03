using RaktarKezelo.Core.Services;
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
    public partial class DashboardForm : Form
    {
        private readonly RaktarService _raktarService;

        public DashboardForm()
        {
            InitializeComponent();

            _raktarService = new RaktarService();

            StatisztikakBetoltese();
        }

        private void StatisztikakBetoltese()
        {
            try
            {
                decimal teljesErtek = _raktarService.GetTeljesRaktarErtek();
                lblTeljesErtek.Text = $"{teljesErtek:N0} Ft";

                var kritikusok = _raktarService.GetKritikusKeszlet();
                lblKritikusDb.Text = $"{kritikusok.Count} db";

                var osszesTermek = _raktarService.Kereses("");
                lblCikkekDb.Text = $"{osszesTermek.Count} fajta";

                dgvKritikusKeszlet.DataSource = null;

                dgvKritikusKeszlet.AutoGenerateColumns = true;

                dgvKritikusKeszlet.DataSource = kritikusok.OrderBy(t => t.Keszlet).Take(5).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a statisztikák betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
