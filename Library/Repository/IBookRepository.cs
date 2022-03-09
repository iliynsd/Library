using System.Collections.Generic;
using Library.Models;
using Library.Visitor;

namespace Library.Repository
{
    public interface IBookRepository
    {
        public void Add(Book book);
        public void Add(Magazine magazine);

        public int Delete(string name);

        public List<IBook> FindEntity(string name);
    }
}