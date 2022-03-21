namespace Library.Utils
{
    public interface IMenu
    {
        public void ShowMainMenu();
        public string ShowMenuAdd();
        public string ShowMenuRemove();
        public string ShowMenuSearch();
        public string ShowEditMenu();
        public void BackToTheMainMenu();
        public void MenuAfterRemove();
        public void MenuAfterSaveData();
        public void MenuAfterReadData();
        public void IncorrectInput();
    }
}