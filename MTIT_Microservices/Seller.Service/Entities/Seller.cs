using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seller.Service.Entities
{
    public class Seller: BaseEntity
    {
		public string Name { get; set; }
		public string Email { get; set; }
		public string NIC { get; set; }
		public int Phone { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
