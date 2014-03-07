using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;

namespace Alipay.Config
{
    /// <summary>
    /// 用于在 App.config 或 Web.config 中配置支付宝参数的 ConfigSectionHandler。
    /// </summary>
    public class ConfigSectionHandler : IConfigurationSectionHandler
    {
        /// <summary>
        /// 创建支付宝配置节处理程序。
        /// </summary>
        /// <param name="parent">父对象。</param>
        /// <param name="configContext">配置上下文环境。</param>
        /// <param name="section">XML 节点。</param>
        /// <returns>创建的支付宝配置节处理程序对象。</returns>
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            if (string.Compare("alipay", section.LocalName, true) == 0 &&
                section.NodeType == XmlNodeType.Element)
            {
                return new XmlAlipayConfig((XmlElement)section);
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format("不支持的 {0} XML节点", section.LocalName));
            }
        }
    }
}
