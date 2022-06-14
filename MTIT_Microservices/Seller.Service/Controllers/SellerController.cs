using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seller.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Seller.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IApplicationDbContext context;

        public SellerController(IApplicationDbContext context)
        {

            this.context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await this.context.Seller.ToListAsync();
            if (products == null) return NotFound();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0) return NotFound();
            var product = await this.context.Seller.Where(x => x.SellerId == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Entities.Seller seller)
        {
            this.context.Seller.Add(seller);
            await this.context.SaveCustomerChanges();
            return Ok(seller.SellerId);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Seller sellerData)
        {
            var seller = await this.context.Seller.Where(x => x.SellerId == id).FirstOrDefaultAsync();
            if (seller == null) return NotFound();
            else
            {
                seller.Name = sellerData.Name;
                seller.Email = sellerData.Email;
                seller.NIC = sellerData.NIC;
                seller.Phone = sellerData.Phone;
                seller.UserName = sellerData.UserName;
                seller.Password = sellerData.Password;
                await this.context.SaveCustomerChanges();
                return Ok(seller.SellerId);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return NotFound();
            var product = await this.context.Seller.Where(x => x.SellerId == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            this.context.Seller.Remove(product);
            await this.context.SaveCustomerChanges();
            return Ok(product.SellerId);
        }
    }
}
