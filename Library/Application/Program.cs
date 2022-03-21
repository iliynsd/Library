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

            
            IBookRepository books = new BookFileRepository();
            IMagazineRepository magazines = new MagazineFileRepository();
            
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<Configuration>();
            serviceCollection.AddSingleton(books);
            serviceCollection.AddSingleton(magazines);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var testConfiguration = serviceProvider.GetService<Configuration>();
            
            var pathToBooks = testConfiguration.GetSection("pathToBooks");
            var pathToMagazines = testConfiguration.GetSection("pathToMagazines");

            var menu = new ConsoleMenu();
            var librarian = new Librarian(books, magazines,menu, pathToBooks, pathToMagazines);
            
            Console.WriteLine("It's a librarian, enter -help to see commands");
            var cmd = Console.ReadLine();
               
               while (cmd != "-end")
               {
                   librarian.Execute(cmd);
                   cmd = Console.ReadLine();
               }
        }
    }
}