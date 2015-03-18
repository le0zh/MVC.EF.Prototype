
namespace le0zh.Repository
{
    using System;
    using System.Data.Entity;
    using le0zh.Repository.Mappings;

    /// <summary>
    /// EntityFramework 数据服务的上下文信息
    /// </summary>
    public class DataContext : DbContext, IDisposable
    {
        /// <summary>
        /// 制定链接字符串名称的构造函数
        /// </summary>
        /// <param name="nameOrConnectionString">连接字符串</param>
        public DataContext(string nameOrConnectionString)
             : base(nameOrConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// 空构造函数，使用默认的连接字符串
        /// </summary>
        public DataContext()
            : this("dbConStr")
        {
        }

        /// <summary>
        /// 添加数据库与实体的映射
        /// </summary>
        /// <param name="modelBuilder">将CLR类型映射到数据库</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeMapping());
        }
    }
}
