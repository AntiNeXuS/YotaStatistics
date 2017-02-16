using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YotaStat;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly string GoodInput = 
            @"State=Connected
WebGuiUrl=http://status.yota.ru
UpdateState=NotStarted\nUpdateProgress=0\nSupportsConnectDisabling=0\n3GPP.SINR=7\n3GPP.RSSI=-99\n3GPP.RSRP=-108\n3GPP.RSRQ=-11\n3GPP.MCC=250\n3GPP.MNC=11\n3GPP.PLMN=25011\n3GPP.RoamingStatus=0\n3GPP.CGI=25011AAEBD00\n3GPP.CI=AAEBD00\n3GPP.eNBID=AAEBD\n3GPP.HNBN=\n3GPP.CSGT=\n3GPP.CenterFreq=2975000\n3GPP.TxPWR=23\n3GPP.SPN=Yota\n3GPP.IsIdle=1\nConnectedTime=2175\nSessionID=17\nSentBytes=51546867\nReceivedBytes=1146943612\nMaxDownlinkThroughput=10428\nMaxUplinkThroughput=1238\nCurDownlinkThroughput=3\nCurUplinkThroughput=2\nTotalHandoversCount=31\nSucceededHandoversCount=0\nIsReadyForUpdate=0\nIP=10.206.243.27\nSubnetMask=255.0.0.0\nDefaultGateway=10.206.243.1\nDHCP=10.0.0.1\nDNS=83.149.49.44,83.149.49.36\n";

        [TestMethod]
        public void ParserTest1()
        {
            var result = Parser.Parse(GoodInput);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ParserTest2()
        {
            var result = Parser.Parse(GoodInput);
            Assert.AreEqual("Connected", result.State);
            Assert.AreEqual("10.206.243.27", result.IP);
            Assert.AreEqual(7, result.SINR);
            Assert.AreEqual(-99, result.RSSI);
            Assert.AreEqual(-108, result.RSRP);
            Assert.AreEqual(-11, result.RSRQ);
            Assert.AreEqual(250, result.MCC);
            Assert.AreEqual(11, result.MNC);
            Assert.AreEqual(25011, result.PLMN);
            Assert.AreEqual(23, result.TxPWR);
            Assert.AreEqual(17, result.SessionID);
            Assert.AreEqual(2175, result.ConnectedTime);
            Assert.AreEqual(51546867, result.SentBytes);
            Assert.AreEqual(1146943612, result.ReceivedBytes);
            Assert.AreEqual(10428, result.MaxDownlinkThroughput);
            Assert.AreEqual(1238, result.MaxUplinkThroughput);
            Assert.AreEqual(3, result.CurDownlinkThroughput);
            Assert.AreEqual(2, result.CurUplinkThroughput);
        }
    }
}
