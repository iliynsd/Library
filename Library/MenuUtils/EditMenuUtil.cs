using System;
using Library.Application;
using Library.Models.ModelsUtils;

namespace Library.MenuUtils
{
    public static class EditMenuUtil
    {
        public static void ShowEditMenu(Librarian librarian)
        {
            Console.WriteLine("Enter name of book or magazine to edit:");
            var name = Console.ReadLine();
            var books = librarian.FindEntity(name);
            if (books.Count > 0)
            {
                books.ForEach(i => i.Accept(librarian, new Edit()));
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