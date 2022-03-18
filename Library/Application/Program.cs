using System;
using System.IO;
using Library.Config;
using Library.Repositories;
using Library.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
    static class Program
    {
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName).AddJsonFile("appSettings.json")
                .Build();

            
            IBookRepository bookRepo = new BookFileRepository();
            IMagazineRepository magazineRepo = new MagazineFileRepository();
            
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<Configuration>();
            serviceCollection.AddSingleton(bookRepo);
            serviceCollection.AddSingleton<BookRepositoryDI>();
            serviceCollection.AddSingleton(magazineRepo);
            serviceCollection.AddSingleton<MagazineRepositoryDI>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var testConfiguration = serviceProvider.GetService<Configuration>();
            
            var pathToBooks = testConfiguration.GetSection("pathToBooks");
            var pathToMagazines = testConfiguration.GetSection("pathToMagazines");
            
            
            var books = serviceProvider.GetService<BookRepositoryDI>();
            var magazines = serviceProvider.GetService<MagazineRepositoryDI>();
            
            Console.WriteLine("It's a librarian, enter -help to see commands");
            var cmd = Console.ReadLine();
               
               while (cmd != "-end")
               {
                    if (cmd == "-add")
                    {
                        ConsoleMenu.ShowMenuAdd(books, magazines);
                    }
                    else if (cmd == "-help")
                    {
                        ConsoleMenu.ShowMainMenu();
                    }
                    
                    else if (cmd == "-remove")
                    {
                        ConsoleMenu.ShowMenuRemove(books, magazines);
                    }
   
                    else if (cmd == "-edit")
                    {
                        ConsoleMenu.ShowEditMenu(books, magazines);
                    }
   
                    else if (cmd == "-search")
                    {
                        ConsoleMenu.ShowMenuSearch(books, magazines);
                    }
                    
                    else if (cmd == "-save")
                    {
                        books.SaveToDb(pathToBooks);
                        magazines.SaveToDb(pathToMagazines);
                        Console.WriteLine("Successfully saved");
                        Console.WriteLine("You are returned to the main menu");
                    }
                    
                    else if (cmd == "-read")
                    {
                        books.GetFromDb(pathToBooks);
                        magazines.GetFromDb(pathToMagazines);
                        Console.WriteLine("Successfully read data from files");
                        Console.WriteLine("You are returned to the main menu");
                    }
                    
                    else
                    {
                        Console.WriteLine("No such command");
                        Console.WriteLine("Enter -help to see commands");
                    }
                    cmd = Console.ReadLine();
               }
        }
    }
}