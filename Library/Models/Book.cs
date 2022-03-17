using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book 
    {
        [Range(0, 10000)]
        public int Code { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Range(0, 10000)]
        public int Amount { get; set; }
        
        [Range(1900, 2022)]
        public int YearOfPublishing { get; set; }
        
        [StringLength(50, MinimumLength = 3)]  
        public string PublishingHouse { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string Author { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
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