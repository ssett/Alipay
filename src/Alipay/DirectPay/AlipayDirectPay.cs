using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Pay.Util;
using Pay;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝即时到帐支付请求。
    /// </summary>
    public class AlipayDirectPay : IDirectPay
    {
        /// <summary>
        /// 初始化 Alipay.AlipayDirect 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public AlipayDirectPay(AlipayConfig config)
        {
            this.Config = config;
        }

        /// <summary>
        /// 获取支付宝配置。
        /// </summary>
        public AlipayConfig Config { get; private set; }

        /// <summary>
        /// 创建并返回支付宝即时到帐请求 Url。
        /// </summary>
        /// <param name="out_trade_no">商户订单号。</param>
        /// <param name="subject">商品名称。</param>
        /// <param name="body">商品描述。</param>
        /// <param name="total_fee">订单总金额，单位为元。</param>
        /// <param name="clientIPAddress">用户 IP 地址。</param>
        /// <returns></returns>
        public string CreateUrl(string out_trade_no, string subject, string body,
            double total_fee, string clientIPAddress)
        {
            var request = new AlipayDirectPayRequest(this.Config)
            {
                OutTradeNo = out_trade_no,
                Subject = subject,
                Body = body,
                TotalFee = total_fee,
                SellerID = this.Config.Partner
                //ExterInvokeIP = clientIPAddress,
            };

            return request.CreateUrl();
        }

    }
}
