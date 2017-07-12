using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanquetSystem.Domain
{
    public class CustomerImageBDO
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }

        [Required(ErrorMessage ="Images Required")]
        public string Image { get; set; }
    }
}
