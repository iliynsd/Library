using Library.Application;
using Library.Models;

namespace Library.Visitor
{
    public interface IBookVisitor
    {
        public void Visit(Librarian lib, Book book);
        public void Visit(Librarian lib, Magazine magazine);
    }
}