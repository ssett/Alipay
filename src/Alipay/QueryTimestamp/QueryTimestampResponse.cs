using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Alipay.QueryTimestamp
{
    /// <summary>
    /// 表示支付宝防钓鱼时间戳服务的响应结果。
    /// </summary>
    public class QueryTimestampResponse
    {
        private XmlNode _response;

        /// <summary>
        /// 使用服务响应结果初始化 Alipay.QueryTimestamp.QueryTimestampResponse 类的新实例。
        /// </summary>
        /// <param name="responseXml">时间戳服务返回的 XML 字符串。</param>
        public QueryTimestampResponse(string responseXml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(responseXml);
            _response = doc;
        }

        internal QueryTimestampResponse(QueryTimestampRequest request)
        {
            var url = request.CreateUrl();
            var reader = new XmlTextReader(url);
            var doc = new XmlDocument();
            doc.Load(reader);
            _response = doc;
        }

        /// <summary>
        /// 获取时间戳。
        /// </summary>
        public string EncryptKey
        {
            get { return _response.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText; }
        }
    }
}
