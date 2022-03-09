using System.ComponentModel.DataAnnotations;
using Library.Application;
using Library.Visitor;

namespace Library.Models
{
    public class Magazine : IBook
    {
        [Range(0, 10000)]
        public int Code { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Range(1, 10000)]
        public int Amount { get; set; }
        [Range(1900, 2022)]
        public int YearOfPublishing { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string PublishingHouse { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string Periodicity { get; set; }
        [Range(1, 10)]
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

        public void Accept(Librarian lib, IBookVisitor visitor)
        {
            visitor.Visit(lib, this);
        }
    }
}