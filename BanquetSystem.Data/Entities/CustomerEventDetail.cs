using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanquetSystem.Data
{
    public class CustomerEventDetail
    {
        [Key]
        public int Id { get; set; }      
        public int? CustomerId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int? EventId { get; set; }

        [Required]
        public decimal? CostPerHead { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Capacity { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Event Event { get; set; }

    }
}
