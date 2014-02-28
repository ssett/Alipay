using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 表示支付宝配置信息。
    /// </summary>
    public class AlipayConfig
    {
        /// <summary>
        /// 初始化 Alipay.AlipayConfig 类的新实例。
        /// </summary>
        public AlipayConfig()
        {
            this.InputCharset = "utf-8";
            this.SignType = Alipay.SignType.MD5.ToString();
            this.Transport = "https";
        }


        /// <summary>
        /// 获取或设置合作身份者ID。
        /// </summary>
        public string Partner { get; set; }

        /// <summary>
        /// 获取或设置交易安全检验码。
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 获取或设置签名方式。
        /// </summary>
        public string SignType { get; set; }

        /// <summary>
        /// 获取或设置页面跳转返回同步通知页面路径。
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 获取或设置字符编码。
        /// </summary>
        public string InputCharset { get; set; }

        /// <summary>
        /// 获取或设置是否使用 HTTPS 安全链接。
        /// </summary>
        public string Transport { get; set; }
    }

    /// <summary>
    /// 表示支付宝支付请求的配置。
    /// </summary>
    public class AlipayPayConfig : AlipayConfig
    {
        /// <summary>
        /// 获取或设置服务器后台异步通知页面路径。
        /// </summary>
        public string NotifyUrl { get; set; }

    }

}
