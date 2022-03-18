using System.Collections.Generic;
using Library.Models;

namespace Library.Repositories
{
    public interface IMagazineRepository
    {
        public void Add(Magazine item);
        
        public void Delete(Magazine item);
        
        public List<Magazine> GetAll();
        
        public List<Magazine> Find(string name);
        
        public void SaveToDb(string source);

        public void GetFromDb(string source);
    }
}