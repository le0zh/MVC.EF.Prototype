//-----------------------------------------------------------------------
// <copyright file="RepositoryBase.cs" company="Tiki Tec">
//     Tiki Tec copyright.
// </copyright>
// <author>张宇</author>
// <date>2014-05-30</date>
//-----------------------------------------------------------------------

namespace le0zh.Infrastructure.Data.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    using le0zh.Infrastructure.Data.Specification;
    using le0zh.Infrastructure.Data.Core;

    /// <summary>
    /// 数据仓库基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private readonly DbContext _dataContext;

        /// <summary>
        /// 实体集合
        /// </summary>
        private readonly IDbSet<TEntity> _dbSet;

        /// <summary>
        /// 实体集合
        /// </summary>
        protected IDbSet<TEntity> DbSet
        {
            get
            {
                return _dbSet;
            }
        }

        /// <summary>
        /// 数据库上下文
        /// </summary>
        protected DbContext DataContext
        {
            get { return _dataContext; }
        }

        /// <summary>
        /// 利用构造函数设置数据库上下文和实体集合
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public RepositoryBase(DbContext context)
        {
            this._dataContext = context;
            this._dbSet = DataContext.Set<TEntity>();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            if (entity == (TEntity)null)
            {
                throw new ArgumentNullException();
            }
            _dbSet.Add(entity);
        }


        public void Remove(TEntity entity)
        {
            if (entity == (TEntity)null)
                throw new ArgumentNullException();

            _dbSet.Remove(entity);
        }

        /// <summary>
        /// 从删除中删除对象
        /// </summary>
        /// <param name="entity">被删除的对象</param>
        public void Delete(TEntity entity)
        {
            DbEntityEntry<TEntity> entry = this.DataContext.Entry<TEntity>(entity);
            //2,将伪包装类对象的状态设置为unchanged
            entry.State = System.Data.Entity.EntityState.Deleted;
        }

        public void Modify(TEntity entity)
        {
            if (entity == (TEntity)null)
                throw new ArgumentNullException();

            _dbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public TEntity GetModel(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable<TEntity>();
        }

        public IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification)
        {
            return _dbSet.Where(specification.SatisfiedBy()).AsEnumerable<TEntity>();
        }

        public IEnumerable<TEntity> GetPagedElements<S>(int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, bool ascending)
        {
            return (ascending)
                ?
                    _dbSet
                    .OrderBy(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()
                :
                    _dbSet
                    .OrderByDescending(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public IEnumerable<TEntity> GetPagedElements<S>(int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, ISpecification<TEntity> specification, bool ascending)
        {
            return (ascending)
                ?
                    _dbSet
                    .Where(specification.SatisfiedBy())
                    .OrderBy(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()
                :
                    _dbSet
                    .Where(specification.SatisfiedBy())
                    .OrderByDescending(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException("filter", Messages.exception_FilterCannotBeNull);

            return _dbSet.Where(filter).AsEnumerable();
        }

        public IEnumerable<TEntity> GetFilteredElements<S>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, bool ascending)
        {
            if (filter == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException("filter", Messages.exception_FilterCannotBeNull);

            if (pageIndex < 0)
                throw new ArgumentException(Messages.exception_InvalidPageIndex);

            if (pageSize <= 0)
                throw new ArgumentException(Messages.exception_InvalidPageSize);

            if (orderByExpression == (Expression<Func<TEntity, S>>)null)
                throw new ArgumentNullException("orderByExpression", Messages.exception_OrderByExpressionCannotBeNull);


            return (ascending)
                ?
                    _dbSet
                    .Where(filter)
                    .OrderBy(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()
                :
                    _dbSet
                    .Where(filter)
                    .OrderByDescending(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

        }

        public PagedResult<TEntity> GetPageResult<S>(int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, ISpecification<TEntity> specification, bool ascending)
        {
            int count = _dbSet.Where(specification.SatisfiedBy()).Count();
            return new PagedResult<TEntity>(
                pageIndex,
                pageSize,
                count,
                GetPagedElements<S>(pageIndex, pageSize, orderByExpression, specification, ascending)
            );
        }

        public PagedResult<TEntity> GetFilteredPageResult<S>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, bool ascending)
        {
            int count = _dbSet.Where(filter).Count();
            return new PagedResult<TEntity>(
                pageIndex,
                pageSize,
                count,
                GetFilteredElements<S>(filter, pageIndex, pageSize, orderByExpression, ascending)
            );
        }


        public IEnumerable<SEntity> GetAllSubType<SEntity>() where SEntity : TEntity
        {
            return _dbSet.OfType<SEntity>().AsEnumerable();
        }

        public IEnumerable<SEntity> GetSubTypeBySpec<SEntity>(ISpecification<SEntity> specification) where SEntity : class, TEntity
        {
            return _dbSet.OfType<SEntity>().Where(specification.SatisfiedBy()).AsEnumerable();
        }

        public IEnumerable<SEntity> GetPagedSubTypeElements<S, SEntity>(int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, bool ascending) where SEntity : TEntity
        {
            return (ascending)
                ?
                    _dbSet.OfType<SEntity>()
                    .OrderBy(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()
                :
                    _dbSet.OfType<SEntity>()
                    .OrderByDescending(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public IEnumerable<SEntity> GetPagedSubTypeElements<S, SEntity>(int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, ISpecification<SEntity> specification, bool ascending) where SEntity : class, TEntity
        {
            return (ascending)
                ?
                    _dbSet.OfType<SEntity>()
                    .Where(specification.SatisfiedBy())
                    .OrderBy(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()
                :
                    _dbSet.OfType<SEntity>()
                    .Where(specification.SatisfiedBy())
                    .OrderByDescending(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public IEnumerable<SEntity> GetFilteredSubTypeElements<SEntity>(Expression<Func<SEntity, bool>> filter) where SEntity : TEntity
        {
            return _dbSet.OfType<SEntity>().Where(filter).AsEnumerable();
        }

        public IEnumerable<SEntity> GetFilteredSubTypeElements<S, SEntity>(Expression<Func<SEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, bool ascending) where SEntity : TEntity
        {
            if (filter == (Expression<Func<SEntity, bool>>)null)
                throw new ArgumentNullException("filter", Messages.exception_FilterCannotBeNull);

            if (pageIndex < 0)
                throw new ArgumentException(Messages.exception_InvalidPageIndex);

            if (pageSize <= 0)
                throw new ArgumentException(Messages.exception_InvalidPageSize);

            if (orderByExpression == (Expression<Func<SEntity, S>>)null)
                throw new ArgumentNullException("orderByExpression", Messages.exception_OrderByExpressionCannotBeNull);


            return (ascending)
                ?
                    _dbSet.OfType<SEntity>()
                    .Where(filter)
                    .OrderBy(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()
                :
                    _dbSet.OfType<SEntity>()
                    .Where(filter)
                    .OrderByDescending(orderByExpression)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public PagedResult<SEntity> GetPageSubTypeResult<S, SEntity>(int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, ISpecification<SEntity> specification, bool ascending) where SEntity : class, TEntity
        {
            int count = _dbSet.OfType<SEntity>().Where(specification.SatisfiedBy()).Count();
            int pageCount = (int)Math.Ceiling((double)count / pageSize);

            if (pageIndex > 0)
                pageIndex = pageIndex > pageCount - 1 ? pageCount - 1 : pageIndex;

            pageIndex = pageIndex < 0 ? 0 : pageIndex;

            return new PagedResult<SEntity>(
                pageIndex,
                pageSize,
                count,
                GetPagedSubTypeElements<S, SEntity>(pageIndex, pageSize, orderByExpression, specification, ascending)
            );
        }

        public PagedResult<SEntity> GetFilteredSubTypePageResult<S, SEntity>(Expression<Func<SEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, bool ascending) where SEntity : TEntity
        {
            int count = _dbSet.OfType<SEntity>().Where(filter).Count();

            int pageCount = (int)Math.Ceiling((double)count / pageSize);

            if (pageIndex > 0)
                pageIndex = pageIndex > pageCount - 1 ? pageCount - 1 : pageIndex;

            pageIndex = pageIndex < 0 ? 0 : pageIndex;

            return new PagedResult<SEntity>(
                pageIndex,
                pageSize,
                count,
                GetFilteredSubTypeElements<S, SEntity>(filter, pageIndex, pageSize, orderByExpression, ascending)
            );
        }

        public bool IsExsist(Expression<Func<TEntity, bool>> filter)
        {
            return GetRecordCount(filter) > 0;
        }


        public bool IsExsistSubType<SEntity>(Expression<Func<SEntity, bool>> filter) where SEntity : TEntity
        {
            return GetSubTypeRecordCount(filter) > 0;
        }

        public int GetRecordCount(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).Count();
        }

        public int GetSubTypeRecordCount<SEntity>(Expression<Func<SEntity, bool>> filter) where SEntity : TEntity
        {
            return _dbSet.OfType<SEntity>().Where(filter).Count();
        }
    }
}
