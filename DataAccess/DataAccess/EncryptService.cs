using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Suzsoft.Smart.Data
{
    public class EncryptService
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// 使用固定密钥加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <returns>密文</returns>
        public static string SEncrypt(string encryptString)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes("Suzsoft1");
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// 使用固定密钥解密数据
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <returns>明文</returns>
        public static string SDecrypt(string decryptString)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes("Suzsoft1");
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray(), 0, mStream.ToArray().Length);
            }
            catch
            {
                return decryptString;
            }
        }
    }
}
