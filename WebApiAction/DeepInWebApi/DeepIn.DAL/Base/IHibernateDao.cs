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
    /// Hibernate数据访问对象接口
    /// </summary>
    public interface IHibernateDao
    {
        /// <summary>
        /// 通过键值加载实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Load<T, K>(K id);

        /// <summary>
        /// 通过HQL语句加载实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strHql"></param>
        /// <returns></returns>
        IList<T> Load<T>(string strHql);

        /// <summary>
        /// 通过HQL语句及参数集合加载实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strHql"></param>
        /// <param name="paramDict"></param>
        /// <returns></returns>
        IList<T> Load<T>(string strHql, Dictionary<string, object> paramDict);

        /// <summary>
        /// 加载所有实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<T> LoadAll<T>();

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Save<T>(T entity);

        /// <summary>
        /// 保存实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <returns></returns>
        IList<T> Save<T>(IList<T> entityList);

        /// <summary>
        /// 保存或更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T SaveOrUpdate<T>(T entity);

        /// <summary>
        /// 保存或更新实体列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <returns></returns>
        IList<T> SaveOrUpdate<T>(IList<T> entityList);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Update<T>(T entity);

        /// <summary>
        /// 更新实体列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        void Update<T>(IList<T> entityList);

        /// <summary>
        /// 更新实体指定的属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="updateFieldList"></param>
        /// <returns></returns>
        T Update<T>(T entity, List<string> updateFieldList);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity);

        /// <summary>
        ///删除实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        void Delete<T>(IList<T> entityList);

        /// <summary>
        /// 通过HQL语句删除实体
        /// </summary>
        /// <param name="strHQL"></param>
        /// <returns></returns>
        int Delete(string strHQL);
    }
}
