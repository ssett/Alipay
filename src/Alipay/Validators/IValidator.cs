using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay.Validators
{
    /// <summary>
    /// 提供请求校验功能。
    /// </summary>
    internal interface IValidator
    {
        /// <summary>
        /// 校验请求。
        /// </summary>
        /// <param name="request">待校验的请求。</param>
        void Validate(IParamProvider request);
    }
}
