using CommonLib;
using EmergencyAccount.Application;
using EmergencyAccount.Data;
using EmergencyAccount.Etity;
using EmergencyApi.Framework;
using EmergencyApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public AuthController(IAccountService _iAccountService)
        {
            IAccountService = _iAccountService;
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


        /// <summary>
        /// 获得token 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("image")]
        public async Task<HttpResponseMessage> GetAccountImg()
        {
            var imgPath = Directory.GetCurrentDirectory();

            var client = new WebClient();
            var result = await client.DownloadDataTaskAsync("http://pic1.sc.chinaz.com/files/pic/pic9/201712/bpic4898.jpg");

            //从图片中读取流
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(result)
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");

            return resp;
        }
    }
}
