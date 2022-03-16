using System;
using Library.Models;

namespace Library.UI
{
    public static class UIConsoleShow
    {
        public static void ShowMagazine(Magazine magazine)
        {
            Console.WriteLine("-----Magazine-----");
            Console.WriteLine($"Code - {magazine.Code}");
            Console.WriteLine($"Name - {magazine.Name}");
            Console.WriteLine($"Amount - {magazine.Amount}");
            Console.WriteLine($"Year of publishing - {magazine.YearOfPublishing}");
            Console.WriteLine($"Publishing house - {magazine.PublishingHouse}");
            Console.WriteLine($"Periodicity - {magazine.Periodicity}");
            Console.WriteLine($"Number - {magazine.Number}");
        }
        
        public static void ShowBook(Book book)
        {
            Console.WriteLine("-----Book-----");
            Console.WriteLine($"Code - {book.Code}");
            Console.WriteLine($"Name - {book.Name}");
            Console.WriteLine($"Amount - {book.Amount}");
            Console.WriteLine($"Year of publishing - {book.YearOfPublishing}");
            Console.WriteLine($"Publishing house - {book.PublishingHouse}");
            Console.WriteLine($"Author - {book.Author}");
            Console.WriteLine($"Genre - {book.Genre}");
        }
    }
}