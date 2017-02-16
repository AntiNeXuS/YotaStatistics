// /****************************** YotaStat ******************************\
// Project:            Client
// Filename:           DataLoader.cs
// Created:            16.02.2017
// 
// <summary>
// 
// </summary>
// \***************************************************************************/

using System;
using System.Net;
using System.Text;
using FluentScheduler;
using LiteDB;
using YotaStat;

namespace Client.DataLoader
{
    public class DataLoader
    {
        private string _address = "http://status.yota.ru/status";
        private string _testDb = "testdb.db";
        private readonly WebClient _client = new WebClient();

        private int legend = 0;

        private int interval = 2;

        public void Start()
        {
            var reg = new Registry();
            reg.Schedule(GetData).ToRunEvery(interval).Seconds();

            JobManager.Initialize(reg);
        }

        public Action<Data> OnGetData;

        private void GetData()
        {
            Data data;
            try
            {
                var rawBytes = _client.DownloadData(_address);
                var rawData = Encoding.ASCII.GetString(rawBytes);

                data = Parser.Parse(rawData);
                OnGetData?.Invoke(data);
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error parse data!" + Environment.NewLine + e.Message);
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
                //Console.WriteLine("Error write data to DB." + Environment.NewLine + e.Message);
            }
        }
    }
}