using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using BanquetSystem.Domain;
using BanquetSystem.Data;

namespace BanquetSystem.Business
{
    public class CustomerServices : ICustomerServices
    {

        #region "Declerations"
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Public constructor.
        /// </summary>
        public CustomerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Get Customer by customerId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public CustomerBDO GetCustomerById(int customerdetailId)
        {
            var customer = _unitOfWork.CustomerRepository.GetByID(customerdetailId);
            if (customer != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerBDO>());
                var customerModel = Mapper.Map<Customer, CustomerBDO>(customer);
                return customerModel;
            }
            return null;
        }

        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerBDO> GetAllCustomers()
        {
            var customer =  (from _cust in _unitOfWork.CustomerRepository.GetAll()
                             select new CustomerBDO
                             {
                                 Id = _cust.Id,
                                 CustomerType = _unitOfWork.CustomerTypeRepository.GetByID(_cust.CustomerTypeId).Name,
                                 FirstName = _cust.FirstName,
                                 LastName = _cust.LastName,
                                 Email = _cust.Email,
                                 Phone = _cust.Phone,
                                 Mobile = _cust.Mobile,
                                 AddressLine1 = _cust.AddressLine1,
                                 AddressLine2 = _cust.AddressLine2,
                                 AddressLine3 = _cust.AddressLine3,
                                 PostCode = _cust.PostCode,
                                 Country = _unitOfWork.CountryRepository.GetByID(_cust.CountryId).CountryName,
                                 City = _unitOfWork.CityRepository.GetByID(_cust.CityId).CityName,
                                 CreatedDate = _cust.CreatedDate,
                              }).ToList();

            if (customer.Any())
            {
                //Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerBDO>());
                //var customerModel = Mapper.Map<List<Customer>, List<CustomerBDO>>(customer);
                return customer;
            }
            return null;
        }

        #endregion
    }
}
