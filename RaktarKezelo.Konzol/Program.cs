namespace RaktarKezelo.Konzol;

class Program
{
    const string ADABTAZIS_FILE = "raktar.csv";
    
    static void Main(string[] args)
    {
        IRaktar raktar = new Raktar();
        IFajlKezelo fajlKezelo = new CVSFajlKezelo();

        Console.WriteLine("-----");

        Console.WriteLine("Adatok betöltése...");
        
        List<Termek> mentettAdatok = fajlKezelo.Betoltes(ADABTAZIS_FILE);

        foreach (var t in mentettAdatok)
        {
            raktar.Hozzaad(t);
        }

        Console.WriteLine("\nÚj termék hozzáadása...");
        
        int ujId = raktar.GetOsszesTermek().Count + 1;
        raktar.Hozzaad(new Termek(ujId, "Akkus csavarozó", 25000, 5));
        
        Console.WriteLine(" --- Jelenlegi készlet: ");
        
        Listazas(raktar.GetOsszesTermek());

        Console.WriteLine(" --- Legdrágább előle rendezve: ");
        var rendezettLista = raktar.RendezesArAlapjan(false);
        Listazas(rendezettLista);

        Console.WriteLine(" --- Keresés, pl. fúró: ");
        string keresett = Console.ReadLine();

        if (!string.IsNullOrEmpty(keresett))
        {
            var talalatok = raktar.KeresesNevAlapjan(keresett);
            Console.WriteLine($"\nTalálatok a következőre: {keresett}: ");

            if (talalatok.Count > 0)
            {
                Listazas(talalatok);
            }
            else
            {
                Console.WriteLine("Nincs találat!");
            }
        }
        
        Console.WriteLine("Mentés és kilépés...");
        
        fajlKezelo.Mentes(raktar.GetOsszesTermek(), ADABTAZIS_FILE);

        Console.ReadKey();
    }

    static void Listazas(List<Termek> lista)
    {
        foreach (var t in lista)
        {
            Console.WriteLine(t);
        }
    }
}
