using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 提供付款通知验证服务。
    /// </summary>
    public interface INotifyService
    {
        /// <summary>
        /// 获取或设置验证通知请求的超时时间。
        /// </summary>
        int Timeout { get; set; }

        /// <summary>
        /// 验证通知请求是否来自支付宝，并返回验证结果。
        /// </summary>
        /// <param name="notify">待验证的通知请求。</param>
        /// <returns></returns>
        string Verify(INotify notify);
    }
}
