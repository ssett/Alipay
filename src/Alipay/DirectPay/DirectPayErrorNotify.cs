using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Validators;
using Alipay.Extensions;

namespace Alipay.DirectPay
{
    /// <summary>
    /// 表示支付宝请求出错通知。
    /// </summary>
    public class DirectPayErrorNotify : IParamProvider
    {        
        
        /// <summary>
        /// 获取合作者身份 ID。
        /// </summary>
        [Required("partner")]
        public string Partner
        {
            get { return this.GetString("partner"); }
        }

        /// <summary>
        /// 获取商户网站唯一订单号。
        /// </summary>
        [Required("out_trade_no")]
        public string OutTradeNo
        {
            get { return this.GetString("out_trade_no"); } //64
        }

        /// <summary>
        /// 获取错误码。当出现多个错误时，将错误码用“|”连接起来。
        /// </summary>
        [Required("error_code")]
        public string ErrorCode
        {
            get { return this.GetString("error_code"); }
        }

        /// <summary>
        /// 获取请求出错时的页面通知路径。
        /// </summary>
        [Required("return_url")]
        public string ReturnUrl
        {
            get { return this.GetString("return_url"); } //64
        }

        /// <summary>
        /// 获取卖家支付宝账号。
        /// </summary>
        public string SellerEmail
        {
            get { return this.GetString("seller_email"); }
        }

        /// <summary>
        /// 获取买家支付宝账号。
        /// </summary>
        public string BuyerEmail
        {
            get { return this.GetString("buyer_email"); }
        }

        /// <summary>
        /// 获取卖家支付宝账号对应的支付宝唯一账户号。
        /// </summary>
        public string SellerID
        {
            get { return this.GetString("seller_id"); }
        }

        /// <summary>
        /// 获取买家支付宝账号对应的支付宝唯一账户号。
        /// </summary>
        public string BuyerID
        {
            get { return this.GetString("buyer_id"); }
        }

        #region IParamProvider

        private IDictionary<string, string> _parameters;

        /// <summary>
        /// 获取参数字典。
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                if (_parameters == null)
                    _parameters = new Dictionary<string, string>();
                return _parameters;
            }
            private set
            {
                _parameters = value;
            }
        }

        #endregion
    }
}
