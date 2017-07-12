using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanquetSystem.Data
{
    public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Country> CountryRepository { get; }
        GenericRepository<City> CityRepository { get; }
        GenericRepository<CustomerType> CustomerTypeRepository { get; }
        GenericRepository<Customer> CustomerRepository { get; }
        GenericRepository<CustomerEventDetail> CustomerEventDetailRepository { get; }
        GenericRepository<CustomerImage> CustomerImageRepository { get; }
        #endregion

        #region Public methods
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
        #endregion
    }
}
