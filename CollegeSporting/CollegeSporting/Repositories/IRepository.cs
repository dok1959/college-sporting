using System;
using System.Collections.Generic;

namespace CollegeSporting.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Save();
        void Create(T item);
        IEnumerable<T> GetAll();
        T Get(long id);
        void Update(T item);
        T Remove(T item);
    }
}
