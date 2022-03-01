namespace Library.Models
{
    public class Book : IBook
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int YearOfPublishing { get; set; }
        public string PublishingHouse { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        
        public Book(){}

        public Book(int code, string name, int amount, int yearOfPublishing, string publishingHouse, string author, string genre)
        {
            Code = code;
            Name = name;
            Amount = amount;
            YearOfPublishing = yearOfPublishing;
            PublishingHouse = publishingHouse;
            Author = author;
            Genre = genre;
        }
    }
}