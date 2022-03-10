using System;
using Library.Repositories;
using Library.Utils;


namespace Library.Application
{
    static class Program
    {
        static void Main()
        {
            var books = new BookRepository();
            var magazines = new MagazineRepository();

            Console.WriteLine("It's a librarian, enter -help to see commands");
            var cmd = Console.ReadLine();
               
               while (cmd != "-end")
               {
                    if (cmd == "-add")
                    {
                        MenuUtil.ShowMenuAdd(books, magazines);
                    }
                    else if (cmd == "-help")
                    {
                        MenuUtil.ShowMainMenu();
                    }
                    
                    else if (cmd == "-remove")
                    {
                        MenuUtil.ShowMenuRemove(books, magazines);
                    }
   
                    else if (cmd == "-edit")
                    {
                        MenuUtil.ShowEditMenu(books, magazines);
                    }
   
                    else if (cmd == "-search")
                    {
                        MenuUtil.ShowMenuSearch(books, magazines);
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