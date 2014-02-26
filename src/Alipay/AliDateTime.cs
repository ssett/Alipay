using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 表示支付宝日期时间。如 90m、24h、7d、1c，等等。
    /// </summary>
    public class AliDateTime
    {
        private AliDateTime()
        {
            
        }

        /// <summary>
        /// 获取支付宝 DateTime 的值。
        /// </summary>
        public string Value { get; private set; }


        /// <summary>
        /// 分钟数。
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static AliDateTime Minutes(int minutes)
        {
            return new AliDateTime { Value = string.Format("{0}m", minutes) };
        }

        /// <summary>
        /// 小时数。
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static AliDateTime Hours(int hours)
        {
            return new AliDateTime { Value = string.Format("{0}h", hours) };
        }

        /// <summary>
        /// 天数。
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static AliDateTime Days(int days)
        {
            return new AliDateTime { Value = string.Format("{0}d", days) };
        }

        /// <summary>
        /// 当天（无论交易何时创建，都在 0 点关闭）
        /// </summary>
        /// <returns></returns>
        public static AliDateTime Today()
        {
            return new AliDateTime { Value = "1c" };
        }

        /// <summary>
        /// 将 AlipayDateTime 的字符串表示形式转换为 AlipayDateTime 实例。
        /// </summary>
        /// <param name="s">要转换的 AlipayDateTime 字符串。</param>
        /// <returns></returns>
        public static AliDateTime Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentNullException("s");

            var str = s.Trim();

            // 拆解字符串。
            var strNum = str.Substring(0, str.Length - 1);
            var strUnit = str.Substring(str.Length - 1).ToLower();

            // 验证数字。
            int num;
            if (!int.TryParse(strNum, out num))
                throw new FormatException();

            // 验证日期时间单位。
            var exists = new[] { "m", "h", "d", "c" }.Any(unit => unit == strUnit);
            if (!exists)
                throw new FormatException();

            // 返回 AlipayDateTime。
            return new AliDateTime { Value = string.Format("{0}{1}", num, strUnit) };
        }

    }
}
