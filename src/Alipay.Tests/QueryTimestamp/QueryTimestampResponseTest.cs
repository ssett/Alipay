using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Alipay.QueryTimestamp.Tests
{
    [TestClass]
    public class QueryTimestampResponseTest
    {
        [TestMethod]
        public void EncryptKey()
        {
            var actual = "6402757654153618";
            var xml = new XDocument(
                new XElement("alipay",
                    new XElement("is_success", "T"),
                    new XElement("request",
                        new XElement("param", "query_timestamp", 
                            new XAttribute("name", "service")),
                        new XElement("param", "2088101568338364",
                            new XAttribute("name", "partner"))),
                    new XElement("response",
                        new XElement("timestamp",
                            new XElement("encrypt_key", actual))),
                    new XElement("sign", "95be39886ad81e947bf0afce89c96e11"),
                    new XElement("sign_type", "MD5"))
                );
            
            var response = new QueryTimestampResponse(xml.ToString());

            Assert.AreEqual(actual, response.EncryptKey);
        }
    }
}
