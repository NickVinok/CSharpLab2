using System;
using LabWork2.Solution;

namespace LabWork2.FileWorks
{
    interface IFileWork
    {
        String ReadFromFile();
        void WriteIntoTheFile(string text);
    }
}
