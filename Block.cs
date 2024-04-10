using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
namespace AutoGenerateCertificate.util
{
   class Block
    {
        String prevhash, hash, timestamp;
        
        string iscurrupted;
        TransferCertPojo transferPojo;
        public string Prevhash { get => prevhash; set => prevhash = value; }
        public string Hash { get => hash; set => hash = value; }

        public string Timestamp { get => timestamp; set => timestamp = value; }
        public string Iscurrupted { get => iscurrupted; set => iscurrupted = value; }
        public TransferCertPojo TransferPojo { get => transferPojo; set => transferPojo = value; }
      
        public Block()
        {

        }
        public Block(String prevhash, String timestamp, TransferCertPojo tcp)
        {
            this.Prevhash = prevhash + "";

            this.Timestamp = timestamp;

            this.transferPojo = tcp;
            this.Hash = Block.calculateHash(this);


        }
        public static string calculateHash(Block block)
        {
            if (block != null)
            {

                String data = block.transferPojo.Name + block.Prevhash + block.transferPojo.Nationality+block.transferPojo.Religion+block.transferPojo.Caste+ block.Timestamp;

                byte[] bytes = Encoding.ASCII.GetBytes(data);
                byte[] buffer = new byte[bytes.Length];
                FileStream stream;
                int readCount;
                HashAlgorithm algorithm = SHA256.Create();


                algorithm.TransformBlock(bytes, 0, bytes.Length, buffer, 0);

                algorithm.TransformFinalBlock(buffer, 0, bytes.Length);
                string result = System.BitConverter.ToString(algorithm.Hash).Replace("-", "");
                return result;
            }
            return null;
        }

    }
}
