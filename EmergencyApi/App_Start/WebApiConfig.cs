using EmergencyApi.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;

namespace EmergencyApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 移除XML格式输出
            var json = config.Formatters.JsonFormatter;
            // 解决json序列化时的循环引用问题
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // 包括 exception detail
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // 禁用XML序列化器
            config.Formatters.XmlFormatter.UseXmlSerializer = false;

            // 使用attribute路由规则 
            config.MapHttpAttributeRoutes();

            //跨域配置(后期拿掉)
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.Filters.Add(new WebApiPowerAttribute());
            config.Filters.Add(new WebApiExceptionAttribute());
            config.Filters.Add(new ValidationActionFilter());

            //日期格式
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new MyDateTimeConvertor());

            ////设置json对象的首字符小写
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //DependencyRegister.Register(config);
        }
    }
    /// <summary>
    /// 自定义时间格式
    /// </summary>
    public class MyDateTimeConvertor : IsoDateTimeConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
