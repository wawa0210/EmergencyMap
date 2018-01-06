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
    [Table("T_SysPermission")]

    public class TableSysPermission
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
        /// 角色编号: 
        /// </summary>
        [Column("RoleId")]
        [Key]
        [Description("")]
        public string RoleId
        {
            get;
            set;
        }
        /// <summary>
        /// 角色编号: 
        /// </summary>
        [Column("菜单编号")]
        [Key]
        [Description("")]
        public string MenuId
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
