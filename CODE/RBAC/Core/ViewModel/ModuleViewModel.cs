﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MyFrame.RBAC.ViewModel
{
    public class ModuleViewModel
    {
        public ModuleViewModel() { }
        [Display(Name = "模块id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "模块编号不能为空")]
        [Display(Name = "模块编号")]
        [MaxLength(20, ErrorMessage = "模块编号不能超过{1}个字符")]
        public string Code { get; set; }

        [Required(ErrorMessage = "模块名称不能为空")]
        [Display(Name = "模块名称")]
        [MaxLength(20, ErrorMessage = "模块名称不能超过{1}个字符")]
        public string Name { get; set; }

        [Display(Name = "模块链接")]
        [MaxLength(100, ErrorMessage = "模块链接不能超过{1}个字符")]
        public string LinkUrl { get; set; }

        [Display(Name = "模块图标")]
        [MaxLength(50, ErrorMessage = "模块图标不能超过{1}个字符")]
        public string Icon { get; set; }

        [Display(Name = "排序号")]
        public int SortOrder { get; set; }

        [Display(Name = "父模块id")]
        public int? ParentId { get; set; }

        [Display(Name = "父模块")]
        public string ParentName { get; set; }

        [Display(Name = "是否启用")]
        public bool Enabled { get; set; }

        [Display(Name = "是否系统模块")]
        public bool IsSystem { get; set; }

        [Display(Name = "备注")]
        [MaxLength(255, ErrorMessage = "备注不能超过{1}个字符")]
        public string Remark { get; set; }

        public int? Creator { get; set; }

        [Display(Name = "创建人")]
        public string CreatorName { get; set; }

        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }

        public int? LastModifier { get; set; }

        [Display(Name = "最后修改人")]
        public string LastModifierName { get; set; }

        [Display(Name = "最后修改时间")]
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 子模块列表
        /// </summary>
        public IList<ModuleViewModel> SubModules { get; set; }
    }
}
