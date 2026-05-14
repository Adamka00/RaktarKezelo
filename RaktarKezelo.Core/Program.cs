using RaktarKezelo.Core.Entities;

namespace RaktarKezelo.Core;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== BÁLNAERŐS BACKEND STRESSZ-TESZT v2.1 (Öngyógyító) ===\n");

        var raktar = new RaktarService();

        try
        {
            // 1. ADATOK ELLENŐRZÉSE ÉS AUTOMATIKUS PÓTLÁS
            Console.WriteLine("1. Lépés: Adatok betöltése...");
            var termekLista = raktar.Kereses("");

            if (!termekLista.Any())
            {
                Console.WriteLine("⚠️ Üres a raktár (vagy minden törölt), új teszt-termék generálása...");
                
                // Új termék összeállítása
                var ujTesztTermek = new Termek
                {
                    Nev = "Profi Kalapács 500g",
                    Cikkszam = "HAM-" + DateTime.Now.Ticks.ToString().Substring(10), // Egyedi cikkszám
                    Ar = 4500.50m,
                    Keszlet = 15,
                    MinKeszlet = 5,
                    KategoriaId = 1 // Feltételezzük, hogy az 1-es ID létezik
                };

                // Mentés a service-en keresztül
                raktar.UjTermekMentese(ujTesztTermek);
                Console.WriteLine("✅ Új termék sikeresen hozzáadva!");
                
                // Lista frissítése
                termekLista = raktar.Kereses("");
            }

            // 2. SOFT DELETE TESZT
            Console.WriteLine("\n2. Lépés: Soft Delete (Puha törlés) tesztelése...");
            var termek = termekLista.First();
            int id = termek.Id;
            string nev = termek.Nev;

            Console.WriteLine($"Kiválasztott termék törlésre: {nev} (ID: {id})");
            
            // Törlés végrehajtása
            raktar.TermekTorles(id); 
            Console.WriteLine("Törlési parancs kiadva.");

            // Új service példány a friss DB állapot ellenőrzéséhez
            var frissRaktar = new RaktarService();
            var ellenorzoLista = frissRaktar.Kereses("");

            if (ellenorzoLista.Any(t => t.Id == id))
            {
                Console.WriteLine($"❌ HIBA: A(z) '{nev}' még mindig látszik a listában!");
            }
            else
            {
                Console.WriteLine($"✅ SIKER: A(z) '{nev}' eltűnt a listából (IsDeleted = true).");
            }

            // 3. ÖSSZETETT KERESÉS (ADVANCED SEARCH)
            Console.WriteLine("\n3. Lépés: Összetett keresés tesztelése...");
            // Keressünk rá egy olyan árkategóriára, amiben biztosan van/volt valami
            var talalatok = frissRaktar.ReszletesKereses(null, null, 1000, 100000);
            
            Console.WriteLine($"Aktív termékek a 1.000 - 100.000 Ft sávban: {talalatok.Count} db.");
            foreach (var t in talalatok)
            {
                Console.WriteLine($"  -> {t.Nev} ({t.Ar} Ft)");
            }

            // 4. TRANZAKCIÓ BIZTONSÁG
            Console.WriteLine("\n4. Lépés: Tranzakció biztonság (Rollback teszt)...");
            try
            {
                var eloTermek = talalatok.FirstOrDefault();
                if (eloTermek != null)
                {
                    Console.WriteLine($"Hibás eladás szimulálása: {eloTermek.Nev}");
                    frissRaktar.BiztonsagosKeszletModositas(eloTermek.Id, -500000, "Hibás eladás");
                }
                else
                {
                    Console.WriteLine("Nincs aktív termék a tranzakció teszthez.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✅ SIKER: A tranzakció visszagördítve! Hiba: {ex.Message}");
            }

            // 5. ZÁRÓ ÖSSZESÍTÉS
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine($"Rendszeridő: {frissRaktar.GetFormattedCurrentTime()}");
            Console.WriteLine($"Aktuális raktárérték (aktív termékek): {frissRaktar.GetTeljesRaktarErtek():N2} Ft");
            Console.WriteLine("--------------------------------------------");
            
            // 6. CSV
            
            Console.WriteLine("\n6. Lépés: Exportálás tesztelése...");
            string asztalUtvonal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "raktar_export.csv");

            string eredmeny = raktar.ExportaloCsvbe(asztalUtvonal);
            Console.WriteLine(eredmeny);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ KRITIKUS HIBA A TESZT SORÁN: {ex.Message}");
            if (ex.InnerException != null) Console.WriteLine($"Részletek: {ex.InnerException.Message}");
        }

        Console.WriteLine("\nA teszt befejeződött. Nyomj egy gombot!");
        Console.ReadKey();
    }
}