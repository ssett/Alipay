using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Validators;

namespace Alipay.Trades
{
    /// <summary>
    /// 表示支付宝 标准双接口 和 纯担保交易 的支付请求的基类。
    /// </summary>
    public abstract class TradeRequestBase : PayRequestBase, ISign
    {
        /// <summary>
        /// 创建 Alipay.Trades.AlipayTradeRequestBase 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public TradeRequestBase(AlipayConfig config)
            : base(config)
        {
            
        }

        /// <summary>
        /// 获取或设置商品单价。
        /// </summary>
        [Required("price")]
        public override double? Price
        {
            get
            {
                return base.Price;
            }
            set
            {
                base.Price = value;
            }
        }

        /// <summary>
        /// 获取或设置商品数量。
        /// </summary>
        [Required("quantity")]
        public override int Quantity
        {
            get
            {
                return base.Quantity;
            }
            set
            {
                base.Quantity = value;
            }
        }

        /// <summary>
        /// 获取或设置商品折扣。
        /// </summary>
        public double? Discount
        {
            get { return this.GetNullableDouble("discount"); }
            set { this.Set("discount", value, -100000000d, 100000000d); }
        }

        /// <summary>
        /// 获取或设置快捷登录授权令牌。 
        /// </summary>
        public string Token
        {
            get { return this.GetString("token"); }
            set { this.Set("token", value, 40); }
        }

        /// <summary>
        /// 获取或设置收件人姓名。
        /// </summary>
        public string ReceiveName
        {
            get { return this.GetString("receive_name"); }
            set { this.Set("receive_name", value, 128); }
        }

        /// <summary>
        /// 获取或设置收件人地址。
        /// </summary>
        public string ReceiveAddress
        {
            get { return this.GetString("receive_address"); }
            set { this.Set("receive_address", value, 256); }
        }

        /// <summary>
        /// 获取或设置收件人邮编。
        /// </summary>
        public string ReceiveZip
        {
            get { return this.GetString("receive_zip"); }
            set { this.Set("receive_zip", value, 20); }
        }

        /// <summary>
        /// 获取或设置收件人电话。
        /// </summary>
        public string ReceivePhone
        {
            get { return this.GetString("receive_phone"); }
            set { this.Set("receive_phone", value, 30); }
        }

        /// <summary>
        /// 获取或设置收件人手机。
        /// </summary>
        public string ReceiveMobile
        {
            get { return this.GetString("receive_mobile"); }
            set { this.Set("receive_mobile", value); }
        }

        /// <summary>
        /// [必需] 获取或设置物流类型。
        /// </summary>
        [Required("logistics_type")]
        public LogisticsType LogisticsType
        {
            get { return this.GetEnum<LogisticsType>("logistics_type"); }
            set { this.Set("logistics_type", value.ToString()); }
        }

        /// <summary>
        /// [必需] 获取或设置物流费用。
        /// </summary>
        [Required("logistics_fee")]
        public double? LogisticsFee
        {
            get { return this.GetNullableDouble("logistics_fee"); }
            set { this.Set("logistics_fee", value); }
        }

        /// <summary>
        /// [必需] 获取或设置物流支付类型。
        /// </summary>
        [Required("logistics_payment")]
        public LogisticsPayment LogisticsPayment
        {
            get { return this.GetEnum<LogisticsPayment>("logistics_payment"); }
            set { this.Set("logistics_payment", value.ToString()); }
        }

        /// <summary>
        /// 获取或设置物流类型。
        /// </summary>
        public LogisticsType LogisticsType1
        {
            get { return this.GetEnum<LogisticsType>("logistics_type_1"); }
            set { this.Set("logistics_type_1", value); }
        }

        /// <summary>
        /// 获取或设置物流费用。
        /// </summary>
        public double? LogisticsFee1
        {
            get { return this.GetNullableDouble("logistics_fee_1"); }
            set { this.Set("logistics_fee_1", value); }
        }

        /// <summary>
        /// 获取或设置物流支付类型。
        /// </summary>
        public LogisticsPayment LogisticsPayment1
        {
            get { return this.GetEnum<LogisticsPayment>("logistics_payment_1"); }
            set { this.Set("logistics_payment_1", value); }
        }

        /// <summary>
        /// 获取或设置物流类型。
        /// </summary>
        public LogisticsType LogisticsType2
        {
            get { return this.GetEnum<LogisticsType>("logistics_type_2"); }
            set { this.Set("logistics_type_2", value); }
        }

        /// <summary>
        /// 获取或设置物流费用。
        /// </summary>
        public double? LogisticsFee2
        {
            get { return this.GetNullableDouble("logistics_fee_2"); }
            set { this.Set("logistics_fee_2", value); }
        }

        /// <summary>
        /// 获取或设置物流支付类型。
        /// </summary>
        public LogisticsPayment LogisticsPayment2
        {
            get { return this.GetEnum<LogisticsPayment>("logistics_payment_3"); }
            set { this.Set("logistics_payment_3", value); }
        }

        /// <summary>
        /// 获取或设置卖家逾期不发货，允许买家退款。
        /// </summary>
        public AliDateTime TimeoutSellerSend1
        {
            get { return this.GetDate("t_s_send_1"); }
            set { this.Set("t_s_send_1", value); }
        }

        /// <summary>
        /// 获取或设置买家逾期不发货，建议买家退款。
        /// </summary>
        public AliDateTime TimeoutSellerSend2
        {
            get { return this.GetDate("t_s_send_2"); }
            set { this.Set("t_s_send_2", value); }
        }

        /// <summary>
        /// 获取或设置买家逾期不确认收货，自动完成交易（平邮）。
        /// </summary>
        public AliDateTime TimeoutBuyerReceivePost
        {
            get { return this.GetDate("t_b_rec_post"); }
            set { this.Set("t_b_rec_post", value); }
        }

    }
}
