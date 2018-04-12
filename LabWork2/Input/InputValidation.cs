using System;

namespace LabWork2.Input
{
    class InputValidation : IInputValidation
    {
        public int CorrectIntInput(String message, int firstItemNumber = 0, int lastItemNumber = 0)
        {
            bool inputSuccess = false;
            int item = 0;
            Console.Write(message);
            while (!inputSuccess)
            {
                string consoleInput = Console.ReadLine();
                if (!int.TryParse(consoleInput, out item))
                {
                    Console.Write("It's not a number, pls try again: ");
                    continue;
                }
                if(firstItemNumber != lastItemNumber && (item < firstItemNumber || item > lastItemNumber))
                {
                    Console.Write("Number is out of range, try again: ");
                    continue;
                }
                inputSuccess = true;
            }
            return item;
        }

        public char CorrectCharInput()
        {
            bool inputSuccess = false;
            char item = 'a';
            while (!inputSuccess)
            {
                string consoleInput = Console.ReadLine();
                if (!char.TryParse(consoleInput, out item))
                {
                    Console.Write("It's not a symbol, pls try again: ");
                    continue;
                }
                inputSuccess = true;
            }
            return item;
        }
    }
}

