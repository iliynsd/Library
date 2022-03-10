namespace Library.Repositories
{
    public interface IRepository
    {
        public void Create();
        public void Show(string name);
        public void Edit(string name);
        public void Delete(string name);
    }
}