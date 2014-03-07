using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Alipay.Extensions;
using Alipay.Validators;
using Alipay.Config;

namespace Alipay
{
    /// <summary>
    /// 表示支付宝请求的基类。
    /// </summary>
    public abstract class RequestBase : AlipayBase, ISign
    {

        /// <summary>
        /// 初始化 Alipay.AlipayRequestBase 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public RequestBase(AlipayConfig config)
            : base(config)
        {
            this.Partner = config.Partner;
            this.InputCharset = config.InputCharset;
            this.SignType = config.SignType;

            this.RequestValidators = new List<IValidator>();
            this.RequestValidators.Add(new RequiredValidator());
        }

        /// <summary>
        /// 获取请求的基准路径。
        /// </summary>
        public abstract string Gateway { get; }

        /// <summary>
        /// 获取请求验证程序。
        /// </summary>
        protected IList<IValidator> RequestValidators
        {
            get;
            private set;
        }

        #region 基本参数

        /// <summary>
        /// [必需] 获取接口名称。
        /// </summary>
        [Required("service")]
        public string Service
        {
            get { return this.GetString("service"); }
            protected set { this.Set("service", value); }
        }

        /// <summary>
        /// [必需] 获取合作者身份 ID。
        /// </summary>
        [Required("partner")]
        public string Partner
        {
            get { return this.GetString("partner"); }
            protected set { this.Set("partner", value, 16); }
        }

        /// <summary>
        /// [必需] 获取参数编码字符集。
        /// </summary>
        [Required("_input_charset")]
        public string InputCharset
        {
            get { return this.GetString("_input_charset"); }
            protected set { this.Set("_input_charset", value); }
        }

        /// <summary>
        /// [必需] 获取签名方式。
        /// </summary>
        [Required("sign_type")]
        public string SignType
        {
            get { return this.GetString("sign_type"); }
            protected set { this.Set("sign_type", value); }
        }

        /// <summary>
        /// [必需] 获取签名。
        /// </summary>
        [Required("sign")]
        public string Sign
        {
            get { return this.GetString("sign"); }
            protected set { this.Set("sign", value); }
        }

        /// <summary>
        /// 获取页面跳转同步通知页面路径。
        /// </summary>
        public string ReturnUrl
        {
            get { return this.GetString("return_url"); }
            set { this.Set("return_url", value, 200); }
        }

        #endregion


        /// <summary>
        /// 创建并返回支付宝请求链接。
        /// </summary>
        /// <returns></returns>
        public virtual string CreateUrl()
        {
            // 生成签名
            if (this.Sign == null)
                this.Sign = this.GenerateSignature();

            // 验证请求
            this.RequestValidators.ToList()
                .ForEach(v => v.Validate(this));

            var encoded = this.Parameters.Sort().Join(
                paramValue => HttpUtility.UrlEncode(paramValue));

            return string.Format("{0}{1}", this.Gateway, encoded);
        }

    }
}
