using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Config;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝即时到帐和纯网关接口的页面跳转返回结果的基类。
    /// </summary>
    public class DirectPayReturnBase : PayReturnBase, ISign
    {
        /// <summary>
        /// 初始化 Alipay.DirectPay.AlipayDirectPayResponseBase 类的新实例。
        /// </summary>
        /// <param name="config"></param>
        public DirectPayReturnBase(AlipayConfig config)
            : base(config)
        {

        }

        /// <summary>
        /// 获取接口名称。
        /// </summary>
        public string Exterface
        {
            get { return this.GetString("exterface"); }
        }

        /// <summary>
        /// 获取公用回传参数。
        /// </summary>
        public string ExtraCommonParam
        {
            get { return this.GetString("extra_common_param"); }
        }

    }
}
