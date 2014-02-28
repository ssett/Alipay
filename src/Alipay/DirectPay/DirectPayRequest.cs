using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Services;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝即时到帐的支付请求。
    /// </summary>
    public class DirectPayRequest : DirectPayRequestBase, ISign
    {

        /// <summary>
        /// 初始化 Alipay.DirectPay.DirectPayRequest 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public DirectPayRequest(AlipayConfig config)
            : base(config)
        {
        }


        #region 业务参数

        /// <summary>
        /// 获取或设置快捷登录授权令牌。 
        /// </summary>
        public string Token
        {
            get { return this.GetString("token"); }
            set { this.Set("token", value, 40); }
        }

        /// <summary>
        /// 获取或设置快捷登录授权令牌。 
        /// </summary>
        public string ItemOrdersInfo
        {
            get { return this.GetString("item_orders_info"); }
            set { this.Set("item_orders_info", value, 40000); }
        }

        #endregion

    }
}
