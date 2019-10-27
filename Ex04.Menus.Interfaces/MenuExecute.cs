using System;

namespace Ex04.Menus.Interfaces
{
    internal class MenuExecute : IMenuItem
    {
        private readonly IMenuItemExecute r_Action;
        private string m_Title;

        public string Title
        {
            get
            {
                return m_Title;
            }

            set
            {
                m_Title = value;
            }
        }

        public MenuExecute(string i_Title, IMenuItemExecute i_Action)
        {
            Title = i_Title;
            r_Action = i_Action;
        }

        public void Show()
        {
            Console.Clear();
            r_Action.ExecuteItem();
        }
    }
}