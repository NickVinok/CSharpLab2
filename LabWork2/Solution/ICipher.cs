using System;

namespace LabWork2.Solution
{
    public interface ICipher
    {
        string Encrypt(string text, int key=13);
        string Decrypt(string text, int key=13);
    }
}
