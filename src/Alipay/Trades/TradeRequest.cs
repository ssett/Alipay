using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;

namespace Alipay.Trades
{
    /// <summary>
    /// 表示支付宝 标准双接口 的支付请求。
    /// </summary>
    public class TradeRequest : TradeRequestBase, ISign
    {
        static readonly string ServiceName = "trade_create_by_buyer";

        /// <summary>
        /// 创建 Alipay.Trades.AlipayTradeRequest 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public TradeRequest(AlipayConfig config)
            : base(config)
        {
            this.Service = TradeRequest.ServiceName;
        }

        /// <summary>
        /// 获取或设置防钓鱼时间戳。通过时间戳查询接口获取的加密支付宝系统时间戳。
        /// 如果已申请开通防钓鱼时间戳验证，则此字段必填。
        /// </summary>
        public string AntiPhishingKey
        {
            get { return this.GetString("anti_phishing_key"); }
            set { this.Set("anti_phishing_key", value); }
        }
    }
}
