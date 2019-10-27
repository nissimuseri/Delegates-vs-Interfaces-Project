using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountDigitsAction : IMenuItemExecute
    {
        private static int s_DigitsCount = 0;

        public void ExecuteItem()
        {
            Console.WriteLine("Please enter a sentence:");
            string sentence = Console.ReadLine();
            foreach(char c in sentence)
            {
                if(c >= '0' && c <= '9')
                {
                    s_DigitsCount++;
                }
            }

            Console.WriteLine(
                @"This sentence contains {0} digits.
Press any key to step back.",
                s_DigitsCount);
            s_DigitsCount = 0;
            Console.ReadKey();
        }
    }
}