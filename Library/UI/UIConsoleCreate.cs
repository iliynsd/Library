using System;
using Library.Models;
using Library.Utils;

namespace Library.UI
{
    public static class UIConsoleCreate
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
            var createdBook = new Book(code, name, amount, yearOfPublishing, publishingHouse, author, genre);
            if (ValidatorUtil.ValidateBook(createdBook))
            {
                Console.WriteLine("Book was successfully add");
                return createdBook;
            }
            else
            {
                Console.WriteLine("Book wasn't added");
                return null;
            }
        }
        
        public static Magazine CreateMagazine()
        {
            Console.WriteLine("Enter the code of magazine:");
            var code = ValidatorUtil.TryEnterNaturalNum();
            Console.WriteLine("Enter the name of magazine:");
            var name = ValidatorUtil.TryEnterStringNotNum();
            Console.WriteLine("Enter the amount of the magazine:");
            var amount = ValidatorUtil.TryEnterNaturalNum();
            Console.WriteLine("Enter the year of publishing the magazine:");
            var yearOfPublishing = ValidatorUtil.TryEnterNaturalNum();
            Console.WriteLine("Enter the publishing house of the magazine:");
            var publishingHouse = ValidatorUtil.TryEnterStringNotNum();
            Console.WriteLine("Enter the periodicity of the magazine:");
            var periodicity = ValidatorUtil.TryEnterStringNotNum();
            Console.WriteLine("Enter the number of the magazine:");
            var number = ValidatorUtil.TryEnterNaturalNum();
            var createdMagazine = new Magazine(code, name, amount, yearOfPublishing, publishingHouse, periodicity, number);
            if (ValidatorUtil.ValidateMagazine(createdMagazine))
            {
                Console.WriteLine("Magazine was successfully added");
                return createdMagazine;
            }
            else
            {
                Console.WriteLine("Magazine wasn't added");
                return null;
            }
        }
    }
}