using System;

namespace LabWork2.Greetings
{
    class Greeting
    {
        private const String Message = "This programm was developed by Nickita Vinokurov \n" +
            "Student of SPBSTI(TU)'s group 465.\n" +
            "Programm's purpose is encrypting and decrypting texts, using ROT13 and Caesar's cyphers\n" +
            "The result of the programms's work is displayed in a console.";
        
        public Greeting()
        {
            Console.WriteLine(Message);
        }
    }
}
