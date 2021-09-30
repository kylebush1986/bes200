using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiringApi.Models
{
    public class PostHiringRequest
    {
  
        [Required]
        public string  Name { get; set; }
        [Required, MaxLength(3)]
        public string  Department { get; set; }
        [Required]
        public decimal StartingSalary { get; set; }
    }

}


