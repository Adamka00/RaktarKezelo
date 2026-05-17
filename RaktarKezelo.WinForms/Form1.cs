using RaktarKezelo.Core.Services;
using RaktarKezelo.Core.Entities;

namespace RaktarKezelo.WinForms;

public partial class Form1 : Form
{
    private readonly RaktarService _raktarService;

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
        try
        {
            var ujTermek = new Termek
            {
                Nev = txtUjNev.Text,
                Cikkszam = txtUjCikkszam.Text,
                Ar = decimal.Parse(txtUjAr.Text),
                Keszlet = int.Parse(txtUjKeszlet.Text),
                MinKeszlet = 5,
                KategoriaId = int.Parse(txtUjKategoriaId.Text),
                IsDeleted = false
            };

            _raktarService.UjTermekMentese(ujTermek);

            MessageBox.Show("Termék sikeresen elmentve a Mac-es MySQL-be!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtUjNev.Clear();
            txtUjCikkszam.Clear();
            txtUjAr.Clear();
            txtUjKeszlet.Clear();
            txtUjKategoriaId.Clear();

            TermekekFrissitese();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Hiba történt a mentés során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}