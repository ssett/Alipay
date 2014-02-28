using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Alipay.Extensions
{
    static class NameValueCollectionExtension
    {
        public static IDictionary<string, string> ToDictionary(
            this NameValueCollection collection)
        {
            var dict = new Dictionary<string, string>();

            foreach (string key in collection.Keys)
                dict.Add(key, collection[key].ToString());
            
            return dict;
        }
    }
}
