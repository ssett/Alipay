using Alipay.Config;
using Alipay.Notifications;
using Alipay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.Trades
{
    /// <summary>
    /// 表示支付宝标准双接口的服务器异步通知。
    /// </summary>
    public class TradeNotify : TradeNofityBase, ISign, INotify
    {       
        
        /// <summary>
        /// 初始化 Alipay.Trades.TradeNotify 类的新实例。
        /// </summary>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public TradeNotify(
            IDictionary<string, string> parameters, AlipayConfig config)
            : this(new NotifyService(config), parameters, config)
        {
            
        }

        /// <summary>
        /// 初始化 Alipay.Trades.TradeNotify 类的新实例。
        /// </summary>
        /// <param name="service">通知请求验证服务。</param>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public TradeNotify(INotifyService service, 
            IDictionary<string, string> parameters, AlipayConfig config)
            : base(service, parameters, config)
        {
        }

    }
}
