using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 表示退款状态。
    /// </summary>
    public enum RefundStatus
    {
        /// <summary>
        /// 退款成功。
        /// </summary>
        REFUND_SUCCESS,

        /// <summary>
        /// 退款关闭。
        /// </summary>
        REFUND_CLOSED,
    }
}
