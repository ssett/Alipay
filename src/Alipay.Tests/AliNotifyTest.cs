using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Alipay;
using System.Web;
using Alipay.DirectPay;
using Alipay.Services;

namespace Alipay.Tests
{
    [TestClass]
    public class AliNotifyTest
    {

        [TestMethod]
        public void Notify_Verify_Valid()
        {
            // Arrange
            var partner = "2088123456789012";
            var responseText = "true";
            var notifyId = "123";
            var sign = "4652a3fdd86f1544fa5f91204c2b7ac1";

            var notifyService = new FackNotifyService(() => responseText);

            var dict = new Dictionary<string, string>();
            dict.Add("notify_id", notifyId);
            dict.Add("sign", sign);

            var config = new AlipayConfig 
            {
                Partner = partner,
            };

            // Act
            var notify = new DirectPayNotify(notifyService, dict, config);            
            
            // Assert
            Assert.IsNotNull(notify);
            
            Assert.AreEqual(notifyId, notify.NotifyID);

            Assert.AreEqual(dict.Count, notify.Parameters.Count);
            Assert.AreEqual(config, notify.Config);

            Assert.AreEqual(sign, notify.GenerateSignature());
            Assert.AreEqual(true, notify.Verify());
        }

        [TestMethod]
        public void Notify_Verify_Invalid()
        {
            // Arrange
            var partner = "2088123456789012";
            var responseText = "false";
            var notifyId = "123";

            var notifyService = new FackNotifyService(() => responseText);

            var dict = new Dictionary<string, string>();
            dict.Add("notify_id", notifyId);

            var config = new AlipayConfig
            {
                Partner = partner,
            };

            // Act
            var notify = new DirectPayNotify(notifyService, dict, config);

            // Assert
            Assert.IsNotNull(notify);

            Assert.AreEqual(notifyId, notify.NotifyID);

            Assert.AreEqual(config, notify.Config);

            Assert.AreEqual(false, notify.Verify());
        }

        [TestMethod]
        public void Parse_Alipay_Notify()
        {
            var url = new Uri("http://www.xxx.com/alipay/return_url.php?is_success=T&sign=b1af584504b8e845ebe40b8e0e733729&sign_type=MD5&body=Hello&buyer_email=xinjie_xj%40163.com&buyer_id=2088101000082594&exterface=create_direct_pay_by_user&out_trade_no=6402757654153618&payment_type=1&seller_email=chao.chenc1%40alipay.com&seller_id=2088002007018916&subject=%E5%A4%96%E9%83%A8FP&total_fee=10.00&trade_no=2008102303210710&trade_status=TRADE_FINISHED&notify_id=RqPnCoPT3K9%252Fvwbh3I%252BODmZS9o4qChHwPWbaS7UMBJpUnBJlzg42y9A8gQlzU6m3fOhG&notify_time=2008-10-23+13%3A17%3A39&notify_type=tra de_status_sync&extra_common_param=%E4%BD%A0%E5%A5%BD%EF%BC%8C%E8%BF%99%E6%98%AF%E6%B5%8B%E8%AF%95%E5%95%86%E6%88%B7%E7%9A%84%E5%B9%BF%E5%91%8A%E3%80%82");
            var parameters = ParseParameters(url.Query);

            var target = new DirectPayNotify(parameters, new AlipayConfig());

            Assert.AreEqual("b1af584504b8e845ebe40b8e0e733729", target.Sign);
            Assert.AreEqual("6402757654153618", target.OutTradeNo);
            Assert.AreEqual(10d, target.TotalFee);

            // Assert - TradeInfo
            Assert.AreEqual("2008102303210710", 
                target.TradeNo);
            Assert.AreEqual(TradeStatus.TRADE_FINISHED.ToString(),
                target.TradeStatus);
            Assert.AreEqual("外部FP",
                target.Subject);
            Assert.AreEqual("Hello",
                target.Body);

            // Assert - NotifyInfo
            Assert.AreEqual("RqPnCoPT3K9%2Fvwbh3I%2BODmZS9o4qChHwPWbaS7UMBJpUnBJlzg42y9A8gQlzU6m3fOhG",
                target.NotifyID);
            Assert.AreEqual(new DateTime(2008, 10, 23, 13, 17, 39), 
                target.NotifyTime);
            Assert.AreEqual("tra de_status_sync",
                target.NotifyType);
        }

        public IDictionary<string,string> ParseParameters(string queryString)
        {
            var parameters = queryString.Split('&');
            var dict = new Dictionary<string, string>();
            foreach(var p in parameters)
            {
                var s = p.Split('=');
                dict.Add(s[0], HttpUtility.UrlDecode(s[1], System.Text.Encoding.UTF8)); 
            }
            return dict;
        }
    }

    public class FackNotifyService : INotifyService
    {
        Func<string> _returns;

        public FackNotifyService(Func<string> returns)
        {
            _returns = returns;
        }

        public string Verify(INotify notify)
        {
            return _returns.Invoke();
        }

        public int Timeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
