﻿using EmergencyCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyCompany.Application
{
    public interface ICompanyService
    {
        Task<List<TableCompany>> GetAllCompanyInfo();
    }
}
