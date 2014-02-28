using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;
using Alipay.Validators;

namespace Alipay
{

    /// <summary>
    /// 提供支付宝通知功能的基类。
    /// </summary>
    public abstract class ReturnBase : AlipayBase, ISign
    {        


        /// <summary>
        /// 初始化 Alipay.AlipayResponseBase 类的新实例。
        /// </summary>
        /// <param name="config">支付宝默认配置。</param>
        public ReturnBase(AlipayConfig config)
            : base(config)
        {
        }


        /// <summary>
        /// 获取接口调用是否成功，并不表明业务处理结果。
        /// </summary>
        [Required("is_success")]
        public bool IsSuccess
        {
            get { return this.GetBoolean("is_success"); }
        }

        /// <summary>
        /// 获取签名方式。
        /// </summary>
        [Required("sign_type")]
        public string SignType
        {
            get { return this.GetString("sign_type"); }
        }

        /// <summary>
        /// 获取签名。
        /// </summary>
        [Required("sign")]
        public string Sign
        {
            get { return this.GetString("sign"); } //32
        }


    }


}
