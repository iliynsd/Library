using System;
using Library.Utils;

namespace Library.Models.ModelsUtils
{
    public static class BookUtil
    {
        public static Book CreateBook()
        {
            Console.WriteLine("Enter the code of book:");
            var code = ValidatorUtil.TryEnterNaturalNum();
            Console.WriteLine("Enter the name of book:");
            var name = ValidatorUtil.TryEnterStringNotNum();
            Console.WriteLine("Enter the amount of the book:");
            var amount = ValidatorUtil.TryEnterNaturalNum();
            Console.WriteLine("Enter the year of publishing the book:");
            var yearOfPublishing = ValidatorUtil.TryEnterNaturalNum();
            Console.WriteLine("Enter the publishing house of the book:");
            var publishingHouse = ValidatorUtil.TryEnterStringNotNum();
            Console.WriteLine("Enter the author of the book:");
            var author = ValidatorUtil.TryEnterStringNotNum();
            Console.WriteLine("Enter the genre of the book:");
            var genre = ValidatorUtil.TryEnterStringNotNum();
            return new Book(code, name, amount, yearOfPublishing, publishingHouse, author, genre);
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
        
        public static void EditBook(Book book)
        {
            Console.WriteLine("Enter field you want to edit or enter leave to stop making changes");
            var choose = ValidatorUtil.TryEnterStringNotNum();

            if (choose == "code")
            {
                Console.WriteLine("Enter the new code of book");
                book.Code = ValidatorUtil.TryEnterNaturalNum();
            }

            else if (choose == "name")
            {
                Console.WriteLine("Enter the new name of book:");
                book.Name = ValidatorUtil.TryEnterStringNotNum();
            }

            else if (choose == "amount")
            {
                Console.WriteLine("Enter the new amount of the book:");
                book.Amount = ValidatorUtil.TryEnterNaturalNum();
            }

            else if (choose == "yearOfPublishing")
            {
                Console.WriteLine("Enter the new year of publishing the book:");
                book.YearOfPublishing = ValidatorUtil.TryEnterNaturalNum();
            }

            else if (choose == "publishingHouse")
            {
                Console.WriteLine("Enter the new publishing house of the book:");
                book.PublishingHouse = ValidatorUtil.TryEnterStringNotNum();
            }

            else if (choose == "author")
            {
                Console.WriteLine("Enter the new author of the book:");
                book.Author = ValidatorUtil.TryEnterStringNotNum();
            }

            else if (choose == "genre")
            {
                Console.WriteLine("Enter the new genre of the book:");
                book.Genre = ValidatorUtil.TryEnterStringNotNum();
            }

            else if (choose == "leave")
            {
                
            }
            else
            {
                EditBook(book);
            }
        }
    }
}