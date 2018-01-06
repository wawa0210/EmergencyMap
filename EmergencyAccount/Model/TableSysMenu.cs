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
    [Table("T_SysMenu")]
    public class TableSysMenu
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
        /// 菜单名称
        /// </summary>
        [Column("Title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 菜单地址
        /// </summary>
        [Column("ReferUrl")]
        public string ReferUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 菜单等级
        /// </summary>
        [Column("MenuLevel")]
        public int MenuLevel
        {
            get;
            set;
        }

        /// <summary>
        /// 图标地址
        /// </summary>
        [Column("IconUrl")]
        public string IconUrl
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

        /// <summary>
        /// 上一级编号
        /// </summary>
        [Column("ParentId")]
        public string ParentId
        {
            get;
            set;
        }
    }
}
