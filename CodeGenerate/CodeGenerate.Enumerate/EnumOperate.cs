using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace CodeGenerate.Enumerate
{
    /// <summary>
    /// 枚举操作类
    /// </summary>
    public class EnumOperate
    {
        /// <summary>
        /// 获取枚举的描述信息
        /// </summary>
        /// <param name="e">传入枚举对象</param>
        /// <returns>得到对应描述信息</returns>
        public static String GetEnumDesc(Enum e)
        {
            var enumInfo = e.GetType().GetField(e.ToString());
            var enumAttributes = (DescriptionAttribute[])enumInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return enumAttributes.Length > 0 ? enumAttributes[0].Description : e.ToString();
        }

        /// <summary>
        /// 获取枚举的描述信息，泛型方法
        /// </summary>
        /// <typeparam name="T">任意枚举类型</typeparam>
        /// <param name="t">传入枚举泛型</param>
        /// <returns>得到对应描述</returns>
        public static string GetEnumDesc<T>(T t)
        {
            var enumInfo = t.GetType().GetField(t.ToString());
            if (enumInfo == null)
            {
                return null;
            }
            var enumAttributes = (DescriptionAttribute[])enumInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return enumAttributes.Length > 0 ? enumAttributes[0].Description : t.ToString();
        }

        
    }
}
