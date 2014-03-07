using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Extensions;

namespace Alipay.Validators
{
    /// <summary>
    /// 表示检测必需参数的校验器。
    /// </summary>
    internal class RequiredValidator : IValidator
    {
        /// <summary>
        /// 校验请求。
        /// </summary>
        /// <param name="provider">待校验的请求。</param>
        /// <exception cref="Alipay.Validators.RequiredParameterNotExistException">如果缺少必需参数则抛出异常。</exception>
        public void Validate(IParamProvider provider)
        {
            var requiredAttrs = this.GetRequiredAttributes(provider);
            
            foreach (RequiredAttribute required in requiredAttrs)
            {
                if (string.IsNullOrEmpty(provider.GetString(required.Key)))
                {
                    throw new RequiredParameterNotExistException 
                    {
                        Provider = provider,
                        Key = required.Key,
                    };
                }
            }
        }

        /// <summary>
        /// 返回待校验的自定义属性。
        /// </summary>
        /// <param name="request">待校验的请求。</param>
        /// <returns>返回待校验的自定义属性。</returns>
        private IEnumerable<object> GetRequiredAttributes(IParamProvider request)
        {
            var commandType = request.GetType();
            var results = new List<object>();

            foreach (var prop in commandType.GetProperties())
            {
                var required = prop.GetCustomAttributes(typeof(RequiredAttribute), true);
                if (required != null && required.Length > 0)
                    results.AddRange(required);
            }

            return results;
        }
    }
}
