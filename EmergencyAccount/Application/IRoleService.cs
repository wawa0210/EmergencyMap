using EmergencyAccount.Etity;
using EmergencyEntity.PageQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Application
{
    public interface IRoleService
    {
        Task<PageBase<EntityRole>> GetPageRoleInfo(EntityRolePageQuery entityRolePageQuery);

    }
}
