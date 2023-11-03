using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic
{
    public class Doctor
    {
        int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string specialization { get; set; }
        public string Appointments { get; set; }
    }
}