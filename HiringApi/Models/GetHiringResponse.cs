using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiringApi.Models
{
    //public class GetHiringResponse
    //{
    //    [Required]
    //    public string Name { get; set; }
    //    [Required, MaxLength(3)]
    //    public string Department { get; set; }
    //    [Required]
    //    public decimal StartingSalary { get; set; }
    //}

    public record GetHiringResponse
    {
        [Required]
        public string Name { get; init; }
        [Required, MaxLength(3)]
        public string Department { get; init; }
        [Required]
        public decimal StartingSalary { get; init; }
        [Required]
        public Guid Id { get; init; }
        [Required]
        public HiringStatus Status { get; init; }

    };

}
