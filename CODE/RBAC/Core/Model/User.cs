﻿
using MyFrame.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyFrame.RBAC.Model
{
    [Description("用户信息")]
    [Table("Users")]
    public class User : BaseEntity<int>, IKey<int>
    {
        public User()
        {

        }

        [Display(Name = "用户名")]
        public string UserName { get; set; }


        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

        [Display(Name = "创建人")]
        public int? Creator { get; set; }

        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "最后修改人")]
        public int? LastModifier { get; set; }

        [Display(Name = "最后修改时间")]
        public DateTime? LastModifyTime { get; set; }
    }
}
