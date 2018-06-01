using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class Bedaprogram
    {
        public int BedaprogramID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
