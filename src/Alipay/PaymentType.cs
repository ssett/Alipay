using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 收款类型。
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        /// 商品购买。
        /// </summary>
        Purchase = 1,

        /// <summary>
        /// 捐赠。
        /// </summary>
        Donate = 4,
    }
}
