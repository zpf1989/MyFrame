﻿using MyFrame.Infrastructure.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Extensions.Filters
{
    /// <summary>
    /// 自定义异常处理类
    /// </summary>
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        ILogHelper<CustomHandleErrorAttribute> _logHelper = LogHelperFactory.GetLogHelper<CustomHandleErrorAttribute>();
        public override void OnException(ExceptionContext filterContext)
        {
            //记录日志
            _logHelper.LogError(filterContext.Exception);
        }
    }
}