using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryVehicleRegistration.Data
{
    public interface IApplicationDbContext
    {

        DbSet<Entities.DeliveryVehicle> DeliverVehicle { get; set; }
        Task<int> SaveDeliveryVehicleChanges();
    }
}
