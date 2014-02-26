using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 表示参数签名方式。
    /// </summary>
    public enum SignType
    {
        /// <summary>
        /// MD5。
        /// </summary>
        MD5,

        /// <summary>
        /// DSA。
        /// </summary>
        DSA,

        /// <summary>
        /// RSA。
        /// </summary>
        RSA,
    }
}
