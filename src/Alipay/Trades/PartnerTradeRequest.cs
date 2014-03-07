using Alipay.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.Trades
{
    /// <summary>
    /// 表示支付宝 纯担保交易 的支付请求。
    /// </summary>
    public class PartnerTradeRequest : TradeRequestBase, ISign
    {
        static readonly string ServiceName = "create_partner_trade_by_buyer";

        /// <summary>
        /// 创建 Alipay.Trades.AlipayPartnerTradeRequest 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public PartnerTradeRequest(AlipayConfig config)
            : base(config)
        {
            this.Service = PartnerTradeRequest.ServiceName;
        }
    }
}
