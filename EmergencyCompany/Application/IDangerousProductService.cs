using EmergencyCompany.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyCompany.Application
{
    public interface IDangerousProductService
    {
        Task<List<EntityDangerousProduct>> GetDangerousProduct(string companyId);

        Task AddDangerousProduct(EntityDangerousProduct entityDangerous);

        Task EditDangerousProduct(EntityDangerousProduct entityDangerous);
    }
}
