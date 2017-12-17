using EmergencyApi.Framework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

[assembly: OwinStartup(typeof(EmergencyApi.Startup))]
namespace EmergencyApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            MapperInit.InitMapping();

            app.UseCors(CorsOptions.AllowAll);
            var config = new HttpConfiguration();

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

            config.MessageHandlers.Add(new CorsHandler());
            config.Filters.Add(new WebApiPowerAttribute());
            config.Filters.Add(new WebApiExceptionAttribute());
            config.Filters.Add(new ValidationActionFilter());

            //日期格式
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new MyDateTimeConvertor());

            ////设置json对象的首字符小写
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            app.UseWebApi(config);
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