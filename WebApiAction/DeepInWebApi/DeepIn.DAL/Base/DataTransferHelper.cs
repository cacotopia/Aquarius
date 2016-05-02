#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DeepIn.DAL
{
    /// <summary>
    /// DataType Transformer Helper
    /// </summary>
    public static class DataTransformHelper
    {
        /// <summary>
        /// 对枚举进行过滤，对没定义的枚举赋为空并写日志
        /// </summary>
        /// <typeparam name="T">类型参数</typeparam>
        /// <param name="b">待转换的参数</param>
        /// <returns>转换后的参数</returns>
        public static object GetEnumValue<T>(object b)
        {
            //定义一个NULL
            object obj = null;
            if (b == null)
            {
                //为空直接返回
                return obj;
            }
            //判断参数是否是INT或CHAR
            if ((b.GetType() == typeof(System.Int32)) || (b.GetType() == typeof(System.Char)))
            {
                //判断参数是否为空
                try
                {
                    //判断参数是否已经定义
                    if (Enum.IsDefined(typeof(T), Convert.ToInt32(b)))
                    {
                        //对已经定义的参数进行转换 
                        obj = (T)(object)Convert.ToInt32(b);
                    }
                    else
                    {
                        //对没有定义的参数返回空
                        obj = null;

                        //如果没有值不用抛出异常，反而导致IIS连续异常错误
                        //if (m_eLogLevel >= eLogLevel.Advanced)
                        //{
                        //    //写日志记录脏数据
                        //    throw new CIHDDBEnumInvalidExp(b, typeof(T));
                        //}
                        //AddDebug(string.Format("不能将{0}转换成{1}", b, typeof(T)), eLogLevel.Normal);
                    }
                }
                catch (Exception e)
                {
                    //AddLog(e);
                    //AddWarning(String.Format("工程：{0}，方法：{1}，警告信息：{2}，堆栈跟踪：{3}",
                    //e.Source, e.TargetSite, e.Message, e.StackTrace), eLogLevel.Advanced);
                }
            }
            else
            {
                //出现不是int或char类型的
                //throw new CIHDDBException(string.Format("{0}不是int或char，不能转换成枚举", b));
            }
            return obj;
        }

        public static T TakeUniqueResultTransfer<T>(object obj)
        {
            T t = default(T);
            object temp = null;
            if (obj != null)
            {
                if (typeof(T) == obj.GetType() || typeof(T) == typeof(object))
                {
                    return (T)obj;
                }
                else if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
                {
                    temp = decimal.Parse(obj.ToString());
                    return (T)temp;
                }
                else if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
                {
                    temp = double.Parse(obj.ToString());
                    return (T)temp;
                }
                else if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
                {
                    temp = long.Parse(obj.ToString());
                    return (T)temp;
                }
                else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                {
                    temp = DateTime.Parse(obj.ToString());
                    return (T)temp;
                }
                else if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                {
                    temp = int.Parse(obj.ToString());
                    return (T)temp;
                }
                else if (typeof(T) == typeof(string))
                {
                    temp = obj.ToString();
                    return (T)temp;
                }
            }
            return t;
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的字符串值，如果数据为空，则返回null
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的字符串值，可能为null</returns>
        public static string GetStrValue(object value)
        {
            if (value == null)
                return null;
            else
                return value.ToString();
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的日期值，如果数据为空，则返回最小时间
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的字符串值，可能为最小时间</returns>
        public static DateTime? GetDateTimeValue(object value)
        {
            if (value == null)
                return null;
            else
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value.ToString(), out dt);
                return dt;
            }
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的字符值，如果数据为空，则返回空格
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的字符串值，可能为空格</returns>
        public static char? GetCharValue(object value)
        {
            if (value == null)
                return null;
            else
            {
                char dt;
                char.TryParse(value.ToString(), out dt);
                return dt;
            }
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的Int32整数值，如果数据为空，则返回0
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的Int32整数值，可能为0</returns>
        public static int? GetIntValue(object value)
        {
            if (value == null)
                return null;
            else
            {
                if (value.GetType() == typeof(System.Int32))
                {
                    return (int)value;
                }
                else if (value.GetType() == typeof(System.Decimal))
                {
                    return (int)((Decimal)value);
                }
                else
                {
                    int dt;
                    int.TryParse(value.ToString(), out dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的Int64整数值，如果数据为空，则返回0
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的Int64整数值，可能为0</returns>
        public static long? GetLongValue(object value)
        {
            if (value == null)
                return null;
            else
            {
                if (value.GetType() == typeof(System.Decimal))
                {
                    return (long)((Decimal)value);
                }
                else
                {
                    long dt;
                    long.TryParse(value.ToString(), out dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的字节值，如果数据为空，则返回0
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的字节值，可能为0</returns>
        public static Byte? GetByteValue(object value)
        {
            if (value == null)
                return null;
            else
            {
                Byte dt;
                Byte.TryParse(value.ToString(), out dt);
                return dt;
            }
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的double值，如果数据为空，则返回0
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的double值，可能为0</returns>
        public static double? GetDoubleValue(object value)
        {
            if (value == null)
                return null;
            else
            {
                double dt;
                double.TryParse(value.ToString(), out dt);
                return dt;
            }
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的decimal值，如果数据为空，则返回0
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的decimal值，可能为0</returns>
        public static decimal? GetDecimalValue(object value)
        {
            if (value == null)
                return null;
            else
            {
                decimal dt;
                decimal.TryParse(value.ToString(), out dt);
                return dt;
            }
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的float值，如果数据为空，则返回0
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的decimal值，可能为0</returns>
        public static float? GetFloatValue(object value)
        {
            if (value == null)
                return null;
            else
            {
                float dt;
                float.TryParse(value.ToString(), out dt);
                return dt;
            }
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的bool值，如果数据为空，则返回false
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的int值，可能为false</returns>
        public static bool? GetBooleanValue(object value)
        {
            if (value == null)
                return null;
            else
            {
                bool dt;
                bool.TryParse(value.ToString(), out dt);
                return dt;
            }
        }

        /// <summary>
        /// 指定列对象得到Reader对象中的bool值，如果数据为空，则返回false
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <param name="col">列对象</param>
        /// <returns>列的int值，可能为false</returns>
        public static bool? GetBooleanValue(int value)
        {
            if (value == null)
                return null;
            else
            {
                bool dt;
                if (value != 0)
                {
                    dt = true;
                }
                else
                {
                    dt = false;
                }
                return dt;
            }
        }
    }
}
   
    

