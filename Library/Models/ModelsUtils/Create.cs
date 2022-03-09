using System;
using Library.Application;
using Library.Utils;
using Library.Visitor;

namespace Library.Models.ModelsUtils
{
    public class Create : IBookVisitor
    {
        public void Visit(Librarian lib, Book book)
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
                lib.Add(createdBook);
            }
            else
            {
                Console.WriteLine("Book wasn't added");
            }
        }

        public void Visit(Librarian lib, Magazine magazine)
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
                lib.Add(createdMagazine);
            }
            else
            {
                Console.WriteLine("Magazine wasn't added");
            }
        }
    }
}