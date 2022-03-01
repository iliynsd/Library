using System;
using Library.Models;
using Library.Models.ModelsUtils;

namespace Library.MenuUtils
{
    public static class MenuAddUtil
    {
        public static void ShowMenuAdd(Lib library)
        {
            Console.WriteLine("Enter -book to add book or -magazine to add magazine");
            var choose = Console.ReadLine();
            if (choose == "-book")
            {
                library.Books.Add(BookUtil.CreateBook());
            }
            if (choose == "-magazine")
            {
                library.Magazines.Add(MagazineUtil.CreateMagazine());
            }
        }
    }
}