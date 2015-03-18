//------------------------------------------------------------
// <copyright file="RandomNumberHelper.cs" company="WIKI Tec">
//     WIKI Tec copyright.
// </copyright>
// <author>张宇</author>
// <date>2014/11/5 9:17:41</date>
// <summary>
//  随机数生成辅助类
// </summary>
//------------------------------------------------------------

namespace le0zh.Infrastructure.Toolkit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 随机数生成辅助类
    /// </summary>
    public class RandomNumberHelper
    {
        public static string GetRandomNumber(int length = 8)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            string r = rand.Next(99999999).ToString();
            var result = string.Empty;
            if (r.Length < length)
            {
                for (int i = 0; i < length - r.Length; i++)
                {
                    result += "0";
                }
            }

            return result + r;
        }
    }
}
