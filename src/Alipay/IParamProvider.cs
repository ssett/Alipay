using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 提供参数字典功能。
    /// </summary>
    public interface IParamProvider
    {
        /// <summary>
        /// 获取参数字典。
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }

}
