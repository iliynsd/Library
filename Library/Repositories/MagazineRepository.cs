using System;
using System.Collections.Generic;
using Library.Models;
using Library.Utils;

namespace Library.Repositories
{
    public class MagazineRepository : IRepository<Magazine>
    {
        private List<Magazine> _magazines = new List<Magazine>();

        public void Create()
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
            var createdMagazine = new Magazine(code, name, amount, yearOfPublishing, publishingHouse, periodicity, number);
            if (ValidatorUtil.ValidateMagazine(createdMagazine))
            {
                _magazines.Add(createdMagazine);
                Console.WriteLine("Magazine was successfully added");
            }
            else
            {
                Console.WriteLine("Magazine wasn't added");
            }
        }

        public void Show(string name)
        {
            var magazines = _magazines.FindAll(i => i.Name == name);
            
            if (magazines.Count > 0)
            {
                magazines.ForEach(ShowMagazine);
            }
            else
            {
                Console.WriteLine($"No magazines with this name - {name}");
            }

            void ShowMagazine(Magazine magazine)
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
        }

        public void Edit(string name)
        {
            var magazine = _magazines.Find(i => i.Name == name);
            if (magazine == null)
            {
                Console.WriteLine($"No magazines with this name - {name}");
                return;
            }
            string choose;
            do
            {
                Console.WriteLine("Magazine has this fields: code;name;amount;yearOfPublishing;publishingHouse;periodicity;number");
                Console.WriteLine("Enter name of field you want to edit or enter -leave to stop making changes");
                choose = ValidatorUtil.TryEnterStringNotNum();

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
            } while (choose != "-leave");

            if (!ValidatorUtil.ValidateMagazine(magazine))
            {
                Console.WriteLine("Edit one more time");
                Edit(name);
            }
            else
            {
                Console.WriteLine("Edit magazine successfully");
            }
        }

        public void Delete(string name)
        {
            var rez = _magazines.RemoveAll(i => i.Name.ToLower() == name.ToLower());
            if (rez <= 0)
            { 
                Console.WriteLine($"No magazines with this name - {name}");
            }
            else
            {
                Console.WriteLine($"Removed {rez} magazines");
            }
        }
        
        public List<Magazine> GetAll() => _magazines;

        public void Add(Magazine magazine) => _magazines.Add(magazine);
    }
}