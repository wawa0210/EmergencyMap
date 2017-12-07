using EmergencyAccount.Etity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace EmergencyApi.Framework
{
    public class EmergencyPrincipal: IPrincipal
    {
        public IIdentity Identity
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public EntityAccountManager UserContext { get; set; }
    }
}