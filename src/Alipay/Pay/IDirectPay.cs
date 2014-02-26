using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pay
{
    /// <summary>
    /// 提供即时到帐功能。
    /// </summary>
    public interface IDirectPay
    {
        /// <summary>
        /// 创建并返回即时到帐 Url。
        /// </summary>
        /// <param name="out_trade_no">商户订单号。</param>
        /// <param name="subject">商品名称。</param>
        /// <param name="body">商品描述。</param>
        /// <param name="total_fee">订单总金额。</param>
        /// <param name="clientIPAddress">用户 IP。</param>
        /// <returns></returns>
        string CreateUrl(string out_trade_no, string subject, string body, 
            double total_fee, string clientIPAddress);
    }
}
