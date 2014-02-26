using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using Alipay.Validators;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝即时到帐服务器异步通知。
    /// </summary>
    public class DirectPayNotify : DirectPayNotifyBase, ISign, INotify
    {

        /// <summary>
        /// 初始化 Alipay.DirectPay.DirectPayNotify 类的新实例。
        /// </summary>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public DirectPayNotify(
            IDictionary<string, string> parameters, AlipayConfig config)
            : this(new NotifyService(config), parameters, config)
        {
            
        }

        /// <summary>
        /// 初始化 Alipay.DirectPay.DirectPayNotify 类的新实例。
        /// </summary>
        /// <param name="service">通知请求验证服务。</param>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public DirectPayNotify(INotifyService service, 
            IDictionary<string, string> parameters, AlipayConfig config)
            : base(service, parameters, config)
        {
        }

    }

}
