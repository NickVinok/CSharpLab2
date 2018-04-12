using System;

namespace LabWork2.Solution
{
    interface ICypher
    {
        string Encrypt(string text, int key = 13);
        string Decrypt(string text, int key = 13);
    }
}
