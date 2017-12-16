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
    [RoutePrefix("v0/accounts")]
    public class AccountController : BaseApiController
    {


        private IAccountService IAccountService { get; set; }

        /// <summary>
        /// 初始化(autofac 已经注入)
        /// </summary>
        public AccountController()
        {
            IAccountService = new AccountService();
        }

        /// <summary>
        /// 根据用户编号获得用户详细信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpOptions]
        [Route("{userId}")]
        public ResponseModel GetAccountInfo(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return Fail(ErrorCodeEnum.ParamIsNullArgument);
            var result = IAccountService.GetAccountManagerInfo(userId);
            return Success(result);
        }

        /// <summary>
        /// 根据用户编号获得用户详细信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpOptions]
        [Route("query")]
        public ResponseModel CheckAccountInfo(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return Fail(ErrorCodeEnum.ParamIsNullArgument);
            return Success(IAccountService.GetAccountManager(userName));
        }

        /// <summary>
        /// 根据用户编号获得用户详细信息
        /// </summary>
        /// <returns></returns>
        [HttpPost, HttpOptions]
        [Route("")]
        public async Task<ResponseModel> AddAccountInfo(EntityAccountNewManager entityAccountNew)
        {
            var result = await IAccountService.AddAccountInfo(entityAccountNew);
            return Success(result);
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <returns></returns>
        [HttpPut, HttpOptions]
        [Route("pwd")]
        public async Task<ResponseModel> UpdateAccountPwd(EntityAccountPwd entityAccountPwd)
        {
            await IAccountService.UpdateAccountPwd(entityAccountPwd);
            return Success("更新成功");
        }

        /// <summary>
        /// 根据用户编号获得用户详细信息
        /// </summary>
        /// <returns></returns>
        [HttpPost, HttpOptions]
        [Route("delete")]
        public async Task<ResponseModel> DeleteAccountInfo(EntityAccountDelete entityAccountDelete)
        {
            if (entityAccountDelete.Id == "14E1952B-F674-4EE9-BD18-D4EB2F71084B") return Fail(ErrorCodeEnum.SuperManagerNotCanDelete);
            await IAccountService.DeleteManager(entityAccountDelete.Id);
            return Success("删除成功");
        }

        /// <summary>
        /// 根据用户编号获得用户详细信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpOptions]
        [Route("")]
        public async Task<ResponseModel> GetAccountInfo([FromUri]EntityAccountPageQuery entityAccountPageQuery)
        {
            if (entityAccountPageQuery == null) return Fail(ErrorCodeEnum.ParamIsNullArgument);
            var result = await IAccountService.GetAccountManagerInfo(entityAccountPageQuery);
            return Success(result);
        }
    }
}
