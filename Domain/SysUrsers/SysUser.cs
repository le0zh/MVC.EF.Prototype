//------------------------------------------------------------
// <copyright file="SysUser.cs" company="WIKI Tec">
//     WIKI Tec copyright.
// </copyright>
// <author>朱新亮</author>
// <date>2015/3/17 11:19:28</date>
// <summary>
//  主要功能有：
//  
// </summary>
//------------------------------------------------------------

using le0zh.Domain.SysOrgs;

namespace le0zh.Domain.SysUrsers
{
    using System;

    /// <summary>
    /// 系统用户
    /// </summary>
    public class SysUser
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 员工状态
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int? SysRoleId { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public int? CreateById { get; set; }

        /// <summary>
        /// 用户创建人
        /// </summary>
        public virtual SysUser CreateBy { get; set; }

        /// <summary>
        /// 所属部门Id
        /// </summary>
        public int? SysOrgId { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public virtual SysOrg SysOrg { get; set; }

        /// <summary>
        /// 所属机构
        /// </summary>
        public SysOrg Org
        {
            get
            {
                var org = SysOrg.Parent;
                while (org != null)
                {
                    if (org.Parent == null)
                    {
                        return org;
                    }

                    org = org.Parent;
                }

                return SysOrg;
            }
        }
    }
}
