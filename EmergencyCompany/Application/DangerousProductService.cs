using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyCompany.Entity;
using EmergencyBaseService;
using EmergencyCompany.Model;
using AutoMapper;
using CommonLib;

namespace EmergencyCompany.Application
{
    public class DangerousProductService : BaseAppService, IDangerousProductService
    {
        public async Task AddDangerousProduct(EntityDangerousProduct entityDangerous)
        {
            var model = Mapper.Map<EntityDangerousProduct, TableDangerousProduct>(entityDangerous);
            model.RegesterId = Utils.GetNewId();
            var dangerousProductRep = GetRepositoryInstance<TableDangerousProduct>();
            dangerousProductRep.Insert(model);
        }

        public async Task EditDangerousProduct(EntityDangerousProduct entityDangerous)
        {
            var model = Mapper.Map<EntityDangerousProduct, TableDangerousProduct>(entityDangerous);
            var dangerousProductRep = GetRepositoryInstance<TableDangerousProduct>();
            dangerousProductRep.Update<TableDangerousProduct>(
                model, dangerousProduct => new
                {
                    dangerousProduct.ProductName,
                    dangerousProduct.AliasName,
                    dangerousProduct.ProductAttributes,
                    dangerousProduct.Manufacturability,
                    dangerousProduct.ProductReserve,
                    dangerousProduct.YearProduct,
                    dangerousProduct.Cas,
                    dangerousProduct.Un,
                    dangerousProduct.IsToxicity,
                    dangerousProduct.Instructions,
                    dangerousProduct.Memo,
                    dangerousProduct.ExpertOpinion,
                    dangerousProduct.ManagementPlan
                });
        }

        public async Task<List<EntityDangerousProduct>> GetDangerousProduct(string companyId)
        {
            var dangerousProductRep = GetRepositoryInstance<TableDangerousProduct>();
            var restult = dangerousProductRep.FindAll(x => x.CompanyId == companyId).ToList();
            var model = Mapper.Map<List<TableDangerousProduct>, List<EntityDangerousProduct>>(restult);
            return model;
        }
    }
}
