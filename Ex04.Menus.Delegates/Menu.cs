using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class Menu
    {
        private readonly bool r_IsSubMenu;
        private readonly string r_Title;
        private readonly Dictionary<MenuItem, Action> r_Items;
        private readonly List<Menu> r_SubMenusList = new List<Menu>();
        private readonly int r_SubMenuNumber = 1;

        public Menu(string i_Title, int i_SubMenuNumber, bool i_IsSubMenu)
        {
            r_IsSubMenu = i_IsSubMenu;
            r_SubMenuNumber = i_SubMenuNumber;
            r_Title = i_Title;
            r_Items = new Dictionary<MenuItem, Action>();
        }

        public void ShowMenu()
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
                    foreach (KeyValuePair<MenuItem, Action> item in r_Items)
                    {
                        if (item.Key.ItemNumberInMenu == userInput)
                        {
                            item.Key.ChooseItem();
                        }
                    }
                }
            }
        }

        public void AddItem(string i_Title, Action i_FunctionAction)
        {
            MenuItem newMenuItem = new MenuItem(i_Title, r_Items.Count + 1);
            newMenuItem.EventHandlerItemAction += ItemAction;
            r_Items.Add(newMenuItem, i_FunctionAction);
        }

        public Menu AddMenu(string i_Title)
        {
            r_SubMenusList.Add(new Menu(i_Title, r_SubMenuNumber + 1, true));
            MenuItem newMenuItem = new MenuItem(i_Title, r_Items.Count + 1);
            newMenuItem.EventHandlerItemAction += ItemAction;
            r_Items.Add(newMenuItem, r_SubMenusList[r_SubMenusList.Count - 1].ShowMenu);
            return r_SubMenusList[r_SubMenusList.Count - 1];
        }

        private void ItemAction(MenuItem i_MenuItem)
        {
            Action functionToAction;
            r_Items.TryGetValue(i_MenuItem, out functionToAction);
            functionToAction.Invoke();
        }

        private void printMenu()
        {
            Console.Clear();
            Console.WriteLine("{0}: {1}", r_SubMenuNumber, r_Title);
            Console.Write("0) ");
            if (this.r_IsSubMenu != true)
            {
                Console.WriteLine("Exit");
            }
            else
            {
                Console.WriteLine("Back");
            }

            foreach (KeyValuePair<MenuItem, Action> item in r_Items)
            {
                Console.WriteLine("{0}) {1}", item.Key.ItemNumberInMenu, item.Key.Title);
            }
        }

        private int getUserInput()
        {
            bool isValidInput = false;
            string userInput;
            int chosenItem = -1;
            while (isValidInput != true)
            {
                Console.Write("Please choose between {0} to {1}: ", 0, this.r_Items.Count);
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out chosenItem) != true)
                {
                    Console.WriteLine("Invalid input.");
                }
                else if (chosenItem < 0 || chosenItem > this.r_Items.Count)
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
    }
}
