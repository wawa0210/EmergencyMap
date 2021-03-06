﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Etity
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public class EntityLoginModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "用户密码不能为空")]
        public string UserPwd { get; set; }
    }
}
