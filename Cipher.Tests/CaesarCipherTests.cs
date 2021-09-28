using NUnit.Framework;

namespace Cipher.Tests
{
    [TestFixture]
    public class CaesarCipherTests
    {
        [Test]
        public void Encrypt_WithEmptyMessage_ReturnsEmptyEncryptedMessage()
        {
            //Arrange
            string message = "";
            int key = 5;
            ICipher cipher = new CaesarCipher(key);
            string expectedEncryptedMessage = "";

            //Act
            string actualEncryptedMessage = cipher.Encrypt(message);

            //Assert
            Assert.AreEqual(expectedEncryptedMessage, actualEncryptedMessage);
        }

        [Test]
        public void Encrypt_WithoutOverflow_ReturnsEncryptedUppercaseMessage()
        {
            //Arrange
            string message = "abcdef";
            int key = 5;
            ICipher cipher = new CaesarCipher(key);
            string expectedEncryptedMessage = "fghijk";

            //Act
            string actualEncryptedMessage = cipher.Encrypt(message);

            //Assert
            Assert.AreEqual(expectedEncryptedMessage.ToUpper(), actualEncryptedMessage);
        }

        [Test]
        public void Encrypt_WithOverflow_ReturnsEncryptedUppercaseMessage()
        {
            //Arrange
            string message = "abcdef";
            int key = 31;
            ICipher cipher = new CaesarCipher(key);
            string expectedEncryptedMessage = "fghijk";

            //Act
            string actualEncryptedMessage = cipher.Encrypt(message);

            //Assert
            Assert.AreEqual(expectedEncryptedMessage.ToUpper(), actualEncryptedMessage);
        }

        [Test]
        public void Encrypt_WithNegativeKey_ReturnsEncryptedUppercaseMessage()
        {
            //Arrange
            string message = "abcdef";
            int key = -5;
            ICipher cipher = new CaesarCipher(key);
            string expectedEncryptedMessage = "vwxyza";

            //Act
            string actualEncryptedMessage = cipher.Encrypt(message);

            //Assert
            Assert.AreEqual(expectedEncryptedMessage.ToUpper(), actualEncryptedMessage);
        }

        [Test]
        public void Decrypt_WithEmptyMessage_ReturnsEmptyDecryptedMessage()
        {
            //Arrange
            string message = "";
            int key = 5;
            ICipher cipher = new CaesarCipher(key);
            string expectedDecryptedMessage = "";

            //Act
            string actualDecryptedMessage = cipher.Decrypt(message);

            //Assert
            Assert.AreEqual(expectedDecryptedMessage, actualDecryptedMessage);
        }
        
        [Test]
        public void Decrypt_WithoutOverflow_ReturnsDecryptedUppercaseMessage()
        {
            //Arrange
            string message = "fghijk";
            int key = 5;
            ICipher cipher = new CaesarCipher(key);
            string expectedDecryptedMessage = "abcdef";

            //Act
            string actualDecryptedMessage = cipher.Decrypt(message);

            //Assert
            Assert.AreEqual(expectedDecryptedMessage.ToUpper(), actualDecryptedMessage);
        }

        [Test]
        public void Decrypt_WithOverflow_ReturnsDecryptedUppercaseMessage()
        {
            //Arrange
            string message = "fghijk";
            int key = 31;
            ICipher cipher = new CaesarCipher(key);
            string expectedDecryptedMessage = "abcdef";

            //Act
            string actualDecryptedMessage = cipher.Decrypt(message);

            //Assert
            Assert.AreEqual(expectedDecryptedMessage.ToUpper(), actualDecryptedMessage);
        }

        [Test]
        public void Decrypt_WithNegativeKey_ReturnsDecryptedUppercaseMessage()
        {
            //Arrange
            string message = "vwxyza";
            int key = -5;
            ICipher cipher = new CaesarCipher(key);
            string expectedDecryptedMessage = "abcdef";

            //Act
            string actualDecryptedMessage = cipher.Decrypt(message);

            //Assert
            Assert.AreEqual(expectedDecryptedMessage.ToUpper(), actualDecryptedMessage);
        }

        [Test]
        public void EncryptAndDecrypt_WithNotNegativeKey_ReturnsSameUppercaseMessage()
        {
            //Arrange
            string message = "Hello world! It's me :)";
            int key = 7;
            ICipher cipher = new CaesarCipher(key);

            //Act
            string encryptedMessage = cipher.Encrypt(message);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            //Assert
            Assert.AreEqual(message.ToUpper(), decryptedMessage);
        }

        [Test]
        public void EncryptAndDecrypt_WithNegativeKey_ReturnsSameUppercaseMessage()
        {
            //Arrange
            string message = "Hello world! It's me :)";
            int key = -7;
            ICipher cipher = new CaesarCipher(key);

            //Act
            string encryptedMessage = cipher.Encrypt(message);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            //Assert
            Assert.AreEqual(message.ToUpper(), decryptedMessage);
        }
    }
}