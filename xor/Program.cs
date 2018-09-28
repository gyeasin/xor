using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace xor
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "383035303031303930303831313137"; //value
            string b = "313233343536373839313233343535";  //key
            

            byte[] bKeyCom1 = HexToByte(a);
            byte[] bKeyCom2 = HexToByte(b);
            int iKeyLength = bKeyCom1.Length;

            if (bKeyCom1.Length == bKeyCom2.Length)
            {
                byte[] result = new byte[bKeyCom1.Length];
                for (int i = 0; i < bKeyCom1.Length; i++)
                {
                    result[i] = (byte)(bKeyCom1[i] ^ bKeyCom2[i]);
                }
                Console.WriteLine( ByteToHex(result, iKeyLength / 2)); //8 here length of byte which means 16 hex

                //Console.WriteLine(string.Join(",", result));
            }
            else
            {
                throw new ArgumentException();
            }
        }


        public static byte[] HexToByte(String hexString)
        {
            int NoOfChars = hexString.Length;
            byte[] bytes = new byte[NoOfChars / 2];
            for (int i = 0; i < NoOfChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            return bytes;
        }

        public static string ByteToHex(byte[] bytes, Int32? length = null)
        {
            if (length != null && length > bytes.LongLength)
                throw new Exception("Length specified greater than actual data length");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < (length ?? bytes.Length); i++)
                sb.Append(bytes[i].ToString("X2"));

            return sb.ToString();
        }
    }
}
