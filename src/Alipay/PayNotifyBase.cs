using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;

namespace Alipay
{
    /// <summary>
    /// 表示支付宝支付的服务器异步通知。
    /// </summary>
    public abstract class PayNotifyBase : NotifyBase, ISign, INotify
    {
        /// <summary>
        /// 初始化 Alipay.PayNotifyBase 类的新实例。
        /// </summary>
        /// <param name="service">通知请求验证服务。</param>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public PayNotifyBase(INotifyService service,
            IDictionary<string, string> parameters, AlipayConfig config)
            : base(service, parameters, config)
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
        /// 获取商品单价。
        /// </summary>
        public double? Price
        {
            get { return this.GetNullableDouble("price"); }
        }

        /// <summary>
        /// 获取购买数量。
        /// </summary>
        public int Quantity
        {
            get { return this.GetInt32("quantity"); }
        }

        /// <summary>
        /// 获取交易金额，单位为元。
        /// </summary>
        public double? TotalFee
        {
            get { return this.GetNullableDouble("total_fee"); }
        }

        /// <summary>
        /// 获取折扣。
        /// </summary>
        public double? Discount
        {
            get { return this.GetNullableDouble("discount"); }
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
        public TradeStatus TradeStatus
        {
            get { return this.GetEnum<TradeStatus>("trade_status"); }
        }

        /// <summary>
        /// 获取交易创建时间。
        /// </summary>
        public DateTime? GmtCreate
        {
            get { return this.GetNullableDateTime("gmt_create"); }
        }

        /// <summary>
        /// 获取交易创建时间。
        /// </summary>
        public DateTime? GmtPayment
        {
            get { return this.GetNullableDateTime("gmt_payment"); }
        }

        /// <summary>
        /// 获取交易创建时间。
        /// </summary>
        public DateTime? GmtRefund
        {
            get { return this.GetNullableDateTime("gmt_refund"); }
        }

        /// <summary>
        /// 获取退款状态。
        /// </summary>
        public RefundStatus RefundStatus
        {
            get { return this.GetEnum<RefundStatus>("refund_status"); }
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

        /// <summary>
        /// 获取总价是否调整过。
        /// </summary>
        public bool IsTotalFeeAdjust
        {
            get { return this.GetBoolean("is_total_fee_adjust"); }
        }

        /// <summary>
        /// 获取是否使用红包。
        /// </summary>
        public bool UseCoupon
        {
            get { return this.GetBoolean("use_coupon"); }
        }


        #endregion
    }
}
