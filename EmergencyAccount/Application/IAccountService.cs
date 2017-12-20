using EmergencyAccount.Etity;
using EmergencyEntity.PageQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Application
{
    public interface IAccountService
    {

        EntityAccountManager GetAccountManager(string userName);


        Task<EntityAccountManager> GetAccountManagerInfo(string useId);

        Task DeleteManager(string managerId);

        Task<bool> AddAccountInfo(EntityAccountNewManager entityAccountNew);

        Task UpdateAccountPwd(EntityAccountPwd entityAccountPwd);

        Task UpdateAccount(EntityAccount entityAccount);

        Task<PageBase<EntityAccountManager>> GetAccountManagerInfo(EntityAccountPageQuery entityAccountPageQuery);

        /// <summary>
        /// 校验登录密码是否正确
        /// </summary>
        /// <param name="inputPwd"></param>
        /// <param name="salt"></param>
        /// <param name="dbPwd"></param>
        /// <returns></returns>
        bool CheckLoginInfo(string inputPwd, string salt, string dbPwd);
    }
}
