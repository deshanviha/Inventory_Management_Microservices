using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryVehicleRegistration.Entities
{
    public class DeliveryVehicle:BaseEntity
    {
		public string OwnerName { get; set; }
		public string VehicleType { get; set; }
		public string VehicleNumber { get; set; }
		public string VehicleYear { get; set; }
		public int Phone { get; set; }
		public string LicenseNumber { get; set; }
		public string AllocatedBranch { get; set; }

	}
}
