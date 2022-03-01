using System;
using Library.Models;
using Library.Models.ModelsUtils;

namespace Library.MenuUtils
{
    public static class EditMenuUtil
    {
        public static void ShowEditMenu(Lib library)
        {
            Console.WriteLine("Enter name of book or magazine to edit:");
            var name = Console.ReadLine();
            library.Books.FindAll(i => i.Name == name).ForEach(BookUtil.EditBook);
            library.Magazines.FindAll(i => i.Name == name).ForEach(MagazineUtil.EditMagazine);
        }
    }
}