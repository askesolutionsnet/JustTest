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
    public class CustomerDetailServices : ICustomerDetailServices
    {
        #region "Declerations"
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Public constructor.
        /// </summary>
        public CustomerDetailServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Get Customer details by customerdetailId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public CustomerDetailBDO GetCustomerDetailById(int customerdetailId)
        {
            var customerdetail = _unitOfWork.CustomerRepository.GetByID(customerdetailId);
            var customereventdetail = _unitOfWork.CustomerEventDetailRepository.GetByID(customerdetail.Id);
            List<CustomerImage> CustomerDetailImages = _unitOfWork.CustomerImageRepository.GetAll().Where(img=>img.CustomerId.Equals(customerdetail.Id)).ToList();

            if (customerdetail != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<CustomerImage, CustomerImageBDO>());
                var customerdetailimageModel = Mapper.Map<List<CustomerImage>, List<CustomerImageBDO>>(CustomerDetailImages);

                return new CustomerDetailBDO
                {
                    Id = customerdetail.Id,
                    CustomerTypeName = _unitOfWork.CustomerTypeRepository.GetByID(customerdetail.CustomerTypeId).Name,
                    FirstName = customerdetail.FirstName,
                    LastName = customerdetail.LastName,
                    Email = customerdetail.Email,
                    Phone = customerdetail.Phone,
                    Mobile = customerdetail.Mobile,
                    AddressLine1 = customerdetail.AddressLine1,
                    AddressLine2 = customerdetail.AddressLine2,
                    AddressLine3 = customerdetail.AddressLine3,
                    PostCode = customerdetail.PostCode,
                    CountryName = _unitOfWork.CountryRepository.GetByID(customerdetail.CountryId).CountryName,
                    CityName = _unitOfWork.CityRepository.GetByID(customerdetail.CityId).CityName,
                    CustomerEventDetails = new CustomerEventDetailBDO
                                                        { CostPerHead = customereventdetail.CostPerHead,
                                                            Capacity = customereventdetail.Capacity },
                    CustomerImages =customerdetailimageModel,
                   CreatedDate = customerdetail.CreatedDate
                };

            }
            return null;
        }

        /// <summary>
        /// Get the customer details.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerDetailBDO> GetAllCustomersDetails()
        {
            var customer = _unitOfWork.CustomerRepository.GetAll().ToList();
            if (customer.Any())
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerDetailBDO>());
                var customerModel = Mapper.Map<List<Customer>, List<CustomerDetailBDO>>(customer);
                return customerModel;
            }
            return null;
        }

        /// <summary>
        /// Creates a new Customer
        /// </summary>
        /// <param name="customerdetailBDO"></param>
        /// <returns></returns>
        public int CreateCustomerDetail(CustomerDetailBDO customerdetailBDO)
        {
            using (var scope = new TransactionScope())
            {
                var customer = new Customer
                {
                    CustomerTypeId = 1,
                    UserId = "1", /*Hard Coded User ID will Switch when user going to create their own account*/
                    FirstName = customerdetailBDO.FirstName,
                    LastName = customerdetailBDO.LastName,
                    Email = customerdetailBDO.Email,
                    Phone = customerdetailBDO.Phone,
                    Mobile = customerdetailBDO.Mobile,
                    AddressLine1 = customerdetailBDO.AddressLine1,
                    AddressLine2 = customerdetailBDO.AddressLine2,
                    AddressLine3 = customerdetailBDO.AddressLine3,
                    PostCode = customerdetailBDO.PostCode,
                    CountryId = customerdetailBDO.CountryId,
                    CityId = customerdetailBDO.CityId,
                    CreatedDate = DateTime.Now,
                };
                _unitOfWork.CustomerRepository.Insert(customer);
                _unitOfWork.Save();

                var customereventdetail = new CustomerEventDetail
                {
                    CustomerId = customer.Id,
                    EventId = 1,
                    Capacity = customerdetailBDO.CustomerEventDetails.Capacity,
                    CostPerHead = customerdetailBDO.CustomerEventDetails.CostPerHead,
                };
                _unitOfWork.CustomerEventDetailRepository.Insert(customereventdetail);
                _unitOfWork.Save();

                foreach (var imageitem in customerdetailBDO.CustomerImages)
                {
                    var customerimage = new CustomerImage
                    {
                        CustomerId = customer.Id,
                        Image = imageitem.Image
                    };
                    _unitOfWork.CustomerImageRepository.Insert(customerimage);
                    _unitOfWork.Save();
                }

                scope.Complete();
                return customer.Id;
            }
        }

        /// <summary>
        /// Update a existing post
        /// </summary>
        /// <param name="customerdetailBDO"></param>
        /// <returns></returns>
        /*public bool UpdateCustomerDetail(CustomerDetailBDO customerdetailBDO)
        {
          var success = false;

          var customer = _unitOfWork.CustomerRepository.GetByID(CustomerDetailBDO.Id);
            if (customer != null)
            {
                using (var scope = new TransactionScope())
                {
                    CustomerTypeId = customerdetailBDO.CustomerTypesId,
                    UserId = customerdetailBDO.UserId,
                    FirstName = customerdetailBDO.FirstName,
                    LastName = customerdetailBDO.LastName,
                    Email = customerdetailBDO.Email,
                    Phone = customerdetailBDO.Phone,
                    Mobile = customerdetailBDO.Mobile,
                    AddressLine1 = customerdetailBDO.AddressLine1,
                    AddressLine2 = customerdetailBDO.AddressLine2,
                    AddressLine3 = customerdetailBDO.AddressLine3,
                    PostCode = customerdetailBDO.PostCode,
                    CountryId = customerdetailBDO.CountryId,
                    CityId = customerdetailBDO.CityId,
                    post.ModifiedBy = postBDO.ModifiedBy;
                    post.ModifiedDate = DateTime.Now;
                    _unitOfWork.PostRepository.Update(post);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;

                }
            }
            else
                success = false;

            return success;
        }*/

        /// <summary>
        /// Deletes a particular post
        /// </summary>
        /// <param name="customerdetailId"></param>
        /// <returns></returns>
        public bool DeleteCustomerDetail(int customerdetailId)
        {
            var success = false;
            if (customerdetailId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var customerdetail = _unitOfWork.CustomerRepository.GetByID(customerdetailId);
                    if (customerdetail != null)
                    {
                        _unitOfWork.CustomerEventDetailRepository.Delete(customerdetail);
                        _unitOfWork.CustomerImageRepository.Delete(customerdetail);
                        _unitOfWork.CustomerRepository.Delete(customerdetail);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        #endregion

    }
}
