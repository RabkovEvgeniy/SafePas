using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptLib;
using System;

namespace EncryptLibTest
{
    [TestClass]
    public class EncryptionKeyTests
    {
        [TestMethod]
        public void ValueSetTest()
        {
            //Arrange
            EncryptionKey key = new EncryptionKey();

            int[] minNormalKeyValue = new int[100];
            int[] maxNormalKeyValue = new int[100];
            int[] nonValidNormalKeyValue = new int[100];
            int[] nonValidSizeKeyValue = new int[10];

            bool minNormalKeyValueException = false;
            bool maxNormalKeyValueException = false;
            bool nonValidNormalKeyValueException = false;
            bool nonValidSizeKeyValueException = false;

            for (int i = 0; i < 100; i++)
            {
                minNormalKeyValue[i] = 0;
                maxNormalKeyValue[i] = 1103;
                nonValidNormalKeyValue[i] = 1104;
            }

            //Act
            try
            {
                key.Value = minNormalKeyValue;
            }
            catch (Exception) 
            {
                minNormalKeyValueException = true;
            }

            try
            {
                key.Value = maxNormalKeyValue;
            }
            catch (Exception)
            {
                maxNormalKeyValueException = true;
            }

            try
            {
                key.Value = nonValidNormalKeyValue;
            }
            catch (Exception)
            {
                nonValidNormalKeyValueException = true;
            }

            try
            {
                key.Value = nonValidSizeKeyValue;
            }
            catch (Exception)
            {
                nonValidSizeKeyValueException = true;
            }

            //Arrange
            Assert.IsFalse(minNormalKeyValueException);
            Assert.IsFalse(maxNormalKeyValueException);
            Assert.IsTrue(nonValidNormalKeyValueException);
            Assert.IsTrue(nonValidSizeKeyValueException);
        }
    }
}
