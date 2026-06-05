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

        _raktarService = new RaktarService();

        this.Text = "Gyári Raktárkezelő Alkalmazás 1.0";


        TermekekFrissitese();

        KategoriakBetoltese();


    }

    private void TermekekFrissitese()
    {
        try
        {
            var mindenTermek = _raktarService.Kereses("");

            var racsAdat = mindenTermek
                .Select(t => new
                {
                    ID = t.Id,
                    Cikkszám = t.Cikkszam,
                    Megnevezés = t.Nev,
                    Kategória = t.Kategoria != null ? t.Kategoria.Nev : "Nincs kategória",
                    Ár = $"{t.Ar:N0} Ft",
                    Készlet = $"{t.Keszlet} db",
                    MinKészlet = $"{t.MinKeszlet} db",
                    Státusz = t.IsDeleted ? "Törölt" : "Aktív"
                })
                .ToList();

            dgvTermekek.DataSource = null;
            dgvTermekek.Columns.Clear();

            dgvTermekek.DataSource = racsAdat;

            if (dgvTermekek.Columns["ID"] != null)
            {
                dgvTermekek.Columns["ID"].Visible = false;
            }

            dgvTermekek.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Hiba a táblázat frissítésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void KategoriakBetoltese()
    {
        try
        {
            var kategoriak = _raktarService.GetKategoriak();

            cmbKategoria.DataSource = kategoriak;

            cmbKategoria.DisplayMember = "Nev";

            cmbKategoria.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Hiba a kategóriák betöltésekor: {ex.Message}");
        }
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

    private void TablazatMegjelenites(List<Termek> lista)
    {
        var megjelenitendo = lista.Select(t => new
        {
            ID = t.Id,
            Cikkszám = t.Cikkszam,
            Megnevezés = t.Nev,
            Kategória = t.Kategoria != null ? t.Kategoria.Nev : "Nincs",
            Ár = $"{t.Ar:N0} Ft",
            Készlet = $"{t.Keszlet} db",
            MinKészlet = $"{t.MinKeszlet} db",
            Státusz = t.IsDeleted ? "Törölt" : "Aktív"
        }).ToList();

        dgvTermekek.DataSource = null;
        dgvTermekek.Columns.Clear();
        dgvTermekek.DataSource = megjelenitendo;

        if (dgvTermekek.Columns["ID"] != null) dgvTermekek.Columns["ID"].Visible = false;
        dgvTermekek.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void txtKereses_TextChanged(object sender, EventArgs e)
    {
        var eredmeny = _raktarService.Kereses(txtKereses.Text);
        TablazatMegjelenites(eredmeny);
    }

    private void btnMentes_Click(object sender, EventArgs e)
    {
        // 1. VALIDÁCIÓK (Az eddigi kódod, ez teljesen jó volt)
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

        if (cmbKategoria.SelectedValue == null)
        {
            MessageBox.Show("Kérlek, válassz egy kategóriát a listából!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int kategoriaId = (int)cmbKategoria.SelectedValue;

        try
        {
            // 2. SZÉTVÁLASZTÁS: Módosítás vagy Új hozzáadás?
            if (_szerkesztendoTermekId.HasValue)
            {
                // --- MÓDOSÍTÁS ÁG ---
                // MAGYARÁZAT: Nem hozunk létre "new Termek"-et! Megkérjük a Service-t, 
                // hogy hozza el nekünk a meglévő, adatbázis által már "ismert" terméket az ID alapján.
                var letezoTermek = _raktarService.GetTermekById(_szerkesztendoTermekId.Value);

                if (letezoTermek != null)
                {
                    // Csak az értékeket frissítjük az objektumon, az ID-hoz nem nyúlunk
                    letezoTermek.Nev = txtUjNev.Text;
                    letezoTermek.Cikkszam = txtUjCikkszam.Text;
                    letezoTermek.Ar = ar;
                    letezoTermek.Keszlet = keszlet;
                    letezoTermek.KategoriaId = kategoriaId;
                    // a MinKeszlet és az IsDeleted marad az, ami eddig is volt rajta

                    // Átadjuk a frissített eredeti objektumot a Service-nek
                    _raktarService.Modositas(letezoTermek);

                    MessageBox.Show("Termék sikeresen frissítve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("A módosítandó termék nem található az adatbázisban!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // --- ÚJ HOZZÁADÁS ÁG ---
                // Itt viszont kell a "new Termek", mert ez egy teljesen új rekord lesz a MySQL-ben
                var ujTermek = new Termek
                {
                    Nev = txtUjNev.Text,
                    Cikkszam = txtUjCikkszam.Text,
                    Ar = ar,
                    Keszlet = keszlet,
                    MinKeszlet = 5, // Alapértelmezett minimum készlet
                    KategoriaId = kategoriaId,
                    IsDeleted = false
                };

                _raktarService.Hozzaadas(ujTermek);
                MessageBox.Show("Új termék elmentve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 3. TAKARÍTÁS ÉS REFRESH (Sikeres mentés után visszaállunk alaphelyzetbe)
            _szerkesztendoTermekId = null;
            btnMentes.Text = "Termék Mentése";

            txtUjNev.Clear();
            txtUjCikkszam.Clear();
            txtUjAr.Clear();
            txtUjKeszlet.Clear();
            cmbKategoria.SelectedIndex = -1;

            // Frissítjük a táblázatot az új, ékezetes, magyar nyelvű metódusoddal
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
        if (dgvTermekek.CurrentRow != null)
        {
            int id = Convert.ToInt32(dgvTermekek.CurrentRow.Cells["ID"].Value);

            var termek = _raktarService.GetTermekById(id);

            if (termek != null)
            {
                _szerkesztendoTermekId = termek.Id;

                txtUjNev.Text = termek.Nev;
                txtUjCikkszam.Text = termek.Cikkszam;
                txtUjAr.Text = termek.Ar.ToString();
                txtUjKeszlet.Text = termek.Keszlet.ToString();
                //txtUjMinKeszlet.Text = termek.MinKeszlet.ToString();
                cmbKategoria.SelectedValue = termek.KategoriaId;


                pnlOldalsav.Visible = true;
                btnMentes.Text = "Módosítás mentése";
            }
        }
    }

    private void btnDashboard_Click(object sender, EventArgs e)
    {
        using (var dashboard = new DashboardForm())
        {
            dashboard.ShowDialog();
        }
    }

    private void btnOldalsavToggle_Click(object sender, EventArgs e)
    {
        pnlOldalsav.Visible = !pnlOldalsav.Visible;

        if (pnlOldalsav.Visible)
        {
            btnOldalsavToggle.Text = "Oldalsáv elrejtése";
        }
        else
        {
            btnOldalsavToggle.Text = "Új termék / Szerkesztés";
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        pnlOldalsav.Visible = false;

        btnOldalsavToggle.Text = "Új termék / Szerkesztés";
    }

    private void btnCsvExport_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Title = "Raktárkészlet exportálása CSV fájlba";

            sfd.Filter = "CSV fájl (*.csv)|*.csv|Minden fájl (*.*)|*.*";
            sfd.DefaultExt = "csv";

            sfd.FileName = $"raktarkeszlet_{DateTime.Now:yyyy-MM-dd}";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string eredmenyUzenet = _raktarService.ExportaloCsvbe(sfd.FileName);

                    MessageBox.Show(eredmenyUzenet, "Sikeres mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt a mentés során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}