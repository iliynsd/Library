using Library.Repositories;
using Library.UI;

namespace Library.Utils
{
    public class Librarian
    {
        private IBookRepository _bookRepository;
        private IMagazineRepository _magazineRepository;

        public Librarian(IBookRepository bookRepository, IMagazineRepository magazineRepository)
        {
            _bookRepository = bookRepository;
            _magazineRepository = magazineRepository;
        }
        public void Add(string choose)
        {
            if (choose == "-book")
            {
                _bookRepository.Add(UIConsoleCreate.CreateBook());
            }
            else if (choose == "-magazine")
            {
                _magazineRepository.Add(UIConsoleCreate.CreateMagazine());
            }
        }

        public void Remove(string name)
        {
            _bookRepository.Find(name).ForEach(_bookRepository.Delete);
            _magazineRepository.Find(name).ForEach(_magazineRepository.Delete);
        }

        public void Edit(string name)
        {
            _bookRepository.Find(name).ForEach(UIConsoleEdit.EditBook);
            _magazineRepository.Find(name).ForEach(UIConsoleEdit.EditMagazine);
        }

        public void Search(string name)
        {
            _bookRepository.Find(name).ForEach(UIConsoleShow.ShowBook);
            _magazineRepository.Find(name).ForEach(UIConsoleShow.ShowMagazine);
        }
    }
}