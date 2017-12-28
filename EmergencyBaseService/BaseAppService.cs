using EmergencyData;
using EmergencyData.MicroOrm;
using EmergencyData.MicroOrm.SqlGenerator;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyBaseService
{
    /// <summary>
    /// AppService基类
    /// </summary>
    public class BaseAppService
    {

        private IDbConnection _connection;
        public BaseAppService()
        {

        }

        /// <summary>
        /// 根据类型获取Repository对象
        /// </summary>
        /// <typeparam name="T">Repository对象类型</typeparam>
        /// <returns></returns>
        protected virtual DapperRepository<T> GetRepositoryInstance<T>(string connStr = null) where T : class, new()
        {
            //获取程序集名+类名，作为CallContext的key
            var type = typeof(T);
            var typeName = type.Assembly.FullName + type.FullName;

            System.Diagnostics.Debug.WriteLine(typeName);

            //保证在同一个HTTP请求下，对象是单例的,优先从CallContext中取
            var repository = CallContext.GetData(typeName) as DapperRepository<T>;

            if (repository == null)
            {
                if (_connection == null)
                {
                    if (string.IsNullOrEmpty(connStr))
                        connStr = WebConfigSetting.GetInstance.DbConnectionString;
                    _connection = new MySqlConnection(connStr);
                }
                repository = new DapperRepository<T>(_connection, ESqlConnector.MySql);
                CallContext.SetData(typeName, repository);
            }
            return repository;
        }
    }
}
