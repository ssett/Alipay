using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Config;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝纯网关接口的页面跳转返回结果。
    /// </summary>
    public class DirectPayBankReturn : DirectPayReturnBase, ISign
    {
        /// <summary>
        /// 初始化 Alipay.DirectPay.AlipayDirectPayBankReturn 类的新实例。
        /// </summary>
        /// <param name="config"></param>
        public DirectPayBankReturn(AlipayConfig config)
            : base(config)
        {
        }

        /// <summary>
        /// 获取网银流水。
        /// </summary>
        public string BankSeqNo
        {
            get { return this.GetString("bank_seq_no"); }
        }

    }
}
