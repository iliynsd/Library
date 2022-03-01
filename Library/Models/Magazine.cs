namespace Library.Models
{
    public class Magazine : IBook
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int YearOfPublishing { get; set; }
        public string PublishingHouse { get; set; }
        public string Periodicity { get; set; }
        public int Number { get; set; }
        
        public Magazine(){}

        public Magazine(int code, string name, int amount, int yearOfPublishing, string publishingHouse, string periodicity, int number)
        {
            Code = code;
            Name = name;
            Amount = amount;
            YearOfPublishing = yearOfPublishing;
            PublishingHouse = publishingHouse;
            Periodicity = periodicity;
            Number = number;
        }
    }
}