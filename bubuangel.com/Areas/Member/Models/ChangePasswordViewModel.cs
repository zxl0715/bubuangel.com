﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bubuangel.com.Areas.Member.Models
{
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [Display(Name = "旧密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string OriginalPassword { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [Display(Name = "新密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}