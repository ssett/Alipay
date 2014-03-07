using Alipay.Config;
using Alipay.Extensions;
using System.Net;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝即时到帐和纯网关接口的支付请求的基类。
    /// </summary>
    public abstract class DirectPayRequestBase : PayRequestBase, ISign
    {
        static readonly string ServiceName = "create_direct_pay_by_user";

        /// <summary>
        /// 初始化 Alipay.DirectPay.AlipayDirectPayRequestBase 类的新实例。
        /// </summary>
        /// <param name="config"></param>
        public DirectPayRequestBase(AlipayConfig config)
            : base(config)
        {
            this.Service = DirectPayRequestBase.ServiceName;
        }


        #region 基本参数

        /// <summary>
        /// 获取请求出错时的通知页面路径。
        /// </summary>
        public string ErrorNotifyUrl
        {
            get { return this.GetString("error_notify_url"); }
            set { this.Set("error_notify_url", value, 200); }
        }

        #endregion

        #region 业务参数

        /// <summary>
        /// 获取或设置默认支付方式。
        /// </summary>
        public PayMethod PayMethod
        {
            get { return this.GetEnum<PayMethod>("paymethod"); }
            set { this.Set("paymethod", value); }
        }

        /// <summary>
        /// 获取或设置网银支付时是否做CTU校验。
        /// </summary>
        public bool? NeedCtuCheck
        {
            get { return this.GetNullableBoolean("need_ctu_check"); }
            set { this.Set("need_ctu_check", value); }
        }

        /// <summary>
        /// 获取或设置提成类型。目前只支持一种类型：10（卖家给第三方提成）。
        /// </summary>
        public string RoyaltyType
        {
            get { return this.GetString("royalty_type"); }
            set { this.Set("royalty_type", value, 2); }
        }

        /// <summary>
        /// 获取或设置分润账号集。
        /// </summary>
        public string RoyaltyParameters
        {
            get { return this.GetString("royalty_parameters"); }
            set { this.Set("royalty_parameters", value); }
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
        public IPAddress ExterInvokeIP
        {
            get { return this.GetIPAddress("exter_invoke_ip"); }
            set { this.Set("exter_invoke_ip", value.ToString()); }
        }

        /// <summary>
        /// 获取或设置公用回传参数。如果用户请求时传递了该参数，则返回给商户时会回传该参数。 
        /// </summary>
        public string ExtraCommonParam
        {
            get { return this.GetString("extra_common_param"); }
            set { this.Set("extra_common_param", value, 100); }
        }

        /// <summary>
        /// 获取或设置公用业务扩展参数。用于商户的特定业务信息的传递，
        /// 只有商户与支付宝约定了传递此参数且约定了参数含义，此参数才有效。 
        /// </summary>
        public string ExtendParam
        {
            get { return this.GetString("extend_param"); }
            set { this.Set("extend_param", value); }
        }

        /// <summary>
        /// 获取或设置自动登录标识。 
        /// </summary>
        public AliBoolean DefaultLogin
        {
            get { return this.GetBoolOrDefault("default_login"); }
            set { this.Set("default_login", value.ToString()); }
        }

        /// <summary>
        /// 获取或设置商户申请的产品类型。 
        /// </summary>
        public string ProductType
        {
            get { return this.GetString("product_type"); }
            set { this.Set("product_type", value, 50); }
        }

        #endregion

    }

}
