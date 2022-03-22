using System;
using System.Threading.Tasks;
using Library.Config;
using Library.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Library.Application
{
    public class App
    {
       private readonly PathOptions _options;

        public App(IOptions<PathOptions> options)
        {
            _options = options.Value;
        }

        public async Task Run(IServiceProvider provider)
        {
            var librarian = provider.GetRequiredService<Librarian>();
            librarian.Execute(_options.PathToBooks, _options.PathToMagazines);
            await Task.CompletedTask;
        }
    }
}