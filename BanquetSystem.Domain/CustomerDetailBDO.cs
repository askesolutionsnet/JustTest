using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BanquetSystem.Domain
{
    public class CustomerDetailBDO
    {
        public int Id { get; set; }
        public int? CustomerTypesId { get; set; }
        public string CustomerTypeName { get; set; }
        public List<CustomerTypeBDO> CustomerTypes { get; set; }
        public string UserId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage ="First Name Required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number Required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Mobile Number Required")]
        public string Mobile { get; set; }
        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Address Line 1 Required")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Line 2")]
        [Required(ErrorMessage = "Address Line2 Required")]
        public string AddressLine2 { get; set; }
        [Display(Name = "Line 3")]
        public string AddressLine3 { get; set; }
        [Display(Name = "Postal Code")]
        public string PostCode { get; set; }
        [Display(Name ="Country")]
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public List<SelectListItem> Countries { get; set; }
        [Display(Name = "City")]
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public CustomerEventDetailBDO CustomerEventDetails { get; set; }
        public List<CustomerImageBDO> CustomerImages { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
