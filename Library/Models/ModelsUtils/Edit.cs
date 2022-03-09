using System;
using Library.Application;
using Library.Utils;
using Library.Visitor;

namespace Library.Models.ModelsUtils
{
    public class Edit : IBookVisitor
    {
        public void Visit(Librarian lib, Book book)
        {
            string choose;
            do
            {
                Console.WriteLine("Book has this fields: code;name;amount;yearOfPublishing;publishingHouse;author;genre");
                Console.WriteLine("Enter field you want to edit or enter -leave to stop making changes");
                choose = ValidatorUtil.TryEnterStringNotNum();

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
            } while (choose != "-leave");

            if (!ValidatorUtil.ValidateBook(book))
            {
                Console.WriteLine("Edit one more time");
                Visit(lib, book);
            }
            else
            {
                Console.WriteLine("Edit book successfully");
            }
        }

        public void Visit(Librarian lib, Magazine magazine)
        {
            string choose;
            do
            {
                Console.WriteLine("Magazine has this fields: code;name;amount;yearOfPublishing;publishingHouse;periodicity;number");
                Console.WriteLine("Enter name of field you want to edit or enter -leave to stop making changes");
                choose = ValidatorUtil.TryEnterStringNotNum();

                if (choose == "code")
                {
                    Console.WriteLine("Enter the new code of magazine");
                    magazine.Code = ValidatorUtil.TryEnterNaturalNum();
                }

                else if (choose == "name")
                {
                    Console.WriteLine("Enter the new name of magazine:");
                    magazine.Name = ValidatorUtil.TryEnterStringNotNum();
                }

                else if (choose == "amount")
                {
                    Console.WriteLine("Enter the new amount of the magazine:");
                    magazine.Amount = ValidatorUtil.TryEnterNaturalNum();
                }

                else if (choose == "yearOfPublishing")
                {
                    Console.WriteLine("Enter the new year of publishing the magazine:");
                    magazine.YearOfPublishing = ValidatorUtil.TryEnterNaturalNum();
                }

                else if (choose == "publishingHouse")
                {
                    Console.WriteLine("Enter the new publishing house of the magazine:");
                    magazine.PublishingHouse = ValidatorUtil.TryEnterStringNotNum();
                }

                else if (choose == "periodicity")
                {
                    Console.WriteLine("Enter the periodicity of the magazine:");
                    magazine.Periodicity = ValidatorUtil.TryEnterStringNotNum();
                }

                else if (choose == "number")
                {
                    Console.WriteLine("Enter the number of the magazine:");
                    magazine.Number = ValidatorUtil.TryEnterNaturalNum();
                }
            } while (choose != "-leave");

            if (!ValidatorUtil.ValidateMagazine(magazine))
            {
                Console.WriteLine("Edit one more time");
                Visit(lib, magazine);
            }
            else
            {
                Console.WriteLine("Edit magazine successfully");
            }
        }
    }
}