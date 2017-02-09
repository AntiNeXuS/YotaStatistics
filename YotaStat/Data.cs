// /****************************** YotaStat ******************************\
// Project:            YotaStat
// Filename:           Data.cs
// Created:            10.02.2017
// 
// <summary>
// 
// </summary>
// \***************************************************************************/

using System;

namespace YotaStat
{
    public class Data
    {
        public DateTime Date { get; set; }

        public string State { get; set; }
        public string IP { get; set; }
        public int SINR { get; set; }
        public int RSSI { get; set; }
        public int RSRP { get; set; }
        public int RSRQ { get; set; }
        public int MCC { get; set; }
        public int MNC { get; set; }
        public int PLMN { get; set; }
        public int TxPWR { get; set; }
        public int SessionID { get; set; }
        public long ConnectedTime { get; set; }
        public long SentBytes { get; set; }
        public long ReceivedBytes { get; set; }
        public long MaxDownlinkThroughput { get; set; }
        public long MaxUplinkThroughput { get; set; }
        public long CurDownlinkThroughput { get; set; }
        public long CurUplinkThroughput { get; set; }
    }
}