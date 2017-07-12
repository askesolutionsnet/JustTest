using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanquetSystem.Data
{
    public class CustomerEvent
    {
        [Key]
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        [Column(TypeName = "int")]
        public int? EventId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Event Event { get; set; }
    }
}
