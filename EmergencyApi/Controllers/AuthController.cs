﻿using CommonLib;
using EmergencyAccount.Application;
using EmergencyAccount.Data;
using EmergencyAccount.Etity;
using EmergencyApi.Framework;
using EmergencyApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmergencyApi.Controllers
{
    [RoutePrefix("v0/auth")]
    public class AuthController : BaseApiController
    {
        private IAccountService IAccountService { get; set; }

        /// <summary>
        /// 初始化(autofac 已经注入)
        /// </summary>
        public AuthController()
        {
            IAccountService = new AccountService();
        }

        /// <summary>
        /// 获得token 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost, HttpOptions]
        [AllowAnonymous]
        [Route("token")]
        public ResponseModel GetAccountAuth(EntityLoginModel loginModel)
        {
            var result = IAccountService.GetAccountManager(loginModel.UserName);

            if (result == null) return Fail(ErrorCodeEnum.UserIsNull);

            var checkResult = IAccountService.CheckLoginInfo(loginModel.UserPwd, result.UserSalt, result.UserPwd);
            if (!checkResult) return Fail(ErrorCodeEnum.UserPwdCheckFaild);

            return Success(new
            {
                token = AesHelper.Encrypt(JsonConvert.SerializeObject(result)),
                userInfo = result
            });
        }
    }
}
