using EmergencyApi.Models;
using EmergencyCompany.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmergencyApi.Controllers
{
    [RoutePrefix("v0/companies")]
    public class CompanyController : BaseApiController
    {
        private ICompanyService ICompanyService { get; set; }

        /// <summary>
        /// 初始化(autofac 已经注入)
        /// </summary>
        public CompanyController()
        {
            ICompanyService = new CompanyService();
        }

        /// <summary>
        /// 根据用户编号获得用户详细信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpOptions]
        [Route("")]
        public async Task<ResponseModel> GetAccountInfo()
        {
            var result = await ICompanyService.GetAllCompanyInfo();
            return Success(result);
        }
    }
}
