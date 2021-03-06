﻿using CommonLib;
using EmergencyApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace EmergencyApi.Framework
{
    /// <summary>
    /// model  数据校验
    /// </summary>
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                var checkResult = new ResponseModel();
                var errorFieldsAndMsgs = modelState.Where(m => m.Value.Errors.Any())
                    .Select(x => new { x.Key, x.Value.Errors });

                var listErrMsg = new List<dynamic>();
                foreach (var item in errorFieldsAndMsgs)
                {
                    var listMsgDetail = new List<dynamic>();

                    foreach (var msgItem in item.Errors)
                    {
                        //如果存在异常 暴露
                        var exceptionMsg = "";
                        if (msgItem.Exception != null)
                        {
                            exceptionMsg = msgItem.Exception.Message;
                        }
                        listMsgDetail.Add(new { msgItem.ErrorMessage, exceptionMsg });
                    }

                    listErrMsg.Add(new { item.Key, listMsgDetail });
                }

                checkResult.Data = JsonConvert.SerializeObject(listErrMsg);
                checkResult.Code = (int)ErrorCodeEnum.ParamsInvalid;
                checkResult.Message = EnumExtensionHelper.ToEnumDescriptionString((int)ErrorCodeEnum.ParamsInvalid, typeof(ErrorCodeEnum));

                //返回异常信息
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(checkResult))
                };
            }

        }
    }
}