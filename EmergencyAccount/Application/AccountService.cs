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

namespace EmergencyAccount.Application
{
    public class AccountService : BaseAppService, IAccountService
    {

        public bool CheckLoginInfo(string inputPwd, string salt, string dbPwd)
        {
            var userPwd = DESEncrypt.Encrypt(inputPwd, salt);
            return userPwd == dbPwd;
        }

        public EntityAccountManager GetAccountManager(string userName)
        {
            var orderPayRep = GetRepositoryInstance<TableAccountManager>();
            var restult = orderPayRep.Find(x => x.UserName == userName);

            return Mapper.Map<TableAccountManager, EntityAccountManager>(restult);
        }

        public EntityAccountManager GetAccountManagerInfo(string useId)
        {
            var orderPayRep = GetRepositoryInstance<TableAccountManager>();
            var restult = orderPayRep.Find(x => x.Id == useId);

            return Mapper.Map<TableAccountManager, EntityAccountManager>(restult);
        }
    }
}
