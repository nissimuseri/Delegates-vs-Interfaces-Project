using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private readonly string r_Title;
        private readonly int r_ItemNumberInMenu;

        public event Action<MenuItem> EventHandlerItemAction;

        public MenuItem(string i_Title, int i_ItemNumberInMenu)
        {
            r_Title = i_Title;
            r_ItemNumberInMenu = i_ItemNumberInMenu;
        }

        public string Title
        {
            get
            {
                return r_Title;
            }
        }

        public int ItemNumberInMenu
        {
            get
            {
                return r_ItemNumberInMenu;
            }
        }

        public void ChooseItem()
        {
            Console.Clear();
            EventHandlerItemAction.Invoke(this);
        }
    }
}
