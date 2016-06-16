﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace MyFrame.Repository.EF
{
    /// <summary>
    /// EF数据库上下文简单工厂
    /// </summary>
    public class EFDbContextFactory
    {
        const string CurrentEFContextName = "CurrentEFContext";
        /// <summary>
        /// CallContext，MSDN中讲CallContext提供对每个逻辑执行线程都唯一的数据槽，
        /// 而在WEB程序里，每一个请求恰巧就是一个逻辑线程所以可以使用CallContext
        /// 来实现单个请求之内的DbContext单例
        /// </summary>
        /// <returns></returns>
        public static EFDbContext GetCurrentContext()
        {
            EFDbContext _context = CallContext.GetData(CurrentEFContextName) as EFDbContext;
            if (_context == null)
            {
                _context = new EFDbContext();
                CallContext.SetData(CurrentEFContextName, _context);
            }

            return _context;
        }
    }
}
