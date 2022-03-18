using System.Collections.Generic;
using Library.Models;

namespace Library.Repositories
{
    public interface IBookRepository
    {
        public void Add(Book item);
        
        public void Delete(Book item);
        
        public List<Book> GetAll();
        
        public List<Book> Find(string name);
    }
}