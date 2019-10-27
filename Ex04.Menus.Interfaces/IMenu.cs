namespace Ex04.Menus.Interfaces
{

    public interface IMenu : IMenuItem
    {
        IMenu AddMenu(string i_Title);

        void AddItem(string i_Title, IMenuItemExecute i_Action);
    }
}