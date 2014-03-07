using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Alipay.Extensions;
using Alipay.Config;

namespace Alipay
{
    /// <summary>
    /// 提供支付宝 Web 交互功能的基类。
    /// </summary>
    public abstract class AlipayBase : IParamProvider
    {       
        /// <summary>
        /// 获取 System.DateTime 解析格式字符串。
        /// </summary>
        protected static readonly string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 初始化 Alipay.AlipayBase 类的新实例。
        /// </summary>
        /// <param name="config">支付宝默认配置。</param>
        public AlipayBase(AlipayConfig config)
        {
            this.Config = config;
        }


        /// <summary>
        /// 获取支付宝默认配置。
        /// </summary>
        public AlipayConfig Config { get; protected set; }

        /// <summary>
        /// 返回支付宝 Web 请求参数签名。
        /// </summary>
        /// <returns></returns>
        public string GenerateSignature()
        {
            var s = this.GetSignParameters().Sort().Join() + this.Config.Key;
            return GetMD5(s, this.Config.InputCharset);
        }


        /// <summary>
        /// 与ASP兼容的MD5加密算法
        /// </summary>
        static string GetMD5(string s, string charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }


        /// <summary>
        /// 返回参与生成签名的请求参数。
        /// </summary>
        /// <returns></returns>
        protected IDictionary<string, string> GetSignParameters()
        {
            return this.Parameters.Where(pair =>
                    pair.Value != "" &&
                    pair.Key != "sign" &&
                    pair.Key != "sign_type"
                ).ToDictionary(k => k.Key, k => k.Value);
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
