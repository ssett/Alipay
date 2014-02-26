using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.Validators
{
    /// <summary>
    /// 表示必需参数的自定义属性。
    /// </summary>
    public class RequiredAttribute : System.Attribute
    {
        /// <summary>
        /// 初始化 Pay.RequiredAttribute 类的新实例。
        /// </summary>
        /// <param name="key">待检测参数的名称。</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public RequiredAttribute(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            this.Key = key;
        }

        /// <summary>
        /// 获取或设置待检测参数的名称。
        /// </summary>
        public string Key { get; set; }
    }
}
