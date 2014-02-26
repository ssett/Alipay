using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    /// <summary>
    /// 表示支付宝布尔值。
    /// </summary>
    public class AliBoolean
    {
        /// <summary>
        /// 表示 true 的支付宝布尔值。
        /// </summary>
        public static readonly AliBoolean True = new AliBoolean { Value = "Y" };

        /// <summary>
        /// 表示 false 的支付宝布尔值。
        /// </summary>
        public static readonly AliBoolean False = new AliBoolean { Value = "N" };

        private AliBoolean()
        { }

        /// <summary>
        /// 初始化 Alipay.Bool 类的新实例。
        /// </summary>
        /// <param name="value">布尔值。</param>
        public AliBoolean(bool value)
        {
            this.Value = (value) ? True.Value : False.Value;
        }

        private string Value { get; set; }

        /// <summary>
        /// 返回当前 Alipay.AlipayBoolean 的字符串表示。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Value;
        }

    }
}
