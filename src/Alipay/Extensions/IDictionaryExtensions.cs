using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 提供 System.Collections.Generic.IDictionary 的扩展方法。
    /// </summary>
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// 将 IDictionary 中的参数按参数名称排序。
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public static IDictionary<string, string> Sort(this IDictionary<string, string> keyValues)
        {
            return keyValues.Keys.OrderBy(key => key)
                .ToDictionary(key => key, key => keyValues[key]);
        }

        /// <summary>
        /// 将 IDictionary 中的参数组合成字符串。
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public static string Join(this IDictionary<string, string> keyValues)
        {
            return Join(keyValues, value => value);
        }

        /// <summary>
        /// 将 IDictionary 中的参数组合成字符串。
        /// </summary>
        /// <param name="keyValues"></param>
        /// <param name="valueSelector">参数值的选择方法。使用此方法修改序列化字符串中的参数值。</param>
        /// <returns></returns>
        public static string Join(this IDictionary<string, string> keyValues,
            Func<string, string> valueSelector)
        {
            string[] strs = new string[keyValues.Count];
            var index = 0;
            foreach (var key in keyValues.Keys)
                strs[index++] = string.Format("{0}={1}", key, valueSelector(keyValues[key]));
            return string.Join("&", strs);
        }

    }
}
