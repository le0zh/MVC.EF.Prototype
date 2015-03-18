using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace le0zh.Infrastructure.Toolkit
{
    public class EnumHelper
    {
        /// <summary>
        /// 获得某个Enum类型的绑定列表

        /// </summary>
        /// <param name="enumType">枚举的类型，例如：typeof(Sex)</param>
        /// <returns>
        /// 返回一个DataTable
        /// DataTable 有两列：    "Text"    : System.String;
        ///                        "Value"    : System.Char
        /// </returns>
        public static DataTable EnumListTable(Type enumType)
        {
            if (enumType.IsEnum != true)
            {    //不是枚举的要报错
                throw new InvalidOperationException();
            }

            //建立DataTable的列信息
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(System.String));
            dt.Columns.Add("Value", typeof(System.Char));

            //获得特性Description的类型信息

            Type typeDescription = typeof(DescriptionAttribute);

            //获得枚举的字段信息（因为枚举的值实际上是一个static的字段的值）
            System.Reflection.FieldInfo[] fields = enumType.GetFields();

            //检索所有字段

            foreach (FieldInfo field in fields)
            {
                //过滤掉一个不是枚举值的，记录的是枚举的源类型

                if (field.FieldType.IsEnum == true)
                {
                    DataRow dr = dt.NewRow();

                    // 通过字段的名字得到枚举的值

                    // 枚举的值如果是long的话，ToChar会有问题，但这个不在本文的讨论范围之内

                    dr["Value"] = (char)(int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);

                    //获得这个字段的所有自定义特性，这里只查找Description特性

                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        //因为Description这个自定义特性是不允许重复的，所以我们只取第一个就可以了！
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        //获得特性的描述值，也就是‘男’‘女’等中文描述
                        dr["Text"] = aa.Description;
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        //如果没有特性描述（-_-!忘记写了吧~）那么就显示英文的字段名
                        //lixiaoliang20111114注：没有Description的枚举不取出来

                        //dr["Text"] = field.Name;
                        //dt.Rows.Add(dr);
                    }
                   
                }
            }

            return dt;
        }


        /// <summary>
        /// 获得某个Enum类型的绑定列表

        /// </summary>
        /// <param name="enumType">枚举的类型，例如：typeof(Sex)</param>
        /// <returns>
        /// 返回一个Dictionary
        /// </returns>
        public static Dictionary<string,string> EnumListDictionary(Type enumType)
        {
            if (enumType.IsEnum != true)
            {    //不是枚举的要报错
                throw new InvalidOperationException();
            }


            Dictionary<string, string> dic = new Dictionary<string, string>();

            //获得特性Description的类型信息

            Type typeDescription = typeof(DescriptionAttribute);

            //获得枚举的字段信息（因为枚举的值实际上是一个static的字段的值）
            System.Reflection.FieldInfo[] fields = enumType.GetFields();

            //检索所有字段

            foreach (FieldInfo field in fields)
            {
                //过滤掉一个不是枚举值的，记录的是枚举的源类型

                if (field.FieldType.IsEnum == true)
                {

                    // 通过字段的名字得到枚举的值

                    // 枚举的值如果是long的话，ToChar会有问题，但这个不在本文的讨论范围之内

                    //r["Value"] = (char)(int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                    string value = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    string key;

                    //获得这个字段的所有自定义特性，这里只查找Description特性

                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        //因为Description这个自定义特性是不允许重复的，所以我们只取第一个就可以了！
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        //获得特性的描述值，也就是‘男’‘女’等中文描述
                        //dr["Text"] = aa.Description;
                        key = aa.Description;
                        dic.Add(key, value);
                    }
                    else
                    {
                        //如果没有特性描述（-_-!忘记写了吧~）那么就显示英文的字段名
                        //如果没有特性描述（-_-!忘记写了吧~）那么就显示英文的字段名
                        //lixiaoliang20111114注：没有Description的枚举不取出来

                        //dr["Text"] = field.Name;
                        //dt.Rows.Add(dr);

                    }
                }
            }

            return dic;
        }

        /// <summary>
        /// 根据枚举value返回该value的Description，如果Description不存在，则返回该value的key
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescriptionByValue(Type enumType, string value)
        {
            if (enumType.IsEnum != true)
            {    //不是枚举的要报错
                throw new InvalidOperationException();
            }


            string desciption = string.Empty;

            //获得特性Description的类型信息

            Type typeDescription = typeof(DescriptionAttribute);

            //获得枚举的字段信息（因为枚举的值实际上是一个static的字段的值）
            System.Reflection.FieldInfo[] fields = enumType.GetFields();

            //检索所有字段

            foreach (FieldInfo field in fields)
            {
                //过滤掉一个不是枚举值的，记录的是枚举的源类型

                if (field.FieldType.IsEnum == true)
                {

                    // 通过字段的名字得到枚举的值

                    // 枚举的值如果是long的话，ToChar会有问题，但这个不在本文的讨论范围之内

                    //r["Value"] = (char)(int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                    if (value == ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString())
                    {
                        //获得这个字段的所有自定义特性，这里只查找Description特性

                        object[] arr = field.GetCustomAttributes(typeDescription, true);
                        if (arr.Length > 0)
                        {
                            //因为Description这个自定义特性是不允许重复的，所以我们只取第一个就可以了！
                            DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                            //获得特性的描述值，也就是‘男’‘女’等中文描述
                            //dr["Text"] = aa.Description;
                            desciption = aa.Description;
                        }
                        else
                        {
                            //如果没有特性描述（-_-!忘记写了吧~）那么就显示英文的字段名
                            desciption = field.Name;
                        }
                        break;
                    }
                    
                }
            }

            return desciption;
        }
    }
}
