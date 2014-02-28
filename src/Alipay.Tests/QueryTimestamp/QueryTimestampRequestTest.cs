using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.QueryTimestamp.Tests
{
    [TestClass]
    public class QueryTimestampRequestTest
    {
        [TestMethod]
        public void Gateway()
        {
            var request = new QueryTimestampRequest(Global.Config);
            Assert.AreEqual(
                "https://mapi.alipay.com/gateway.do?",
                request.Gateway);
        }

        [TestMethod]
        public void CreateUrl_IsMatch()
        {
            var request = new QueryTimestampRequest(Global.Config);

            Assert.AreEqual(
                "https://mapi.alipay.com/gateway.do?service=query_timestamp&partner=" + Global.Config.Partner, 
                request.CreateUrl());
        }
    }
}
