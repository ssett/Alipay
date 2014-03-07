using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Config;

namespace Alipay.Trades
{
    /// <summary>
    /// 表示支付宝标准双接口的页面跳转返回结果。
    /// </summary>
    public class TradeReturn : TradeReturnBase, ISign
    {
        /// <summary>
        /// 初始化 Alipay.Trades.AlipayTradeReturn 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public TradeReturn(AlipayConfig config)
            : base(config)
        {
            
        }

        /// <summary>
        /// 获取商品展示网址。
        /// </summary>
        public string ShowUrl
        {
            get { return this.GetString("show_url"); }
        }

    }
}
