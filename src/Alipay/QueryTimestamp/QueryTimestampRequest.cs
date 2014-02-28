using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Alipay.Extensions;

namespace Alipay.QueryTimestamp
{
    /// <summary>
    /// 表示支付宝防钓鱼时间戳服务的获取请求。
    /// </summary>
    public class QueryTimestampRequest : RequestBase
    {
        /// <summary>
        /// 初始化 Alipay.QueryTimestamp.QueryTimestampRequest 类的新实例。
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
        /// 返回服务的响应结果。
        /// </summary>
        /// <returns></returns>
        public QueryTimestampResponse GetResponse()
        {
            return new QueryTimestampResponse(this);
        }
    }

}
