using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class DateAction : IMenuItemExecute
    {
        public void ExecuteItem()
        {
            Console.WriteLine(
                @"The date is {0}
Press any key to step back.",
                DateTime.Today.ToShortDateString());
            Console.ReadKey();
        }
    }
}