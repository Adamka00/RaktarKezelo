using RaktarKezelo.Core.Services;
using RaktarKezelo.Core.Entities;

namespace RaktarKezelo.WinForms;

public partial class Form1 : Form
{
    private readonly RaktarService _raktarService;
    private int? _szerkesztendoTermekId = null;

    public Form1()
    {
        InitializeComponent();

        // Elindítjuk a backendet és a MySQL kapcsolatot
        _raktarService = new RaktarService();
        this.Text = "Gyári Raktárkezelő Alkalmazás Beta v1.0";

        TermekekFrissitese();
    }

    private void TermekekFrissitese()
    {
        // Lekérjük az aktív termékeket az adatbázisból
        var aktivTermekek = _raktarService.Kereses("");

        // Rárakjuk a táblázatra
        dgvTermekek.DataSource = aktivTermekek;
    }

    private void oraTimer_Tick_1(object sender, EventArgs e)
    {
        lblStatusIdo.Text = $"Rendszeridő: {_raktarService.GetFormattedCurrentTime()}";
    }

    private void btnKereses_Click(object sender, EventArgs e)
    {
        string keresendoSzoveg = txtKereses.Text;

        var szurtTermekek = _raktarService.Kereses(keresendoSzoveg);

        dgvTermekek.DataSource = szurtTermekek;
    }

    private void txtKereses_TextChanged(object sender, EventArgs e)
    {
        dgvTermekek.DataSource = _raktarService.Kereses(txtKereses.Text);
    }

    private void btnMentes_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUjNev.Text) || string.IsNullOrWhiteSpace(txtUjCikkszam.Text))
        {
            MessageBox.Show("A név és a cikkszám kitöltése kötelező!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!decimal.TryParse(txtUjAr.Text, out decimal ar) || ar < 0)
        {
            MessageBox.Show("Kérlek, érvényes, pozitív számot adj meg árnak!", "Hibás adat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(txtUjKeszlet.Text, out int keszlet) || keszlet < 0)
        {
            MessageBox.Show("Kérlek, érvényes, pozitív egész számot adj meg készletnek!", "Hibás adat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(txtUjKategoriaId.Text, out int kategoriaId))
        {
            MessageBox.Show("A kategória ID csak szám lehet!", "Hibás adat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var termekAdat = new Termek
            {
                Nev = txtUjNev.Text,
                Cikkszam = txtUjCikkszam.Text,
                Ar = ar,
                Keszlet = keszlet,
                MinKeszlet = 5,
                KategoriaId = kategoriaId,
                IsDeleted = false
            };

            if (_szerkesztendoTermekId.HasValue)
            {
                termekAdat.Id = _szerkesztendoTermekId.Value;

                _raktarService.Modositas(termekAdat);

                MessageBox.Show("Termék sikeresen frissítve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _raktarService.Hozzaadas(termekAdat);
                MessageBox.Show("Új termék elmentve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _szerkesztendoTermekId = null;
            btnMentes.Text = "Termék Mentése";

            txtUjNev.Clear();
            txtUjCikkszam.Clear();
            txtUjAr.Clear();
            txtUjKeszlet.Clear();
            txtUjKategoriaId.Clear();

            TermekekFrissitese();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Adatbázis hiba: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnTorles_Click(object sender, EventArgs e)
    {
        if (dgvTermekek.SelectedRows.Count == 0)
        {
            MessageBox.Show("Kérlek, válassz ki egy terméket a törléshez!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int kivalasztottId = (int)dgvTermekek.SelectedRows[0].Cells["Id"].Value;
        string kivalasztottNev = dgvTermekek.SelectedRows[0].Cells["Nev"].Value.ToString();

        var valasz = MessageBox.Show($"Biztosan törölni szeretnéd ezt a terméket: {kivalasztottNev}?",
                                 "Törlés megerősítése",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

        if (valasz == DialogResult.Yes)
        {
            try
            {
                _raktarService.TermekTorles(kivalasztottId);

                TermekekFrissitese();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a törlés során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void dgvTermekek_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dgvTermekek.SelectedRows.Count > 0)
        {
            var sor = dgvTermekek.SelectedRows[0];

            _szerkesztendoTermekId = (int)sor.Cells["Id"].Value;

            txtUjNev.Text = sor.Cells["Nev"].Value.ToString();
            txtUjCikkszam.Text = sor.Cells["Cikkszam"].Value.ToString();
            txtUjAr.Text = sor.Cells["Ar"].Value.ToString();
            txtUjKeszlet.Text = sor.Cells["Keszlet"].Value.ToString();
            txtUjKategoriaId.Text = sor.Cells["KategoriaId"].Value.ToString();

            btnMentes.Text = "Módosítás Mentése";
        }
    }
}