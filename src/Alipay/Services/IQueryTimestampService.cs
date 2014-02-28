using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.Services
{
    /// <summary>
    /// 提供时间戳获取服务。
    /// </summary>
    public interface IQueryTimestampService
    {
        /// <summary>
        /// 返回防钓鱼时间戳。
        /// </summary>
        /// <returns></returns>
        string GetEncryptKey();
    }
}
