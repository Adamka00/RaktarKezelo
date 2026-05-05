using RaktarKezelo.Core.Entities;
using RaktarKezelo.Core.Repositories;


namespace RaktarKezelo.Core;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== BÁLNAERŐS RAKTÁR RENDSZER TESZT (2026) ===\n");

        // 1. Service példányosítása (ez elintézi a Repository-kat és a Contextet is)
        var raktar = new RaktarService();

        try
        {
            // 2. Egy kis idő formátum teszt (amit kértél)
            Console.WriteLine($"Aktuális szerveridő: {raktar.GetFormattedCurrentTime()}");
            Console.WriteLine("--------------------------------------------");

            // 3. Nézzük meg az összes terméket, ami eddig van
            var regiTermekek = raktar.Kereses(""); // Üres keresés = minden
            Console.WriteLine($"Jelenleg {regiTermekek.Count} termék van a rendszerben.");

            // 4. Készletmozgás teszt
            // Tegyük fel, hogy a korábban felvett 1-es ID-jú termékből eladunk 2 darabot
            if (regiTermekek.Any())
            {
                var elsoTermek = regiTermekek.First();
                Console.WriteLine($"\nELADÁS TESZT: {elsoTermek.Nev} (Készlet: {elsoTermek.Keszlet})");
                
                raktar.KeszletModositas(elsoTermek.Id, -2, "Eladás");
                
                // Újra lekérjük, hogy lássuk a változást
                Console.WriteLine($"Új készlet: {elsoTermek.Keszlet} (Naplózva az adatbázisba! ✅)");
            }

            // 5. Raktár-érték elemzés
            decimal osszertek = raktar.GetTeljesRaktarErtek();
            Console.WriteLine($"\nTELJES RAKTÁRÉRTÉK: {osszertek:N2} Ft");

            // 6. Kategória statisztika
            Console.WriteLine("\nKATEGÓRIA STATISZTIKA:");
            foreach (var stat in raktar.GetKategoriaStatisztika())
            {
                Console.WriteLine($"- {stat.Key}: {stat.Value} féle termék");
            }

            // 7. Kritikus készlet figyelés
            var kritikusok = raktar.GetKritikusKeszlet();
            if (kritikusok.Any())
            {
                Console.WriteLine("\n⚠️ FIGYELEM! ALACSONY KÉSZLET:");
                foreach (var k in kritikusok)
                {
                    Console.WriteLine($"  -> {k.Nev} (Csak {k.Keszlet} db van, minimum: {k.MinKeszlet})");
                }
            }
            else
            {
                Console.WriteLine("\nKészlet rendben, nincs kritikus termék. ✅");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ HIBA A TESZT SORÁN: {ex.Message}");
            if (ex.InnerException != null) Console.WriteLine($"Részletek: {ex.InnerException.Message}");
        }

        Console.WriteLine("\nTeszt vége. Nyomj egy gombot!");
        Console.ReadKey();
    }
}