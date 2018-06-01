using System;
using System.IO;
using LabWork2.Solution;
using LabWork2.Input;

namespace LabWork2.FileWorks
{
    class FileWork : IFileWork
    {
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
            string fileName = "";
            FileStream fileStream;
            Confirmation confirmation = new Confirmation();
            StreamWriter streamWriter;
            InputValidation inputValidation = new InputValidation();
            bool fileIsSaved = false;
            while (!fileIsSaved)
            {
                fileIsSaved = true;
                bool wrongFileName = true;
                Console.Write("Enter the name of file: ");
                while (wrongFileName)
                {
                    fileName = Console.ReadLine();
                    wrongFileName = false;
                    try
                    {
                        using(streamWriter = new StreamWriter(fileName))
                        {

                        }

                    }
                    catch
                    {
                        Console.WriteLine("Error occured");
                        Console.Write("Try again:");
                        wrongFileName = true;
                    }
                    
                }

                if (File.Exists(fileName))
                {
                    if (confirmation.Confirm("Do you want to rewrite the file? Y/N"))
                    {
                        fileStream = new FileStream(fileName, FileMode.Open);
                    }
                    else
                    {
                        if (confirmation.Confirm("Do you want to add your txt to the end of the file? Y/N"))
                        {
                            fileStream = new FileStream(fileName, FileMode.Append);
                        }
                        else
                        {
                            fileIsSaved = false;
                            Console.WriteLine("Choose another file");
                            continue;
                        }
                    }
                }
                else
                {
                    fileStream = new FileStream(fileName, FileMode.Create);
                }


                streamWriter = new StreamWriter(fileStream);
                foreach(char c in text)
                {
                    streamWriter.Write(c);
                }
                streamWriter.Write('\n');

                streamWriter.Close();
                fileStream.Close();
            }
        }
    }
}
