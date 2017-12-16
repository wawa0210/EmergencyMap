using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Etity
{
    public class EntityAccount
    {
        [Required(ErrorMessage = "用户编号不能为空")]
        public string Id { get; set; }

        [Required(ErrorMessage = "真实名称不能为空")]

        public string RealName { get; set; }

        [Required(ErrorMessage = "电话号码不能为空")]

        public string Tel { get; set; }

        public int Level { get; set; }
    }
}
