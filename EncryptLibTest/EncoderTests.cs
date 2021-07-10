using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EncryptLib;

namespace EncryptLibTests
{
    [TestClass]
    public class EncoderTests
    {
        [TestMethod]
        public void EncryptTest()
        {
            //Arrange
            const string password = "11111";
            const string encryptedPassword = "22222";
            string result;

            int[] keyValue = new int[100];
            for (int i = 0; i < 100; i++)
            {
                keyValue[i] = 1;
            }
            EncryptionKey key = new EncryptionKey()
            {
                Value = keyValue
            };

            //Act
            result = Encoder.Encrypt(password, key);

            //Assert
            Assert.AreEqual(encryptedPassword, result);
        }
    }
}
