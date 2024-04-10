using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoGenerateCertificate.pojo;

namespace AutoGenerateCertificate.util
{
    class BlockBonafide
    {
        string prevhash, hash, timestamp;
        string iscurrupted;
        BonafidePojo bonafidePojo;

        public string Prevhash { get => prevhash; set => prevhash = value; }
        public string Hash { get => hash; set => hash = value; }
        public string Timestamp { get => timestamp; set => timestamp = value; }
        public string Iscurrupted { get => iscurrupted; set => iscurrupted = value; }
        public BonafidePojo BonafidePojo { get => bonafidePojo; set => bonafidePojo = value; }

        public BlockBonafide()
        {
        }

        public BlockBonafide(string prevhash, string timestamp, BonafidePojo bonafidePojo)
        {
            this.prevhash = prevhash;
            this.timestamp = timestamp;
            this.bonafidePojo = bonafidePojo;
            this.Hash = BlockBonafide.calculateHash(this);
        }

        public static string calculateHash(BlockBonafide bf)
        {
            if (bf != null)
            {

                String data = bf.bonafidePojo.Name + bf.Prevhash + bf.bonafidePojo.Academic_year + bf.bonafidePojo.Branch + bf.bonafidePojo.Reason + bf.Timestamp;

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
            return null;
        }
    }
}
