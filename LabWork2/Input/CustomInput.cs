using System;
using LabWork2.Solution;
using LabWork2.FileWorks;

namespace LabWork2.Input
{
    class CustomInput : IInput
    {
        public void Input(int chosenTypeOfEncryption, int typeOfOperation)
        {
            FileWork fileWork = new FileWork();
            ICypher cypher;
            IInputValidation inputValidation = new InputValidation();
            string text = "";
            if(chosenTypeOfEncryption == 1)
            {
                cypher = new Caesar();
                if(typeOfOperation == 1)
                {
                    Console.Write("Enter the text, you want to encrypt: ");
                    text = Console.ReadLine();
                    int key = inputValidation.CorrectIntInput("Enter encryprion key(1-36)", 1, 36);
                    text = cypher.Encrypt(text, key);
                }
                else
                {
                    Console.Write("Enter the text, you want to decrypt: ");
                    text = Console.ReadLine();
                    int key = inputValidation.CorrectIntInput("Enter encryprion key(1-36)", 1, 36);
                    text = cypher.Decrypt(text, key);
                   
                }
            }
            else
            {
                cypher = new RotThirteen();
                if (typeOfOperation == 1)
                {
                    Console.Write("Enter the text, you want to encrypt: ");
                    text = Console.ReadLine();
                    cypher.Encrypt(text);
                }
                else
                {
                    Console.Write("Enter the text, you want to decrypt: ");
                    text = Console.ReadLine();
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
