using System;
using LabWork2.Input;

namespace LabWork2.Control
{
    class Menu
    {
        private enum CypherTypes { CaesarCypher = 1, ROT13, Exit }
        private enum ActionTypes { EncryptFromKeyBoard = 1, EncryptFromFile , DecryptFromKeyboard, DecryptFromFile, Cancel }
        private enum TypeOfTypes { Cypher, Action }
        private static string CypherTypePresentation = "1.Work with Caesar's Cypher\n" +
                    "2.Work with ROT13 cypher\n" +
                "3.Finish work with the programm";
        private static string ActionsWithCypher = "1.Encryption of the text, typed in from keyboard\n" +
            "2.Encryption of the text from file\n" +
            "3.Decryption of the text, typed in from keyboard\n" +
            "4.Decryption of the text from file\n" +
            "5.Stop working with this encryption type";
        private void ShowMenu(string message)
        {
            Console.WriteLine(message);
        }

        private int GetMenuItem(TypeOfTypes typeOfTypes)
        {
            InputValidation inputValidation = new InputValidation();
            int item;
            switch (typeOfTypes)
            {
                case TypeOfTypes.Cypher:
                    item = inputValidation.CorrectIntInput("Enter number of the menu item: ",
                       (int)CypherTypes.CaesarCypher, (int)CypherTypes.Exit); //2 последних параметра - границы для ввода цифры(от 1 до 4)
                    return item;
                    
                case TypeOfTypes.Action:
                    item = inputValidation.CorrectIntInput("Enter number of the menu item: ",
                       (int)ActionTypes.EncryptFromKeyBoard, (int)ActionTypes.Cancel); //2 последних параметра - границы для ввода цифры(от 1 до 5)
                    return item;
                default:
                    return 0;
            }
        }

        private void ActionMenu(int ChosenTypeOfEncryption)
        {

            bool cancelWithThisTypeOfEncryprion = false;
            while (!cancelWithThisTypeOfEncryprion)
            {
                String delimitter = new string('-', 40);
                Console.Write(delimitter + '\n');

                ActionTypes item;
                ShowMenu(ActionsWithCypher);
                item = (ActionTypes)GetMenuItem(TypeOfTypes.Action);
                IInput input;
                switch (item)
                {
                    case ActionTypes.EncryptFromKeyBoard:
                        input = new CustomInput();
                        input.Input(ChosenTypeOfEncryption, (int)item);
                        break;
                    case ActionTypes.EncryptFromFile:
                        input = new FileInput();
                        input.Input(ChosenTypeOfEncryption, (int)item);
                        break;
                    case ActionTypes.DecryptFromKeyboard:
                        input = new CustomInput();
                        input.Input(ChosenTypeOfEncryption, (int)item);
                        break;
                    case ActionTypes.DecryptFromFile:
                        input = new FileInput();
                        input.Input(ChosenTypeOfEncryption, (int)item);
                        break;
                    case ActionTypes.Cancel:
                        cancelWithThisTypeOfEncryprion = true;
                        break;
                }
            }
        }

        public Menu()
        {
            bool stopExecution = false;
            while (!stopExecution)
            {
                String delimitter = new string('-', 40);
                Console.Write(delimitter + '\n');

                CypherTypes item;
                ShowMenu(CypherTypePresentation);
                item = (CypherTypes)GetMenuItem(TypeOfTypes.Cypher);
                switch (item)
                {
                    case CypherTypes.CaesarCypher:
                        ActionMenu((int)CypherTypes.CaesarCypher);
                        break;
                    case CypherTypes.ROT13:
                        ActionMenu((int)CypherTypes.ROT13);
                        break;
                    case CypherTypes.Exit:
                        stopExecution = true;
                        break;
                }
            }
        }
    }
}
