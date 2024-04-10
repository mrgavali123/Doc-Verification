using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;
namespace AutoGenerateCertificate
{

    class Utils
    {
        public static int logflg = 0;
        public static int formno = 0;
        public static string calculateHash(String data)
        {
           

                byte[] bytes = Encoding.ASCII.GetBytes(data);
                byte[] buffer = new byte[bytes.Length];
                FileStream stream;
                int readCount;
                HashAlgorithm algorithm = SHA1.Create();
                algorithm.TransformBlock(bytes, 0, bytes.Length, buffer, 0);
                algorithm.TransformFinalBlock(buffer, 0, bytes.Length);
                string result = System.BitConverter.ToString(algorithm.Hash).Replace("-", "");
                return result;
         
        }
    }
}
