#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DeepIn.DataRule
{
    public class ManagerBase<T> : IManager<T> where T : class
    {
        public IRepository<T> CurrentRepository { get; set; }

        public virtual T Get(object id)
        {
            if (id == null)
            {
                return null;
            }
            return CurrentRepository.Get(id);
        }

        public virtual object Save(T entity)
        {
            if (entity == null)
            {
                return null;
            }
            return CurrentRepository.Save(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity != null)
            {
                this.CurrentRepository.Update(entity);
            }
        }

        public virtual void SaveOrUpdate(T entity)
        {
            if (entity != null)
            {
                CurrentRepository.SaveOrUpdate(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            if (entity != null)
            {
                CurrentRepository.Delete(entity);
            }
        }

        public virtual IList<T> LoadAll()
        {
            return CurrentRepository.LoadAll().ToList();
        }

    }
}
