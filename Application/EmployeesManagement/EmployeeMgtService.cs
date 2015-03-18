using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using le0zh.Domain.Employees;
using le0zh.Infrastructure.Data.Core;

namespace le0zh.Application.EmployeesManagement
{
    public class EmployeeMgtService
    {
        /// <summary>
        /// 员工数据仓储
        /// </summary>
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IUnitOfWork _unitOfWork;

        public EmployeeMgtService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this._employeeRepository = employeeRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns>IEnumerable<Employee/>所有员工信息</returns>
        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
    }
}
