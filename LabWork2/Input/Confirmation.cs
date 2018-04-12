using System;


namespace LabWork2.Input
{
    class Confirmation : IConfirmation
    {
        public bool Confirm(String message)
        {
            Console.WriteLine(message);
            InputValidation inputValidation = new InputValidation();
            char answer;
            while (true)
            {
                answer = Char.ToUpper(inputValidation.CorrectCharInput());
                if (!answer.Equals('Y') && !answer.Equals('N'))
                {
                    Console.WriteLine("Invalid Input, try again");
                    continue;
                }
                break;
            }
            return (answer.Equals('Y')) ? true : false;
        }
    }
}
