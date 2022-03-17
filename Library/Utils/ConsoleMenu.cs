using System;
using Library.Repositories;
using Library.UI;

namespace Library.Utils
{
    public class ConsoleMenu
    {
        public static void ShowMainMenu()
        {
            Console.WriteLine("----------  1.Enter -add to add book or magazine  ------------");
            Console.WriteLine("----------  2.Enter -remove to delete book or magazine  --------");
            Console.WriteLine("----------  3.Enter -edit to change data in book or magazine  --------");
            Console.WriteLine("----------  4.Enter -search to search book or magazine  --------");
            Console.WriteLine("----------  5.Enter -save to save data in files --------");
            Console.WriteLine("----------  6.Enter -read to read data from files --------");
            Console.WriteLine("----------  7.Enter -end to end program  --------");
        }
        
        public static void ShowMenuAdd(BookRepository bookRepo, MagazineRepository magazineRepo)
        {
            Console.WriteLine("Enter -book or -magazine to choose");
            var choose = Console.ReadLine();
            
            if (choose == "-book")
            {
                bookRepo.Add(UIConsoleCreate.CreateBook());
            }
            else if (choose == "-magazine")
            {
                magazineRepo.Add(UIConsoleCreate.CreateMagazine());
            }
            else
            {
                Console.WriteLine("Incorrect input, you are returned to the main menu");
                return;
            }
            
            Console.WriteLine("You are returned to the main menu ");
            Console.WriteLine("Enter -help to see commands");
        }
        
        public static void ShowMenuRemove(BookRepository bookRepo, MagazineRepository magazineRepo)
        {
            Console.WriteLine("Enter name book or magazine to remove");
            var name = Console.ReadLine();
            Console.WriteLine("Enter -book or -magazine to remove");
            var choose = Console.ReadLine();
            
            if (choose == "-book")
            { 
                bookRepo.Find(name).ForEach(bookRepo.Delete);
            }
            else if (choose == "-magazine")
            {
                magazineRepo.Find(name).ForEach(magazineRepo.Delete);
            }
            else
            {
                Console.WriteLine("Incorrect input, you are returned to the main menu");
                return;
            }
            
            Console.WriteLine("Successfully deleted if exists");
            Console.WriteLine("You are returned to the main menu");
            Console.WriteLine("Enter -help to see commands");
        }
        
        public static void ShowMenuSearch(BookRepository bookRepo, MagazineRepository magazineRepo)
        {
            Console.WriteLine("Enter name of book or magazine to search");
            var name = Console.ReadLine();
            bookRepo.Find(name).ForEach(UIConsoleShow.ShowBook);
            magazineRepo.Find(name).ForEach(UIConsoleShow.ShowMagazine);
            Console.WriteLine("You are returned to the main menu");
            Console.WriteLine("Enter -help to see commands");
        }
        
        public static void ShowEditMenu(BookRepository bookRepo, MagazineRepository magazineRepo)
        {
            Console.WriteLine("Enter name book or magazine to edit");
            var name = Console.ReadLine();
            Console.WriteLine("Enter -book or -magazine to edit");
            var choose = Console.ReadLine();
            
            if (choose == "-book")
            {
                bookRepo.Find(name).ForEach(UIConsoleEdit.EditBook);
            }
            else if (choose == "-magazine")
            {
                magazineRepo.Find(name).ForEach(UIConsoleEdit.EditMagazine);
            }
            else
            {
                Console.WriteLine("Incorrect input, you are returned to the main menu");
                return;
            }
            
            Console.WriteLine("You are returned to the main menu");
            Console.WriteLine("Enter -help to see commands");
        }
    }
}