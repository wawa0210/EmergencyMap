using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyBaseService
{
    public sealed class WebConfigSetting
    {
        private static WebConfigSetting _instance = null;
        private static readonly object Padlock = new object();

        public static WebConfigSetting GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = InitConfiguration();
                        }
                    }
                }
                return _instance;
            }
        }

        private static WebConfigSetting InitConfiguration()
        {
            return new WebConfigSetting
            {
                DbConnectionString = ConfigurationManager.ConnectionStrings["EmergencyConn"] == null ? string.Empty : ConfigurationManager.ConnectionStrings["EmergencyConn"].ConnectionString,
            };
        }

        /// <summary>
        /// 主站数据库记录
        /// </summary>
        public string DbConnectionString { get; set; }
    }
}
