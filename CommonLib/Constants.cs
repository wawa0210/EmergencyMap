using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class Constants
    {
        public const string RequestLogId = "const_ReuqestLogId";

        /// <summary>
        /// 放在Request.Context.Properties中UserContext对象的key
        /// </summary>
        public const string GlobalUserContextKeyName = "_userInfoContext";
    }
}
