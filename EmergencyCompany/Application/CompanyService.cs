using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyCompany.Model;
using EmergencyBaseService;
using EmergencyCompany.Entity;
using EmergencyData.MicroOrm.SqlGenerator;
using Dapper;

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
            strSql.Append(@"SELECT  Id ,
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
                                    RiskLevel
                            FROM    dbo.T_Company WITH ( NOLOCK ) where 1= 1 ");
            if (!string.IsNullOrEmpty(entityCompany.CountryCode) && entityCompany.CountryCode!="0")
            {
                strSql.Append(" and County = @countryCode ");
            }
            if (!string.IsNullOrEmpty(entityCompany.CompanyName))
            {
                strSql.Append(" and CompanyName like '%' +@companyName + '%'");
            }
            if (entityCompany.RiskLevel!=0)
            {
                strSql.Append(" and RiskLevel = @riskLevel ");
            }

            var paras = new DynamicParameters(new
            {
                countryCode= entityCompany.CountryCode,
                companyName = entityCompany.CompanyName,
                riskLevel = entityCompany.RiskLevel,
            });

            var restult = companyRep.FindAll(new SqlQuery(strSql.ToString(), paras)).ToList();

            return restult;
        }
    }
}
