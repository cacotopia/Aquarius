#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NHibernate;
using NHibernate.Cfg;

#endregion

namespace DeepIn.DAL
{   
    public static class NHiberateSessionFactory
    {
        #region 私有静态变量

        private static object  _locker = new object();
        private static Configuration  _Configuration = null;
        private static ISessionFactory _SessionFactory = null;
        private static Mutex _mutex = new Mutex();
        private static AutoResetEvent _synchronize;

        //private static ISessionStorage m_Sessionsource;

        
        #endregion

        #region 静态构造函数
        static NHiberateSessionFactory()
        {
           // m_Sessionsource = ISessionStorageFactory.GetSessionStorage();
        }
        #endregion        

        #region 内部静态变量
        
        /// <summary>
        /// NHibernate configuration
        /// </summary>
        public static Configuration Configuration
        {
            get
            {
                if (_Configuration == null) 
                {
                    lock (_locker)
                    {
                        if (_Configuration == null)
                        {
                            CreateConfiguration();
                        }                       
                    }
                }
                return _Configuration;
            }
            set { _Configuration = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionFactoryConfigPath"></param>
        /// <returns></returns>
        public static Configuration ConfigurationPath(string sessionFactoryConfigPath)
        {
            if (!string.IsNullOrEmpty(sessionFactoryConfigPath))
            {
                if (_Configuration == null) 
                {
                    lock (_locker)
                    {
                        if (_Configuration == null)
                        {
                            CreateConfiguration(sessionFactoryConfigPath);
                        }
                    }
                }
            }
            return _Configuration;
        }
        
        /// <summary>
        /// NHibernate的对象工厂
        /// </summary>
        internal static ISessionFactory SessionFactory
        {
            get
            {
                if (null == _SessionFactory)
                {
                    if (_Configuration == null)
                    {
                        CreateConfiguration();
                    }
                    lock (_locker)
                    {
                        if (_SessionFactory == null) 
                        {
                            _SessionFactory = Configuration.BuildSessionFactory();
                        }                        
                    }
                }
                return _SessionFactory;
            }
        }

        /// <summary>
        /// 多数据库的对象工程
        /// </summary>
        /// <param name="sessionFactoryConfigPath">数据库配置路径</param>
        /// <returns>会话工厂</returns>
        public static ISessionFactory GetSessionFactoryFor(string sessionFactoryConfigPath)
        {

            CreateConfiguration(sessionFactoryConfigPath);

            lock (_locker)
            {
                _SessionFactory = Configuration.BuildSessionFactory();
            }

            return _SessionFactory;
        }
        #endregion

        #region 公共方法     
        
        /// <summary>
        /// 建立ISessionFactory的实例
        /// </summary>
        /// <returns></returns>
        public static ISession GetISession()
        {
            //初始化NHProfilter  
            //InitNHProfilter();    
            return SessionFactory.OpenSession();
            //if (Config.UserSessionSource) //如果使用保存的ISession
            //{
            //    mutex.WaitOne();
            //    SessionPool s = m_Sessionsource.Get(OperationContext.Current.SessionId.ToString());
            //    mutex.ReleaseMutex();

            //    ISession session = null;
            //    if (s != null)
            //    {
            //        session = s.Session;
            //    }
            //    if (session == null || session.IsConnected)
            //    {
            //        session = SessionFactory.OpenSession();
            //        m_Sessionsource.Set(session);
            //    }
            //    if ((!session.IsConnected))
            //    {
            //        session.Reconnect();
            //        if (s != null)
            //            s.bSessionState = true;
            //    }

            //    return session;
            //}
            //else //如果使用新ISession
            //{
            //    return SessionFactory.OpenSession();
            //}
        }

        /// <summary>
        /// 建立HttpISessionFactory的实例
        /// </summary>
        /// <returns></returns>
        //public static ISession GetHttpISession()
        //{
            //if (Config.UserSessionSource) //如果使用保存的ISession
            //{
            //    mutex.WaitOne();
            //    SessionPool s = m_Sessionsource.GetHttp(OperationContext.Current.InstanceContext.Extensions.ToString());
            //    mutex.ReleaseMutex();

            //    ISession session = null;
            //    if (s != null)
            //    {
            //        session = s.Session;
            //    }
            //    if (session == null || session.IsConnected)
            //    {
            //        session = SessionFactory.OpenSession();
            //        m_Sessionsource.SetHttp(session);
            //    }
            //    if ((!session.IsConnected))
            //    {
            //        session.Reconnect();
            //        if (s != null)
            //            s.bSessionState = true;
            //    }

            //    return session;
            //}
            //else //如果使用新ISession
            //{
            //    return SessionFactory.OpenSession();
            //}
        //}

        /// <summary>
        /// 连接多数据库获取会话
        /// </summary>
        /// <param name="sessionFactoryConfigPath"></param>
        /// <returns></returns>
        public static ISession GetISession(string sessionFactoryConfigPath)
        {
            //if (SessionConfiguration.UserSessionSource) //如果使用保存的ISession
            //{
            //    _mutex.WaitOne();
            //    SessionPool s = m_Sessionsource.Get(OperationContext.Current.SessionId.ToString());
            //    _mutex.ReleaseMutex();
            //    ISession session = null;
            //    if (s != null)
            //    {
            //        session = s.Session;
            //    }
                
            //    if (session == null || !session.IsConnected)
            //    {
            //        ISessionFactory SessionFactory = GetSessionFactoryFor(sessionFactoryConfigPath);
            //        session = SessionFactory.OpenSession();
            //        //m_Sessionsource.Set(session);
            //    }
            //    if ((!session.IsConnected))
            //    {
            //        session.Reconnect();
            //        if (s != null)
            //            s.bSessionState = true;
            //    }
            //    return session;
            //}
            //else 
            //{
            //    return SessionFactory.OpenSession();
            //}
            return null;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 
        /// </summary>
        private static void CreateConfiguration()
        {
           Configuration = new Configuration().Configure();
            // Add interceptor, if you need to.
            // _config.Interceptor = new Interceptor();
        }

        /// <summary>
        /// 多数据库连接创建配置文件
        /// </summary>
        /// <param name="sessionFactoryConfigPath">数据库配置路径</param>
        private static void CreateConfiguration(string sessionFactoryConfigPath)
        {
            string strConfigPath = System.Configuration.ConfigurationSettings.AppSettings[sessionFactoryConfigPath];
            _Configuration = new Configuration().Configure(@strConfigPath);
        }

        /// <summary>
        /// 是否初始化 NHProfiler 软件,用以监控SQL语句.
        /// </summary>
        /// <returns>是否启用NHProfiler.</returns>
        //private static bool InitNHProfilter()
        //{
        //    bool bOpenNHProfiler = false;
        //    try
        //    {
        //        string strOpenNHProfiler = System.Configuration.ConfigurationManager.AppSettings["OpenNHProfiler"];
        //        if (!string.IsNullOrEmpty(strOpenNHProfiler))
        //        {
        //            bOpenNHProfiler = bool.Parse(strOpenNHProfiler);
        //            if (bOpenNHProfiler)
        //            {
        //                HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        bOpenNHProfiler = false;
        //    }
        //    return bOpenNHProfiler;
        //}
        #endregion

    }
}
