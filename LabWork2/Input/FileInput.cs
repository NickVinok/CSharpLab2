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
            ICipher cipher;
            if (chosenTypeOfEncryption == 1)
            {
                cipher = new Сiphers();
                if (typeOfOperation == 2)
                {
                    int key = inputValidation.CorrectIntInput("Enter encryprion key(1-25): ", 1, 25);
                    text = cipher.Encrypt(text, key);
                }
                else
                {
                    int key = inputValidation.CorrectIntInput("Enter encryprion key(1-25): ", 1, 25);
                    text = cipher.Decrypt(text, key);      
                }
            }
            else
            {
                cipher = new Сiphers();
                if (typeOfOperation == 2)
                {
                     text = cipher.Encrypt(text);
                }
                else
                {
                    text = cipher.Decrypt(text);
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
