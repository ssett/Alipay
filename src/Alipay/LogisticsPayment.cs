using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 表示物流支付类型。
    /// </summary>
    public enum LogisticsPayment
    {
        /// <summary>
        /// 物流买家承担运费。
        /// </summary>
        BUYER_PAY,

        /// <summary>
        /// 物流卖家承担运费。
        /// </summary>
        SELLER_PAY,

        /// <summary>
        /// 买家到货付款，运费显示但不计入总价。
        /// </summary>
        BUYER_PAY_AFTER_RECEIVE
    }
}
