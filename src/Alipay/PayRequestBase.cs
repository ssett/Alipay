using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Validators;

namespace Alipay
{
    /// <summary>
    /// 表示支付宝各种支付请求的基类。
    /// </summary>
    public abstract class PayRequestBase : RequestBase, ISign
    {
        static readonly string gateway = "http://www.alipay.com/cooperate/gateway.do?";

        /// <summary>
        /// 初始化 Alipay.AlipayPayRequestBase 类的新实例。
        /// </summary>
        /// <param name="config"></param>
        public PayRequestBase(AlipayConfig config)
            : base(config)
        {
            this.PaymentType = ((int)Alipay.PaymentType.Purchase).ToString();
        }

        /// <summary>
        /// 获取支付宝网关地址。
        /// </summary>
        public override string Gateway
        {
            get { return gateway; }
        }

        #region 基本参数

        /// <summary>
        /// 获取服务器异步通知页面路径。
        /// </summary>
        public string NotifyUrl
        {
            get { return this.GetString("notify_url"); }
            protected set { this.Set("notify_url", value, 190); }
        }

        #endregion

        #region 业务参数


        /// <summary>
        /// [必需] 获取或设置商户网站唯一订单号。
        /// </summary>
        [Required("out_trade_no")]
        public string OutTradeNo
        {
            get { return this.GetString("out_trade_no"); }
            set { this.Set("out_trade_no", value, 64); }
        }

        /// <summary>
        /// [必需] 获取或设置商品名称。
        /// </summary>
        [Required("subject")]
        public string Subject
        {
            get { return this.GetString("subject"); }
            set { this.Set("subject", value, 256); }
        }

        /// <summary>
        /// 获取或设置商品描述。
        /// </summary>
        public string Body
        {
            get { return this.GetString("body"); }
            set { this.Set("body", value, 1000); }
        }

        /// <summary>
        /// 获取或设置商品单价。
        /// </summary>
        public virtual double? Price
        {
            get { return this.GetNullableDouble("price"); }
            set { this.Set("price", value, 0.01D, 100000000.00D); }
        }

        /// <summary>
        /// 获取或设置购买数量。
        /// Price、Quantity 能代替 TotalFee 。即
        /// 存在 TotalFee ，就不能存在 Price 和 Quantity；
        /// 存在 Price、Quantity，就不能存在 TotalFee 。
        /// </summary>
        public virtual int Quantity
        {
            get { return this.GetInt32("quantity"); }
            set { this.Set("quantity", value); }
        }

        /// <summary>
        /// 获取或设置交易金额。
        /// </summary>
        public double? TotalFee
        {
            get { return this.GetNullableDouble("total_fee"); }
            set { this.Set("total_fee", value, 0.01D, 100000000.00D); }
        }

        /// <summary>
        /// [必需] 获取或设置支付类型。
        /// </summary>
        [Required("payment_type")]
        public string PaymentType
        {
            get { return this.GetString("payment_type"); }
            set { this.Set("payment_type", value, 4); }
        }

        /// <summary>
        /// 获取卖家支付宝账号。
        /// </summary>
        public string SellerEmail
        {
            get { return this.GetString("seller_email"); }
            set { this.Set("seller_email", value, 100); }
        }

        /// <summary>
        /// 获取买家支付宝账号。
        /// </summary>
        public string BuyerEmail
        {
            get { return this.GetString("buyer_email"); }
            set { this.Set("buyer_email", value, 100); }
        }

        /// <summary>
        /// 获取卖家支付宝账号对应的支付宝唯一账户号。
        /// </summary>
        public string SellerID
        {
            get { return this.GetString("seller_id"); }
            set { this.Set("seller_id", value, 16); }
        }

        /// <summary>
        /// 获取买家支付宝账号对应的支付宝唯一账户号。
        /// </summary>
        public string BuyerID
        {
            get { return this.GetString("buyer_id"); }
            set { this.Set("buyer_id", value, 16); }
        }

        /// <summary>
        /// 获取或设置卖家别名支付宝账号。
        /// </summary>
        public string SellerAccountName
        {
            get { return this.GetString("seller_account_name"); }
            set { this.Set("seller_account_name", value, 100); }
        }

        /// <summary>
        /// 获取或设置买家别名支付宝账号。
        /// </summary>
        public string BuyerAccountName
        {
            get { return this.GetString("buyer_account_name"); }
            set { this.Set("buyer_account_name", value, 100); }
        }

        /// <summary>
        /// 获取或设置商品展示网址。
        /// </summary>
        public string ShowUrl
        {
            get { return this.GetString("show_url"); }
            set { this.Set("show_url", value, 400); }
        }
        

        /// <summary>
        /// 获取或设置超时时间。 设置未付款交易的超时时间，一旦超时，该笔交易就会自动被关闭。 
        /// 取值范围：1m～15d 。 m -分钟，h -小时，d -天，1c-当天（无论交易何时创建，都在0 点关闭）。 
        /// 该参数数值不接受小数点，如1.5h ，可转换为90m 。 
        /// 该功能需要联系技术支持来配置关闭时间。
        /// </summary>
        public string Timeout
        {
            get { return this.GetString("it_b_pay"); }
            set { this.Set("it_b_pay", value); }
        }

        #endregion

    }
}
