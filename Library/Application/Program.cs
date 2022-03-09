using System;
using Library.MenuUtils;
using Library.Models;
using Library.Models.ModelsUtils;

namespace Library.Application
{
    static class Program
    {

        
        static void Main()
        {
            var librarian = new Librarian();

            librarian.Add(new Book()
                {Amount = 1, Author = "we", Code = 1, Genre= "q", Name = "errty", PublishingHouse= "we", YearOfPublishing = 2});

            librarian.FindEntity("errty").ForEach(i => i.Accept(librarian, new Show()));
            var book = new Magazine();
            book.Accept(librarian, new Create());
            
            librarian.FindEntity("errty").ForEach(i => i.Accept(librarian, new Show()));
            
             Console.WriteLine("It's a librarian, enter -help to see commands");
               var cmd = Console.ReadLine();
               
               while (cmd != "-end")
               {
                    if (cmd == "-add")
                    {
                        MenuAddUtil.ShowMenuAdd(librarian);
                    }
                    else if (cmd == "-help")
                    {
                        MainMenuUtil.ShowMainMenu();
                    }
                    
                    else if (cmd == "-remove")
                    {
                        MenuRemoveUtil.ShowMenuRemove(librarian);
                    }
   
                    else if (cmd == "-edit")
                    {
                        EditMenuUtil.ShowEditMenu(librarian);
                    }
   
                    else if (cmd == "-search")
                    {
                        MenuSearchUtil.ShowMenuSearch(librarian);
                    }
                    else
                    {
                        Console.WriteLine("Enter -help to see commands");
                    }
                    cmd = Console.ReadLine();
               }
        }
    }
}