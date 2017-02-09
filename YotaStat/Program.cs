using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using FluentScheduler;
using LiteDB;

namespace YotaStat
{
    class Program
    {
        private static string _address = "http://status.yota.ru/status";
        private static string _testDb = "testdb.db";

        static void Main(string[] args)
        {
            var reg = new Registry();
            reg.Schedule(GetData).ToRunEvery(5).Seconds();
            
            JobManager.Initialize(reg);
            
            Console.ReadKey();
        }

        static void GetData()
        {
            Data data;
            try
            {
                var client = new WebClient();
                var rawBytes = client.DownloadData(_address);
                var rawData = Encoding.ASCII.GetString(rawBytes);

                data = Parser.Parse(rawData);

                Console.WriteLine($"D: {data.CurDownlinkThroughput} U: {data.CurUplinkThroughput}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error parse data!" + Environment.NewLine + e.Message);
                return;
            }

            try
            {
                using (var db = new LiteDatabase(_testDb))
                {
                    var col = db.GetCollection<Data>("data");
                    data.Date = DateTime.Now;
                    col.Insert(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error write data to DB." + Environment.NewLine + e.Message);
            }
        }
    }
}
