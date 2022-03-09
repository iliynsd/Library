using System;
using Library.Application;
using Library.Models;
using Library.Models.ModelsUtils;
using Library.Visitor;

namespace Library.MenuUtils
{
    public static class MenuAddUtil
    {
        public static void ShowMenuAdd(Librarian lib)
        {
           Console.WriteLine("Enter -book or -magazine to choose");
           var choose = Console.ReadLine();
           IBook book;
           if (choose == "-book")
           {
               book = new Book();
           }
           else if (choose == "-magazine")
           {
               book = new Magazine();
           }
           else
           {
               Console.WriteLine("Incorrect input, you are returned to the main menu");
               return;
           }
           book.Accept(lib,new Create());
           Console.WriteLine("You are returned to the main menu ");
           Console.WriteLine("Enter -help to see commands");
        }
    }
}