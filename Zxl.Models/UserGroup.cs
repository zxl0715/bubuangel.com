using System.ComponentModel.DataAnnotations;

namespace Zxl.Models
{
    public class UserGroup
    {
        [Key]
        public int GroupID { get; set; }

        /// <summary>
        /// 组名称
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{1}至{0}个字符")]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        ///  用户组类型　0普通组（普通注册用户）；1特权组类型（VIP之类组）；2管理类型（管理权限类型）
        /// </summary>
        [Required(ErrorMessage="必填项")]
        [Display(Name="用户组类型")]
        public int GroupType { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [Required(ErrorMessage="必填项")]
        [StringLength(50,ErrorMessage="少于{0}个字符")]
        [Display(Name="说明")]
        public string Description { get; set; }
    }
}
