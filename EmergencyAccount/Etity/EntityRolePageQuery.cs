using EmergencyEntity.PageQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Etity
{
    public class EntityRolePageQuery : EntityBasePageQuery
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get; set;
        }
    }
}
