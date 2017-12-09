using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyCompany.Entity
{
    public class EntityDangerousProduct
    {
        public EntityDangerousProduct()
        {
            Status = 1;
            Memo = "";
            CreateTime = DateTime.Now;
        }
        /// <summary>
        /// 登记号
        /// </summary>
        public string RegesterId
        {
            get;
            set;
        }

        /// <summary>
        /// 公司编号
        /// </summary>
        [Required(ErrorMessage = "企业编号不能为空")]
        public string CompanyId { get; set; }

        /// <summary>
        /// 危险源商品名称
        /// </summary>
        [Required(ErrorMessage = "危险源商品名称不能为空")]
        public string ProductName
        {
            get;
            set;
        }

        /// <summary>
        /// 别名
        /// </summary>
        [Required(ErrorMessage = "别名不能为空")]
        public string AliasName
        {
            get;
            set;
        }

        /// <summary>
        /// 属性
        /// </summary>
        [Required(ErrorMessage = "属性不能为空")]
        public string ProductAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// 成产能力
        /// </summary>
        [Required(ErrorMessage = "生产能力不能为空")]
        public decimal Manufacturability
        {
            get;
            set;
        }

        /// <summary>
        /// 最大储能
        /// </summary>
        [Required(ErrorMessage = "最大储能不能为空")]
        public decimal ProductReserve
        {
            get;
            set;
        }

        /// <summary>
        /// 年生产量
        /// </summary>
        [Required(ErrorMessage = "年生产量不能为空")]
        public decimal YearProduct
        {
            get;
            set;
        }

        /// <summary>
        /// cas
        /// </summary>
        [Required(ErrorMessage = "cas不能为空")]
        public decimal Cas
        {
            get;
            set;
        }

        /// <summary>
        /// un
        /// </summary>
        [Required(ErrorMessage = "un不能为空")]
        public decimal Un
        {
            get;
            set;
        }

        [Required(ErrorMessage = "毒性不能为空")]
        public int IsToxicity
        {
            get;
            set;
        }

        /// <summary>
        /// 说明书
        /// </summary>
        [Required(ErrorMessage = "说明书不能为空")]
        public string Instructions
        {
            get;
            set;
        }

        /// <summary>
        /// 描述
        /// </summary>

        public string Memo
        {
            get;
            set;
        }


        public DateTime CreateTime
        {
            get;
            set;
        }



        public int Status
        {
            get;
            set;
        }
    }
}
