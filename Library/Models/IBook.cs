namespace Library.Models
{
    public interface IBook
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int YearOfPublishing { get; set; }
        public string PublishingHouse { get; set; }
    }
}