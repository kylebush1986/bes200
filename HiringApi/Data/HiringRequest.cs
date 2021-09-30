using HiringApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringApi.Data
{
    public class HiringRequest
    {
        public string Name { get; init; }
        
        public string Department { get; init; }
        
        public decimal StartingSalary { get; init; }
        
        public Guid Id { get; init; }
        
        public HiringStatus Status { get; init; }
    }
}
