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
                        ConsoleMenu.ShowMenuAdd(books, magazines);
                    }
                    else if (cmd == "-help")
                    {
                        ConsoleMenu.ShowMainMenu();
                    }
                    
                    else if (cmd == "-remove")
                    {
                        ConsoleMenu.ShowMenuRemove(books, magazines);
                    }
   
                    else if (cmd == "-edit")
                    {
                        ConsoleMenu.ShowEditMenu(books, magazines);
                    }
   
                    else if (cmd == "-search")
                    {
                        ConsoleMenu.ShowMenuSearch(books, magazines);
                    }
                    
                    else if (cmd == "-save")
                    {
                        FileBaseRepository.SaveBooks(books);
                        FileBaseRepository.SaveMagazines(magazines);
                        Console.WriteLine("Successfully saved");
                        Console.WriteLine("You are returned to the main menu");
                    }
                    
                    else if (cmd == "-read")
                    {
                        books = FileBaseRepository.ReadBooks();
                        magazines = FileBaseRepository.ReadMagazines();
                        Console.WriteLine("Successfully read data from files");
                        Console.WriteLine("You are returned to the main menu");
                    }
                    
                    else
                    {
                        Console.WriteLine("No such command");
                        Console.WriteLine("Enter -help to see commands");
                    }
                    cmd = Console.ReadLine();
               }
        }
    }
}