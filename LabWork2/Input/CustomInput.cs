using LabWork2.FileWorks;
using LabWork2.Solution;
using System;

namespace LabWork2.Input
{
    class CustomInput : IInput
    {
        public void Input(int chosenTypeOfEncryption, int typeOfOperation)
        {
            FileWork fileWork = new FileWork();
            ICipher cipher;
            IInputValidation inputValidation = new InputValidation();
            string text = "";
            string changed;
            if(chosenTypeOfEncryption == 1)
            {
                cipher = new Сiphers();
                if(typeOfOperation == 1)
                {
                    Console.Write("Enter the text, you want to encrypt: ");
                    text = Console.ReadLine();
                    int key = inputValidation.CorrectIntInput("Enter encryprion key(1-36)", 1, 36);
                    changed = cipher.Encrypt(text, key);
                    
                }
                else
                {
                    Console.Write("Enter the text, you want to decrypt: ");
                    text = Console.ReadLine();
                    int key = inputValidation.CorrectIntInput("Enter encryprion key(1-36)", 1, 36);
                    changed = cipher.Decrypt(text, key);
                    
                }
            }
            else
            {
                cipher = new Сiphers();
                if (typeOfOperation == 1)
                {
                    Console.Write("Enter the text, you want to encrypt: ");
                    text = Console.ReadLine();
                    changed = cipher.Encrypt(text);
                   
                }
                else
                {
                    Console.Write("Enter the text, you want to decrypt: ");
                    text = Console.ReadLine();
                    changed = cipher.Decrypt(text);
                    
                }
            }

            Console.WriteLine(changed);


            Confirmation confirmation = new Confirmation();
            if (confirmation.Confirm("Do you want to save the results? Y/N"))
            {
                fileWork.WriteIntoTheFile(changed);
            }
        }
    }
}
