using System;
using LabWork2.Solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding_DecodingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Rot13Encoding()
        {
            string text = "Hello";
            ICipher cipher = new Сiphers();
            string expected = "Uryyb";
            string actual = cipher.Encrypt(text);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Rot13Decoding()
        {
            string text = "Uryyb";
            ICipher cipher = new Сiphers();
            string expected = "Hello";
            string actual = cipher.Decrypt(text);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CaesarEncoding()
        {
            string text = "Hi there";
            ICipher cipher = new Сiphers();
            int key = 23;
            string expected = "Ef qebob";
            string actual = cipher.Encrypt(text, key);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CaesarDecoding()
        {
            string text = "Ef qebob";
            ICipher cipher = new Сiphers();
            int key = 23;
            string expected = "Hi there";
            string actual = cipher.Decrypt(text, key);
            Assert.AreEqual(expected, actual);
        }
    }
}
