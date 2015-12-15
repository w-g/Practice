using System;
using System.Linq;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;

namespace Sediment.Common
{
    /// <summary>
    /// AES对称加密(256位)
    /// </summary>
    public class AES
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptStr">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static string Encrypt(string encryptStr, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(encryptStr);

            var aes = new AesManaged();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 256;
            aes.Key = keyArray.Take(32).ToArray();

            var resultArray = aes.CreateEncryptor().TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 加密（使用MachineKey做密钥）
        /// </summary>
        /// <param name="encryptStr">明文</param>
        /// <returns>密文</returns>
        public static string Encrypt(string encryptStr)
        {
            MachineKeySection section = (MachineKeySection)ConfigurationManager.GetSection("system.web/machineKey");

            return Encrypt(encryptStr, section.DecryptionKey);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static string Decrypt(string decryptStr, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(decryptStr);

            var aes = new AesManaged();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 256;
            aes.Key = keyArray.Take(32).ToArray();

            byte[] resultArray = aes.CreateDecryptor().TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// 解密（使用MachineKey做密钥）
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <returns>明文</returns>
        public static string Decrypt(string decryptStr)
        {
            MachineKeySection section = (MachineKeySection)ConfigurationManager.GetSection("system.web/machineKey");

            return Decrypt(decryptStr, section.DecryptionKey);
        }
    }
}
