using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Pay.Util
{
    /// <summary>
    /// 工具类。
    /// </summary>
    public static class PayUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public static IDictionary<string, string> ToDictionary(NameValueCollection keyValues)
        {
            var dict = new Dictionary<string, string>();
            foreach (string key in keyValues.Keys)
                dict.Add(key, keyValues[key]);
            return dict;
        }

    }
}
