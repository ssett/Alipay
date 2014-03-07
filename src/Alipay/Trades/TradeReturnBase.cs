using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Config;
using Alipay.Notifications;

namespace Alipay.Trades
{
    /// <summary>
    /// 表示支付宝标准双接口和纯担保交易的页面跳转返回结果的基类。
    /// </summary>
    public abstract class TradeReturnBase : PayReturnBase, ISign
    {
        /// <summary>
        /// 初始化 Alipay.Trades.AlipayTradeResponseBase 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public TradeReturnBase(AlipayConfig config)
            : base(config)
        {
            
        }

        #region 基本参数

        /// <summary>
        /// 获取合作者身份 ID。
        /// </summary>
        public string Partner
        {
            get { return this.GetString("partner"); } 
        }

        /// <summary>
        /// 获取参数编码字符集。
        /// </summary>
        public string Charset
        {
            get { return this.GetString("charset"); }
        }

        #endregion

        #region 业务参数

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
        /// 获取折扣。
        /// </summary>
        public double? Discount
        {
            get { return this.GetNullableDouble("discount"); }
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

        /// <summary>
        /// 获取收件人姓名。
        /// </summary>
        public string ReceiveName
        {
            get { return this.GetString("receive_name"); }
        }

        /// <summary>
        /// 获取收件人地址。
        /// </summary>
        public string ReceiveAddress
        {
            get { return this.GetString("receive_address"); }
        }

        /// <summary>
        /// 获取收件人邮编。
        /// </summary>
        public string ReceiveZip
        {
            get { return this.GetString("receive_zip"); }
        }

        /// <summary>
        /// 获取收件人电话。
        /// </summary>
        public string ReceivePhone
        {
            get { return this.GetString("receive_phone"); }
        }

        /// <summary>
        /// 获取收件人手机。
        /// </summary>
        public string ReceiveMobile
        {
            get { return this.GetString("receive_mobile"); }
        }

        /// <summary>
        /// 获取物流类型。
        /// </summary>
        public LogisticsType LogisticsType
        {
            get { return this.GetEnum<LogisticsType>("logistics_type"); }
        }

        /// <summary>
        /// 获取物流费用。
        /// </summary>
        public double? LogisticsFee
        {
            get { return this.GetNullableDouble("logistics_fee"); }
        }

        /// <summary>
        /// 获取物流支付类型。
        /// </summary>
        public LogisticsPayment LogisticsPayment
        {
            get { return this.GetEnum<LogisticsPayment>("logistics_payment"); }
        }

        /// <summary>
        /// 获取物流状态更新时间。
        /// </summary>
        public DateTime? GmtLogisticsModify
        {
            get { return this.GetNullableDateTime("gmt_logistics_modify"); }
        }

        /// <summary>
        /// 获取买家动作集合。
        /// </summary>
        public string BuyerActions
        {
            get { return this.GetString("buyer_actions"); }
        }

        /// <summary>
        /// 获取卖家动作集合。
        /// </summary>
        public string SellerActions
        {
            get { return this.GetString("seller_actions"); }
        }

        #endregion

    }
}
