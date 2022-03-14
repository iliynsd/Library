using System;
using Library.Repositories;

namespace Library.Utils
{
    public class MenuUtil
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
                bookRepo.Create();
            }
            else if (choose == "-magazine")
            {
                magazineRepo.Create();
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
                bookRepo.Delete(name);
            }
            else if (choose == "-magazine")
            {
                magazineRepo.Delete(name);
            }
            else
            {
                Console.WriteLine("Incorrect input, you are returned to the main menu");
                return;
            }
            
            Console.WriteLine("You are returned to the main menu");
            Console.WriteLine("Enter -help to see commands");
        }
        
        public static void ShowMenuSearch(BookRepository bookRepo, MagazineRepository magazineRepo)
        {
            Console.WriteLine("Enter name of book or magazine to search");
            var name = Console.ReadLine();
            bookRepo.Show(name);
            magazineRepo.Show(name);
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
                bookRepo.Edit(name);
            }
            else if (choose == "-magazine")
            {
                magazineRepo.Edit(name);
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