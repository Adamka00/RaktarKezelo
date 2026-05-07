using RaktarKezelo.Core.Entities;

namespace RaktarKezelo.Core;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== BÁLNAERŐS BACKEND STRESSZ-TESZT v2.0 ===\n");

        var raktar = new RaktarService();

        try
        {
            // 1. TESZTADATOK ELLENŐRZÉSE
            Console.WriteLine("1. Lépés: Adatok betöltése...");
            var mindenTermek = raktar.Kereses(""); 
            
            if (!mindenTermek.Any())
            {
                Console.WriteLine("Az adatbázis üres! Vegyél fel egy terméket a teszt előtt.");
                return;
            }

            // 2. SOFT DELETE TESZT
            Console.WriteLine("\n2. Lépés: Soft Delete tesztelése...");
            var tesztTermek = mindenTermek.First();
            int id = tesztTermek.Id;
            string nev = tesztTermek.Nev;

            Console.WriteLine($"Kiválasztott termék: {nev} (ID: {id})");
            Console.WriteLine("Törlés végrehajtása...");
            
            // Itt hívjuk a service-t, ami hívja a repo.Delete-et és a repo.Save-et!
            raktar.TermekTorles(id); 

            // Fontos: Új service példányt használunk a lekérdezéshez, 
            // hogy biztosan az adatbázisból jöjjön a friss állapot, ne a memóriából!
            var ellenorzoRaktar = new RaktarService();
            var frissLista = ellenorzoRaktar.Kereses("");

            bool megMindigOttVan = frissLista.Any(t => t.Id == id);

            if (megMindigOttVan)
            {
                Console.WriteLine($"❌ HIBA: A(z) '{nev}' még mindig látszik a listában!");
                Console.WriteLine("Ellenőrizd a TermekRepository.GetAll() metódusban a .Where(t => !t.IsDeleted) szűrést!");
            }
            else
            {
                Console.WriteLine($"✅ SIKER: A(z) '{nev}' sikeresen elrejtve a listából!");
            }

            // 3. ÖSSZETETT KERESÉS TESZT
            Console.WriteLine("\n3. Lépés: Advanced Search teszt...");
            // Keressünk rá a törölt termék nevére - elvileg 0 találat kellene
            var keresesToroltre = ellenorzoRaktar.ReszletesKereses(nev, null, null, null);
            
            if (!keresesToroltre.Any())
            {
                Console.WriteLine($"✅ SIKER: A kereső sem dobja ki a törölt terméket.");
            }
            else
            {
                Console.WriteLine($"❌ HIBA: A kereső megtalálta a törölt terméket!");
            }

            // 4. TRANZAKCIÓ BIZTONSÁG
            Console.WriteLine("\n4. Lépés: Tranzakció biztonság...");
            try
            {
                // Egy nem törölt terméket próbálunk túlcsordítani
                var eloTermek = frissLista.FirstOrDefault();
                if (eloTermek != null)
                {
                    raktar.BiztonsagosKeszletModositas(eloTermek.Id, -999999, "Hibás eladás");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✅ SIKER: Tranzakció megállítva. Üzenet: {ex.Message}");
            }

            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine($"Záró raktárérték: {ellenorzoRaktar.GetTeljesRaktarErtek():N2} Ft");
            Console.WriteLine("--------------------------------------------");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ KRITIKUS HIBA: {ex.Message}");
        }

        Console.WriteLine("\nNyomj egy gombot a kilépéshez...");
        Console.ReadKey();
    }
}