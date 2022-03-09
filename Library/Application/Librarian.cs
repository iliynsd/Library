using System.Collections.Generic;
using Library.Models;
using Library.Repository;
using Library.Visitor;

namespace Library.Application
{
    public class Librarian : IBookRepository
    {
        private List<Book> _books;
        private List<Magazine> _magazines;
        
        public Librarian()
        {
            _books = new List<Book>();
            _magazines = new List<Magazine>();
        }
        
        public void Add(Book book) => _books.Add(book);
        public void Add(Magazine magazine) => _magazines.Add(magazine);

        public int Delete(string name)
        {
            var rez = 0;
            rez += _books.RemoveAll(i => i.Name.ToLower() == name.ToLower());
            rez += _magazines.RemoveAll(i => i.Name.ToLower() == name.ToLower());
            return rez;
        }
        
        public List<IBook> FindEntity(string name)
        {
            var rez = new List<IBook>();
            _books.FindAll(i => i.Name.ToLower() == name.ToLower()).ForEach(i => rez.Add(i));
            _magazines.FindAll(i => i.Name.ToLower() == name.ToLower()).ForEach(i => rez.Add(i));
            return rez;
        }
    }
}