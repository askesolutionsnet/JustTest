using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BanquetSystem.Business;

namespace BanquetSystem.UI.Controllers
{
    //I am here testing on branching...
    public class BanquetAPIController : ApiController
    {
        private readonly ICustomerServices _customerservice;

        public BanquetAPIController()
        {

        }
        public BanquetAPIController(ICustomerServices customerservice)
        {
            this._customerservice = customerservice;
        }

        // GET: api/BanquetAPI
        public HttpResponseMessage Get()
        {
            try
            {
                var getallcustomer = this._customerservice.GetAllCustomers();

                return Request.CreateResponse(getallcustomer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(ex.Message);
            }
        }

        // GET: api/BanquetAPI/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var getallcustomer = this._customerservice.GetCustomerById(id);

                return Request.CreateResponse(getallcustomer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(ex.Message);
            }
        }
    }
}
