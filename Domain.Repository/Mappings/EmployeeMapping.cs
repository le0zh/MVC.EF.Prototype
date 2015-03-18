//-----------------------------------------------------------------------
// <copyright file="EmployeeMapping.cs" company="Tiki Tec">
//     Tiki Tec copyright.
// </copyright>
// <author>张宇</author>
// <date>2014-05-30</date>
//-----------------------------------------------------------------------

namespace WikiTec.Repository.Mappings
{
    using System.Data.Entity.ModelConfiguration;
    using WikiTec.Domain.Employees;

    /// <summary>
    /// 员工实体类与数据表的映射
    /// </summary>
    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        /// <summary>
        /// 设置Mapping
        /// </summary>
        public EmployeeMapping()
        {
            // Table & Column Mappings
            this.ToTable("Employees");

            // Primary key
            this.HasKey(o => o.Id);

            // Properties
            this.Property(o => o.Id).IsRequired();

            // Table & Column Mappings
            this.Property(o => o.UserName).HasColumnType("NVarchar").HasMaxLength(50);
            this.Property(o => o.Pwd).HasColumnType("NVarchar").HasMaxLength(50);
        }
    }
}
