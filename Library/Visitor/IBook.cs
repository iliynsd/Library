using Library.Application;

namespace Library.Visitor
{
    public interface IBook
    {
        public void Accept(Librarian lib, IBookVisitor visitor);
    }
}