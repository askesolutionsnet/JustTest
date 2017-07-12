using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BanquetSystem.Data
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerTypeId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(75)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(25)]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(25)]
        public string Mobile { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string AddressLine3 { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string PostCode { get; set; }

        [Required]
        public int? CountryId { get; set; }

        [Required]
        public int? CityId { get; set; }

        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(128)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual IList<CustomerImage> CustomerImages { get; set; }
        public virtual IList<CustomerEventDetail> CustomerEventDetails { get; set; }

    }
}
