using System;
using System.IO;
using Library.Config;
using Library.Repositories;
using Library.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unity;
using Unity.Lifetime;

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
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var testConfiguration = serviceProvider.GetService<Configuration>();
            
            
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IConfiguration>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMagazineRepository, MagazineFileRepository>();
            container.RegisterType<IBookRepository, BookFileRepository>();
            container.RegisterType<IMenu, ConsoleMenu>();
            var books = container.Resolve<BookFileRepository>();
            var magazines = container.Resolve<MagazineFileRepository>();
            var menu = container.Resolve<ConsoleMenu>();
            
            
            
            var pathToBooks = testConfiguration.GetSection("pathToBooks");
            var pathToMagazines = testConfiguration.GetSection("pathToMagazines");
            
            
            var librarian = new Librarian(books, magazines, pathToBooks, pathToMagazines);
            
            librarian.Execute();
        }
    }
}