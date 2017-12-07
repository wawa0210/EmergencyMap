using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace EmergencyApi.Framework
{
    public class WebApiExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly string _exceptionMessageTips = "您输入的信息暂时无法被生意专家识别，如果该信息对您十分重要可联系服务专员，谢谢！";

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var param = JsonConvert.SerializeObject(actionExecutedContext.ActionContext.ActionArguments);
            //ToExceptionLess
            if (actionExecutedContext.Exception != null && !(actionExecutedContext.Exception is EmergencyException))
            {
                // SimpleLog.Instance.WriteLogForFile("错误日志", actionExecutedContext.Exception.Message+"||"+ param);
                //ExceptionExtensions.Exception(actionExecutedContext);
                //ExceptionExtensions.Info(param);
            }

        }
    }
}