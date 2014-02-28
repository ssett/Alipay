using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Validators;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝 纯网关接口 的支付请求。
    /// </summary>
    public class DirectPayBankRequest : DirectPayRequestBase, ISign
    {
        /// <summary>
        /// 初始化 Alipay.DirectPay.AlipayDirectPayBankRequest 类的新实例。
        /// </summary>
        /// <param name="config"></param>
        public DirectPayBankRequest(AlipayConfig config)
            : base(config)
        {
        }

        /// <summary>
        /// [必需] 获取或设置默认网银。
        /// </summary>
        [Required("default_bank")]
        public string DefaultBank
        {
            get { return this.GetString("default_bank"); }
            set { this.Set("default_bank", value, 4); }
        }

    }
}
