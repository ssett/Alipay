using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Alipay.Extensions;

namespace Alipay
{
    /// <summary>
    /// 表示用于获取时间戳的支付宝请求。
    /// </summary>
    class QueryTimestampRequest : RequestBase
    {
        /// <summary>
        /// 初始化 Alipay.QueryTimestampRequest 类的新实例。
        /// </summary>
        /// <param name="config">支付宝配置。</param>
        public QueryTimestampRequest(AlipayConfig config)
            : base(config)
        {
            this.Service = "query_timestamp";
        }


        /// <summary>
        /// 获取支付宝网关地址。
        /// </summary>
        public override string Gateway
        {
            get { return "https://mapi.alipay.com/gateway.do?"; }
        }

        /// <summary>
        /// 创建并返回支付宝请求链接。
        /// </summary>
        /// <returns></returns>
        public override string CreateUrl()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("service", this.Service);
            parameters.Add("partner", this.Partner);
            return string.Format("{0}{1}", this.Gateway, parameters.Join());
        }

        /// <summary>
        /// 请求支付宝时间戳服务并返回时间戳密钥。
        /// </summary>
        /// <returns></returns>
        public string GetEncryptKey()
        {
            var url = this.CreateUrl();
            var reader = new XmlTextReader(url);

            return new QueryTimestampResponse(reader).EncryptKey;
        }
    }

    class QueryTimestampResponse
    {
        private XmlNode _response;

        internal QueryTimestampResponse(XmlTextReader reader)
        {
            var doc = new XmlDocument();
            doc.Load(reader);
            _response = doc;
        }

        internal QueryTimestampResponse(string responseXml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(responseXml);
            _response = doc;
        }

        public string EncryptKey
        {
            get { return _response.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText; }
        }
    }
}
