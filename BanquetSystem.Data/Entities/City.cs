using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanquetSystem.Data
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public int? CountryId { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string CityName { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
