using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seller.Service.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Seller> Seller { get; set; }
        Task<int> SaveCustomerChanges();
    }
}
