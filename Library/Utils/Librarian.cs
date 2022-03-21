using Library.Repositories;
using Library.UI;

namespace Library.Utils
{
    public class Librarian
    {
        private IBookRepository _bookRepository;
        private IMagazineRepository _magazineRepository;
        private IMenu _menu;
        private string _pathToMagazines;
        private string _pathToBooks;

        public Librarian(IBookRepository bookRepository, IMagazineRepository magazineRepository,IMenu menu, string pathToBooks, string pathToMagazines)
        {
            _bookRepository = bookRepository;
            _magazineRepository = magazineRepository;
            _menu = menu;
            _pathToBooks = pathToBooks;
            _pathToMagazines = pathToMagazines;
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

        public void Execute(string command)
        {
            if (command == "-add")
            {
                Add(_menu.ShowMenuAdd());
                _menu.BackToTheMainMenu();
            }
            else if (command == "-help")
            {
                _menu.ShowMainMenu();
            }
                    
            else if (command == "-remove")
            {
                Remove(_menu.ShowMenuRemove());
                _menu.MenuAfterRemove();
            }
   
            else if (command == "-edit")
            {
                Edit(_menu.ShowEditMenu());
                _menu.BackToTheMainMenu();
            }
   
            else if (command == "-search")
            {
                Search(_menu.ShowMenuSearch());
                _menu.BackToTheMainMenu();
            }
                    
            else if (command == "-save")
            {
                _bookRepository.SaveToDb(_pathToBooks);
                _magazineRepository.SaveToDb(_pathToMagazines);
                _menu.MenuAfterSaveData();
            }
                    
            else if (command == "-read")
            {
                _bookRepository.GetFromDb(_pathToBooks);
                _magazineRepository.GetFromDb(_pathToMagazines);
                _menu.MenuAfterReadData();
            }
            
            else
            {
                _menu.IncorrectInput();
            }
        }
    }
}