using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Validators;
using Alipay.Config;

namespace Alipay.Auth
{
    /// <summary>
    /// 表示支付宝快速登录请求。
    /// </summary>
    public class AuthorizeRequest : RequestBase, ISign
    {
        static readonly string ServiceName = "alipay.auth.authorize";
        static readonly string TargetServiceName = "user.auth.quick.login";
        static readonly string gateway = "https://mapi.alipay.com/gateway.do?";

        /// <summary>
        /// 初始化 Alipay.Auth.AuthorizeRequest 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public AuthorizeRequest(AlipayConfig config)
            : base(config)
        {
            this.Service = AuthorizeRequest.ServiceName;
            this.TargetService = AuthorizeRequest.TargetServiceName;
        }

        /// <summary>
        /// 初始化 Alipay.Auth.AlipayFastLoginRequest 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        /// <param name="returnUrl">页面跳转同步通知页面路径。</param>
        public AuthorizeRequest(AlipayConfig config, string returnUrl)
            : this(config)
        {
            this.ReturnUrl = returnUrl;
        }


        /// <summary>
        /// 获取支付宝网关地址。
        /// </summary>
        public override string Gateway
        {
            get { return gateway; }
        }

        /// <summary>
        /// 获取目标服务地址。
        /// </summary>
        [Required("target_service")]
        public string TargetService
        {
            get { return this.GetString("target_service"); }
            private set { this.Set("target_service", value); }
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

        /// <summary>
        /// 获取或设置客户端 IP。用户在创建交易时，该用户当前所使用机器的IP 。
        /// 如果商户申请后台开通防钓鱼IP地址检查选项，此字段必填，校验用。
        /// </summary>
        public string ExterInvokeIP
        {
            get { return this.GetString("exter_invoke_ip"); }
            set { this.Set("exter_invoke_ip", value, 15); }
        }

    }
}
