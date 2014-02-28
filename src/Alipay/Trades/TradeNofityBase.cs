using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;

namespace Alipay.Trades
{
    /// <summary>
    /// 表示支付宝标准双接口和纯担保交易的服务器异步通知。
    /// </summary>
    public class TradeNofityBase : PayNotifyBase, ISign, INotify
    {
        /// <summary>
        /// 初始化 Alipay.Trades.TradeNofityBase 类的新实例。
        /// </summary>
        /// <param name="service">通知请求验证服务。</param>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public TradeNofityBase(INotifyService service,
            IDictionary<string, string> parameters, AlipayConfig config)
            : base(service, parameters, config)
        {
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

    }
}
