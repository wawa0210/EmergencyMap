﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyCompany.Model;
using EmergencyBaseService;
using EmergencyCompany.Entity;
using EmergencyData.MicroOrm.SqlGenerator;
using Dapper;
using EmergencyEntity.PageQuery;
using System.Data;

namespace EmergencyCompany.Application
{
    public class CompanyService : BaseAppService, ICompanyService
    {
        public async Task<List<TableCompany>> GetAllCompanyInfo()
        {
            var companyRep = GetRepositoryInstance<TableCompany>();
            var restult = companyRep.FindAll();
            return restult.ToList();
        }

        /// <summary>
        /// 暂时不支持分页
        /// </summary>
        /// <param name="entityCompany"></param>
        /// <returns></returns>
        public async Task<List<TableCompany>> GetCompanyInfo(EntityCompanySearch entityCompany)
        {
            var companyRep = GetRepositoryInstance<TableCompany>();

            var strSql = new StringBuilder();
            strSql.Append(@"SELECT Id ,
                                   CompanyName ,
                                   Provice ,
                                   City ,
                                   County ,
                                   AddressDetail ,
                                   Longitude ,
                                   Latitude ,
                                   Industry ,
                                   Economy ,
                                   CompanyDetail ,
                                   ZipCode ,
                                   FoundedTime ,
                                   IssureTime ,
                                   IndustryCode ,
                                   Owner ,
                                   CompanyScale ,
                                   CompanyIncome ,
                                   ChiefSafeyName ,
                                   ChiefSafeyPhone ,
                                   ViceSafeyName ,
                                   ViceSafeyPhone ,
                                   OnDutyPhone ,
                                   EmergencyPhone ,
                                   CompanyProductDetail ,
                                   CreateTime ,
                                   Memo ,
                                   Status ,
                                   RiskLevel ,
                                   ProvCode ,
                                   CityCode ,
                                   CountyCode FROM T_Company WITH ( NOLOCK ) where 1= 1 ");
            if (!string.IsNullOrEmpty(entityCompany.CountryCode) && entityCompany.CountryCode != "0")
            {
                strSql.Append(" and CountyCode = @countryCode ");
            }
            if (!string.IsNullOrEmpty(entityCompany.CompanyName))
            {
                strSql.Append(" and CompanyName like '%' +@companyName + '%'");
            }
            if (entityCompany.RiskLevel != 0)
            {
                strSql.Append(" and RiskLevel = @riskLevel ");
            }

            var paras = new DynamicParameters(new
            {
                countryCode = entityCompany.CountryCode,
                companyName = entityCompany.CompanyName,
                riskLevel = entityCompany.RiskLevel,
            });

            var restult = companyRep.FindAll(new SqlQuery(strSql.ToString(), paras)).ToList();

            return restult;
        }

        public async Task<TableCompany> GetCompanyInfo(string id)
        {
            var companyRep = GetRepositoryInstance<TableCompany>();
            var restult = companyRep.Find(x => x.Id == id);
            return restult;
        }

        /// <summary>
        /// 企业搜索分页
        /// </summary>
        /// <param name="companyPageQuery"></param>
        /// <returns></returns>
        public async Task<PageBase<TableCompany>> GetPageCompanyInfo(EntityCompanyPageQuery companyPageQuery)
        {
            var result = new PageBase<TableCompany>
            {
                CurrentPage = companyPageQuery.CurrentPage,
                PageSize = companyPageQuery.PageSize
            };

            var strSql = new StringBuilder();

            //计算总数
            strSql.Append(@"        
                            SELECT  @totalCount = COUNT(1)
                            FROM    dbo.T_Company WITH ( NOLOCK ) ");

            if (!string.IsNullOrEmpty(companyPageQuery.CompanyName))
            {
                strSql.Append(" where  CompanyName like '%' + @companyName +'%' ;");
            }

            //分页信息
            strSql.Append(@";   SELECT * FROM (SELECT  ROW_NUMBER() OVER ( ORDER BY CreateTime DESC ) RowNumber ,
                                Id ,
                                CompanyName ,
                                Provice ,
                                City ,
                                County ,
                                AddressDetail ,
                                Longitude ,
                                Latitude ,
                                Industry ,
                                Economy ,
                                CompanyDetail ,
                                ZipCode ,
                                FoundedTime ,
                                IssureTime ,
                                IndustryCode ,
                                Owner ,
                                CompanyScale ,
                                CompanyIncome ,
                                ChiefSafeyName ,
                                ChiefSafeyPhone ,
                                ViceSafeyName ,
                                ViceSafeyPhone ,
                                OnDutyPhone ,
                                EmergencyPhone ,
                                CompanyProductDetail ,
                                CreateTime ,
                                Memo ,
                                Status ,
                                RiskLevel ,
                                ProvCode ,
                                CityCode ,
                                CountyCode
                        FROM    dbo.T_Company WITH ( NOLOCK ) ");

            if (!string.IsNullOrEmpty(companyPageQuery.CompanyName))
            {
                strSql.Append(" where  CompanyName like '%' + @companyName +'%' ");
            }
            strSql.Append(@"
                                   ) AS a
                            WHERE   a.RowNumber > @startIndex
                                    AND a.RowNumber <= @endIndex              
                        ");
            strSql.Append(@" order by a.RowNumber ");

            var paras = new DynamicParameters(new
            {
                companyName = companyPageQuery.CompanyName,
                startIndex = (companyPageQuery.CurrentPage - 1) * companyPageQuery.PageSize,
                endIndex = companyPageQuery.CurrentPage * companyPageQuery.PageSize
            });
            var companyRep = GetRepositoryInstance<TableCompany>();

            paras.Add("totalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var sqlQuery = new SqlQuery(strSql.ToString(), paras);
            result.Items = companyRep.FindAll(sqlQuery).ToList();
            result.TotalCounts = paras.Get<int?>("totalCount") ?? 0;
            result.TotalPages = Convert.ToInt32(Math.Ceiling(result.TotalCounts / (companyPageQuery.PageSize * 1.0)));
            return result;
        }
    }
}
