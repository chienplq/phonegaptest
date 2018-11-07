using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Data.Common;
using ConnectionSQLServer;

namespace DemoHash
{
    class BlockChain
    {
        static List<Block> listBlock = new List<Block>();
        static void Main(string[] args)
        {



            var md5 = MD5.Create();


            // Console.WriteLine("Lenght of a hash is: \n" + CalculateMD5Hash("hello").Length +"\n");
            Console.WriteLine("The hash string result: \n" + CalculateMD5Hash("chien dep trai") + "\n"); //1
            Console.WriteLine("The hash string result: \n" + CalculateMD5Hash("chien dep trai.") + "\n"); //2
            Console.WriteLine("The hash helo baby string result: \n" + CalculateMD5Hash("hello baby") + "\n"); //2
       
            string filName = "D:\\hash.txt";
            Console.WriteLine("The hash file co helo baby .txt result: \n" + checkMD5(filName) + "\n"); //3

            filName = "D:\\hash2.txt";
            Console.WriteLine("The hash file .txt result: \n" + checkMD5(filName) + "\n");
            filName = "D:\\123.jpeg";
            Console.WriteLine("The hash image (.jpeg) result: \n" + checkMD5(filName) + "\n"); //4


            //listBlock.Add(getGenesisBlock());

            //Block block = new Block(1, listBlock[0].hash, "", DateTime.Now, "chien");
            //block.hash = calculateHash(block);
            //listBlock[0].show();
            //if (addNewBlock(block))
            //{

            //    listBlock[1].show();
            //    listBlock[1].changeData("chien.");
            //    listBlock[1].show();
            //}
            // Console.WriteLine(block.timestamp);
            // Console.WriteLine(calculateHash(block));

            Console.Read();


        }
        //demo hash
        public static string checkMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
            //byte[] imageArray = File.ReadAllBytes(@"D:\123.jpeg");
            //Console.WriteLine(imageArray.ToString());
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
        //demo blockChain
        //hash
        public static string calculateHash(Block bl)
        {
            var input = bl.index + bl.previousHash + bl.timestamp.ToString() + bl.data + "";
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
        public static Block getGenesisBlock()
        {
            Block bl = new Block(0, "0", "", DateTime.Now, "This is the Genesis block.");
            bl.hash = calculateHash(bl);
            return bl;
        }
        public static bool isValidNewBlock(Block previousBlock, Block newBlock)
        {
            if (previousBlock.index + 1 != newBlock.index)
            {

                return false;
            }
            else if (previousBlock.hash != newBlock.previousHash)
            {

                return false;
            }
            else if (calculateHash(newBlock) != newBlock.hash)
            {

                return false;
            }


            return true;
        }
        public static Block getLastBlock()
        {
            return listBlock[listBlock.Count - 1];

        }
        public static bool addNewBlock(Block block)
        {

            if (isValidNewBlock(getLastBlock(), block))
            {

                listBlock.Add(block);
                return true;
            }
            return false;
        }
        public static bool isValidBlockChain(List<Block> listBl, string lastHash)
        {
            if (listBl[0].index != 0 || !listBl[0].previousHash.Equals('0')
                || calculateHash(listBl[0]).Equals(listBl[0].hash))
            {
                return false;
            }
            for (int i = 1; i < listBl.Count - 1; i++)
            {
                if (listBl[i].index != i) return false;
                if (listBl[i].previousHash.Equals(listBl[i - 1].hash)) return false;
                if (listBl[i].hash.Equals(calculateHash(listBl[i]))) return false;
            }
            if (!listBlock[listBlock.Count - 1].hash.Equals(lastHash)) { return false; }

            return true;
        }
        private static void QueryBlockChain(SqlConnection conn)
        {
            string sql = "Select * from block";

            // Tạo một đối tượng Command.
            SqlCommand cmd = new SqlCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;


            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // Chỉ số của cột Emp_ID trong câu lệnh SQL.
                        int index = reader.GetOrdinal("index"); // 0




                        // Cột Emp_No có index = 1.
                        string preHash = reader.GetString(1);
                        string hash = reader.GetString(2);
                        DateTime timestamp = reader.GetDateTime(3);
                        string data = reader.GetString(4);


                        Console.WriteLine("--------------------");
                        Console.WriteLine("index:" + index);
                        Console.WriteLine("prehash:" + preHash);
                        Console.WriteLine("hash:" + hash);
                        Console.WriteLine("time:" + timestamp);
                        Console.WriteLine("data:" + data);
                    }
                }
            }


        }
        private static void getBlock()
        {
            SqlConnection conn = DBUtils.GetDBConnection();

            try
            {


                conn.Open();
                QueryBlockChain(conn);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                // Đóng kết nối.
                conn.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                conn.Dispose();
            }
            Console.Read();
        }
        private static void insertBlock(Block block)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {


                conn.Open();
                string sql = "Insert into block (?,?,?,?,?) values ("+ block.index + "," +block.previousHash +"," + 
                    block.hash + "," + block.timestamp + "," + block.data + ")";
                
                // Tạo một đối tượng Command.
                SqlCommand cmd = new SqlCommand();

                // Liên hợp Command với Connection.
                cmd.Connection = conn;
                cmd.CommandText = sql;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                // Đóng kết nối.
                conn.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                conn.Dispose();
            }
            Console.Read();
        }
    }

    internal class Block
    {
        public int index;
        public string previousHash;
        public string hash;
        public DateTime timestamp;
        public string data;

        public Block(int index, string previousHash, string hash, DateTime timestamp, string data)
        {
            this.index = index;
            this.previousHash = previousHash;
            this.hash = hash;
            this.timestamp = timestamp;
            this.data = data;
        }

        public void changeData(String dt)
        {
            this.data = dt;
            this.timestamp = DateTime.Now;
          //  this.hash = calculateHash(this.Block);
        }
        public void show()
        {
            Console.WriteLine("Index: " + index + "\n PreviousHash: " + previousHash + "\n Hash: " + hash + "\n Timestap: "
                + timestamp + "\n Data: " + data);
        }
        public string calculateHash(block bl)
        {
            var input = bl.index + bl.previousHash + bl.timestamp.ToString() + bl.data + "";
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }

        public override bool Equals(object obj)
        {
            var block = obj as block;
            return block != null;
        }
    }
}
