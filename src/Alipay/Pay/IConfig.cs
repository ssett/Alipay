using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pay
{
    /// <summary>
    /// 提供基础配置信息。
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 获取商户号。
        /// </summary>
        string Partner { get; }

        /// <summary>
        /// 获取签名密钥。
        /// </summary>
        string Key { get; }

        /// <summary>
        /// 获取后台通知 Url。
        /// </summary>
        string NotifyUrl { get; }

        /// <summary>
        /// 获取页面返回 Url。
        /// </summary>
        string ReturnUrl { get; }

        /// <summary>
        /// 获取字符编码。
        /// </summary>
        string InputCharset { get; }
    }

    /// <summary>
    /// 提供基础配置信息的基类。
    /// </summary>
    public abstract class ConfigBase : IConfig
    {

    }
}
