using System;
using System.ComponentModel.DataAnnotations;

namespace Zxl.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User
    {
        [Key]
        public int UserID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        ///// <summary>
        ///// 用户组ID
        ///// </summary>
        //[Required(ErrorMessage="必填项")]
        //[Display(Name="分组ID")]
        //public int GroupID { get; set; }


        /// <summary>
        /// 显示名称
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "显示名")]
        public string DisplayName { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        /// <summary>
        /// 用户状态 0正常；1锁定；2未通过邮箱验证，3未通过管理员验证
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisrationTime { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 上次登录IP
        /// </summary>
        public string LoginIP { get; set; }


        //  public virtual UserGroup Group { get; set; }
    }
}
