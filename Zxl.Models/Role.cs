using System.ComponentModel.DataAnnotations;

namespace Zxl.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{1}至{0}个字符")]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        ///  角色类型　0普通（普通注册用户）；1特权类型（VIP之类组）；2管理类型（管理权限类型）
        /// </summary>
        [Required(ErrorMessage="必填项")]
        [Display(Name="角色类型")]
        public int Type { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [Required(ErrorMessage="必填项")]
        [StringLength(50,ErrorMessage="少于{0}个字符")]
        [Display(Name="说明")]
        public string Description { get; set; }

        /// <summary>
        /// 获取角色类型名称
        /// </summary>
        /// <returns></returns>
        public string TypeToString()
        {
            switch (Type)
            {
                case 0:
                    return "普通";
                case 1:
                    return "特权";
                case 2:
                    return "管理";
                default:
                    return "未知";
            }
        }
    }
}
