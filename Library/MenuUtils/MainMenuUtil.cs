using System;

namespace Library.MenuUtils
{
    public static class MainMenuUtil
    {
        public static void ShowMainMenu()
        {
            Console.WriteLine("----------  1.Enter -add to add book or magazine   ------------");
            Console.WriteLine("----------  2.Enter -remove to delete book or magazine  --------");
            Console.WriteLine("----------  3.Enter -edit to change data in book or magazine  --------");
            Console.WriteLine("----------  4.Enter -search to search book or magazine  --------");
        }
    }
}