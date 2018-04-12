using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork2.Solution
{
    class Caesar : ICypher
    {
        private static int numbOfMainLatinSymbols = 25;
        private static int numbOfMainCyrillicSymbols = 33;

        private static int codeOfFirstLatinSymbol = 65;
        private static int codeOfLastBigLatinSymbol = 90;
        private static int codeOfFirstSmallLatinSymbol = 97;
        private static int codeOfLastLatinSymbol = 122;

        private static int codeOfFirstCyrillicSymbol = 1040;
        private static int codeOfLastCyrillicSymbol = 1103;

        public string Encrypt(string text, int key)
        {
            string EncryptedText = "";
            foreach(char letter in text)
            {
                if (letter < codeOfLastBigLatinSymbol && letter > codeOfFirstLatinSymbol ||
                    letter< codeOfLastCyrillicSymbol && letter > codeOfFirstCyrillicSymbol || 
                    letter < codeOfLastLatinSymbol && letter > codeOfFirstSmallLatinSymbol)
                {
                    int tmp = letter + key;
                    if(tmp > codeOfLastCyrillicSymbol)
                    {
                        tmp -= numbOfMainCyrillicSymbols;
                    }
                    else if(tmp < codeOfFirstCyrillicSymbol && tmp > codeOfLastLatinSymbol)
                    {
                        tmp -= numbOfMainLatinSymbols;
                    }
                    else if(tmp < codeOfFirstSmallLatinSymbol && tmp > codeOfLastBigLatinSymbol)
                    {
                        tmp -= codeOfFirstSmallLatinSymbol - codeOfLastBigLatinSymbol;
                    }
                    EncryptedText += char.ConvertFromUtf32(tmp);
                }
                else
                {
                    EncryptedText += letter;
                }
            }
            return EncryptedText;
        }
        public string Decrypt(string text, int key)
        {
            string DecryptedText = "";
            foreach(char letter in text)
            {
                if (letter < codeOfLastBigLatinSymbol && letter > codeOfFirstLatinSymbol ||
                    letter < codeOfLastCyrillicSymbol && letter > codeOfFirstCyrillicSymbol ||
                    letter < codeOfLastLatinSymbol && letter > codeOfFirstSmallLatinSymbol)
                {
                    int tmp = letter - key;
                    if(tmp < codeOfFirstLatinSymbol)
                    {
                        tmp += numbOfMainLatinSymbols;
                    }
                    else if(tmp < codeOfFirstSmallLatinSymbol && tmp > codeOfLastBigLatinSymbol)
                    {
                        tmp += codeOfFirstSmallLatinSymbol - codeOfLastBigLatinSymbol;
                    } 
                    else if(tmp < codeOfFirstCyrillicSymbol && tmp > codeOfLastLatinSymbol)
                    {
                        tmp += numbOfMainCyrillicSymbols;
                    }
                    DecryptedText += char.ConvertFromUtf32(tmp);
                }
                else
                {
                    DecryptedText += letter;
                }
            }
            return DecryptedText;
        }
    }
}
