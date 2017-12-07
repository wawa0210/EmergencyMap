using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyCompany.Model;
using EmergencyBaseService;

namespace EmergencyCompany.Application
{
    public class CompanyService : BaseAppService, ICompanyService
    {
        public async Task<List<TableCompany>> GetAllCompanyInfo()
        {
            var orderPayRep = GetRepositoryInstance<TableCompany>();
            var restult = orderPayRep.FindAll();
            return restult.ToList();
        }
    }
}
