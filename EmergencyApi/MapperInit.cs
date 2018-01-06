using AutoMapper;
using EmergencyAccount.Etity;
using EmergencyAccount.Model;
using EmergencyCompany.Entity;
using EmergencyCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyApi
{
    public class MapperInit
    {
        public static void InitMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TableAccountManager, EntityAccountManager>()
                   .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                   .ForMember(x => x.RoleId, y => y.MapFrom(z => z.RoleId))
                   .ForMember(x => x.DeptId, y => y.MapFrom(z => z.DeptId))
                   .ForMember(x => x.UserPwd, y => y.MapFrom(z => z.UserPwd))
                   .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                   .ForMember(x => x.UserSalt, y => y.MapFrom(z => z.UserSalt))
                   .ForMember(x => x.RealName, y => y.MapFrom(z => z.RealName))
                   .ForMember(x => x.Tel, y => y.MapFrom(z => z.Tel))
                   .ForMember(x => x.IsLock, y => y.MapFrom(z => z.IsLock))
                   .ForMember(x => x.Level, y => y.MapFrom(z => z.Level))
                   .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
                   .ForAllOtherMembers(x => x.Ignore());

                cfg.CreateMap<EntityCompany, TableCompany>()
                    .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.CompanyName))
                    .ForMember(x => x.Provice, y => y.MapFrom(x => x.Provice))
                    .ForMember(x => x.ProvCode, y => y.MapFrom(x => x.ProvCode))
                    .ForMember(x => x.City, y => y.MapFrom(x => x.City))
                    .ForMember(x => x.CityCode, y => y.MapFrom(x => x.CityCode))
                    .ForMember(x => x.County, y => y.MapFrom(x => x.County))
                    .ForMember(x => x.CountyCode, y => y.MapFrom(x => x.CountyCode))
                    .ForMember(x => x.AddressDetail, y => y.MapFrom(x => x.AddressDetail))
                    .ForMember(x => x.Longitude, y => y.MapFrom(x => x.Longitude))
                    .ForMember(x => x.Latitude, y => y.MapFrom(x => x.Latitude))
                    .ForMember(x => x.Industry, y => y.MapFrom(x => x.Industry))
                    .ForMember(x => x.Economy, y => y.MapFrom(x => x.Economy))
                    .ForMember(x => x.CompanyDetail, y => y.MapFrom(x => x.CompanyDetail))
                    .ForMember(x => x.ZipCode, y => y.MapFrom(x => x.ZipCode))
                    .ForMember(x => x.FoundedTime, y => y.MapFrom(x => x.FoundedTime))
                    .ForMember(x => x.IssureTime, y => y.MapFrom(x => x.IssureTime))
                    .ForMember(x => x.IndustryCode, y => y.MapFrom(x => x.IndustryCode))
                    .ForMember(x => x.Owner, y => y.MapFrom(x => x.Owner))
                    .ForMember(x => x.CompanyScale, y => y.MapFrom(x => x.CompanyScale))
                    .ForMember(x => x.CompanyIncome, y => y.MapFrom(x => x.CompanyIncome))
                    .ForMember(x => x.ChiefSafeyName, y => y.MapFrom(x => x.ChiefSafeyName))
                    .ForMember(x => x.ChiefSafeyPhone, y => y.MapFrom(x => x.ChiefSafeyPhone))
                    .ForMember(x => x.ViceSafeyName, y => y.MapFrom(x => x.ViceSafeyName))
                    .ForMember(x => x.ViceSafeyPhone, y => y.MapFrom(x => x.ViceSafeyPhone))
                    .ForMember(x => x.OnDutyPhone, y => y.MapFrom(x => x.OnDutyPhone))
                    .ForMember(x => x.EmergencyPhone, y => y.MapFrom(x => x.EmergencyPhone))
                    .ForMember(x => x.CompanyProductDetail, y => y.MapFrom(x => x.CompanyProductDetail))
                    .ForMember(x => x.CreateTime, y => y.MapFrom(x => x.CreateTime))
                    .ForMember(x => x.Memo, y => y.MapFrom(x => x.Memo))
                    .ForMember(x => x.Status, y => y.MapFrom(x => x.Status))
                    .ForMember(x => x.RiskLevel, y => y.MapFrom(x => x.RiskLevel)).
                    ForAllOtherMembers(x => x.Ignore());

                cfg.CreateMap<EntityDangerousProduct, TableDangerousProduct>()
                   .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                   .ForMember(x => x.RegesterId, y => y.MapFrom(z => z.RegesterId))
                   .ForMember(x => x.ExpertOpinion, y => y.MapFrom(z => z.ExpertOpinion))
                   .ForMember(x => x.ManagementPlan, y => y.MapFrom(z => z.ManagementPlan))
                   .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                   .ForMember(x => x.ProductName, y => y.MapFrom(z => z.ProductName))
                   .ForMember(x => x.AliasName, y => y.MapFrom(z => z.AliasName))
                   .ForMember(x => x.ProductAttributes, y => y.MapFrom(z => z.ProductAttributes))
                   .ForMember(x => x.Manufacturability, y => y.MapFrom(z => z.Manufacturability))
                   .ForMember(x => x.ProductReserve, y => y.MapFrom(z => z.ProductReserve))
                   .ForMember(x => x.YearProduct, y => y.MapFrom(z => z.YearProduct))
                   .ForMember(x => x.Cas, y => y.MapFrom(z => z.Cas))
                   .ForMember(x => x.Un, y => y.MapFrom(z => z.Un))
                   .ForMember(x => x.IsToxicity, y => y.MapFrom(z => z.IsToxicity))
                   .ForMember(x => x.Instructions, y => y.MapFrom(z => z.Instructions))
                   .ForMember(x => x.Memo, y => y.MapFrom(z => z.Memo))
                   .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
                   .ForAllOtherMembers(x => x.Ignore());

                cfg.CreateMap<TableDangerousProduct, EntityDangerousProduct>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.RegesterId, y => y.MapFrom(z => z.RegesterId))
               .ForMember(x => x.ExpertOpinion, y => y.MapFrom(z => z.ExpertOpinion))
               .ForMember(x => x.ManagementPlan, y => y.MapFrom(z => z.ManagementPlan))
               .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
               .ForMember(x => x.ProductName, y => y.MapFrom(z => z.ProductName))
               .ForMember(x => x.AliasName, y => y.MapFrom(z => z.AliasName))
               .ForMember(x => x.ProductAttributes, y => y.MapFrom(z => z.ProductAttributes))
               .ForMember(x => x.Manufacturability, y => y.MapFrom(z => z.Manufacturability))
               .ForMember(x => x.ProductReserve, y => y.MapFrom(z => z.ProductReserve))
               .ForMember(x => x.YearProduct, y => y.MapFrom(z => z.YearProduct))
               .ForMember(x => x.Cas, y => y.MapFrom(z => z.Cas))
               .ForMember(x => x.Un, y => y.MapFrom(z => z.Un))
               .ForMember(x => x.IsToxicity, y => y.MapFrom(z => z.IsToxicity))
               .ForMember(x => x.Instructions, y => y.MapFrom(z => z.Instructions))
               .ForMember(x => x.Memo, y => y.MapFrom(z => z.Memo))
               .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
               .ForAllOtherMembers(x => x.Ignore());

            cfg.CreateMap<TableSysRole, EntityRole>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
             .ForMember(x => x.RoleName, y => y.MapFrom(z => z.RoleName))
             .ForMember(x => x.CreateTime, y => y.MapFrom(z => z.CreateTime))
             .ForAllOtherMembers(x => x.Ignore());
                
            }
            );
        }
    }
}