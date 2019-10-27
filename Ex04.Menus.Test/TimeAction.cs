using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class TimeAction : IMenuItemExecute
    {
        public void ExecuteItem()
        {
            Console.WriteLine(
                @"The time is {0}
Press any key to step back.",
                DateTime.Now.ToShortTimeString());
            Console.ReadKey();
        }
    }
}