using RaktarKezelo.Core.Entities;
using System.Linq;

namespace RaktarKezelo.Core;

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
    
    public List<Termek> KeresesNevAlapjan(string kulcsszo)
    {
        return termekek
            .Where(t => t.Nev.ToLower().Contains(kulcsszo.ToLower()))
            .ToList();
    }
    
    public List<Termek> RendezesArAlapjan(bool novekvo)
    {
        if (novekvo)
        {
            return termekek.OrderBy(t => t.Ar).ToList();
        }
        else
        {
            return termekek.OrderByDescending(t => t.Ar).ToList();
        }
    }
}