using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using RaktarKezelo.Core.Entities;

namespace RaktarKezelo.Core;

public class RaktarContext : DbContext
{
    public DbSet<Termek> Termekek { get; set; }
    public DbSet<Kategoria> Kategoriak { get; set; }
    public DbSet<Tranzakcio> Tranzakciok { get; set; }

    public RaktarContext()
    {
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "server=10.211.55.2;database=raktar_db;user=root;password=Ad123456";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Kategoria>().HasData(
        new Kategoria { Id = 1, Nev = "Kéziszerszámok" },
        new Kategoria { Id = 2, Nev = "Elektromos gépek" },
        new Kategoria { Id = 3, Nev = "Munkavédelem" },
        new Kategoria { Id = 4, Nev = "Kötőelemek & Csavarok" },
        new Kategoria { Id = 5, Nev = "Ragasztók & Vegyszerek" },
        new Kategoria { Id = 6, Nev = "Mérőműszerek" },
        new Kategoria { Id = 7, Nev = "Csomagolóanyagok" }
    );

        // --- TESZT TERMÉKEK SEED DATA (20 DB) ---
        modelBuilder.Entity<Termek>().HasData(
            // 1. Kéziszerszámok (KategoriaId = 1)
            new Termek { Id = 1, Nev = "Kalapács 500g", Cikkszam = "HAND-001", Ar = 3490, Keszlet = 25, MinKeszlet = 5, KategoriaId = 1, IsDeleted = false },
            new Termek { Id = 2, Nev = "Csavarhúzó készlet 6 részes", Cikkszam = "HAND-002", Ar = 5990, Keszlet = 12, MinKeszlet = 5, KategoriaId = 1, IsDeleted = false },
            new Termek { Id = 3, Nev = "Kombinált fogó pro", Cikkszam = "HAND-003", Ar = 4200, Keszlet = 2, MinKeszlet = 5, KategoriaId = 1, IsDeleted = false }, // ⚠️ RENDELENDŐ (Keszlet: 2 <= Min: 5)
            new Termek { Id = 4, Nev = "Kézifűrész fához", Cikkszam = "HAND-004", Ar = 6800, Keszlet = 8, MinKeszlet = 3, KategoriaId = 1, IsDeleted = false },

            // 2. Elektromos gépek (KategoriaId = 2)
            new Termek { Id = 5, Nev = "Akkus Fúró-Csavarozó 18V", Cikkszam = "ELEC-001", Ar = 28900, Keszlet = 15, MinKeszlet = 4, KategoriaId = 2, IsDeleted = false },
            new Termek { Id = 6, Nev = "Sarokcsiszoló 900W", Cikkszam = "ELEC-002", Ar = 19500, Keszlet = 1, MinKeszlet = 3, KategoriaId = 2, IsDeleted = false },  // ⚠️ RENDELENDŐ (Keszlet: 1 <= Min: 3)
            new Termek { Id = 7, Nev = "Rezgőcsiszoló", Cikkszam = "ELEC-003", Ar = 14200, Keszlet = 6, MinKeszlet = 2, KategoriaId = 2, IsDeleted = false },
            new Termek { Id = 8, Nev = "Keverőgép festékhez/habarcshoz", Cikkszam = "ELEC-004", Ar = 32000, Keszlet = 0, MinKeszlet = 2, KategoriaId = 2, IsDeleted = false }, // ⚠️ RENDELENDŐ (Keszlet: 0 <= Min: 2)

            // 3. Munkavédelem (KategoriaId = 3)
            new Termek { Id = 9, Nev = "Védőszemüveg karcmentes", Cikkszam = "SAFE-001", Ar = 1890, Keszlet = 50, MinKeszlet = 10, KategoriaId = 3, IsDeleted = false },
            new Termek { Id = 10, Nev = "Munkavédelmi bakancs S3", Cikkszam = "SAFE-002", Ar = 16500, Keszlet = 3, MinKeszlet = 5, KategoriaId = 3, IsDeleted = false }, // ⚠️ RENDELENDŐ (Keszlet: 3 <= Min: 5)
            new Termek { Id = 11, Nev = "Nitril mártott kesztyű (pár)", Cikkszam = "SAFE-003", Ar = 450, Keszlet = 200, MinKeszlet = 50, KategoriaId = 3, IsDeleted = false },

            // 4. Kötőelemek & Csavarok (KategoriaId = 4)
            new Termek { Id = 12, Nev = "Faforgácslap csavar 4x40 (100db)", Cikkszam = "FAST-001", Ar = 1200, Keszlet = 45, MinKeszlet = 10, KategoriaId = 4, IsDeleted = false },
            new Termek { Id = 13, Nev = "Metrikus csavar M6x20 (50db)", Cikkszam = "FAST-002", Ar = 1500, Keszlet = 8, MinKeszlet = 15, KategoriaId = 4, IsDeleted = false }, // ⚠️ RENDELENDŐ (Keszlet: 8 <= Min: 15)
            new Termek { Id = 14, Nev = "Horganyzott anya M6 (100db)", Cikkszam = "FAST-003", Ar = 990, Keszlet = 60, MinKeszlet = 20, KategoriaId = 4, IsDeleted = false },

            // 5. Ragasztók & Vegyszerek (KategoriaId = 5)
            new Termek { Id = 15, Nev = "Univerzális szilikon 280ml", Cikkszam = "CHEM-001", Ar = 2100, Keszlet = 14, MinKeszlet = 5, KategoriaId = 5, IsDeleted = false },
            new Termek { Id = 16, Nev = "Poliuretán szerelőhab 750ml", Cikkszam = "CHEM-002", Ar = 3400, Keszlet = 2, MinKeszlet = 5, KategoriaId = 5, IsDeleted = false }, // ⚠️ RENDELENDŐ (Keszlet: 2 <= Min: 5)
            new Termek { Id = 17, Nev = "Pillanatragasztó gél 3g", Cikkszam = "CHEM-003", Ar = 650, Keszlet = 80, MinKeszlet = 15, KategoriaId = 5, IsDeleted = false },

            // 6. Mérőműszerek (KategoriaId = 6)
            new Termek { Id = 18, Nev = "Digitális tolómérő 150mm", Cikkszam = "MEAS-001", Ar = 8900, Keszlet = 7, MinKeszlet = 2, KategoriaId = 6, IsDeleted = false },
            new Termek { Id = 19, Nev = "Mérőszalag 5m gumírozott", Cikkszam = "MEAS-002", Ar = 1490, Keszlet = 30, MinKeszlet = 8, KategoriaId = 6, IsDeleted = false },

            // 7. Csomagolóanyagok (KategoriaId = 7)
            new Termek { Id = 20, Nev = "Nyújtható sztreccsfólia 5kg", Cikkszam = "PACK-001", Ar = 4800, Keszlet = 4, MinKeszlet = 5, KategoriaId = 7, IsDeleted = false } // ⚠️ RENDELENDŐ (Keszlet: 4 <= Min: 5)
        );
    }
}