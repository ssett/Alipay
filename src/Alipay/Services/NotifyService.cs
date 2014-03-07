using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Alipay.Config;
using Alipay.Notifications;

namespace Alipay.Services
{

    /// <summary>
    /// 表示支付宝通知验证服务。
    /// </summary>
    public class NotifyService : AlipayBase, INotifyService
    {
        static readonly string securityNofifyUrl =
            "https://www.alipay.com/cooperate/gateway.do?service=notify_verify";
        static readonly string normalNotifyURL =
            "http://notify.alipay.com/trade/notify_query.do?";

        /// <summary>
        /// 初始化 Alipay.AlipayNotifyService 类的新实例。
        /// </summary>
        /// <param name="config">支付宝默认配置。</param>
        public NotifyService(AlipayConfig config)
            : base(config)
        {
            this.Timeout = 120000;
        }


        /// <summary>
        /// 获取支付宝通知验证基础地址。
        /// </summary>
        protected string Gateway
        {
            get
            {
                return string.Compare(this.Config.Transport, "https", true) == 0 ?
                    securityNofifyUrl : normalNotifyURL;
            }
        }

        /// <summary>
        /// 获取或设置超时时间。
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 验证此次通知信息是否是支付宝服务器发来的信息，以帮助校验反馈回来的数据的真假性。
        /// </summary>
        /// <param name="notify"></param>
        /// <returns>如果获得的信息是 true ，则校验成功；如果获得的信息是其他，则校验失败</returns>
        public string Verify(INotify notify)
        {
            var verifyUrl = string.Format("{0}&partner={1}&notify_id={2}",
                this.Gateway, this.Config.Partner, notify.NotifyID);

            //TODO:Sign notify_verify

            return HttpGet(verifyUrl, this.Timeout);
        }

        /// <summary>
        /// 获取远程服务器ATN结果，验证是否是支付宝服务器发来的请求
        /// </summary>
        /// <param name="url">HTTP请求的目标URL。</param>
        /// <param name="timeout">HTTP请求超时时间。</param>
        /// <returns></returns>
        static string HttpGet(string url, int timeout)
        {
            string strResult;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(url);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {
                strResult = "错误：" + exp.Message;
            }

            return strResult;
        }

    }
}
