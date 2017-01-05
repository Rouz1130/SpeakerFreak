using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakerFreak.Models
{

    [Table("Musicians")]
    public class Music
    {
        [Key]
        public int Id { get; set; }
        public string Image_url { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        

    }
}