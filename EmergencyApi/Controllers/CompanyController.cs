using EmergencyApi.Framework;
using EmergencyApi.Models;
using EmergencyCompany.Application;
using EmergencyCompany.Entity;
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

        ///// <summary>
        ///// 获得所有企业信息
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, HttpOptions]
        //[Route("")]
        //public async Task<ResponseModel> GetCompanyInfo()
        //{
        //    var result = await ICompanyService.GetAllCompanyInfo();
        //    return Success(result);
        //}

        /// <summary>
        /// 根据搜索获得企业信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpOptions]
        [Route("")]
        public async Task<ResponseModel> GetCompanyInfo([FromUri] EntityCompanySearch entityCompany)
        {
            if (entityCompany == null) entityCompany = new EntityCompanySearch();

            var result = await ICompanyService.GetCompanyInfo(entityCompany);
            return Success(result);
        }
    }
}
