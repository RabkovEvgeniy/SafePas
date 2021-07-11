using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptLib;
using System;

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
            const string encryptedPasswordWithWholePartDiscarded = "00000";
            string smallKeyResult, bigKeyResult;

            int[] keyValue = new int[100];
            for (int i = 0; i < 100; i++)
            {
                keyValue[i] = 1;
            }
            EncryptionKey smallKey = new EncryptionKey()
            {
                Value = keyValue
            };

            for (int i = 0; i < 100; i++)
            {
                keyValue[i] = 1103;
            }
            EncryptionKey bigKey = new EncryptionKey()
            {
                Value = keyValue
            };

            //Act
            smallKeyResult = Encoder.Encrypt(password, smallKey);
            bigKeyResult = Encoder.Encrypt(password, bigKey);

            //Assert
            Assert.AreEqual(encryptedPassword, smallKeyResult);
            Assert.AreEqual(encryptedPasswordWithWholePartDiscarded, bigKeyResult);
        }

        [TestMethod]
        public void DecryptTest()
        {
            //Arrange
            string encryptedPasswordWithWholePartDiscarded, encryptedPassword;
            const string password = "11111";
            string decryptWithSmallKeyResult, decryptWithBigKeyResult;

            int[] keyValue = new int[100];
            for (int i = 0; i < 100; i++)
            {
                keyValue[i] = 1;
            }
            EncryptionKey smallKey = new EncryptionKey()
            {
                Value = keyValue
            };

            for (int i = 0; i < 100; i++)
            {
                keyValue[i] = 1103;
            }
            EncryptionKey bigKey = new EncryptionKey()
            {
                Value = keyValue
            };

            encryptedPassword = Encoder.Encrypt(password, smallKey);
            encryptedPasswordWithWholePartDiscarded = Encoder.Encrypt(password, bigKey);

            //Act
            decryptWithSmallKeyResult = Encoder.Decrypt(encryptedPassword, smallKey);
            decryptWithBigKeyResult = Encoder.Decrypt(encryptedPasswordWithWholePartDiscarded, bigKey);

            //Assert
            Assert.AreEqual(decryptWithSmallKeyResult,password);
            Assert.AreEqual(decryptWithBigKeyResult,password);
        }
    }
}
