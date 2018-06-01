using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork2.Solution
{
    public class Сiphers : ICipher
    {
        string alf = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
        string alfphabet = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя";
        string numbers = "0123456789";


        public string Encrypt(string text, int key=13)
        {
            string encrypted = "";
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (text[i] == alfphabet[j])
                    {
                        int temp = j + key * 2;
                        while (temp >= alfphabet.Length)
                            temp -= alfphabet.Length;
                        encrypted += alfphabet[temp];
                        continue;
                    }
                }
                for (int j = 0; j < alf.Length; j++)
                {
                    if (text[i] == alf[j])
                    {
                        int temp = j + 2 * key;
                        while (temp >= alf.Length)
                            temp -= alf.Length;
                        encrypted += alf[temp];
                        continue;
                    }
                }
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (text[i] == numbers[j])
                    {
                        int temp = j + key;
                        while (temp >= numbers.Length)
                            temp -= numbers.Length;
                        encrypted += numbers[temp];
                        continue;
                    }
                }
                if (!alf.Contains(text[i]) && !alfphabet.Contains(text[i]) && 
                    !numbers.Contains(text[i]))
                {
                    encrypted += text[i];
                }
            }
            return encrypted;
        }
        public string Decrypt(string text, int key=13)
        {
            string encrypted = "";
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (text[i] == alfphabet[j])
                    {
                        int temp = j + alfphabet.Length - key*2;
                        while (temp >= alfphabet.Length)
                            temp -= alfphabet.Length;
                        encrypted += alfphabet[temp];
                        continue;
                    }
                }
                for (int j = 0; j < alf.Length; j++)
                {
                    if (text[i] == alf[j])
                    {
                        int temp = j + alf.Length - key*2;
                        while (temp >= alf.Length)
                            temp -= alf.Length;
                        encrypted += alf[temp];
                        continue;
                    }
                }
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (text[i] == numbers[j])
                    {
                        int temp = j + 3;
                        while (temp >= numbers.Length)
                            temp -= numbers.Length;
                        encrypted += numbers[temp];
                        continue;
                    }
                }
                if (!alf.Contains(text[i]) && !alfphabet.Contains(text[i]) &&
                    !numbers.Contains(text[i]))
                {
                    encrypted += text[i];
                }
            }
            return encrypted;
        }
    }
}
