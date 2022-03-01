using System;
using Library.Utils;

namespace Library.Models.ModelsUtils
{
    public static class MagazineUtil
    {
        public static Magazine CreateMagazine()
        {
            Console.WriteLine("Enter the code of magazine:");
            var code = ValidatorUtil.TryEnterNaturalNum();
            Console.WriteLine("Enter the name of magazine:");
            var name = ValidatorUtil.TryEnterStringNotNum();
            Console.WriteLine("Enter the amount of the magazine:");
            var amount = ValidatorUtil.TryEnterNaturalNum();
            Console.WriteLine("Enter the year of publishing the magazine:");
            var yearOfPublishing = ValidatorUtil.TryEnterNaturalNum();
            Console.WriteLine("Enter the publishing house of the magazine:");
            var publishingHouse = ValidatorUtil.TryEnterStringNotNum();
            Console.WriteLine("Enter the periodicity of the magazine:");
            var periodicity = ValidatorUtil.TryEnterStringNotNum();
            Console.WriteLine("Enter the number of the magazine:");
            var number = ValidatorUtil.TryEnterNaturalNum();
            return new Magazine(code, name, amount, yearOfPublishing, publishingHouse, periodicity, number);
        }

        public static void ShowMagazine(Magazine magazine)
        {
            Console.WriteLine("-----Magazine-----");
            Console.WriteLine($"Code - {magazine.Code}");
            Console.WriteLine($"Name - {magazine.Name}");
            Console.WriteLine($"Amount - {magazine.Amount}");
            Console.WriteLine($"Year of publishing - {magazine.YearOfPublishing}");
            Console.WriteLine($"Publishing house - {magazine.PublishingHouse}");
            Console.WriteLine($"Periodicity - {magazine.Periodicity}");
            Console.WriteLine($"Number - {magazine.Number}");
        }

        public static void EditMagazine(Magazine magazine)
        {
            Console.WriteLine("Enter field you want to edit or enter leave to stop making changes");
            var choose = ValidatorUtil.TryEnterStringNotNum();

            if (choose == "code")
            {
                Console.WriteLine("Enter the new code of magazine");
                magazine.Code = ValidatorUtil.TryEnterNaturalNum();
            }

            else if (choose == "name")
            {
                Console.WriteLine("Enter the new name of magazine:");
                magazine.Name = ValidatorUtil.TryEnterStringNotNum();
            }

            else if (choose == "amount")
            {
                Console.WriteLine("Enter the new amount of the magazine:");
                magazine.Amount = ValidatorUtil.TryEnterNaturalNum();
            }

            else if (choose == "yearOfPublishing")
            {
                Console.WriteLine("Enter the new year of publishing the magazine:");
                magazine.YearOfPublishing = ValidatorUtil.TryEnterNaturalNum();
            }

            else if (choose == "publishingHouse")
            {
                Console.WriteLine("Enter the new publishing house of the magazine:");
                magazine.PublishingHouse = ValidatorUtil.TryEnterStringNotNum();
            }

            else if (choose == "periodicity")
            {
                Console.WriteLine("Enter the periodicity of the magazine:");
                magazine.Periodicity = ValidatorUtil.TryEnterStringNotNum();
            }

            else if (choose == "number")
            {
                Console.WriteLine("Enter the number of the magazine:");
                magazine.Number = ValidatorUtil.TryEnterNaturalNum();
            }

            else if (choose == "leave")
            {
                
            }
            else
            {
                EditMagazine(magazine);
            }
        }
    }
}