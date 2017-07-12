using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BanquetSystem.Business;
using BanquetSystem.Domain;

namespace BanquetSystem.UI.Controllers
{
    public class BanquetDetailAPIController : ApiController
    {
        private readonly ICustomerDetailServices _customerdetailservice;
        public BanquetDetailAPIController()
        {
                
        }
        public BanquetDetailAPIController(ICustomerServices customerservice, ICustomerDetailServices customerdetailservice)
        {
            this._customerdetailservice = customerdetailservice;
        }

        // GET: api/Customer
        public HttpResponseMessage Get()
        {
            try
            {
                var getallcustomerdetail = this._customerdetailservice.GetAllCustomersDetails();

                return Request.CreateResponse(getallcustomerdetail);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(ex.Message);
            }
        }

        // GET: api/Customer/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var getallcustomerdetail = this._customerdetailservice.GetCustomerDetailById(id);

                return Request.CreateResponse(getallcustomerdetail);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(ex.Message);
            }
        }

        // POST: api/Customer
        //[Route("Save")]
        public HttpResponseMessage Post([FromBody]CustomerDetailBDO customerdetails)
        {
            if(customerdetails != null)
            {
                int retcustomerid = this._customerdetailservice.CreateCustomerDetail(customerdetails);
                if (retcustomerid > 0)
                {
                    return Request.CreateResponse(retcustomerid);
                }
                else
                {
                    return Request.CreateResponse(0);
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Problem in saving in database.");
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
