﻿using EmergencyApi.Framework;
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
    /// <summary>
    /// 危险源信息
    /// </summary>
    [RoutePrefix("v0/dangerousproducts")]
    public class DangerousProductController : BaseApiController
    {

        private IDangerousProductService IDangerousProductService { get; set; }

        /// <summary>
        /// 初始化(autofac 已经注入)
        /// </summary>
        public DangerousProductController()
        {
            IDangerousProductService = new DangerousProductService();
        }

        /// <summary>
        /// 获得企业危险源信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpOptions]
        [Route("")]
        public ResponseModel GetDangerousProductInfo(string companyId)
        {
            if (string.IsNullOrEmpty(companyId)) return Fail(ErrorCodeEnum.ParamIsNullArgument);
            var result = IDangerousProductService.GetDangerousProduct(companyId);
            return Success(result.Result);
        }

        /// <summary>
        /// 添加企业危险源信息
        /// </summary>
        /// <returns></returns>
        [HttpPost, HttpOptions]
        [Route("")]
        public ResponseModel AddDangerousProductInfo(EntityDangerousProduct entityDangerous)
        {
            var result = IDangerousProductService.AddDangerousProduct(entityDangerous);
            return Success("保存成功");
        }

        /// <summary>
        /// 编辑企业危险源信息
        /// </summary>
        /// <returns></returns>
        [HttpPut, HttpOptions]
        [Route("")]
        public ResponseModel EditDangerousProductInfo(EntityDangerousProduct entityDangerous)
        {
            if(string.IsNullOrEmpty(entityDangerous.Id)) return Fail(ErrorCodeEnum.ParamsInvalid);
            var result = IDangerousProductService.EditDangerousProduct(entityDangerous);
            return Success("保存成功");
        }

        /// <summary>
        /// 分页获得危险源信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpOptions]
        [Route("pageinfo")]
        public async Task<ResponseModel> GetPageDangerousProductInfo([FromUri] EntityDangerousPageQuery dangerousPageQuery)
        {
            if (dangerousPageQuery == null) return Fail(ErrorCodeEnum.ParamIsNullArgument);

            var result = await IDangerousProductService.GetPageDangerousInfo(dangerousPageQuery);
            return Success(result);
        }
    }
}