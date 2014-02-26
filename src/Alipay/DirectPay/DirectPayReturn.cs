using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.DirectPay
{

    /// <summary>
    /// 表示支付宝页面跳转同步通知。
    /// </summary>
    public class DirectPayReturn : DirectPayReturnBase, ISign
    {
        /// <summary>
        /// 初始化 Alipay.AlipayReturn 类的新实例。
        /// </summary>
        /// <param name="config">支付宝默认配置。</param>
        public DirectPayReturn(AlipayConfig config)
            : base(config)
        {
        }


        /// <summary>
        /// 获取信用支付购票员的代理人 ID。
        /// </summary>
        public string AgentUserID
        {
            get { return this.GetString("agent_user_id"); }
        }
    }
}
