#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeepInWebApi.Models;
//using DeepIn.DAL;
//using NHibernate;
//using DeepIn.DAL;
//using DeepIn.DAL.Sakila;
//using DeepIn.ModelMapper.Model;

#endregion

namespace DeepInWebApi.Controllers
{
    public class AddressController : ApiController
    {
        //IEnumerable<AddressModel> addresses = new AddressModel[]
        //{
        //    new AddressModel(){AddressId=1,Address="47 MySakila Drive",Distict="Albert",CityId=300,LastUpdate= DateTime.Parse("2006-02-15 04:45:30")},
        //    new AddressModel(){AddressId=2,Address="MySQL Boulevard",Distict="QLD",CityId=576,LastUpdate= DateTime.Parse("2006-02-15 04:45:30")}
        //};

        //public IEnumerable<AddressModel> GetAllProducts()
        //{
        //    return addresses;
        //}


        //public IHttpActionResult GetAddress(int id)
        //{
        //    //var address = addresses.FirstOrDefault((p) => p.AddressId == id);
        //    //if (address == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    ISession session = NHiberateSessionFactory.GetISession();
        //    AddressDAO addressDAO = new AddressDAO(session);
        //    Address address;
        //    if (addressDAO != null) 
        //    {
        //      address  = addressDAO.Load<Address, int>(id);
        //      return Ok(address);
        //    }
        //    return NotFound();
            
        //}

        //public HttpResponseMessage DeleteProduct(int addressId)
        //{
        //    return null;
        //}

    }
    
       
    
}
