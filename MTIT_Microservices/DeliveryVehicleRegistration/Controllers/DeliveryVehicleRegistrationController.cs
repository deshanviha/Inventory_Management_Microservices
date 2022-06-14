using DeliveryVehicleRegistration.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryVehicleRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryVehicleRegistrationController : ControllerBase
    {
        private readonly IApplicationDbContext context;


        public DeliveryVehicleRegistrationController(IApplicationDbContext context)
        {

            this.context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await this.context.DeliverVehicle.ToListAsync();
            if (products == null) return NotFound();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0) return NotFound();
            var product = await this.context.DeliverVehicle.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Entities.DeliveryVehicle vehicle)
        {
            this.context.DeliverVehicle.Add(vehicle);
            await this.context.SaveDeliveryVehicleChanges();
            return Ok(vehicle.Id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.DeliveryVehicle vehicleData)
        {
            var vehicle = await this.context.DeliverVehicle.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (vehicle == null) return NotFound();
            else
            {
                vehicle.OwnerName = vehicleData.OwnerName;
                vehicle.VehicleType = vehicleData.VehicleType;
                vehicle.VehicleNumber = vehicleData.VehicleNumber;
                vehicle.VehicleYear = vehicleData.VehicleYear;
                vehicle.Phone = vehicleData.Phone;
                vehicle.LicenseNumber = vehicleData.LicenseNumber;
                vehicle.AllocatedBranch = vehicleData.AllocatedBranch;
                await this.context.SaveDeliveryVehicleChanges();
                return Ok(vehicleData.Id);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return NotFound();
            var product = await this.context.DeliverVehicle.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            this.context.DeliverVehicle.Remove(product);
            await this.context.SaveDeliveryVehicleChanges();
            return Ok(product.Id);
        }
    }
}
