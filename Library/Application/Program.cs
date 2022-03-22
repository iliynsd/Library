using System;
using System.IO;
using System.Threading.Tasks;
using Library.Config;
using Library.Repositories;
using Library.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
    static class Program
    {
        static async Task Main()
        {
            var serviceCollection = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName).AddJsonFile("appSettings.json", optional:false).AddEnvironmentVariables()
                .Build();
           
            
            serviceCollection.Configure<PathOptions>(configuration.GetSection(PathOptions.Path).Bind);
            
            serviceCollection.AddTransient<App>();
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<Configuration>();
            serviceCollection.AddSingleton<IMagazineRepository, MagazineFileRepository>();
            serviceCollection.AddSingleton<IBookRepository, BookFileRepository>();
            serviceCollection.AddSingleton<IMenu, ConsoleMenu>();
            serviceCollection.AddSingleton<Librarian>();
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            await serviceProvider.GetRequiredService<App>().Run(serviceProvider);
        }
    }
}