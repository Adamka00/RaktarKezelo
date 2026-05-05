using RaktarKezelo.Core.Entities;
using RaktarKezelo.Core.Repositories;

namespace RaktarKezelo.Core;

public class RaktarService
{
    private readonly TermekRepository _termekRepo;
    private readonly KategoriaRepository _kategoriaRepo;
    private readonly RaktarContext _context;

    public RaktarService()
    {
        _context = new RaktarContext();
        _termekRepo = new TermekRepository(_context);
        _kategoriaRepo = new KategoriaRepository(_context);
    }
    
    public void KeszletModositas(int termekId, int mennyiseg, string tipus)
    {
        var termek = _termekRepo.GetById(termekId);
        if (termek == null)
        {
            return;
        }

        termek.Keszlet += mennyiseg;
        
        var tranzakcio = new Tranzakcio
        {
            TermekId = termekId,
            Mennyiseg = mennyiseg,
            Tipus = tipus,
            Datum = DateTime.Now
        };
        
        _context.Tranzakciok.Add(tranzakcio);
        _context.SaveChanges();
    }

    public List<Termek> GetKritikusKeszlet()
    {
        return _termekRepo.GetAll()
            .Where(t => t.Keszlet <= t.MinKeszlet)
            .ToList();
    }

    public decimal GetTeljesRaktarErtek()
    {
        return _termekRepo.GetAll()
            .Sum(t => t.Keszlet * t.Ar);
    }

    public Dictionary<string, int> GetKategoriaStatisztika()
    {
        return _termekRepo.GetAll()
            .GroupBy(t => t.Kategoria.Nev)
            .ToDictionary(g => g.Key, g => g.Count());
    }
    
    public List<Tranzakcio> GetTermekEletut(int termekId)
    {
        return _context.Tranzakciok
            .Where(t => t.TermekId == termekId)
            .OrderByDescending(t => t.Datum)
            .ToList();
    }

    public List<Termek> Kereses(string kulcsszo)
    {
        return _termekRepo.GetAll()
            .Where(t => t.Nev.Contains(kulcsszo, StringComparison.OrdinalIgnoreCase) ||
                        t.Cikkszam.Contains(kulcsszo, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public string GetFormattedCurrentTime()
    {
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}