 
using System.ComponentModel.DataAnnotations;
namespace bubuangel.com.Areas.Member.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Display(Name="验证码",Description="请输入图片中的验证码")]
        [Required(ErrorMessage="*")]
        [StringLength(6,MinimumLength=6,ErrorMessage="*")]
        public string VerificationCode { get; set; }

        /// <summary>
        /// 记住我
        /// </summary>
        [Display(Name="记住我")]
        public bool RememberMe { get; set; }
    }
}