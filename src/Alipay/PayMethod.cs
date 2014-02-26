using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayMethod
    {
        /// <summary>
        /// 默认方式
        /// </summary>
        None,

        /// <summary>
        /// 信用支付
        /// </summary>
        creditPay,

        /// <summary>
        /// 余额支付
        /// </summary>
        directPay,
    }
}
