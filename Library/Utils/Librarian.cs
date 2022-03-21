using Library.Config;
using Library.Repositories;
using Library.UI;
using Microsoft.Extensions.Options;

namespace Library.Utils
{
    public class Librarian
    {
        private IBookRepository _bookRepository;
        private IMagazineRepository _magazineRepository;
        private IMenu _menu;
        private PathOptions _options;
        
        public Librarian(IBookRepository bookRepository, IMagazineRepository magazineRepository,IMenu menu, PathOptions options)
        {
            _bookRepository = bookRepository;
            _magazineRepository = magazineRepository;
            _menu = menu;
            _options = options;
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

        public void Execute()
        {
            _menu.Hello();
            string command = _menu.GetCommand();

            while (command != "-end")
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
                    _bookRepository.SaveToDb(_options.PathToBooks);
                    _magazineRepository.SaveToDb(_options.PathToMagazines);
                    _menu.MenuAfterSaveData();
                }
                else if (command == "-read")
                {
                    _bookRepository.GetFromDb(_options.PathToBooks);
                    _magazineRepository.GetFromDb(_options.PathToMagazines);
                    _menu.MenuAfterReadData();
                }
                else
                {
                    _menu.IncorrectInput();
                }

                command = _menu.GetCommand();
            }
        }
    }
}