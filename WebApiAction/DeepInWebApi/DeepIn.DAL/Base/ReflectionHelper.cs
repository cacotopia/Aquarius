#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;

#endregion

namespace DeepIn.DAL
{
    public abstract class ReflectionHelper
    {
        public static string strErr = string.Empty;

        #region "load assembly"
        /// <summary>
        /// 加载程序集
        /// </summary>
        /// <param name="assemblyName">程序集名称,不要加上程序集的后缀，如.dll</param>        
        public static Assembly LoadAssembly(string assemblyName)
        {
            try
            {
                //return Assembly.Load(assemblyName);
                Assembly ass = null;
                string path = string.Format("{0}\\{1}", Environment.CurrentDirectory, assemblyName);
                if (File.Exists(path + ".dll"))
                {
                    byte[] buff = System.IO.File.ReadAllBytes(path + ".dll");
                    ass = Assembly.Load(buff);
                }
                else if (File.Exists(path + ".exe"))
                {
                    byte[] buff = System.IO.File.ReadAllBytes(path + ".exe");
                    ass = Assembly.Load(buff);
                }

                return ass;
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }
        #endregion

        #region "获取程序集中的类型"
        /// <summary>
        /// 获取本地程序集中的类型
        /// </summary>
        /// <param name="typeName">类型名称，范例格式："命名空间.类名",类型名称必须在本地程序集中</param>        
        public static Type GetType(string typeName)
        {
            try
            {
                return Type.GetType(typeName, true, true);
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取指定程序集中的类型
        /// </summary>
        /// <param name="assembly">指定的程序集</param>
        /// <param name="typeName">类型名称，范例格式："命名空间.类名",类型名称必须在assembly程序集中</param>
        /// <returns></returns>
        public static Type GetType(Assembly assembly, string typeName)
        {
            try
            {
                return assembly.GetType(typeName, true, true);
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取指定程序集中的类型
        /// </summary>
        /// <param name="assemblyName">指定的程序集名称</param>
        /// <param name="typeName">类型名称，范例格式："命名空间.类名",类型名称必须在assembly程序集中</param>
        /// <returns></returns>
        public static Type GetType(string assemblyName, string typeName)
        {
            try
            {
                return GetType(LoadAssembly(assemblyName), typeName);
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }
        #endregion

        #region "动态创建对象实例"
        /// <summary>
        /// 创建类型的实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="parameters">传递给构造函数的参数</param>        
        public static object CreateInstance(Type type, params object[] parameters)
        {
            try
            {
                return Activator.CreateInstance(type, parameters);
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 创建类的实例
        /// </summary>
        /// <param name="className">类名，格式:"命名空间.类名"</param>
        /// <param name="parameters">传递给构造函数的参数</param>        
        public static object CreateInstance(Assembly assembly, string className, params object[] parameters)
        {
            try
            {
                //获取类型
                Type type = GetType(assembly, className);

                //类型为空则返回
                if (type == null)
                {
                    return null;
                }

                return CreateInstance(type, parameters);
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 创建类的实例
        /// </summary>
        /// <param name="className">类名，格式:"命名空间.类名"</param>
        /// <param name="parameters">传递给构造函数的参数</param>        
        public static object CreateInstance(string assemblyName, string className, params object[] parameters)
        {
            return CreateInstance(LoadAssembly(assemblyName), className, parameters);
        }
        /// <summary>
        /// 创建类的实例
        /// </summary>
        /// <param name="className">类名，格式:"命名空间.类名"</param>
        /// <param name="parameters">传递给构造函数的参数</param>        
        public static object CreateInstance(string className, params object[] parameters)
        {
            try
            {
                //获取类型
                Type type = GetType(className);

                //类型为空则返回
                if (type == null)
                {
                    return null;
                }

                return CreateInstance(type, parameters);
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 创建类的实例
        /// </summary>
        /// <typeparam name="T">要转换的类名</typeparam>
        /// <param name="className">类名，格式:"命名空间.类名"</param>
        /// <param name="parameters">传递给构造函数的参数</param>        
        public static T CreateInstance<T>(string className, params object[] parameters)
        {
            return (T)CreateInstance(className, parameters);
        }

        /// <summary>
        /// 创建类的实例
        /// </summary>
        /// <typeparam name="T">要转换的类名</typeparam>
        /// <param name="className">类名，格式:"命名空间.类名"</param>
        /// <param name="parameters">传递给构造函数的参数</param>        
        public static T CreateInstance<T>(string assemblyName, string className, params object[] parameters)
        {
            return (T)CreateInstance(assemblyName, className, parameters);
        }
        #endregion

        #region "创建远程代理对象"
        /// <summary>
        /// 创建远程代理对象
        /// </summary>
        /// <param name="type">远程对象的类型</param>
        /// <param name="url">远程对象的URL地址</param>        
        public static object CreateProxy(Type type, string url)
        {
            return Activator.GetObject(type, url);
        }

        /// <summary>
        /// 创建远程代理对象
        /// </summary>
        /// <typeparam name="T">远程对象类</typeparam>
        /// <param name="url">远程对象的URL地址</param>
        public static T CreateProxy<T>(string url)
        {
            //获取远程对象的类型
            Type type = typeof(T);

            return (T)CreateProxy(type, url);
        }

        #endregion

        #region "获取类的命名空间"
        /// <summary>
        /// 获取类的命名空间
        /// </summary>
        /// <typeparam name="T">类名或接口名</typeparam>        
        public static string GetNamespace<T>()
        {
            return typeof(T).Namespace;
        }
        #endregion

        #region "获取成员的值"

        #region "获取方法列表"
        /// <summary>
        /// 获取目标对象的方法
        /// </summary>
        /// <param name="target">要装载数据的目标对象</param>
        /// <param name="methodName">目标对象的方法名</param>
        public static MethodInfo GetMethod(object target, string methodName)
        {
            try
            {
                MethodInfo methodInfo = target.GetType().GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                return methodInfo;
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行目标对象的方法
        /// </summary>
        /// <param name="target">要装载数据的目标对象</param>
        /// <param name="methodName">目标对象的方法名</param>
        public static object InvokeMethod(object target, string methodName, params object[] parameters)
        {
            try
            {
                MethodInfo method = GetMethod(target, methodName);
                if (method == null)
                {
                    return null;
                }
                else
                {
                    return method.Invoke(target, parameters);
                }
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行目标对象的泛型方法
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="target">要装载数据的目标对象</param>
        /// <param name="methodName">目标对象的方法名</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object InvokeMethod<T>(object target, string methodName, params object[] parameters)
        {
            try
            {
                MethodInfo method = GetMethod(target, methodName);
                if (method == null)
                {
                    return null;
                }
                else
                {
                    method = method.MakeGenericMethod(typeof(T));
                    return method.Invoke(target, parameters);
                }
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行目标对象的方法
        /// </summary>
        /// <param name="target">要装载数据的目标对象</param>
        /// <param name="method">目标对象的方法</param>
        public static object InvokeMethod(object target, MethodInfo method, params object[] parameters)
        {
            try
            {
                if (method == null)
                {
                    return null;
                }
                else
                {
                    return method.Invoke(target, parameters);
                }
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }
        #endregion

        #region "获取属性值"
        /// <summary>
        /// 从目标对象的指定属性中获取值
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <param name="propertyName">目标对象的属性名</param>
        public static object GetPropertyValue(object target, string propertyName)
        {
            try
            {
                PropertyInfo propertyInfo = target.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                return propertyInfo.GetValue(target, null);
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
                return null;
            }
        }
        #endregion

        #endregion

        #region "设置成员的值"

        #region "设置属性值"
        /// <summary>
        /// 将值装载到目标对象的指定属性中
        /// </summary>
        /// <param name="target">要装载数据的目标对象</param>
        /// <param name="propertyName">目标对象的属性名</param>
        /// <param name="value">要装载的值</param>
        public static void SetPropertyValue(object target, string propertyName, object value)
        {
            try
            {
                PropertyInfo propertyInfo = target.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                SetValue(target, propertyInfo, value);
            }
            catch (Exception ex)
            {
                //Log4NetFactory.Instance.Logger.Error(ex);
                strErr = ex.Message;
            }
        }
        #endregion

        #region "设置成员的值"
        /// <summary>
        /// 设置成员的值
        /// </summary>
        /// <param name="target">要装载数据的目标对象</param>
        /// <param name="memberInfo">目标对象的成员</param>
        /// <param name="value">要装载的值</param>
        private static void SetValue(object target, MemberInfo memberInfo, object value)
        {
            if (value != null)
            {
                //获取成员类型
                Type pType = null;
                if (memberInfo.MemberType == MemberTypes.Property)
                {
                    pType = ((PropertyInfo)memberInfo).PropertyType;
                }
                else
                {
                    pType = ((FieldInfo)memberInfo).FieldType;
                }

                //获取值的类型
                Type vType = GetPropertyType(value.GetType());

                //强制将值转换为属性类型
                value = CoerceValue(pType, vType, value);
            }
            if (memberInfo.MemberType == MemberTypes.Property)
            {
                ((PropertyInfo)memberInfo).SetValue(target, value, null);
            }
            else
            {
                ((FieldInfo)memberInfo).SetValue(target, value);
            }
        }
        #endregion

        #region "强制将值转换为指定类型"
        /// <summary>
        /// 强制将值转换为指定类型
        /// </summary>
        /// <param name="propertyType">目标类型</param>
        /// <param name="valueType">值的类型</param>
        /// <param name="value">值</param>
        private static object CoerceValue(Type propertyType, Type valueType, object value)
        {
            //如果值的类型与目标类型相同则直接返回,否则进行转换
            if (propertyType.Equals(valueType))
            {
                return value;
            }
            else
            {
                if (propertyType.IsGenericType)
                {
                    if (object.ReferenceEquals(propertyType.GetGenericTypeDefinition(), typeof(Nullable<>)))
                    {
                        if (value == null)
                        {
                            return null;
                        }
                        else if (valueType.Equals(typeof(string)) && (string)value == string.Empty)
                        {
                            return null;
                        }
                    }
                    propertyType = GetPropertyType(propertyType);
                }

                if (propertyType.IsEnum && valueType.Equals(typeof(string)))
                {
                    return Enum.Parse(propertyType, value.ToString());
                }

                if (propertyType.IsPrimitive && valueType.Equals(typeof(string)) && string.IsNullOrEmpty((string)value))
                {
                    value = 0;
                }

                try
                {
                    return Convert.ChangeType(value, GetPropertyType(propertyType));
                }
                catch (Exception ex)
                {
                    TypeConverter cnv = TypeDescriptor.GetConverter(GetPropertyType(propertyType));
                    if (cnv != null && cnv.CanConvertFrom(value.GetType()))
                    {
                        return cnv.ConvertFrom(value);
                    }
                    else
                    {
                        return value;
                    }
                }
            }
        }
        #endregion

        #region "获取类型,如果类型为Nullable<>，则返回Nullable<>的基础类型"
        /// <summary>
        /// 获取类型,如果类型为Nullable(of T)，则返回Nullable(of T)的基础类型
        /// </summary>
        /// <param name="propertyType">需要转换的类型</param>
        private static Type GetPropertyType(Type propertyType)
        {
            Type type = propertyType;
            if (type.IsGenericType && (object.ReferenceEquals(type.GetGenericTypeDefinition(), typeof(Nullable<>))))
            {
                return Nullable.GetUnderlyingType(type);
            }
            return type;
        }
        #endregion

        #endregion

        #region 绑定事件
        public static void BindEvent<T>(object target, string eventName, EventHandler<T> handler) where T : EventArgs
        {
            EventInfo evt = target.GetType().GetEvent(eventName,
                    BindingFlags.NonPublic
                    | BindingFlags.Instance
                    | BindingFlags.Public
                );

            evt.AddEventHandler(target, handler);
        }

        public static void BindEvent(object target, string eventName, EventHandler handler)
        {
            EventInfo evt = target.GetType().GetEvent(eventName,
                    BindingFlags.NonPublic
                    | BindingFlags.Instance
                    | BindingFlags.Public
                );

            evt.AddEventHandler(target, handler);
        }
        #endregion
    }
}
