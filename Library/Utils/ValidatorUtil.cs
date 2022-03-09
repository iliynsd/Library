using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Models;

namespace Library.Utils
{
    public static class ValidatorUtil
    {
        public static int TryEnterNaturalNum()
        {
            var number = Console.ReadLine();
            if (!int.TryParse(number, out int parsedNum) || !IsNumberNotNumerals(number) || parsedNum < 0)
            {
                Console.WriteLine("Incorrect input, try again");
                return TryEnterNaturalNum();
            }

            return int.Parse(number);
        }
        
        public static bool IsNumberNotNumerals(string num) => int.Parse(num).ToString().Length == num.Length;

        public static string TryEnterStringNotNum()
        {
            var text = Console.ReadLine();
            if (double.TryParse(text, out double parsedNum))
            {
                Console.WriteLine("Incorrect input, try again");
                return TryEnterStringNotNum();
            }

            return text;
        }
        
        public static bool ValidateBook(Book book)
        {
            var context = new ValidationContext(book);
            var results = new List<ValidationResult>();
            var rezOfVal = Validator.TryValidateObject(book, context, results, true);
            if (!rezOfVal)
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine();
            }
                
            return rezOfVal;
        }
        public static bool ValidateMagazine(Magazine magazine)
        {
            var context = new ValidationContext(magazine);
            var results = new List<ValidationResult>();
            var rezOfVal = Validator.TryValidateObject(magazine, context, results, true);
            if (!rezOfVal)
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine();
            }
                
            return rezOfVal;
        }
    }
}