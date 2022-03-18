using System.Collections.Generic;
using System.IO;

namespace Library.Utils
{
    public abstract class FileBaseRepository<T>
    {
       protected abstract string RepositoryName { get; }
        
        public void SaveToFile(T item, string path)
        {
            using var writer = new BinaryWriter(File.Open(path, FileMode.Create));
            Write(writer, item);
        }
        
        protected abstract void Write(BinaryWriter writer, T item);
        
        public T GetFromFile(string path)
        {
            using var reader = new BinaryReader(File.OpenRead(path));
            return Read(reader);
        }

        protected abstract T Read(BinaryReader reader);
    }
}