// /****************************** YotaStat ******************************\
// Project:            YotaStat
// Filename:           Parser.cs
// Created:            10.02.2017
// 
// <summary>
// 
// </summary>
// \***************************************************************************/

using System;

namespace YotaStat
{
    public class Parser
    {
        public static Data Parse(string rawData)
        {
            var result =  new Data();

            result.State = ParseString(rawData, nameof(result.State));
            result.IP = ParseString(rawData, nameof(result.IP));
            result.SINR = ParseInt(rawData, nameof(result.SINR));
            result.RSSI = ParseInt(rawData, nameof(result.RSSI));
            result.RSRP = ParseInt(rawData, nameof(result.RSRP));
            result.RSRQ = ParseInt(rawData, nameof(result.RSRQ));
            result.MCC = ParseInt(rawData, nameof(result.MCC));
            result.MNC = ParseInt(rawData, nameof(result.MNC));
            result.PLMN = ParseInt(rawData, nameof(result.PLMN));
            result.TxPWR = ParseInt(rawData, nameof(result.TxPWR));
            result.SessionID = ParseInt(rawData, nameof(result.SessionID));
            result.ConnectedTime = ParseLong(rawData, nameof(result.ConnectedTime));
            result.SentBytes = ParseLong(rawData, nameof(result.SentBytes));
            result.ReceivedBytes = ParseLong(rawData, nameof(result.ReceivedBytes));
            result.MaxDownlinkThroughput = ParseLong(rawData, nameof(result.MaxDownlinkThroughput));
            result.MaxUplinkThroughput = ParseLong(rawData, nameof(result.MaxUplinkThroughput));
            result.CurDownlinkThroughput = ParseLong(rawData, nameof(result.CurDownlinkThroughput));
            result.CurUplinkThroughput = ParseLong(rawData, nameof(result.CurUplinkThroughput));

            return result;
        }

        private static int ParseInt(string rawData, string name)
        {
            var str = ParseString(rawData, name);
            if (str == string.Empty) return 0;

            return int.Parse(str);
        }

        private static long ParseLong(string rawData, string name)
        {
            var str = ParseString(rawData, name);
            if (str == string.Empty) return 0;

            return long.Parse(str);
        }

        private static string ParseString(string rawData, string name)
        {
            var start = rawData.IndexOf(name);
            if (start == -1) return string.Empty;

            start += name.Length + 1;
            var end = rawData.Substring(start).IndexOf('\n');
            if (end == -1) return string.Empty;

            return rawData.Substring(start, end);
        }
    }
}