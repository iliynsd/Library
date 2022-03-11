using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using Library.Utils;

namespace Library.Repositories
{
    public class BookRepository : IRepository
    {
        private List<Book> _books = new List<Book>();
        public void Create()
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
                _books.Add(createdBook);
                Console.WriteLine("Book was successfully add");
            }
            else
            {
                Console.WriteLine("Book wasn't added");
            }
        }

        public void Show(string name)
        {
            var books = _books.FindAll(i => i.Name == name);
            
            if (books.Count > 0)
            {
                books.ForEach(ShowBook);
            }
            else
            {
                Console.WriteLine($"No books with this name - {name}");
            }

            void ShowBook(Book book)
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
        
        public void Edit(string name)
        {
            var book = _books.Find(i => i.Name == name);
            if (book == null)
            {
                Console.WriteLine($"No books with this name - {name}");
                return;
            }
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
                Edit(name);
            }
            else
            {
                Console.WriteLine("Edit book successfully");
            }
        }

        public void Delete(string name)
        {
            var rez = _books.RemoveAll(i => i.Name.ToLower() == name.ToLower());
            if (rez <= 0)
            { 
                Console.WriteLine($"No books with this name - {name}");
            }
            else
            {
                Console.WriteLine($"Removed {rez} books");
            }
        }
    }
}