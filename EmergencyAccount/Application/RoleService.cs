using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using EmergencyAccount.Etity;
using EmergencyAccount.Model;
using EmergencyBaseService;
using EmergencyData.MicroOrm.SqlGenerator;
using EmergencyEntity.PageQuery;

namespace EmergencyAccount.Application
{
    public class RoleService : BaseAppService, IRoleService
    {
        public async Task<PageBase<EntityRole>> GetPageRoleInfo(EntityRolePageQuery entityRolePageQuery)
        {
            var result = new PageBase<EntityRole>
            {
                CurrentPage = entityRolePageQuery.CurrentPage,
                PageSize = entityRolePageQuery.PageSize
            };

            var strSql = new StringBuilder();

            //计算总数
            strSql.Append(@"        
                            SELECT  @totalCount = COUNT(1)
                            FROM    dbo.T_SysRole WITH ( NOLOCK ) where Status=1 ");

            if (!string.IsNullOrEmpty(entityRolePageQuery.RoleName))
            {
                strSql.Append(" and  RoleName like '%' + @roleName +'%' ;");
            }

            //分页信息
            strSql.Append(@"; SELECT * FROM ( SELECT   ROW_NUMBER() OVER(ORDER BY CreateTime DESC ) AS RowNumber,
                                       Id ,
                                       RoleName ,
                                       Status ,
                                       CreateTime ,
                                       Remark FROM dbo.T_SysRole where Status=1 ");

            if (!string.IsNullOrEmpty(entityRolePageQuery.RoleName))
            {
                strSql.Append(" and  RoleName like '%' + @roleName +'%' ");
            }
            strSql.Append(@"
                                   ) AS a
                            WHERE   a.RowNumber > @startIndex
                                    AND a.RowNumber <= @endIndex              
                        ");
            strSql.Append(@" order by a.RowNumber ");

            var paras = new DynamicParameters(new
            {
                roleName = entityRolePageQuery.RoleName,
                startIndex = (entityRolePageQuery.CurrentPage - 1) * entityRolePageQuery.PageSize,
                endIndex = entityRolePageQuery.CurrentPage * entityRolePageQuery.PageSize
            });
            var accountRep = GetRepositoryInstance<TableSysRole>();

            paras.Add("totalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var sqlQuery = new SqlQuery(strSql.ToString(), paras);
            result.Items = Mapper.Map<List<TableSysRole>, List<EntityRole>>((await accountRep.FindAllAsync(sqlQuery)).ToList());
            result.TotalCounts = paras.Get<int?>("totalCount") ?? 0;
            result.TotalPages = Convert.ToInt32(Math.Ceiling(result.TotalCounts / (entityRolePageQuery.PageSize * 1.0)));
            return result;
        }
    }
}
