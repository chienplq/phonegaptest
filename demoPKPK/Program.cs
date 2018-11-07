using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace demoPKPK
{
    class Program
    {
        static void Main(string[] args)
        {
            String data = "Phan Le Quang Chien cuc ky dep trai";

            String hash = CalculateMD5Hash(data);

            String Signature = PrivateKey(hash);
            //Gui di data, sigature and PubKey

            Console.WriteLine(checkDataByPK(data, Signature));

            //Truong hop data bi thay doi
            String dat = "Phan Le Quang Chien cuc ky dep tra";
            Console.WriteLine(checkDataByPK(dat, Signature));
            Console.Read();

        }
         static string PrivateKey(string str)
        {
            
            Char[] abc = str.ToArray();
            for (int i= 0; i <abc.Length; i++)
            {
                abc[i] =(char) (abc[i] + 1);
            }
            string result = new string(abc);
            return result;
        }
         static string PucblicKey(string str)
        {

            Char[] abc = str.ToArray();
            for (int i = 0; i < abc.Length; i++)
            {
                abc[i] = (char)(abc[i] +10 -121/11);
            }
            string result = new string(abc);
            return result;
        }
        static bool checkDataByPK(string data, string Signature)
        {
            if (CalculateMD5Hash(data).Equals(PucblicKey(Signature))) return true;
            
            return false;
        }

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }
    }
}
