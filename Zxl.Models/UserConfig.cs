using System.ComponentModel.DataAnnotations;

namespace Zxl.Models
{
    public class UserConfig
    {
        [Key]
        public int ConfigID { get; set; }


        /// <summary>
        /// 启用注册
        /// </summary>
        [Display(Name = "启用注册")]
        [Required(ErrorMessage = "必填项")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 禁止使用的用户名
        /// </summary>
        [Display(Name = "禁止使用的用户名")]
        public string ProhibitUserName { get; set; }

        /// <summary>
        /// 启用管理员验证
        /// </summary>
        [Display(Name = "启用管理员验证")]
        [Required(ErrorMessage = "必填项")]
        public bool EnableAdminVerify { get; set; }

        /// <summary>
        /// 启用邮箱验证
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [Display(Name = "启用邮箱验证")]
        public bool EnableEmailVerify { get; set; }


        /// <summary>
        /// 默认用户组ID
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [Display(Name = "默认用户组ID")]
        public int DefaultGroupID { get; set; }

    }
}
