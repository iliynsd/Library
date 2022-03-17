using System.Collections.Generic;

namespace Library.Repositories
{
    public interface IRepository<T>
    {
        public void Create();
        public void Show(string name);
        public void Edit(string name);
        public void Delete(string name);
        public List<T> GetAll();
        public void Add(T obj);
    }
}