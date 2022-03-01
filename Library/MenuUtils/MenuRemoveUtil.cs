using System;
using Library.Models;

namespace Library.MenuUtils
{
    public static class MenuRemoveUtil
    {
        public static void ShowMenuRemove(Lib library)
        {
            Console.WriteLine("Enter name of book or magazine to remove:");
            var name = Console.ReadLine();
            var rez = 0;
            rez += library.Books.RemoveAll(i => i.Name == name);
            rez += library.Magazines.RemoveAll(i => i.Name == name);
            if (rez > 0)
            {
                Console.WriteLine($"Successfully removed book or magazine with name - {name}");
            }
            else
            { 
                Console.WriteLine($"There is not any book or magazine with name - {name}");
            }
        }
    }
}