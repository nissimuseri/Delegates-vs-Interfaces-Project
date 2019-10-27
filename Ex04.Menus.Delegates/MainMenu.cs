namespace Ex04.Menus.Delegates
{
    public sealed class MainMenu : Menu
    {
        public MainMenu() : base("Delegates Menu", 1, false)
        {
        }

        public void Show()
        {
            ShowMenu();
        }
    }
}
