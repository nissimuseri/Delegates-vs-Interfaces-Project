using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class VersionAction : IMenuItemExecute
    {
        public void ExecuteItem()
        {
            Console.WriteLine(@"Version: 19.2.4.32
Press any key to step back.");
            Console.ReadKey();
        }
    }
}