using System;

namespace licenses.Models
{
    public class LicenseRenewal
    {
        public string LicenseID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfRenewal { get; set; }
    }
}
