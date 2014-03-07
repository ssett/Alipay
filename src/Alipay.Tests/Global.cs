using Alipay.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alipay
{
    static class Global
    {
        static Global()
        {
            Config = new AlipayConfig
            {
                Partner = "2088101568338364",
                Key = "7d314d22efba4f336fb187697793b9d2",
                SignType = "MD5",
            };
        }

        public static AlipayConfig Config
        {
            get;
            private set;
        }
    }
}
