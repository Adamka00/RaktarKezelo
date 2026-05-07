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
            .Where(t => t.Nev.Contains(kulcsszo, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public string GetFormattedCurrentTime()
    {
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public void BiztonsagosKeszletModositas(int termekId, int mennyiseg, string tipus)
    {
        using var dbTranzakcio = _context.Database.BeginTransaction();
        try
        {
            var termek = _termekRepo.GetById(termekId);
            if (termek == null) throw new Exception("A termék nem található!");

            // Készlet ellenőrzése kivétnél
            if (mennyiseg < 0 && termek.Keszlet + mennyiseg < 0)
                throw new Exception("Nincs elég készlet a raktárban!");

            termek.Keszlet += mennyiseg;
        
            var naplo = new Tranzakcio
            {
                TermekId = termekId,
                Mennyiseg = mennyiseg,
                Datum = DateTime.Now,
                Tipus = tipus
            };

            _context.Tranzakciok.Add(naplo);
            _context.SaveChanges();
            
            dbTranzakcio.Commit();
        }
        catch (Exception e)
        {
            dbTranzakcio.Rollback();
            throw;
        }
    }

    public bool UjTermekMentesek(Termek ujTermek)
    {
        var letezik = _termekRepo.GetAll().Any(t =>t.Cikkszam == ujTermek.Cikkszam);
        if (letezik) throw new Exception("Már létezik termék ezzel a cikkszámmal!");

        if (ujTermek.Ar <= 0) throw new Exception("Az árnak pozitívnak kell lennie!");
        
        _termekRepo.Add(ujTermek);
        _termekRepo.Save();
        return true;
    }
    
    public List<Termek> ReszletesKereses(string? nev, int? kategoriaId, decimal? minAr, decimal? maxAr)
    {
        var query = _termekRepo.GetAll().AsQueryable();

        if (!string.IsNullOrWhiteSpace(nev))
            query = query.Where(t => t.Nev.Contains(nev, StringComparison.OrdinalIgnoreCase));

        if (kategoriaId.HasValue)
            query = query.Where(t => t.KategoriaId == kategoriaId.Value);

        if (minAr.HasValue)
            query = query.Where(t => t.Ar >= minAr.Value);

        if (maxAr.HasValue)
            query = query.Where(t => t.Ar <= maxAr.Value);

        return query.ToList();
    }

    public void TermekTorles(int id)
    {
        _termekRepo.Delete(id);
        _termekRepo.Save();
    }
}   