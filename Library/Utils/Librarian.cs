using Library.Repositories;
using Library.UI;

namespace Library.Utils
{
    public class Librarian
    {
        public void Add(string choose, IBookRepository bookRepo, IMagazineRepository magazineRepo)
        {
            if (choose == "-book")
            {
                bookRepo.Add(UIConsoleCreate.CreateBook());
            }
            else if (choose == "-magazine")
            {
                magazineRepo.Add(UIConsoleCreate.CreateMagazine());
            }
        }

        public void Remove(string name, IBookRepository bookRepo, IMagazineRepository magazineRepo)
        {
            bookRepo.Find(name).ForEach(bookRepo.Delete);
            magazineRepo.Find(name).ForEach(magazineRepo.Delete);
        }

        public void Edit(string name, IBookRepository bookRepo, IMagazineRepository magazineRepo)
        {
            bookRepo.Find(name).ForEach(UIConsoleEdit.EditBook);
            magazineRepo.Find(name).ForEach(UIConsoleEdit.EditMagazine);
        }

        public void Search(string name, IBookRepository bookRepo, IMagazineRepository magazineRepo)
        {
            bookRepo.Find(name).ForEach(UIConsoleShow.ShowBook);
            magazineRepo.Find(name).ForEach(UIConsoleShow.ShowMagazine);
        }
    }
}