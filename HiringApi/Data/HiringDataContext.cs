using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringApi.Data
{
    public class HiringDataContext :DbContext
    {
        public DbSet<HiringRequest> HiringRequests { get; set; }

        public HiringDataContext(DbContextOptions<HiringDataContext> options): base(options)
        {

        }
    }
}
