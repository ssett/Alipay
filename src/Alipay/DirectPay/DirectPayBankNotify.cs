using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Services;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝纯网关接口的服务器异步通知。
    /// </summary>
    public class DirectPayBankNotify : DirectPayNotifyBase, ISign, INotify
    {
        /// <summary>
        /// 初始化 Alipay.DirectPay.DirectPayBankNotify 类的新实例。
        /// </summary>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public DirectPayBankNotify(
            IDictionary<string, string> parameters, AlipayConfig config)
            : this(new NotifyService(config), parameters, config)
        {
            
        }

        /// <summary>
        /// 初始化 Alipay.DirectPay.DirectPayBankNotify 类的新实例。
        /// </summary>
        /// <param name="service">通知请求验证服务。</param>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public DirectPayBankNotify(INotifyService service, 
            IDictionary<string, string> parameters, AlipayConfig config)
            : base(service, parameters, config)
        {
        }

        /// <summary>
        /// 获取错误代码。
        /// </summary>
        public string ErrorCode
        {
            get { return this.GetString("error_codes"); }
        }

        /// <summary>
        /// 获取网银流水。
        /// </summary>
        public string BankSeqNo
        {
            get { return this.GetString("bank_seq_no"); }
        }

    }
}
