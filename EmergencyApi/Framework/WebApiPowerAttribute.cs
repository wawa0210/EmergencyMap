using CommonLib;
using EmergencyAccount.Etity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmergencyApi.Framework
{
    public class WebApiPowerAttribute : ActionFilterAttribute
    {

        //Action方法执行之前执行此方法
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            //给每一次请求分配一个特定编号
            CallContext.SetData(Constants.RequestLogId, DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + CommonHelper.GetTimeStamp());

            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return;
            }


            //前期考虑 前端调用直接把userid 以及accid 放在header里边  后期考虑使用token
            var request = actionContext.Request.Headers;

            var jsonFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            };

            var token = request.SingleOrDefault(x => x.Key.ToLower() == "token");
            var userContext = new EntityAccountManager();


            //token 授权
            if (token.Key != null)
            {
                try
                {
                    var strToken = token.Value.FirstOrDefault();
                    //解密获得token原始信息
                    var aesToken = AesHelper.Decrypt(strToken);
                    //添加到用户上下文
                    userContext = JsonConvert.DeserializeObject<EntityAccountManager>(aesToken);
                }
                catch
                {
                    throw new EmergencyException("api接口请求验证不通过", (int)ErrorCodeEnum.TokenIsExpired);
                }
            }
            else
            {
                throw new EmergencyException("api接口请求验证不通过", (int)ErrorCodeEnum.ApiRequestForbidden);
            }

            actionContext.Request.Properties[Constants.GlobalUserContextKeyName] = userContext;
            System.Threading.Thread.CurrentPrincipal = new EmergencyPrincipal
            {
                UserContext = userContext
            };
        }
    }
}