#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepIn.ModelMapper.Model;
using NHibernate;

#endregion

namespace DeepIn.DAL.Sakila
{
    public  class AddressDAO :BaseDao<Address>,IAddressDAO
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="session"></param>
        public AddressDAO(ISession session) :base(session)
        {

        }


        public void GetAddressById(int addressId) 
        {

        }

    }
}
