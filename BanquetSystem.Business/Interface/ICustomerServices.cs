using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanquetSystem.Domain;

namespace BanquetSystem.Business
{
    public interface ICustomerServices
    {
        CustomerBDO GetCustomerById(int customerId);
        IEnumerable<CustomerBDO> GetAllCustomers();
    }
}
