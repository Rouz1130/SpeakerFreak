using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakerFreak.Models
{


    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Commments { get; set; }
        public virtual ApplicationUser User { get; set; }
      

    }
}
