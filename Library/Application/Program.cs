using System;
using System.IO;
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
                    
                    else if (cmd == "-save")
                    {
                        FileUtil.SaveBooks(books);
                        FileUtil.SaveMagazines(magazines);
                        Console.WriteLine("Successfully saved");
                        Console.WriteLine("You are returned to the main menu");
                    }
                    
                    else if (cmd == "-read")
                    {
                        books = FileUtil.ReadBooks();
                        magazines = FileUtil.ReadMagazines();
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