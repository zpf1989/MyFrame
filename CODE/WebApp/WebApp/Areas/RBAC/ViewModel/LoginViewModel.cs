﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Areas.RBAC.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name = "用户名")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "用户名长度必须在{2}和{1}之间")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        public string Password { get; set; }


        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "验证码不能为空")]
        [Display(Name = "验证码")]
        public string VerifyCode { get; set; }
    }
}