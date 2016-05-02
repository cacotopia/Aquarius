#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DeepIn.DataRule
{
    public interface IManager<T> where T : class
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        T Get(object id);

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        object Save(T entity);

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

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        void Delete(T entity);

        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns></returns>
        IList<T> LoadAll();

    }
}
