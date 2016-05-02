#region "Imports"

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Data.NHibernate.Generic.Support;
using NHibernate.Type;
using NHibernate;

#endregion

namespace DeepIn.DataRule
{
    public class RepositoryBase<T> : HibernateDaoSupport, IRepository<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ISession GetCurrentSession()
        {
            return this.HibernateTemplate.SessionFactory.OpenSession();
        }

        #region "Fetech"

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public T Get(object id)
        {
            return this.HibernateTemplate.Get<T>(id);
        }

        /// <summary>
        /// Load Entity By ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Load(object id)
        {
            return this.HibernateTemplate.Load<T>(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Load<T>(T entity)
        {
            this.HibernateTemplate.Load<T>(entity);
        }

        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns></returns>
        public IList<T> LoadAll()
        {
            return this.HibernateTemplate.LoadAll<T>();
        }

        #endregion

        #region "Save"

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public object Save(T entity)
        {
            return this.HibernateTemplate.Save(entity);
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        public void Save(object entity, object id)
        {
            this.HibernateTemplate.Save(entity, id);
        }

        #endregion

        #region "Update"

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public void Update(T entity)
        {
            this.HibernateTemplate.Update(entity);
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public void SaveOrUpdate(T entity)
        {
            this.HibernateTemplate.SaveOrUpdate(entity);
        }

        #endregion

        #region "Delete"

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public void Delete(T entity)
        {
            this.HibernateTemplate.Delete(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHQL"></param>
        /// <returns></returns>
        public int Delete(string strHQL)
        {
            return this.HibernateTemplate.Delete(strHQL);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHql"></param>
        /// <param name="values"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public int Delete(string strHql, object[] values, IType[] types)
        {
            return HibernateTemplate.Delete(strHql, values, types);
        }

        #endregion

        #region "Query"

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="strHql"></param>
        /// <returns></returns>
        public IList<T> Query(string strHql)
        {
            return this.HibernateTemplate.Find<T>(strHql);
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="Hql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public IList<T> Query(string Hql, params object[] values)
        {
            return this.HibernateTemplate.Find<T>(Hql, values);
        }

        /// <summary>
        /// 无类型条件查询
        /// </summary>
        /// <param name="Hql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public IList<object> QueryList(string Hql, params object[] values)
        {
            return this.HibernateTemplate.Find<object>(Hql, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHql"></param>
        /// <param name="values"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public IList<T> QueryList(string strHql, object[] values, IType[] types)
        {
            return this.HibernateTemplate.Find<T>(strHql, values, types);
        }

        #endregion

        /// <summary>
        /// Execute a procedure
        /// </summary>
        /// <param name="strProcName">存储过程名称</param>
        /// <param name="inParamList">输入参数集合</param>
        /// <param name="outParamList">输出参数集合</param>
        /// <returns></returns>
        public int TakeExecProc(string strProcName, Dictionary<string, object> inParamList, ref Dictionary<string, object> outParamList)
        {
            Dictionary<string, IDbDataParameter> outIDbParamList = new Dictionary<string, IDbDataParameter>();
            int nResult = 0;
            IDbCommand dbCommand = this.Session.Connection.CreateCommand();
            //通过事务中添加命令来实现
            if (this.Session.Transaction != null && this.Session.Transaction.IsActive)
                this.Session.Transaction.Enlist(dbCommand);
            //ITransaction tansaction = session.BeginTransaction();

            dbCommand.CommandText = strProcName;
            dbCommand.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> inParam in inParamList)
            {
                IDbDataParameter inIDbParam = dbCommand.CreateParameter();
                inIDbParam.ParameterName = inParam.Key;
                inIDbParam.Value = inParam.Value;
                dbCommand.Parameters.Add(inIDbParam);
            }

            foreach (KeyValuePair<string, object> outParam in outParamList)
            {
                IDbDataParameter outIDbParam = dbCommand.CreateParameter();
                outIDbParam.ParameterName = outParam.Key;
                outIDbParam.Value = outParam.Value;
                outIDbParam.Direction = ParameterDirection.Output;
                dbCommand.Parameters.Add(outIDbParam);
                outIDbParamList.Add(outParam.Key, outIDbParam);
            }

            nResult = dbCommand.ExecuteNonQuery();

            foreach (KeyValuePair<string, IDbDataParameter> outIDbParam in outIDbParamList)
            {
                outParamList[outIDbParam.Key] = outIDbParam.Value.Value;
            }

            return nResult;
        }

        /*
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
            //session.Save(entity);
            //this.HibernateTemplate.S
            //session.Flush();
            //return entity;
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
        */

    }
}
