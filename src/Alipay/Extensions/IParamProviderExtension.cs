using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Alipay
{
    /// <summary>
    /// 为 Pay.IParamProvider 参数字典提供扩展方法。
    /// </summary>
    public static class IParamProviderExtension
    {
        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <returns></returns>
        public static bool? GetNullableBoolean(
            this IParamProvider provider, string key)
        {
            var s = GetString(provider, key);

            if (string.IsNullOrEmpty(s))
                return null;

            return GetBoolean(provider, key, false);
        }

        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <returns></returns>
        public static AliDateTime GetDate(
            this IParamProvider provider, string key)
        {
            var s = GetString(provider, key);

            try
            {
                return AliDateTime.Parse(s);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <returns></returns>
        public static AliBoolean GetBoolOrDefault(this IParamProvider provider, string key)
        {
            var b = GetNullableBoolean(provider, key);

            if (b != null)
                return new AliBoolean(b.Value);
            else
                return null;
        }

        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <param name="default">参数值为 null 时返回的默认值。</param>
        /// <returns></returns>
        public static bool GetBoolean(this IParamProvider provider,
            string key, bool @default = false)
        {
            var s = GetString(provider, key);

            if (string.IsNullOrEmpty(s))
                return @default;

            switch (s.ToUpper())
            {
                case "TRUE":
                case "T":
                case "YES":
                case "Y":
                case "1":
                    return true;
                case "FALSE":
                case "F":
                case "NO":
                case "N":
                case "0":
                    return false;
            }

            return @default;
        }

        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <returns></returns>
        public static DateTime? GetNullableDateTime(
            this IParamProvider provider, string key)
        {
            return GetNullableDateTime(provider, key, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <param name="format">用于 DateTime 格式化的字符串。</param>
        /// <returns></returns>
        public static DateTime? GetNullableDateTime(
            this IParamProvider provider, string key, string format)
        {
            var s = provider.GetString(key);
            if (!string.IsNullOrEmpty(s))
                return DateTime.ParseExact(s, format, null);
            else
                return null;
        }

        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <returns></returns>
        public static double? GetNullableDouble(
            this IParamProvider provider, string key)
        {
            var s = provider.GetString(key);
            double ret;
            if (double.TryParse(s, out ret))
                return ret;
            else
                return null;
        }

        /// <summary>
        ///  根据名称返回参数值。
        /// </summary>
        /// <typeparam name="TEnum">返回的枚举名称。</typeparam>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <returns></returns>
        public static TEnum GetEnum<TEnum>(
            this IParamProvider provider, string key)
            where TEnum : struct
        {
            var s = GetString(provider, key);

            if (Enum.IsDefined(typeof(TEnum), s))
                return (TEnum)Enum.Parse(typeof(TEnum), s);

            return default(TEnum);
        }

        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <param name="default">参数值为 Null 时返回的默认值。</param>
        /// <returns></returns>
        public static int GetInt32(this IParamProvider provider,
            string key, int @default = 0)
        {
            var s = provider.GetString(key);
            int ret;
            if (int.TryParse(s, out ret))
                return ret;
            else
                return @default;
        }

        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <returns></returns>
        public static IPAddress GetIPAddress(this IParamProvider provider, string key)
        {
            var s = GetString(provider, key);

            IPAddress address;
            if (IPAddress.TryParse(s, out address))
                return address;
            else
                return null;
        }

        /// <summary>
        /// 根据名称返回参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <returns></returns>
        public static string GetString(this IParamProvider provider, string key)
        {
            if (provider.Parameters.ContainsKey(key))
                return provider.Parameters[key];
            else
                return null;
        }


        /// <summary>
        /// 设置指定名称的参数值。
        /// </summary>
        /// <typeparam name="TValue">参数值的类型。</typeparam>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <param name="value"></param>
        public static void Set<TValue>(this IParamProvider provider,
            string key, TValue value)
        {
            if (string.IsNullOrEmpty(key))
                return;

            if (value == null)
            {
                if (provider.Parameters.ContainsKey(key))
                    provider.Parameters.Remove(key);

                return;
            }

            if (provider.Parameters.ContainsKey(key))
                provider.Parameters[key] = value.ToString();
            else
                provider.Parameters.Add(key, value.ToString());
        }

        /// <summary>
        /// 设置指定名称的参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="maxLength">
        /// 字符串的最大长度。如果超出 maxLength，则抛出 System.ArgumentOutOfRangeException 异常。
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// 如果超出 maxLength，则抛出 System.ArgumentOutOfRangeException 异常。
        /// </exception>
        public static void Set(this IParamProvider provider,
            string key, string value, int maxLength)
        {
            if (value != null && value.Length > maxLength)
                throw new ArgumentOutOfRangeException("value");

            Set(provider, key, value);
        }

        /// <summary>
        /// 设置指定名称的参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">要设置的参数名称。</param>
        /// <param name="value">要设置的参数值。</param>
        /// <param name="minimum">
        /// 参数的最小值。如果参数值小于最小值，则抛出 System.ArgumentOutOfRangeException 异常。
        /// </param>
        /// <param name="maximum">
        /// 参数的最大值。如果参数值大于最大值，则抛出 System.ArgumentOutOfRangeException 异常。
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// 如果参数值小于最小值或大于最大值，则抛出 System.ArgumentOutOfRangeException 异常。
        /// </exception>
        public static void Set(this IParamProvider provider,
            string key, double? value, double minimum, double maximum)
        {
            if (value.HasValue)
            {
                var d = value.Value;
                if (d < minimum || d > maximum)
                    throw new ArgumentOutOfRangeException("value", d, null);
            }

            Set(provider, key, value);
        }

        /// <summary>
        /// 设置指定名称的参数值。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="format">用于 DateTime 格式化的字符串。例如：yyyy-MM-dd HH:mm:ss。</param>
        public static void Set(this IParamProvider provider,
            string key, DateTime? value, string format)
        {
            if (value == null)
                Set(provider, key, value);
            else
                Set(provider, key, ((DateTime)value).ToString(format));
        }



    }
}
