#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;

#endregion

namespace DeepIn.DataRule
{
    public interface IRepository<T> where T : class
    {
        #region "Fetech"

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        T Get(object id);

        /// <summary>
        /// Load Entity By ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Load(object id);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Load<T>(T entity);

        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns></returns>
        IList<T> LoadAll();

        #endregion

        #region "Save"

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        object Save(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //T Save(T entity);
        //IList<T> Save(IList<T> entities);
        //void Update(IList<T> entities);
        //void SaveOrUpdate(IList<T> entities);
        //void Delete(IList<T> entities);

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        void Save(object entity, object id);

        #endregion

        #region "Update"

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        void SaveOrUpdate(T entity);

        #endregion

        #region "Delete"

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        void Delete(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHQL"></param>
        /// <returns></returns>
        int Delete(string strHQL);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHql"></param>
        /// <param name="values"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        int Delete(string strHql, object[] values, IType[] types);

        #endregion

        #region "Query"

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="strHql"></param>
        /// <returns></returns>
        IList<T> Query(string strHql);

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="Hql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        IList<T> Query(string Hql, params object[] values);

        /// <summary>
        /// 无类型条件查询
        /// </summary>
        /// <param name="Hql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        IList<object> QueryList(string Hql, params object[] values);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHql"></param>
        /// <param name="values"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        IList<T> QueryList(string strHql, object[] values, IType[] types);


        #endregion

        /// <summary>
        /// 执行存储过程 
        /// </summary>
        /// <param name="strProcName">存储过程名称</param>
        /// <param name="inParamList">输入参数集合</param>
        /// <param name="outParamList">输出参数集合</param>
        /// <returns></returns>
        int TakeExecProc(string strProcName, Dictionary<string, object> inParamList, ref Dictionary<string, object> outParamList);
    }
}
