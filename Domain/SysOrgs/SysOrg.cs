//------------------------------------------------------------
// <copyright file="SysOrg.cs" company="WIKI Tec">
//     WIKI Tec copyright.
// </copyright>
// <author>朱新亮</author>
// <date>2015/3/17 11:19:05</date>
// <summary>
//  主要功能有：
//  Domain for SysOrg
// </summary>
//------------------------------------------------------------

using le0zh.Domain.SysUrsers;

namespace le0zh.Domain.SysOrgs
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 系统机构
    /// </summary>
    public class SysOrg
    {
        /// <summary>
        /// 机构Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 机构编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 机构类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 开业时间
        /// </summary>
        public DateTime? SetUpDate { get; set; }

        /// <summary>
        /// 机构地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 机构规模
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 机构说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 机构经理Id
        /// </summary>
        public int? ManagerId { get; set; }

        /// <summary>
        /// 机构经理
        /// </summary>
        public virtual SysUser Manager { get; set; }

        /// <summary>
        /// 父级部门Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 父级部门
        /// </summary>
        public virtual SysOrg Parent { get; set; }

        /// <summary>
        /// 子部门
        /// </summary>
        public virtual IList<SysOrg> Depts { get; set; }
    }
}
