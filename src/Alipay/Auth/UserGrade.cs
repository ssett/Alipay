using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.Auth
{
    /// <summary>
    /// 表示用户等级。
    /// </summary>
    public enum UserGrade
    {
        /// <summary>
        /// 普通会员。
        /// </summary>
        NORMAL,

        /// <summary>
        /// VIP 会员。
        /// </summary>
        VIP,

        /// <summary>
        /// 至尊 VIP 会员。
        /// </summary>
        IMPERIAL_VIP
    }

    /// <summary>
    /// 表示用户等级类型。
    /// </summary>
    public enum UserGradeType
    {
        /// <summary>
        /// 金账户未激活。
        /// </summary>
        Disable = 0,

        /// <summary>
        /// 金账户已激活。
        /// </summary>
        Enable = 1
    }
}
