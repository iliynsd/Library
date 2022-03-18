using System.Collections.Generic;
using Library.Models;

namespace Library.Repositories
{
    public class MagazineRepositoryDI
    {
        private IMagazineRepository _magazineRepository;

        public MagazineRepositoryDI(IMagazineRepository magazineRepository)
        {
            _magazineRepository = magazineRepository;
        }

        public void Add(Magazine item) => _magazineRepository.Add(item);

        public void Delete(Magazine item) => _magazineRepository.Delete(item);

        public List<Magazine> GetAll() => _magazineRepository.GetAll();

        public List<Magazine> Find(string name) => _magazineRepository.Find(name);
    }
}