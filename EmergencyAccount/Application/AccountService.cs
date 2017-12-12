using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyAccount.Etity;
using EmergencyAccount.Data;
using CommonLib;
using EmergencyBaseService;
using EmergencyAccount.Model;
using AutoMapper;
using EmergencyEntity.PageQuery;
using EmergencyData.MicroOrm.SqlGenerator;
using System.Data;
using Dapper;

namespace EmergencyAccount.Application
{
    public class AccountService : BaseAppService, IAccountService
    {

        public bool CheckLoginInfo(string inputPwd, string salt, string dbPwd)
        {
            var userPwd = DESEncrypt.Encrypt(inputPwd, salt);
            return userPwd == dbPwd;
        }

        public async Task<PageBase<EntityAccountManager>> GetAccountManagerInfo(EntityAccountPageQuery entityAccountPageQuery)
        {
            var result = new PageBase<EntityAccountManager>
            {
                CurrentPage = entityAccountPageQuery.CurrentPage,
                PageSize = entityAccountPageQuery.PageSize
            };

            var strSql = new StringBuilder();

            //计算总数
            strSql.Append(@"        
                            SELECT  @totalCount = COUNT(1)
                            FROM    dbo.T_Sys_Manager WITH ( NOLOCK ) ");

            if (!string.IsNullOrEmpty(entityAccountPageQuery.UserName))
            {
                strSql.Append(" where  UserName like '%' + @userName +'%' ;");
            }

            //分页信息
            strSql.Append(@"; SELECT * FROM (SELECT  ROW_NUMBER() OVER ( ORDER BY AddTime DESC ) RowNumber ,
                                   Id ,
                                   RoleId ,
                                   DeptId ,
                                   UserName ,
                                   UserPwd ,
                                   UserSalt ,
                                   RealName ,
                                   Tel ,
                                   IsLock ,
                                   Level ,
                                   AddTime FROM dbo.T_Sys_Manager WITH(NOLOCK) ");

            if (!string.IsNullOrEmpty(entityAccountPageQuery.UserName))
            {
                strSql.Append(" where  userName like '%' + @userName +'%' ");
            }
            strSql.Append(@"
                                   ) AS a
                            WHERE   a.RowNumber > @startIndex
                                    AND a.RowNumber <= @endIndex              
                        ");
            strSql.Append(@" order by a.RowNumber ");

            var paras = new DynamicParameters(new
            {
                userName = entityAccountPageQuery.UserName,
                startIndex = (entityAccountPageQuery.CurrentPage - 1) * entityAccountPageQuery.PageSize,
                endIndex = entityAccountPageQuery.CurrentPage * entityAccountPageQuery.PageSize
            });
            var accountRep = GetRepositoryInstance<TableAccountManager>();

            paras.Add("totalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var sqlQuery = new SqlQuery(strSql.ToString(), paras);
            result.Items = Mapper.Map<List<TableAccountManager>, List<EntityAccountManager>>(accountRep.FindAll(sqlQuery).ToList());
            result.TotalCounts = paras.Get<int?>("totalCount") ?? 0;
            result.TotalPages = Convert.ToInt32(Math.Ceiling(result.TotalCounts / (entityAccountPageQuery.PageSize * 1.0)));
            return result;
        }

        public EntityAccountManager GetAccountManager(string userName)
        {
            var accountRep = GetRepositoryInstance<TableAccountManager>();
            var restult = accountRep.Find(x => x.UserName == userName);

            return Mapper.Map<TableAccountManager, EntityAccountManager>(restult);
        }

        public EntityAccountManager GetAccountManagerInfo(string useId)
        {
            var accountRep = GetRepositoryInstance<TableAccountManager>();
            var restult = accountRep.Find(x => x.Id == useId);

            return Mapper.Map<TableAccountManager, EntityAccountManager>(restult);
        }
    }
}
