using EmergencyAccount.Application;
using EmergencyAccount.Etity;
using EmergencyApi.Framework;
using EmergencyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmergencyApi.Controllers
{
    [RoutePrefix("v0/roles")]
    public class RoleController : BaseApiController
    {
        private IRoleService IRoleService { get; set; }

        /// <summary>
        /// 初始化(autofac 已经注入)
        /// </summary>
        public RoleController(IRoleService _iRoleService)
        {
            IRoleService = _iRoleService;
        }

        /// <summary>
        /// 分页获得角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpOptions]
        [Route("")]
        public async Task<ResponseModel> GetPageRoleInfo([FromUri]EntityRolePageQuery entityRolePageQuery)
        {
            if (entityRolePageQuery == null) return Fail(ErrorCodeEnum.ParamIsNullArgument);
            var result = await IRoleService.GetPageRoleInfo(entityRolePageQuery);
            return Success(result);
        }
    }
}
