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
        
        public static void ShowMenuAdd(IBookRepository bookFileRepo, IMagazineRepository magazineFileRepo)
        {
            Console.WriteLine("Enter -book or -magazine to choose");
            var choose = Console.ReadLine();
            
            if (choose == "-book")
            {
                bookFileRepo.Add(UIConsoleCreate.CreateBook());
            }
            else if (choose == "-magazine")
            {
                magazineFileRepo.Add(UIConsoleCreate.CreateMagazine());
            }
            else
            {
                Console.WriteLine("Incorrect input, you are returned to the main menu");
                return;
            }
            
            Console.WriteLine("You are returned to the main menu ");
            Console.WriteLine("Enter -help to see commands");
        }
        
        public static void ShowMenuRemove(IBookRepository bookFileRepo, IMagazineRepository magazineFileRepo)
        {
            Console.WriteLine("Enter name book or magazine to remove");
            var name = Console.ReadLine();
            Console.WriteLine("Enter -book or -magazine to remove");
            var choose = Console.ReadLine();
            
            if (choose == "-book")
            { 
                bookFileRepo.Find(name).ForEach(bookFileRepo.Delete);
            }
            else if (choose == "-magazine")
            {
                magazineFileRepo.Find(name).ForEach(magazineFileRepo.Delete);
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
        
        public static void ShowMenuSearch(IBookRepository bookFileRepo, IMagazineRepository magazineFileRepo)
        {
            Console.WriteLine("Enter name of book or magazine to search");
            var name = Console.ReadLine();
            bookFileRepo.Find(name).ForEach(UIConsoleShow.ShowBook);
            magazineFileRepo.Find(name).ForEach(UIConsoleShow.ShowMagazine);
            Console.WriteLine("You are returned to the main menu");
            Console.WriteLine("Enter -help to see commands");
        }
        
        public static void ShowEditMenu(IBookRepository bookFileRepo, IMagazineRepository magazineFileRepo)
        {
            Console.WriteLine("Enter name book or magazine to edit");
            var name = Console.ReadLine();
            Console.WriteLine("Enter -book or -magazine to edit");
            var choose = Console.ReadLine();
            
            if (choose == "-book")
            {
                bookFileRepo.Find(name).ForEach(UIConsoleEdit.EditBook);
            }
            else if (choose == "-magazine")
            {
                magazineFileRepo.Find(name).ForEach(UIConsoleEdit.EditMagazine);
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