using System;
using System.IO;
using Library.Models;
using Library.Repositories;

namespace Library.Utils
{
    public static class FileUtil
    {
        private static string PathToBooks => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Resources\\books.dat"));
        private static string PathToMagazines => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Resources\\magazines.dat"));
        
        public static void SaveBooks(BookRepository bookRepo)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(PathToBooks, FileMode.Create)))
            {
                var books = bookRepo.GetAll();
                foreach (var book in books)
                {
                    if (book.Name != null)
                    {
                        writer.Write(book.Code);
                        writer.Write(book.Name);
                        writer.Write(book.Amount);
                        writer.Write(book.YearOfPublishing);
                        writer.Write(book.PublishingHouse);
                        writer.Write(book.Author);
                        writer.Write(book.Genre);
                    }
                }
            }
        }

        public static void SaveMagazines(MagazineRepository magazineRepo)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(PathToMagazines, FileMode.Create)))
            {
                var magazines = magazineRepo.GetAll();
                foreach (var magazine in magazines)
                {
                    if (magazine.Name != null)
                    {
                        writer.Write(magazine.Code);
                        writer.Write(magazine.Name);
                        writer.Write(magazine.Amount);
                        writer.Write(magazine.YearOfPublishing);
                        writer.Write(magazine.PublishingHouse);
                        writer.Write(magazine.Periodicity);
                        writer.Write(magazine.Number);
                    }
                }
            }
        }

        public static BookRepository ReadBooks()
        {
            var bookRepo = new BookRepository();
            using (BinaryReader reader = new BinaryReader(File.OpenRead(PathToBooks)))
            {
                while (reader.PeekChar() > -1)
                {
                    var book = new Book
                    {
                        Code = reader.ReadInt32(),
                        Name = reader.ReadString(),
                        Amount = reader.ReadInt32(),
                        YearOfPublishing = reader.ReadInt32(),
                        PublishingHouse = reader.ReadString(),
                        Author = reader.ReadString(),
                        Genre = reader.ReadString()
                    };

                    if (book.Name != null)
                    {
                        bookRepo.Add(book);
                    }
                }
            }

            return bookRepo;
        }

        public static MagazineRepository ReadMagazines()
        {
            var magazineRepo = new MagazineRepository();
            using (BinaryReader reader = new BinaryReader(File.OpenRead(PathToMagazines)))
            {
                
                while (reader.PeekChar() > -1)
                {
                    var magazine = new Magazine
                    {
                        Code = reader.ReadInt32(),
                        Name = reader.ReadString(),
                        Amount = reader.ReadInt32(),
                        YearOfPublishing = reader.ReadInt32(),
                        PublishingHouse = reader.ReadString(),
                        Periodicity = reader.ReadString(),
                        Number = reader.ReadInt32()
                    };

                    if (magazine.Name != null)
                    {
                        magazineRepo.Add(magazine);
                    }
                }
            }
            
            return magazineRepo;
        }
    }
}