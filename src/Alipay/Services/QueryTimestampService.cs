using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.Services
{
    /// <summary>
    /// 表示支付宝时间戳获取服务。
    /// </summary>
    public class QueryTimestampService : AlipayBase, IQueryTimestampService
    {
        /// <summary>
        /// 初始化 Alipay.Services.QueryTimestampService 类的新实例。
        /// </summary>
        /// <param name="config">支付宝默认配置。</param>
        public QueryTimestampService(AlipayConfig config)
            : base(config)
        {

        }

        /// <summary>
        /// 返回防钓鱼时间戳。
        /// </summary>
        /// <returns></returns>
        public string GetEncryptKey()
        {
            return new QueryTimestampRequest(this.Config).GetEncryptKey();
        }
    }
}
