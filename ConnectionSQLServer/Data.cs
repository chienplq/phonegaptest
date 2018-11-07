using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSQLServer
{
   public class Data
    {
        
         
     
        public  List<TuanEntity> GetData1()
        {
            List<TuanEntity> tuanList = null;
            SqlConnection conn = DBUtilsTuan.GetDBConnection();

            try
            {


                conn.Open();
                
                 tuanList = GetTuanData(conn);
                

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
            return tuanList;
        
           
        }

        public  List<NguyenEntity> GetData2()
        {
            List < NguyenEntity> nguyenList = null;
            SqlConnection conn = DBUtilsNguyen.GetDBConnection();

            try
            {


                conn.Open();
                 nguyenList = GetNguyenData(conn);
         

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
            return nguyenList;
        }
        public List<Entity> GetThisData()
        {
            List<Entity> list = null;
            SqlConnection conn = DBUtils.GetDBConnection();

            try
            {
          
                conn.Open();
                list = GetData(conn);

                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("index:" + list[i].index);
                        Console.WriteLine("preHash:" + list[i].preHash);
                        Console.WriteLine("Hash:" + list[i].hash);
                        Console.WriteLine("timeStamp:" + list[i].timeStamp);
                        Console.WriteLine("data:" + list[i].data);
                       
                    }
                }

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
            return list;
          
        }

        public  List<TuanEntity> GetTuanData(SqlConnection conn)
        {
            List<TuanEntity> tuanList = new List<TuanEntity>();
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
                        TuanEntity sever1 = new TuanEntity();
                        // Chỉ số của cột Emp_ID trong câu lệnh SQL.
                        sever1.index = reader.GetInt32(0); // 0




                        // Cột Emp_No có index = 1.

                        sever1.preHash = reader.GetString(1);
                        sever1.hash = reader.GetString(2);
                        sever1.timeStamp = reader.GetDateTime(3);
                        sever1.data = reader.GetString(4);

                        tuanList.Add(sever1);




                    }
                }
            }
            return tuanList;
        }
        public List<NguyenEntity> GetNguyenData(SqlConnection conn)
        {
            List<NguyenEntity> nguyenList = new List<NguyenEntity>();
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
                        NguyenEntity sever2 = new NguyenEntity();
                        // Chỉ số của cột Emp_ID trong câu lệnh SQL.
                        sever2.index = reader.GetInt32(0); // 0




                        // Cột Emp_No có index = 1.

                        sever2.preHash = reader.GetString(1);
                        sever2.hash = reader.GetString(2);
                        sever2.timeStamp = reader.GetDateTime(3);
                        sever2.data = reader.GetString(4);

                        nguyenList.Add(sever2);




                    }
                }
            }
            return nguyenList;
        }
        public  List<Entity> GetData(SqlConnection conn)
        {
            List<Entity> list = new List<Entity>();
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
                        Entity sever = new Entity();
                        // Chỉ số của cột Emp_ID trong câu lệnh SQL.
                        sever.index = reader.GetInt32(0); // 0




                        // Cột Emp_No có index = 1.

                        sever.preHash = reader.GetString(1);
                        sever.hash = reader.GetString(2);
                        sever.timeStamp = reader.GetDateTime(3);
                        sever.data = reader.GetString(4);

                        list.Add(sever);




                    }
                }
            }
            return list;
        }

        public void addData()
        {
            String query = "INSERT INTO blockChain (index, previousHash, hash, timestamp, data, status) values ()";

        }
    }
}
