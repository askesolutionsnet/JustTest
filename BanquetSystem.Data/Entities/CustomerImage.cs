using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanquetSystem.Data
{
    public class CustomerImage
    {
        [Key]
        public int Id { get; set; }
       
        public int? CustomerId { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Image { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
