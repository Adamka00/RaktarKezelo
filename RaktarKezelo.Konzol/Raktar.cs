namespace RaktarKezelo.Konzol;

public class Raktar : IRaktar
{
    private List<Termek> termekek;

    public Raktar()
    {
        termekek = new List<Termek>();
    }

    public void Hozzaad(Termek ujTermek)
    {
        termekek.Add(ujTermek);
    }
    
    public List<Termek> GetOsszesTermek()
    {
        return termekek;
    }
}