using System;

namespace Library.Utils
{
    public class ConsoleMenu : IMenu
    {
        public void ShowMainMenu()
        {
            Console.WriteLine("----------  1.Enter -add to add book or magazine  ------------");
            Console.WriteLine("----------  2.Enter -remove to delete book or magazine  --------");
            Console.WriteLine("----------  3.Enter -edit to change data in book or magazine  --------");
            Console.WriteLine("----------  4.Enter -search to search book or magazine  --------");
            Console.WriteLine("----------  5.Enter -save to save data in files --------");
            Console.WriteLine("----------  6.Enter -read to read data from files --------");
            Console.WriteLine("----------  7.Enter -end to end program  --------");
        }
        
        public string ShowMenuAdd()
        {
            Console.WriteLine("Enter -book or -magazine to choose");
            var choose = Console.ReadLine();
            if(choose!= "-book" && choose!= "-magazine")
            {
                Console.WriteLine("Incorrect input, you are returned to the main menu");
            }
            
            return choose;
        }
        
        public string ShowMenuRemove()
        {
            Console.WriteLine("Enter name book or magazine to remove");
            return Console.ReadLine();
        }
        
        public string ShowMenuSearch()
        {
            Console.WriteLine("Enter name of book or magazine to search");
            return Console.ReadLine();
        }
        
        public string ShowEditMenu()
        {
            Console.WriteLine("Enter name book or magazine to edit");
            return Console.ReadLine();
        }

        public void BackToTheMainMenu()
        {
            Console.WriteLine("You are returned to the main menu");
        }

        public void MenuAfterRemove()
        {
            Console.WriteLine("Removed if existed, you are returned to the main menu");
        }

        public void MenuAfterSaveData()
        {
            Console.WriteLine("Successfully saved");
            Console.WriteLine("You are returned to the main menu");
        }

        public void MenuAfterReadData()
        {
            Console.WriteLine("Successfully read data from files");
            Console.WriteLine("You are returned to the main menu");
        }

        public void IncorrectInput()
        {
            Console.WriteLine("No such command");
            Console.WriteLine("Enter -help to see commands");
        }
    }
}