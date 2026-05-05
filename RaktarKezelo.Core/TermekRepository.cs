using Microsoft.EntityFrameworkCore;
using RaktarKezelo.Core.Entities;

namespace RaktarKezelo.Core.Repositories;

public class TermekRepository : IRepository<Termek>
{
    private readonly RaktarContext _context;

    public TermekRepository(RaktarContext context)
    {
        _context = context;
    }

    public IEnumerable<Termek> GetAll()
    {
        // Az Include-ot itt használjuk, hogy a kategória neve is mindig meglegyen
        return _context.Termekek.Include(t => t.Kategoria).ToList();
    }

    public Termek GetById(int id)
    {
        return _context.Termekek.Include(t => t.Kategoria)
            .FirstOrDefault(t => t.Id == id)!;
    }

    public void Add(Termek entity)
    {
        _context.Termekek.Add(entity);
    }

    public void Update(Termek entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var termek = _context.Termekek.Find(id);
        if (termek != null)
        {
            _context.Termekek.Remove(termek);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}