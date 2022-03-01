using System;
using Library.Models;
using Library.Models.ModelsUtils;

namespace Library.MenuUtils
{
    public static class MenuSearchUtil
    {
        public static void ShowMenuSearch(Lib library)
        {
            Console.WriteLine("Enter name of book or magazine to look at:");
            var name = Console.ReadLine();
            library.Books.FindAll(i => i.Name == name).ForEach(BookUtil.ShowBook);
            library.Magazines.FindAll(i => i.Name == name).ForEach(MagazineUtil.ShowMagazine);
        }
    }
}