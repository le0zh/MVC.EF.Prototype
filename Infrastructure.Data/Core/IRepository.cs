using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using le0zh.Infrastructure.Data.Specification;

namespace le0zh.Infrastructure.Data.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 向仓储中添加一条对象
        /// </summary>
        /// <param name="entity">要添加的对象</param>
        void Add(TEntity entity);

        /// <summary>
        /// 从删除中删除对象
        /// </summary>
        /// <param name="entity">被删除的对象</param>
        void Remove(TEntity entity);

        /// <summary>
        /// 从删除中删除对象通过ID删除
        /// </summary>
        /// <param name="entity">被删除的对象</param>
        void Delete(TEntity entity);

        /// <summary>
        /// 将对象的修改保存到仓储中
        /// </summary>
        /// <param name="entity">被修改的对象</param>
        void Modify(TEntity entity);

        /// <summary>
        /// 通过Id获取一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetModel(object id);

        /// <summary>
        /// 获取所有对象
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 获取所有子类型列表
        /// </summary>
        /// <typeparam name="K">子类的类型</typeparam>
        /// <returns></returns>
        IEnumerable<SEntity> GetAllSubType<SEntity>() where SEntity : TEntity;

        /// <summary>
        /// 获取所有匹配规格的对象
        /// </summary>
        /// <param name="specification">查找结果的规格</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification);

        /// <summary>
        /// 获取所有匹配规格的子类型
        /// </summary>
        /// <typeparam name="K">子类的类型</typeparam>
        /// <param name="specification">查找结果的规格</param>
        /// <returns></returns>
        IEnumerable<SEntity> GetSubTypeBySpec<SEntity>(ISpecification<SEntity> specification) where SEntity : class, TEntity;

        /// <summary>
        /// 分页获取所有对象
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="ascending">指定是否升序</param>
        /// <returns>查询得到的结果</returns>
        IEnumerable<TEntity> GetPagedElements<S>(int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, bool ascending);

        /// <summary>
        /// 分页获取子类型对象
        /// </summary>
        /// <typeparam name="S">排序字段类型</typeparam>
        /// <typeparam name="SEntity">子类型</typeparam>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="ascending">是否升序</param>
        /// <returns></returns>
        IEnumerable<SEntity> GetPagedSubTypeElements<S, SEntity>(int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, bool ascending) where SEntity : TEntity;

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <typeparam name="S">排序字段类型</typeparam>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="specification">查找结果的规格</param>
        /// <param name="ascending">指定是否升序</param>
        /// <returns>查询得到的结果</returns>
        IEnumerable<TEntity> GetPagedElements<S>(int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, ISpecification<TEntity> specification, bool ascending);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <typeparam name="S">排序字段类型</typeparam>
        /// <typeparam name="SEntity">子类的类型</typeparam>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="specification">查找结果的规格</param>
        /// <param name="ascending">制定是否升序</param>
        /// <returns></returns>
        IEnumerable<SEntity> GetPagedSubTypeElements<S, SEntity>(int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, ISpecification<SEntity> specification, bool ascending) where SEntity : class, TEntity;

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 通过条件查询子类型
        /// </summary>
        /// <typeparam name="SEntity">子类的类型</typeparam>
        /// <param name="filter">筛选条件</param>
        /// <returns></returns>
        IEnumerable<SEntity> GetFilteredSubTypeElements<SEntity>(Expression<Func<SEntity, bool>> filter) where SEntity : TEntity;

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="filter">筛选条件</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="ascending">指定是否升序</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetFilteredElements<S>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, bool ascending);

        /// <summary>
        /// 通过条件查询子类型
        /// </summary>
        /// <typeparam name="S">排序字段类型</typeparam>
        /// <typeparam name="SEntity">子类的类型</typeparam>
        /// <param name="filter">筛选条件</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="ascending">制定是否升序</param>
        /// <returns></returns>
        IEnumerable<SEntity> GetFilteredSubTypeElements<S, SEntity>(Expression<Func<SEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, bool ascending) where SEntity : TEntity;

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="specification">规格</param>
        /// <param name="ascending">是否升序</param>
        /// <returns>分页结果</returns>
        PagedResult<TEntity> GetPageResult<S>(int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, ISpecification<TEntity> specification, bool ascending);

        /// <summary>
        /// 获取子类型分页数据
        /// </summary>
        /// <typeparam name="S">排序字段类型</typeparam>
        /// <typeparam name="SEntity">子类的类型</typeparam>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="specification">筛选规格</param>
        /// <param name="ascending">是否升序</param>
        /// <returns></returns>
        PagedResult<SEntity> GetPageSubTypeResult<S, SEntity>(int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, ISpecification<SEntity> specification, bool ascending) where SEntity : class,TEntity;

        /// <summary>
        /// 通过条件获取分页数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="filter">筛选条件</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="ascending">指定是否升序</param>
        /// <returns>分页结果</returns>
        PagedResult<TEntity> GetFilteredPageResult<S>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, S>> orderByExpression, bool ascending);

        /// <summary>
        /// 通过条件获取子类型的分页数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="SEntity">子类的类型</typeparam>
        /// <param name="filter">筛选条件</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="ascending">指定是否升序</param>
        /// <returns></returns>
        PagedResult<SEntity> GetFilteredSubTypePageResult<S, SEntity>(Expression<Func<SEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<SEntity, S>> orderByExpression, bool ascending) where SEntity : TEntity;

        /// <summary>
        /// 是否存在符合条件的对象
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <returns>true:存在,flase:不存在</returns>
        bool IsExsist(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 是否存在符合条件的子类型对象
        /// </summary>
        /// <typeparam name="SEntity">子类的类型</typeparam>
        /// <param name="filter">筛选条件</param>
        /// <returns></returns>
        bool IsExsistSubType<SEntity>(Expression<Func<SEntity, bool>> filter) where SEntity : TEntity;

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <returns>符合条件的总记录数</returns>
        int GetRecordCount(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 获取子类型记录数
        /// </summary>
        /// <typeparam name="SEntity">子类的类型</typeparam>
        /// <param name="filter">筛选条件</param>
        /// <returns></returns>
        int GetSubTypeRecordCount<SEntity>(Expression<Func<SEntity, bool>> filter) where SEntity : TEntity;

    }
}
