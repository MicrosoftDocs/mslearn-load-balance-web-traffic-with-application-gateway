using System;

namespace vehicles.Models
{
    public class VehicleRegistration
    {
        public string OwnerID { get; set; }
        public string EmailAddress { get; set; }
        public string Vehicle { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
