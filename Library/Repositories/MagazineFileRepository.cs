using System.Collections.Generic;
using System.IO;
using Library.Models;
using Library.Utils;

namespace Library.Repositories
{
    public class MagazineFileRepository : FileBaseRepository<MagazineFileRepository>, IMagazineRepository
    {
        private List<Magazine> _magazines;
        protected override string RepositoryName { get; }

        public MagazineFileRepository()
        {
            _magazines = new List<Magazine>();
        }

        public void Delete(Magazine magazine) => _magazines.RemoveAll(i => i.Name.ToLower() == magazine.Name.ToLower());

        public List<Magazine> GetAll() => _magazines;

        public void Add(Magazine magazine) => _magazines.Add(magazine);

        public List<Magazine> Find(string name) => _magazines.FindAll(i => i.Name.ToLower() == name.ToLower());

        public void SaveToDb(string source) => SaveToFile(this, source);

        public void GetFromDb(string source) => _magazines = GetFromFile(source).GetAll();
        
        protected override void Write(BinaryWriter writer, MagazineFileRepository magazineFileRepo)
        {
            foreach (var magazine in magazineFileRepo.GetAll())
            {
                if (magazine.Name == null)
                    continue;
                writer.Write(magazine.Code);
                writer.Write(magazine.Name);
                writer.Write(magazine.Amount);
                writer.Write(magazine.YearOfPublishing);
                writer.Write(magazine.PublishingHouse);
                writer.Write(magazine.Periodicity);
                writer.Write(magazine.Number);
            }
        }

        protected override MagazineFileRepository Read(BinaryReader reader)
        {
            var magazineRepo = new MagazineFileRepository();
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

            return magazineRepo;
        }
    }
}