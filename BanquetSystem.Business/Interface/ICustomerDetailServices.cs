using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanquetSystem.Domain;

namespace BanquetSystem.Business
{
    public interface ICustomerDetailServices
    {
        CustomerDetailBDO GetCustomerDetailById(int customerdetailId);
        IEnumerable<CustomerDetailBDO> GetAllCustomersDetails();
        int CreateCustomerDetail(CustomerDetailBDO customerdetailBDO);
        //bool UpdateCustomerDetail(CustomerDetailBDO customerdetailBDO);
        bool DeleteCustomerDetail(int customerdetailId);
    }
}
