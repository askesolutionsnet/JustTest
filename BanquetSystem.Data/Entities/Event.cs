using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BanquetSystem.Data
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string EventName { get; set; }
        public virtual IList<CustomerEventDetail> CustomerEventDetails { get; set; }
        public virtual IList<CustomerEvent> CustomerEvents { get; set; }
    }
}
