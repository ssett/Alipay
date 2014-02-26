using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alipay.Validators;

namespace Alipay.Auth
{
    /// <summary>
    /// 表示支付宝快速登录通知。
    /// </summary>
    public class AlipayQuickLoginNotify : AlipayResponseBase, ISign
    {
        /// <summary>
        /// 初始化 Alipay.Authentication.AlipayQuickLoginNotify 类的新实例。
        /// </summary>
        /// <param name="config"></param>
        public AlipayQuickLoginNotify(AlipayConfig config)
            : base(config)
        {

        }

        #region 业务参数

        /// <summary>
        /// 获取通知校验ID。
        /// </summary>
        public string NotifyID
        {
            get { return this.GetString("notify_id"); }
        }

        /// <summary>
        /// 获取支付宝用户号。
        /// </summary>
        public string UserID
        {
            get { return this.GetString("user_id"); }
        }

        /// <summary>
        /// 获取支付宝用户名称或淘宝昵称。
        /// </summary>
        public string RealName
        {
            get { return this.GetString("real_name"); }
        }

        /// <summary>
        /// 获取支付宝登录账号。
        /// </summary>
        public string Email
        {
            get { return this.GetString("email"); }
        }

        /// <summary>
        /// 获取授权令牌。
        /// </summary>
        public string Token
        {
            get { return this.GetString("token"); }
        }

        /// <summary>
        /// 获取用户等级。
        /// </summary>
        public UserGrade UserGrade
        {
            get { return this.GetEnum<UserGrade>("user_grade"); }
        }

        /// <summary>
        /// 获取用户等级类型。
        /// </summary>
        public UserGradeType UserGradeType
        {
            get { return (UserGradeType)this.GetInt32("user_grade_type"); }
        }

        /// <summary>
        /// 获取用户等级衰减时间。
        /// </summary>
        public DateTime? GmtDecay
        {
            get { return this.GetNullableDateTime("gmt_decay"); }
        }

        /// <summary>
        /// 获取目标商户跳转结果页面。
        /// </summary>
        public string TargetUrl
        {
            get { return this.GetString("target_url"); }
        }


        #endregion

    }
}
