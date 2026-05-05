using RaktarKezelo.Core.Entities;

namespace RaktarKezelo.Core;

public class KategoriaRepository : IRepository<Kategoria>
{
    private readonly RaktarContext _context;
    
    public KategoriaRepository(RaktarContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Kategoria> GetAll() => _context.Kategoriak.ToList();
    
    public Kategoria GetById(int id) => _context.Kategoriak.Find(id)!;
    
    public void Add(Kategoria entity) => _context.Kategoriak.Add(entity);

    public void Update(Kategoria entity) => _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

    public void Delete(int id)
    {
        var kategoria = _context.Kategoriak.Find(id);
        if (kategoria != null)
        {
            _context.Kategoriak.Remove(kategoria);
        }
    }
    
    public void Save() => _context.SaveChanges();
}