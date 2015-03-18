//-----------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="Tiki Tec">
//     Tiki Tec copyright.
// </copyright>
// <author>张宇</author>
// <date>2014-05-30</date>
//-----------------------------------------------------------------------

namespace le0zh.Repository.Repositories
{
    using le0zh.Domain.Employees;
    using le0zh.Infrastructure.Data.Core;

    /// <summary>
    /// 员工数据仓库实现类
    /// </summary>
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataContext">EntityFramework DataContext</param>
        public EmployeeRepository(DataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
