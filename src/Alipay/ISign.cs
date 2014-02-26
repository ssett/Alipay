using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 提供签名。
    /// </summary>
    public interface ISign
    {
        /// <summary>
        /// 获取签名。
        /// </summary>
        string Sign { get; }

        /// <summary>
        /// 获取签名方式。
        /// </summary>
        string SignType { get; }
    }
}
