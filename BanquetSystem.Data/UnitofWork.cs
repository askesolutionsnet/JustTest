using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanquetSystem.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region "Declarations"
        private readonly BanquetDbContext context;
        private GenericRepository<Country> countryRepository;
        private GenericRepository<City> cityRepository;
        private GenericRepository<CustomerType> customerTypeRepository;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<CustomerEventDetail> customerEventDetailRepository;
        private GenericRepository<CustomerImage> customerImageRepository;
        #endregion

        #region "Constructor"
        public UnitOfWork()
        {
            context = new BanquetDbContext();
        }
        #endregion

        #region "UOF Methods"
        public GenericRepository<Country> CountryRepository
        {
            get
            {

                if (this.countryRepository == null)
                {
                    this.countryRepository = new GenericRepository<Country>(context);
                }
                return countryRepository;
            }
        }


        public GenericRepository<City> CityRepository
        {
            get
            {

                if (this.cityRepository == null)
                {
                    this.cityRepository = new GenericRepository<City>(context);
                }
                return cityRepository;
            }
        }


        public GenericRepository<CustomerType> CustomerTypeRepository
        {
            get
            {

                if (this.customerTypeRepository == null)
                {
                    this.customerTypeRepository = new GenericRepository<CustomerType>(context);
                }
                return customerTypeRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {

                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }


        public GenericRepository<CustomerEventDetail> CustomerEventDetailRepository
        {
            get
            {

                if (this.customerEventDetailRepository == null)
                {
                    this.customerEventDetailRepository = new GenericRepository<CustomerEventDetail>(context);
                }
                return customerEventDetailRepository;
            }
        }

        public GenericRepository<CustomerImage> CustomerImageRepository
        {
            get
            {

                if (this.customerImageRepository == null)
                {
                    this.customerImageRepository = new GenericRepository<CustomerImage>(context);
                }
                return customerImageRepository;
            }
        }
        #endregion

        #region public methods
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException entityValidationException)
            {
                throw entityValidationException;

            }

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
