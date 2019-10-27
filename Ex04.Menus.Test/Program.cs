namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            showInterfaceMenu();
            showDelegateMenu();
        }

        private static void showInterfaceMenu()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Interface Menu");
            Interfaces.IMenu dateTimeMenu = mainMenu.AddMenu("Show Date/Time");
            dateTimeMenu.AddItem("Show Time", new TimeAction());
            dateTimeMenu.AddItem("Show Date", new DateAction());
            Interfaces.IMenu versionAndDigits = mainMenu.AddMenu("Version and Digits");
            versionAndDigits.AddItem("Count Digits", new CountDigitsAction());
            versionAndDigits.AddItem("Show Version", new VersionAction());
            mainMenu.Show();
        }

        private static void showDelegateMenu()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu();
            Delegates.Menu dateTimeMenu = mainMenu.AddMenu("Show Date/Time");
            dateTimeMenu.AddItem("Show Time", new TimeAction().ExecuteItem);
            dateTimeMenu.AddItem("Show Date", new DateAction().ExecuteItem);
            Delegates.Menu versionAndDigits = mainMenu.AddMenu("Version and Digits");
            versionAndDigits.AddItem("Count Digits", new CountDigitsAction().ExecuteItem);
            versionAndDigits.AddItem("Show Version", new VersionAction().ExecuteItem);
            mainMenu.Show();
        }
    }
}
