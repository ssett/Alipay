using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Services;
using Alipay.Config;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝即时到帐和纯网关接口的服务器异步通知。
    /// </summary>
    public abstract class DirectPayNotifyBase : PayNotifyBase, ISign, INotify
    {
        /// <summary>
        /// 初始化 Alipay.DirectPay.DirectPayNotifyBase 类的新实例。
        /// </summary>
        /// <param name="service">通知请求验证服务。</param>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public DirectPayNotifyBase(INotifyService service,
            IDictionary<string, string> parameters, AlipayConfig config)
            : base(service, parameters, config)
        {
        }

        /// <summary>
        /// 获取交易关闭时间。
        /// </summary>
        public DateTime? GmtClose
        {
            get { return this.GetNullableDateTime("gmt_close"); }
        }

        /// <summary>
        /// 获取公用回传参数。
        /// </summary>
        public string ExtraCommonParam
        {
            get { return this.GetString("extra_common_param"); }
        }

        /// <summary>
        /// 获取支付渠道组合信息。
        /// </summary>
        public string OutChannelType
        {
            get { return this.GetString("out_channel_type"); }
        }

        /// <summary>
        /// 获取支付金额组合信息。
        /// </summary>
        public string OutChannelAmount
        {
            get { return this.GetString("out_channel_amount"); }
        }

        /// <summary>
        /// 获取实际支付渠道。
        /// </summary>
        public string OutChannelInst
        {
            get { return this.GetString("out_channel_inst"); }
        }

    }
}
