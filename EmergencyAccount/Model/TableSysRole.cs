using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyAccount.Model
{
    [Table("T_SysRole")]
    public class TableSysRole
    {
        /// <summary>
        /// 编号: 
        /// </summary>
        [Column("Id")]
        [Key]
        [Description("")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// 角色名称: 
        /// </summary>
        [Column("RoleName")]
        [Key]
        [Description("")]
        public string RoleName
        {
            get;
            set;
        }


        /// <summary>
        /// 当前状态
        /// </summary>
        [Column("Status")]
        public bool Status
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime")]
        public DateTime CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        public string Remark
        {
            get;
            set;
        }
    }
}
