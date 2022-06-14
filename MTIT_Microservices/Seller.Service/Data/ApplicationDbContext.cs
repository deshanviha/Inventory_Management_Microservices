using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seller.Service.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Entities.Seller> Seller { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){   


        }

        public async Task<int> SaveCustomerChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
