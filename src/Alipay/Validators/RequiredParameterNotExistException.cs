using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.Validators
{
    /// <summary>
    /// 表示缺少必需参数的异常。
    /// </summary>
    public class RequiredParameterNotExistException : AlipayException
    {

        /// <summary>
        /// 获取或设置检测的参数对象。
        /// </summary>
        public IParamProvider Provider
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置检测的参数名称。
        /// </summary>
        public string Key
        {
            get;
            set;
        }
    }
}
