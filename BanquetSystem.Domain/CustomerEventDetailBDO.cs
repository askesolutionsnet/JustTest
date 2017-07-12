using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanquetSystem.Domain
{
    public class CustomerEventDetailBDO
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? EventId { get; set; }

        [Display(Name = "Cost Per Head")]
        [Required(ErrorMessage = "Cost Per Head Required")]
        public decimal? CostPerHead { get; set; }

        [Display(Name = "Capacity")]
        [Required(ErrorMessage = "Capacity Required")]
        public int Capacity { get; set; } 
    }
}
