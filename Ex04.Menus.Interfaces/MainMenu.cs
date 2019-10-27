using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{

    public class MainMenu : IMenu
    {
        private readonly List<IMenuItem> r_ItemList = new List<IMenuItem>();
        private readonly bool r_IsSubMenu;
        private readonly int r_SubMenuNumber;
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

        public MainMenu(string i_Title) : this(i_Title, 1, false)
        {
        }

        internal MainMenu(string i_Title, int i_SubMenuNumber, bool i_IsSubMenu)
        {
            Title = i_Title;
            r_IsSubMenu = i_IsSubMenu;
            r_SubMenuNumber = i_SubMenuNumber;
        }

        public IMenu AddMenu(string i_Title)
        {
            const bool v_IsSubMenu = true;
            IMenu menu = new MainMenu(i_Title, r_SubMenuNumber + 1, v_IsSubMenu);
            r_ItemList.Add(menu);
            return menu;
        }

        public void AddItem(string i_Title, IMenuItemExecute i_Action)
        {
            r_ItemList.Add(new MenuExecute(i_Title, i_Action));
        }

        public void Show()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                printMenu();
                int userInput = getUserInput();
                if (userInput == 0)
                {
                    isRunning = false;
                }
                else
                {
                    r_ItemList[userInput - 1].Show();
                }
            }
        }

        private int getUserInput()
        {
            bool isValidInput = false;
            string userInput;
            int chosenItem = -1;
            while (isValidInput != true)
            {
                Console.Write("Please choose between {0} to {1}: ", 0, this.r_ItemList.Count);
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out chosenItem) != true)
                {
                    Console.WriteLine("Invalid input.");
                }
                else if (chosenItem < 0 || chosenItem > this.r_ItemList.Count)
                {
                    Console.WriteLine("Input out of range.");
                }
                else
                {
                    isValidInput = true;
                }
            }

            return chosenItem;
        }

        private void printMenu()
        {
            int itemCounter = 1;
            Console.Clear();
            Console.WriteLine("{0}: {1}", r_SubMenuNumber, Title);
            Console.Write("0) ");
            if (this.r_IsSubMenu != true)
            {
                Console.WriteLine("Exit");
            }
            else
            {
                Console.WriteLine("Back");
            }

            foreach (IMenuItem item in this.r_ItemList)
            {
                Console.WriteLine("{0}) {1}", itemCounter, item.Title);
                itemCounter++;
            }
        }
    }
}