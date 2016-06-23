﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyFrame.Model.RBAC
{
    [Description("角色信息")]
    [Table("Roles")]
    public class Role : IKey<int>, IDataTrack, ILogicalDelete
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "角色名称")]
        [StringLength(20)]
        public string RoleName { get; set; }

        [Display(Name = "备注")]
        [StringLength(100)]
        public string Remark { get; set; }
        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }
        [Display(Name = "排序")]
        [RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        [Range(1, 99999)]
        public int SortOrder { get; set; }

        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "创建人")]
        public int? Creator { get; set; }

        [Display(Name = "最后修改人")]
        public int? LastModifier { get; set; }

        [Display(Name = "最后修改时间")]
        public DateTime? LastModifyTime { get; set; }


        [Display(Name = "是否已删除")]
        public bool IsDeleted { get; set; }
    }
}
