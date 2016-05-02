#region "Imports"

using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DeepIn.DAL
{
    public abstract class BaseDao<T> where T :class
    {
        #region "nhiberate dao implementations"

        protected ISession session = null;

        public BaseDao(ISession session)
        {
            this.session = session;            
        }

        /// <summary>
        /// Load a persistent object by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Load<T, K>(K id)
        {
            return session.Get<T>(id);
        }

        /// <summary>
        /// Load a list of persistent objects by HQL Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strHQL"></param>
        /// <returns></returns>
        public IList<T> Load<T>(string strHQL)
        {
            return session.CreateQuery(strHQL).List<T>();
        }

        /// <summary>
        /// Load All the persistent objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> LoadAll<T>() 
        {
            return session.CreateQuery(string.Format("from {0}",typeof(T).Name)).List<T>();
        }

        /// <summary>
        /// Load a list of persistent objects by HQL Query with parameter list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strHQL"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public IList<T> Load<T>(string strHQL, Dictionary<string, object> parameterList)
        {
            IQuery hqlQuery = session.CreateQuery(strHQL);
            foreach (var pair in parameterList)
            {
                hqlQuery.SetParameter(pair.Key, pair.Value);               
            }
            return hqlQuery.List<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Save<T>(T entity)
        {
            session.Save(entity);
            session.Flush();
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public IList<T> Save<T>(IList<T> entityList)
        {
            foreach (T entity in entityList)
            {
                session.Save(entity);
            }
            session.Flush();
            session.Clear();
            return entityList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T SaveOrUpdate<T>(T entity)
        {
            session.SaveOrUpdate(entity);
            session.Flush();
            session.Clear();
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public IList<T> SaveOrUpdate<T>(IList<T> entityList)
        {
            foreach (T entity in entityList)
            {
                session.SaveOrUpdate(entity);
            }
            session.Flush();
            session.Clear();
            return entityList;
        }

        /// <summary>
        /// update a persistent entity via hibernate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Update<T>(T entity)
        {
            session.Update(entity);
            session.Flush();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        public void Update<T>(IList<T> entityList)
        {
            foreach (T entity in entityList)
            {
                session.Update(entity);
            }
            session.Flush();
            session.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="updateFieldList"></param>
        /// <returns></returns>
        public virtual T Update<T>(T entity, List<string> updateFieldList)
        {
            if (updateFieldList == null || updateFieldList.Count <= 0)
            {
                return Save<T>(entity);
            }

            //从嵌入式资源读取映射表的主键
            bool bCompositeId = false;
            List<string> keyList = new List<string>();
            getModelMappingId<T>(ref bCompositeId, ref keyList);

            StringBuilder sbHql = new StringBuilder();
            Dictionary<string, object> dictParam = new Dictionary<string, object>();
            sbHql.AppendFormat("update {0} T set", typeof(T).Name);

            foreach (string fieldName in updateFieldList)
            {
                if (dictParam.ContainsKey(fieldName)) continue;
                dictParam.Add(fieldName, ReflectionHelper.GetPropertyValue(entity, fieldName));
                sbHql.AppendFormat(" T.{0} = :{0},", fieldName);
            }
            sbHql = sbHql.Remove(sbHql.Length - 1, 1);

            sbHql.Append(" where");
            foreach (string keyName in keyList)
            {
                if (bCompositeId)
                {
                    object Id = ReflectionHelper.GetPropertyValue(entity, "Id");

                    if (dictParam.ContainsKey(keyName)) continue;
                    dictParam.Add(keyName, ReflectionHelper.GetPropertyValue(Id, keyName));
                    sbHql.AppendFormat(" T.Id.{0} = :{0} and", keyName);
                }
                else
                {
                    if (dictParam.ContainsKey(keyName)) continue;
                    dictParam.Add(keyName, ReflectionHelper.GetPropertyValue(entity, keyName));
                    sbHql.AppendFormat(" T.{0} = :{0} and", keyName);
                }
            }
            sbHql = sbHql.Remove(sbHql.Length - 4, 4);

            IQuery hqlQuery = session.CreateQuery(sbHql.ToString());
            foreach (var pair in dictParam)
            {
                hqlQuery.SetParameter(pair.Key, pair.Value);
            }

            hqlQuery.ExecuteUpdate();
            return entity;
        }

        /// <summary>
        /// 从嵌入式资源读取映射表的主键
        /// </summary>
        /// <param name="bCompositeId">是否复合主键</param>
        /// <param name="keyList">主键列表</param>
        private void getModelMappingId<T>(ref bool bCompositeId, ref List<string> keyList)
        {
            bCompositeId = false;
            keyList = new List<string>();
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetAssembly(typeof(T));
            string hbmName = asm.GetManifestResourceNames().FirstOrDefault(o => o.Contains(string.Format(".{0}.hbm.xml", typeof(T).Name)));
            if (!string.IsNullOrEmpty(hbmName))
            {
                System.IO.Stream sm = asm.GetManifestResourceStream(hbmName);
                System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(sm);

                try
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == System.Xml.XmlNodeType.Element)
                        {
                            switch (reader.Name)
                            {
                                case "key-property":
                                    bCompositeId = true;
                                    keyList.Add(reader.GetAttribute("name"));
                                    break;
                                case "id":
                                    bCompositeId = false;
                                    keyList.Add(reader.GetAttribute("name"));
                                    break;
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Delete<T>(T entity)
        {
            session.Delete(entity);
            session.Flush();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        public void Delete<T>(IList<T> entityList)
        {
            foreach (T entity in entityList)
            {
                session.Delete(entity);
            }
            session.Flush();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHQL"></param>
        /// <returns></returns>
        public int Delete(string strHQL)
        {
            int nResult = session.Delete(strHQL);
            session.Flush();
            return nResult;
        }

        /// <summary>
        /// Get the nexavalue of a sequence by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T FetchSequenceNextValue<T>(string sequenceName)
        {
            string strSQL = string.Format("select {0}.Nextval from dual", sequenceName);
            object obj = session.CreateSQLQuery(strSQL).UniqueResult();
            return (T)Convert.ChangeType(DataTransformHelper.TakeUniqueResultTransfer<decimal>(obj), typeof(T));
        }

        /// <summary>
        /// execute a store producer
        /// </summary>
        /// <param name="strProcName">存储过程名称</param>
        /// <param name="inParamList">传入</param>
        /// <param name="outParamList">传出参数</param>
        public int ExecuteStoredProcedure(string strProcName, Dictionary<string, object> inParamList, ref Dictionary<string, object> outParamList)
        {
            Dictionary<string, IDbDataParameter> outIDbParamList = new Dictionary<string, IDbDataParameter>();
            int nResult = 0;
            IDbCommand m_Cmd = session.Connection.CreateCommand();
            //通过事务中添加命令来实现
            if (session.Transaction != null && session.Transaction.IsActive)
                session.Transaction.Enlist(m_Cmd);

            m_Cmd.CommandText = strProcName;
            m_Cmd.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> inParam in inParamList)
            {
                IDbDataParameter inIDbParam = m_Cmd.CreateParameter();
                inIDbParam.ParameterName = inParam.Key;
                inIDbParam.Value = inParam.Value;
                m_Cmd.Parameters.Add(inIDbParam);
            }

            foreach (KeyValuePair<string, object> outParam in outParamList)
            {
                IDbDataParameter outIDbParam = m_Cmd.CreateParameter();
                outIDbParam.ParameterName = outParam.Key;
                outIDbParam.Value = outParam.Value;
                outIDbParam.Direction = ParameterDirection.Output;
                m_Cmd.Parameters.Add(outIDbParam);
                outIDbParamList.Add(outParam.Key, outIDbParam);
            }
            nResult = m_Cmd.ExecuteNonQuery();

            foreach (KeyValuePair<string, IDbDataParameter> outIDbParam in outIDbParamList)
            {
                outParamList[outIDbParam.Key] = outIDbParam.Value.Value;
            }

            return nResult;
        }

        #endregion
    }
}
