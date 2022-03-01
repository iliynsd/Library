using System;
using System.Collections.Generic;
using Library.MenuUtils;
using Library.Models;

namespace Library.Application
{
    static class Program
    {
        static void Main()
        {
            var library = new Lib
            {
                Magazines = new List<Magazine>(),
                Books = new List<Book>()
            };
            
            var cmd = Console.ReadLine();
            
            while (cmd != "-end")
            {
                 if (cmd == "-add")
                 {
                     MenuAddUtil.ShowMenuAdd(library);
                 }
                 
                 if (cmd == "-help")
                 {
                     MainMenuUtil.ShowMainMenu();
                 }

                 if (cmd == "-remove")
                 {
                     MenuRemoveUtil.ShowMenuRemove(library);
                 }

                 if (cmd == "-edit")
                 {
                     EditMenuUtil.ShowEditMenu(library);
                 }

                 if (cmd == "-search")
                 {
                     MenuSearchUtil.ShowMenuSearch(library);
                 }
                 cmd = Console.ReadLine();
            }
        }
    }
}