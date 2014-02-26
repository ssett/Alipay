using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 提供与通知请求相关的功能。
    /// </summary>
    public interface INotify
    {

        /// <summary>
        /// 获取通知校验 ID。
        /// </summary>
        string NotifyID { get; }

        /// <summary>
        /// 获取通知时间。
        /// </summary>
        DateTime? NotifyTime { get; }

        /// <summary>
        /// 获取通知类型。
        /// </summary>
        string NotifyType { get; }


        /// <summary>
        /// 验证通知请求是否来自支付宝。返回 true 表示通过验证。
        /// </summary>
        /// <returns></returns>
        bool Verify();

        /// <summary>
        /// 校验请求签名并返回校验结果。返回 true 表示签名通过校验。
        /// </summary>
        /// <returns></returns>
        bool VerifySignature();

    }
}
