using System.Collections.Generic;

namespace Library.Repositories
{
    public interface IRepository<T>
    {
        public void Add(T item);
        
        public void Delete(T item);
        
        public List<T> GetAll();
        
        public List<T> Find(string name);
    }
}