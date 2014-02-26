using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 表示物流类型。
    /// </summary>
    public enum LogisticsType
    {
        /// <summary>
        /// 平邮。
        /// </summary>
        POST,

        /// <summary>
        /// 其他快递。
        /// </summary>
        EXPRESS,

        /// <summary>
        /// EMS。
        /// </summary>
        EMS
    }
}
