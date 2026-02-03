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

        foreach (Termek t in raktar.GetOsszesTermek())
        {
            Console.WriteLine(t);
        }

        Console.WriteLine("Mentés és kilépés...");
        
        fajlKezelo.Mentes(raktar.GetOsszesTermek(), ADABTAZIS_FILE);
    }
}
