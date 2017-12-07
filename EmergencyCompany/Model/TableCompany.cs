using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyCompany.Model
{
    [Table("[T_Company]")]
    public class TableCompany
    {
        /// <summary>
        /// 属性: 
        /// </summary>
        [Column("Id")]
        [Key]
        [Description("")]
        public string Id
        {
            get; set;
        }

        /// <summary>
        /// 公司名称 
        /// </summary>
        [Column("CompanyName")]
        [Description("")]
        public string CompanyName
        {
            get; set;
        }

        /// <summary>
        /// 省 
        /// </summary>
        [Column("Provice")]
        [Description("")]
        public string Provice
        {
            get; set;
        }

        /// <summary>
        /// 市 
        /// </summary>
        [Column("City")]
        [Description("")]
        public string City
        {
            get; set;
        }

        /// <summary>
        /// 县区
        /// </summary>
        [Column("County")]
        [Description("")]
        public string County
        {
            get; set;
        }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Column("AddressDetail")]
        [Description("")]
        public string AddressDetail
        {
            get; set;
        }

        /// <summary>
        /// 经度
        /// </summary>
        [Column("Longitude")]
        [Description("")]
        public string Longitude
        {
            get; set;
        }

        /// <summary>
        /// 纬度
        /// </summary>
        [Column("Latitude")]
        [Description("")]
        public string Latitude
        {
            get; set;
        }

        /// <summary>
        /// 行业
        /// </summary>
        [Column("Industry")]
        [Description("")]
        public string Industry
        {
            get; set;
        }

        /// <summary>
        /// 经济类型
        /// </summary>
        [Column("Economy")]
        [Description("")]
        public string Economy
        {
            get; set;
        }

        /// <summary>
        /// 公司详细描述
        /// </summary>
        [Column("CompanyDetail")]
        [Description("")]
        public string CompanyDetail
        {
            get; set;
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [Column("ZipCode")]
        [Description("")]
        public string ZipCode
        {
            get; set;
        }

        /// <summary>
        /// 成立时间
        /// </summary>
        [Column("FoundedTime")]
        [Description("")]
        public DateTime FoundedTime
        {
            get; set;
        }

        /// <summary>
        /// 注册时间
        /// </summary>
        [Column("IssureTime")]
        [Description("")]
        public DateTime IssureTime
        {
            get; set;
        }


        /// <summary>
        /// 行业代码
        /// </summary>
        [Column("IndustryCode")]
        [Description("")]
        public string IndustryCode
        {
            get; set;
        }

        /// <summary>
        /// 法人名称
        /// </summary>
        [Column("Owner")]
        [Description("")]
        public string Owner
        {
            get; set;
        }
    }
}
