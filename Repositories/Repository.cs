using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Nowadays.Data.AplicationDbContext;

namespace Nowadays.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private DbSet<T> entities;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        entities = context.Set<T>();
    }

    public IEnumerable<T> GetAll() => entities.ToList();

    public T GetById(int id) => entities.Find(id);

    public void Insert(T obj)
    {
        entities.Add(obj);
    }

    public void Update(T obj)
    {
        entities.Update(obj);
    }

    public void Delete(int id)
    {
        T existing = entities.Find(id);
        if (existing != null)
            entities.Remove(existing);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
} 
}