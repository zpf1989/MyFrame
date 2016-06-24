﻿using MyFrame.Infrastructure.OptResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MyFrame.Infrastructure.Expression;
using MyFrame.Infrastructure.Pagination;

namespace MyFrame.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        TEntity Add(TEntity entity);

        int Count(Expression<Func<TEntity, bool>> where = null);

        bool Delete(TEntity entity);
        bool Delete(Expression<Func<TEntity, bool>> where);
        bool Update(TEntity entity);
        bool Update(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> update);
        bool Exists(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> FindByPage(Expression<Func<TEntity, bool>> where, IList<OrderByArgs<TEntity>> orderByList, PageArgs pageArgs);
    }
}