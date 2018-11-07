using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
namespace ConnectionSQLServer
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine(checkData());
            Console.Read();
        }

        private static Boolean checkData()
        {
            var data = new Data();
            var list1 = data.GetThisData();
            var data1 = new Data();
            var list2 = data1.GetData1();
            if (list1.Count != list2.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    if (list1[i].index != list2[i].index && list1[i].preHash != list2[i].preHash && list1[i].hash != list2[i].hash
                        && list1[i].timeStamp != list2[i].timeStamp && list1[i].data != list2[i].data)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
       
    }
}
