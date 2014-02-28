using Alipay;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Alipay.DirectPay;

namespace Alipay.Tests
{
    [TestClass]
    public class AlipayRequestTest
    {

        [TestMethod]
        public void Create_DirectPay_Url()
        {
            var config = new DirectPayConfig
            {
                Partner = "2088101568338364",
                Key = "7d314d22efba4f336fb187697793b9d2",
                ReturnUrl = "http://api.test.alipay.net/atinterface/receive_return.htm",
                NotifyUrl = "http://api.test.alipay.net",
                ErrorNotifyUrl = "http://api.test.alipay.net/atinterface/receive_error_notify.htm",
                SignType = "MD5",
            };

            var request = new DirectPayRequest(config)
            {
                Subject = "贝尔金护腕式",
                Body = "美国专业护腕鼠标垫,舒缓式凝胶软垫模拟手腕的自然曲线和运动，创造和缓的GelFlex舒适地带!",
                ExtendParam = "pnr^MFGXDW|start_ticket_no^123|end_ticket_no^234|b2b_login_name^abc",
                OutTradeNo = "6741334835157966",
                TotalFee = 100,
                SellerEmail = "alipay-test01@alipay.com",
                BuyerEmail = "tstable01@alipay.com"
            };

            //var pay = new AliDirectPay(config);

            var url = request.CreateUrl();//pay.CreateUrl(request);

            Assert.AreEqual("http://www.alipay.com/cooperate/gateway.do?_input_charset=utf-8&body=%e7%be%8e%e5%9b%bd%e4%b8%93%e4%b8%9a%e6%8a%a4%e8%85%95%e9%bc%a0%e6%a0%87%e5%9e%ab%2c%e8%88%92%e7%bc%93%e5%bc%8f%e5%87%9d%e8%83%b6%e8%bd%af%e5%9e%ab%e6%a8%a1%e6%8b%9f%e6%89%8b%e8%85%95%e7%9a%84%e8%87%aa%e7%84%b6%e6%9b%b2%e7%ba%bf%e5%92%8c%e8%bf%90%e5%8a%a8%ef%bc%8c%e5%88%9b%e9%80%a0%e5%92%8c%e7%bc%93%e7%9a%84GelFlex%e8%88%92%e9%80%82%e5%9c%b0%e5%b8%a6!&buyer_email=tstable01%40alipay.com&error_notify_url=http%3a%2f%2fapi.test.alipay.net%2fatinterface%2freceive_error_notify.htm&extend_param=pnr%5eMFGXDW%7cstart_ticket_no%5e123%7cend_ticket_no%5e234%7cb2b_login_name%5eabc&notify_url=http%3a%2f%2fapi.test.alipay.net&out_trade_no=6741334835157966&partner=2088101568338364&payment_type=1&return_url=http%3a%2f%2fapi.test.alipay.net%2fatinterface%2freceive_return.htm&seller_email=alipay-test01%40alipay.com&service=create_direct_pay_by_user&sign=287b991f2cfbd6e9156345cc7a23391b&sign_type=MD5&subject=%e8%b4%9d%e5%b0%94%e9%87%91%e6%8a%a4%e8%85%95%e5%bc%8f&total_fee=100", 
                url);
        }
    }
}
