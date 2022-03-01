using System;

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
    }
}