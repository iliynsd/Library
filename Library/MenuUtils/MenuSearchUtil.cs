using System;
using Library.Application;
using Library.Models.ModelsUtils;

namespace Library.MenuUtils
{
    public static class MenuSearchUtil
    {
        public static void ShowMenuSearch(Librarian librarian)
        {
            Console.WriteLine("Enter name of book or magazine to search");
            var books = librarian.FindEntity(Console.ReadLine());
            if (books.Count > 0)
            {
                books.ForEach(i => i.Accept(librarian, new Show()));
            }
            else
            {
                Console.WriteLine("There aren't any books and magazines with this name");
            }
            Console.WriteLine("You are returned to the main menu");
            Console.WriteLine("Enter -help to see commands");
        }
    }
}