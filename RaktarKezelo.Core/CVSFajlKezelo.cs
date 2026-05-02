/*using System.Text;

namespace RaktarKezelo.Core;

public class CVSFajlKezelo : IFajlKezelo
{
    public void Mentes(List<Termek> termekek, string fajlNev)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(fajlNev, false, Encoding.UTF8))
            {
                foreach (Termek t in termekek)
                {
                    sw.WriteLine($"{t.Id};{t.Nev};{t.Ar};{t.Mennyiseg}");
                }
            }

            Console.WriteLine("Sikeres mentés!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Hiba történt a fájl mentésekor: {e.Message}");
            throw;
        }
    }

    public List<Termek> Betoltes(string fajlNev)
    {
        List<Termek> betoltottLista = new List<Termek>();

        if (!File.Exists(fajlNev))
        {
            Console.WriteLine("Még nincs mentett fájl!");
            return betoltottLista;
        }

        try
        {
            using (StreamReader sr = new StreamReader(fajlNev, Encoding.UTF8))
            {
                string sor;
                while ((sor = sr.ReadLine()) != null)
                {
                    string[] adatok = sor.Split(';');

                    int id = int.Parse(adatok[0]);
                    string nev = adatok[1];
                    int ar = int.Parse(adatok[2]);
                    int mennyiseg = int.Parse(adatok[3]);
                    
                    betoltottLista.Add(new Termek(id, nev, ar, mennyiseg));
                }
            }

            Console.WriteLine("Sikeres betöltés!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Hiba történt a fájl betöltésekor: {e.Message}");
            throw;
        }

        return betoltottLista;
    }
}*/