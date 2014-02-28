using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝即时到帐和纯网关接口请求的配置。
    /// </summary>
    public class DirectPayConfig : AlipayPayConfig
    {
        /// <summary>
        /// 获取或设置请求出错时的页面通知路径。
        /// </summary>
        public string ErrorNotifyUrl { get; set; }

    }
}
