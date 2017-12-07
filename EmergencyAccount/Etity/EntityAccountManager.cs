using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Etity
{
    public class EntityAccountManager
    {
        public int RoleId { get; set; }
        public int DeptId { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        public string UserPwd
        {
            get; set;
        }
        [JsonIgnore]

        public string UserSalt { get; set; }
        public string RealName { get; set; }
        public string Tel { get; set; }

        [JsonIgnore]

        public int IsLock { get; set; }
        public int Level { get; set; }
        public DateTime AddTime { get; set; }
    }
}
