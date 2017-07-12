using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanquetSystem.Data
{
    public class CustomerType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
