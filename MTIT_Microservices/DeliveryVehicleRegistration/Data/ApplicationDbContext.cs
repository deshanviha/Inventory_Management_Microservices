using DeliveryVehicleRegistration.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryVehicleRegistration.Data
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        public DbSet<Entities.DeliveryVehicle> DeliverVehicle { get ; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public async Task<int> SaveDeliveryVehicleChanges()
        {
            return await base.SaveChangesAsync();

        }
    }
}
