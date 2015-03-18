namespace le0zh.Infrastructure.Data.Core
{
    using System;
    using System.Collections.Generic;


    [Serializable]
    public class PagedResult<TEntity>
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public IEnumerable<TEntity> List { get; private set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="list">数据列表</param>
        public PagedResult(int pageIndex, int pageSize, int recordCount, IEnumerable<TEntity> list)
        {
            this.List = list;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.RecordCount = recordCount;
        }
    }
}
