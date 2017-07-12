using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BanquetSystem.Data
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string CountryName { get; set; }
        public virtual IList<City> Cities { get; set; }
        public virtual IList<Customer> Customers { get; set; }
    }
}
