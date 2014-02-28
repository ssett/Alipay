using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;

namespace Alipay
{
    /// <summary>
    /// 表示支付宝即时到帐响应的记录。
    /// </summary>
    public abstract class PayReturnBase : ReturnBase, ISign
    {
        /// <summary>
        /// 初始化 Alipay.AlipayPayResponse 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public PayReturnBase(AlipayConfig config)
            : base(config)
        {
            
        }

        #region 业务参数

        /// <summary>
        /// 获取商户网站唯一订单号。
        /// </summary>
        public string OutTradeNo
        {
            get { return this.GetString("out_trade_no"); } //64
        }

        /// <summary>
        /// 获取商品名称。
        /// </summary>
        public string Subject
        {
            get { return this.GetString("subject"); } //256
        }

        /// <summary>
        /// 获取商品描述。
        /// </summary>
        public string Body
        {
            get { return this.GetString("body"); }
        }

        /// <summary>
        /// 获取交易金额，单位为元。
        /// </summary>
        public double? TotalFee
        {
            get { return this.GetNullableDouble("total_fee"); }
        }

        /// <summary>
        /// 获取支付类型。
        /// </summary>
        public string PaymentType
        {
            get { return this.GetString("payment_type"); } //256
        }

        /// <summary>
        /// 获取支付宝交易号。
        /// </summary>
        public string TradeNo
        {
            get { return this.GetString("trade_no"); }
        }

        /// <summary>
        /// 获取交易状态。
        /// </summary>
        public string TradeStatus
        {
            get { return this.GetString("trade_status"); }
        }

        /// <summary>
        /// 获取通知校验ID。
        /// </summary>
        public string NotifyID
        {
            get { return this.GetString("notify_id"); }
        }

        /// <summary>
        /// 获取通知时间。
        /// </summary>
        public DateTime? NotifyTime
        {
            get { return this.GetNullableDateTime("notify_time", DateTimeFormat); }
        }

        /// <summary>
        /// 获取通知类型。
        /// </summary>
        public string NotifyType
        {
            get { return this.GetString("notify_type"); }
        }

        /// <summary>
        /// 获取卖家支付宝账号。
        /// </summary>
        public virtual string SellerEmail
        {
            get { return this.GetString("seller_email"); }
        }

        /// <summary>
        /// 获取买家支付宝账号。
        /// </summary>
        public virtual string BuyerEmail
        {
            get { return this.GetString("buyer_email"); }
        }

        /// <summary>
        /// 获取卖家支付宝账号对应的支付宝唯一账户号。
        /// </summary>
        public virtual string SellerID
        {
            get { return this.GetString("seller_id"); }
        }

        /// <summary>
        /// 获取买家支付宝账号对应的支付宝唯一账户号。
        /// </summary>
        public virtual string BuyerID
        {
            get { return this.GetString("buyer_id"); }
        }

        #endregion

    }
}
