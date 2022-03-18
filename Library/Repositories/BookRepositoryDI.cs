using System.Collections.Generic;
using Library.Models;

namespace Library.Repositories
{
    public class BookRepositoryDI
    {
        private IBookRepository _bookRepository;

        public BookRepositoryDI(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Add(Book item) => _bookRepository.Add(item);

        public void Delete(Book item) => _bookRepository.Delete(item);

        public List<Book> GetAll() => _bookRepository.GetAll();

        public List<Book> Find(string name) => _bookRepository.Find(name);
    }
}