﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Etity
{
    public class EntityAccountPwd
    {
        [Required(ErrorMessage = "用户编号不能为空")]
        public string Id { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        public string UserPwd { get; set; }
    }
}
