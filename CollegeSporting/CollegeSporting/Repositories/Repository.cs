using CollegeSporting.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegeSporting.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationContext _context;
        private DbSet<T> _dbSet;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public T Get(long id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        public T Remove(T item)
        {
            _dbSet.Remove(item);
            return item;
        }
    }
}
