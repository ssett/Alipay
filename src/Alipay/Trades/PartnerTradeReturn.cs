using Alipay.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.Trades
{
    /// <summary>
    /// 表示支付宝纯担保交易页面跳转的返回结果。
    /// </summary>
    public class PartnerTradeReturn : TradeReturnBase, ISign
    {
        /// <summary>
        /// 初始化 Alipay.Trades.AlipayPartnerTradeReturn 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public PartnerTradeReturn(AlipayConfig config)
            : base(config)
        {

        }
    }
}
