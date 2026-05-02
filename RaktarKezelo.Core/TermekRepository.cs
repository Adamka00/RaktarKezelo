namespace RaktarKezelo.Core.Entities;

public class TermekRepository
{
    private readonly RaktarContext _context;

    public TermekRepository()
    {
        _context = new RaktarContext();
    }
    
    public List<Termek> OsszesTermek()
    {
        return _context.Termekek.ToList();
    }
    
    public void Hozzaad(Termek termek)
    {
        _context.Termekek.Add(termek);
        _context.SaveChanges();
    }
}