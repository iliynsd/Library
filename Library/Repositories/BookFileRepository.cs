using System.Collections.Generic;
using System.IO;
using Library.Models;
using Library.Utils;

namespace Library.Repositories
{
    public class BookFileRepository : FileBaseRepository<BookFileRepository>, IBookRepository 
    {
        private List<Book> _books;
        protected override string RepositoryName { get; }
        
        public BookFileRepository()
        {
            _books = new List<Book>();
        }
        public void Delete(Book book) => _books.RemoveAll(i => i.Name.ToLower() == book.Name.ToLower());

        public List<Book> GetAll() => _books;
        
        public void Add(Book book) => _books.Add(book);

        public List<Book> Find(string name) => _books.FindAll(i => i.Name.ToLower() == name.ToLower());
        protected override void Write(BinaryWriter writer, BookFileRepository bookFileRepo)
        {
            foreach (var book in bookFileRepo.GetAll())
            {
                if (book.Name != null)
                {
                    writer.Write(book.Code);
                    writer.Write(book.Name);
                    writer.Write(book.Amount);
                    writer.Write(book.YearOfPublishing);
                    writer.Write(book.PublishingHouse);
                    writer.Write(book.Author);
                    writer.Write(book.Genre);
                }
            }
        }

        protected override BookFileRepository Read(BinaryReader reader)
        {
            var bookRepo = new BookFileRepository();
            while (reader.PeekChar() > -1)
            {
                var book = new Book
                {
                    Code = reader.ReadInt32(),
                    Name = reader.ReadString(),
                    Amount = reader.ReadInt32(),
                    YearOfPublishing = reader.ReadInt32(),
                    PublishingHouse = reader.ReadString(),
                    Author = reader.ReadString(),
                    Genre = reader.ReadString()
                };

                if (book.Name != null)
                {
                    bookRepo.Add(book);
                }
            }

            return bookRepo;
        }
    }
}