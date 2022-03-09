using System;
using Library.Application;
using Library.Models;

namespace Library.MenuUtils
{
    public static class MenuRemoveUtil
    {
        public static void ShowMenuRemove(Librarian lib)
        {
            Console.WriteLine("Enter name book or magazine to remove");
            var rez = lib.Delete(Console.ReadLine());
            if (rez > 0)
            {
                Console.WriteLine($"Successfully deleted {rez} books and magazines");
            }
            else
            {
                Console.WriteLine("Not found books and magazines with this name");
            } 
            Console.WriteLine("You are returned to the main menu");
            Console.WriteLine("Enter -help to see commands");
        }
    }
}