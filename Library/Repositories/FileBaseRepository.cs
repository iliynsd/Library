using System.IO;
using Library.Config;
using Library.Models;
using Library.Repositories;

namespace Library.Utils
{
    public abstract class FileBaseRepository<T>
    {
        private readonly string _pathToBooks = Configuration.GetSection("pathToBooks");
        private readonly string _pathToMagazines = Configuration.GetSection("pathToMagazines");
        
        
        public void SaveToFile(T item, string path)
        {
            using var writer = new BinaryWriter(File.Open(path, FileMode.Create));
            Write(writer, item);
        }
        
        protected abstract void Write(BinaryWriter writer, T item);
        protected abstract string RepositoryName { get; }


        public T GetFromFile()
        {
            using var reader = new BinaryReader(File.OpenRead(_pathToBooks));
            return Read(reader);
        }

        protected abstract T Read(BinaryReader reader);
    }
}