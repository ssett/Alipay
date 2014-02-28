using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 表示支付宝服务调用过程中的异常。
    /// </summary>
    public class AlipayException : Exception
    {
        /// <summary>
        /// 初始化 Alipay.AlipayException 类的新实例。
        /// </summary>
        public AlipayException()
        {

        }

        /// <summary>
        /// 使用指定的错误消息初始化 Alipay.AlipayException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public AlipayException(string message)
            : base(message)
        {
        }

    }
}
