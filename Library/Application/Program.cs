using System;
using System.IO;
using Library.Config;
using Library.Repositories;
using Library.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

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
           
            
            
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<Configuration>();
            serviceCollection.AddSingleton<IMagazineRepository, MagazineFileRepository>();
            serviceCollection.AddSingleton<IBookRepository, BookFileRepository>();
            serviceCollection.AddSingleton<IMenu, ConsoleMenu>();
            var options = new PathOptions();
            serviceCollection.Configure<PathOptions>((opt)=> configuration.GetSection("path").Bind(options));
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var testConfiguration = serviceProvider.GetService<Configuration>();
            var books = serviceProvider.GetRequiredService<IBookRepository>();
            var magazines = serviceProvider.GetRequiredService<IMagazineRepository>();
            var menu = serviceProvider.GetRequiredService<IMenu>();
            
           // var pathToBooks = testConfiguration.GetSection("pathToBooks");
          //  var pathToMagazines = testConfiguration.GetSection("pathToMagazines");


          
            
            
            var librarian = new Librarian(books, magazines,menu, options);

            librarian.Execute();
        }
    }
}