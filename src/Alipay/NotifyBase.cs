using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Validators;
using Alipay.Extensions;

namespace Alipay
{
    /// <summary>
    /// 表示支付宝的服务器异步通知。
    /// </summary>
    public abstract class NotifyBase : AlipayBase, ISign, INotify
    {
        INotifyService _notifyService;

        /// <summary>
        /// 初始化 Alipay.NotifyBase 类的新实例。
        /// </summary>
        /// <param name="service">通知请求验证服务。</param>
        /// <param name="parameters">通知请求参数。</param>
        /// <param name="config">支付宝默认配置。</param>
        public NotifyBase(INotifyService service,
            IDictionary<string, string> parameters, AlipayConfig config)
            : base(config)
        {
            parameters.ToList().ForEach(
                p => this.Parameters.Add(p.Key, p.Value)
                );

            _notifyService = service;
        }

        #region 基本参数

        /// <summary>
        /// 获取通知校验ID。
        /// </summary>
        [Required("notify_id")]
        public string NotifyID
        {
            get { return this.GetString("notify_id"); }
        }

        /// <summary>
        /// 获取通知时间。
        /// </summary>
        [Required("notify_time")]
        public DateTime? NotifyTime
        {
            get { return this.GetNullableDateTime("notify_time", DateTimeFormat).Value; }
        }

        /// <summary>
        /// 获取通知类型。
        /// </summary>
        [Required("notify_type")]
        public string NotifyType
        {
            get { return this.GetString("notify_type"); }
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

        #endregion


        /// <summary>
        /// 验证通知请求是否来自支付宝。返回 true 表示通过验证。
        /// </summary>
        /// <returns></returns>
        public bool Verify()
        {
            var responseText = _notifyService.Verify(this);

            return string.Compare("true", responseText, true) == 0;
        }

        /// <summary>
        /// 校验请求签名并返回校验结果。返回 true 表示签名通过校验。
        /// </summary>
        /// <returns></returns>
        public bool VerifySignature()
        {
            var sign = this.GenerateSignature();
            return string.Compare(sign, this.Sign, true) == 0;
        }


    }
}
