using System;
using System.IO;
using LabWork2.Solution;
using LabWork2.FileWorks;

namespace LabWork2.Input
{
    class FileInput : IInput
    {
        public void Input(int chosenTypeOfEncryption, int typeOfOperation)
        {
            FileWork fileWork = new FileWork();
            string text = "";
            while (text.Equals(""))
            {
                text = fileWork.ReadFromFile();
            }
            IInputValidation inputValidation = new InputValidation();
            ICypher cypher;
            if (chosenTypeOfEncryption == 1)
            {
                cypher = new Caesar();
                if (typeOfOperation == 2)
                {
                    int key = inputValidation.CorrectIntInput("Enter encryprion key(1-25): ", 1, 25);
                    text = cypher.Encrypt(text, key);
                }
                else
                {
                    int key = inputValidation.CorrectIntInput("Enter encryprion key(1-25): ", 1, 25);
                    text = cypher.Decrypt(text, key);      
                }
            }
            else
            {
                cypher = new RotThirteen();
                if (typeOfOperation == 2)
                {
                     text = cypher.Encrypt(text);
                }
                else
                {
                    text = cypher.Decrypt(text);
                }
            }

            Console.WriteLine(text);

            Confirmation confirmation = new Confirmation();     
            if (confirmation.Confirm("Do you want to save the results? Y/N"))
            {
                fileWork.WriteIntoTheFile(text);
            }
        }
    }
}
