using System.Collections.Generic;
using System.IO;
using Library.Models;
using Library.Utils;

namespace Library.Repositories
{
    public class MagazineRepository : FileBaseRepository<MagazineRepository>, IRepository<Magazine>
    {
        private List<Magazine> _magazines;
        protected override string RepositoryName { get; }

        public MagazineRepository()
        {
            _magazines = new List<Magazine>();
        }

        public void Delete(Magazine magazine) => _magazines.RemoveAll(i => i.Name.ToLower() == magazine.Name.ToLower());

        public List<Magazine> GetAll() => _magazines;

        public void Add(Magazine magazine) => _magazines.Add(magazine);

        public List<Magazine> Find(string name) => _magazines.FindAll(i => i.Name.ToLower() == name.ToLower());

        protected override void Write(BinaryWriter writer, MagazineRepository magazineRepo)
        {
            foreach (var magazine in magazineRepo.GetAll())
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

        protected override MagazineRepository Read(BinaryReader reader)
        {
            var magazineRepo = new MagazineRepository();
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