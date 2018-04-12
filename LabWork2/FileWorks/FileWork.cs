using System;
using System.IO;
using LabWork2.Solution;
using LabWork2.Input;

namespace LabWork2.FileWorks
{
    class FileWork : IFileWork
    {
        private string[] ReservedFileNames = { "con.", "nul.", "prn.", "aux.", "com1.", "com2.", "com3.", 
                     "com4.", "com5.", "com6.", "com7.", "com8.", "com9.", "lpt1.", "lpt2.", "lpt3.",
                        "lpt4.", "lpt5.", "lpt6.","lpt7.", "lpt8.", "lpt9."};

        public String ReadFromFile()
        {
            string fileName;
            string text = "";
            Console.Write("Enter the name of file: ");
            while (true)
            {
                fileName = Console.ReadLine();
                if (!File.Exists(fileName))
                {
                    Console.Write("File wasn't found, try again: ");
                }
                else
                {
                    break;
                }
            }
            StreamReader streamReader = new StreamReader(fileName);
            text = streamReader.ReadToEnd();
            streamReader.Close();
            return text;
        }

        public void WriteIntoTheFile(string text)
        {
            string fileName;
            FileStream fileStream;
            Confirmation confirmation = new Confirmation();
            StreamWriter streamWriter;
            InputValidation inputValidation = new InputValidation();

            Console.Write("Enter the name of file: ");
            while (true)
            {
                fileName = Console.ReadLine();
                bool wrongFileName = false;
                //При встрече первого неподходящего символа в файле выставит флаг о неправильном исени файла
                foreach(char c in fileName)
                {
                    if(!(Char.IsLetterOrDigit(c) || c.Equals('.')))
                    {
                        Console.WriteLine("Name of the file can contain only lettres, numbers  and '.'");
                        wrongFileName = true;
                        break;
                    }
                }
                if (!fileName.Contains(".txt"))
                {
                    fileName += ".txt";
                }
                foreach(String name in ReservedFileNames)
                {
                    if (fileName.Contains("//" + name) || fileName.Substring(0,4).Equals(name) || fileName.Substring(0, 5).Equals(name))
                    {
                        Console.WriteLine("You can't save file, with prohibitted or reserved names, like " + name);
                        wrongFileName = true;
                        break;
                    }
                }
                if (!wrongFileName) { break; }
                else { Console.Write("Try again:"); }
            }

            if (File.Exists(fileName))
            {      
                if (confirmation.Confirm("Do you want to rewrite the file? Y/N"))
                {
                    fileStream = new FileStream(fileName, FileMode.Open);
                }
                else
                {
                    fileStream = new FileStream(fileName, FileMode.Append);
                }
            }
            else
            {
                fileStream = new FileStream(fileName, FileMode.Create);
            }
            

            streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(text);

            streamWriter.Close();
            fileStream.Close();
        }
    }
}
