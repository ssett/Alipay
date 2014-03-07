using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Alipay.Config
{
    /// <summary>
    /// 支付宝配置节处理程序。
    /// </summary>
    public class XmlAlipayConfig : AlipayConfig
    {
        internal XmlAlipayConfig(XmlElement element)
        {
            this.Initialize(element);
        }

        private void Initialize(XmlElement element)
        {
            this.ParsePartner(element);
            this.ParseKey(element);
            this.SignType = GetAttributeValue(element, "signType", "MD5");
            this.InputCharset = GetAttributeValue(element, "inputCharset", "utf-8");
        }

        private void ParsePartner(XmlElement element)
        {
            var partner = GetAttributeValue(element, "partner");
            if (partner != null)
            {
                this.Partner = partner;
            }
            else
            {
                throw new System.Configuration.SettingsPropertyNotFoundException("未设置 partner 属性。");
            }
        }

        private void ParseKey(XmlElement element)
        {
            var key = GetAttributeValue(element, "key");
            if (key != null)
            {
                this.Key = key;
            }
            else
            {
                throw new System.Configuration.SettingsPropertyNotFoundException("未设置 key 属性。");
            }
        }

        static string GetAttributeValue(XmlElement element, string name)
        {
            return GetAttributeValue(element, name, null);
        }

        static string GetAttributeValue(XmlElement element, string name, string @default)
        {
            if (element.Attributes[name] != null)
            {
                return element.Attributes[name].InnerText;
            }
            return @default;
        }
    }
}
