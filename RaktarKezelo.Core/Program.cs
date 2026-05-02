using RaktarKezelo.Core.Entities; // Csak ezt az egyet használd az entitásokhoz!
using Microsoft.EntityFrameworkCore;

namespace RaktarKezelo.Core;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- RaktárKezelő Adatbázis Teszt ---");

        using (var db = new RaktarContext())
        {
            try
            {
                // Először töröljük a régi tesztadatokat, hogy tiszta legyen a terep (opcionális)
                // db.Database.EnsureCreated(); 

                var kat = new Kategoria { Nev = "Kéziszerszámok" };
                db.Kategoriak.Add(kat);
                db.SaveChanges();

                // Explicit megadjuk a típust, hogy ne legyen "Ambiguous"
                Termek ujTermek = new Termek
                {
                    Nev = "Profi Kalapács 500g",
                    Cikkszam = "KAL-2026-001",
                    Keszlet = 15,
                    Ar = 4500.50m,
                    MinKeszlet = 3,
                    Megjegyzes = "Nagyon ütős.",
                    KategoriaId = kat.Id
                };

                db.Termekek.Add(ujTermek);
                db.SaveChanges();

                Console.WriteLine("Sikeres mentés!");

                // Itt kényszerítjük a típust a Listában is
                List<Termek> mindenTermek = db.Termekek
                    .Include(t => t.Kategoria)
                    .ToList();

                foreach (Termek t in mindenTermek)
                {
                    // Itt külön változókba szedjük, hogy a WriteLine ne akadjon ki
                    string nev = t.Nev;
                    string kod = t.Cikkszam;
                    string kategoriaNev = t.Kategoria?.Nev ?? "Nincs kategória";
                    
                    Console.WriteLine($"- [{kod}] {nev} | Kategória: {kategoriaNev} | Ár: {t.Ar} Ft");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HIBA: {ex.Message}");
                if (ex.InnerException != null) Console.WriteLine($"Infó: {ex.InnerException.Message}");
            }
        }
        Console.ReadKey();
    }
}