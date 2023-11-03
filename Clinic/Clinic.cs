using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Clinic
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }

        private List<Doctor> doctors = new List<Doctor>();

        public void Add_doctor(string name, string phoneNumber, string spec, string appointments)
        {
            var doc = new Doctor { Name = name , PhoneNumber = phoneNumber, specialization = spec, Appointments = appointments };
            doctors.Add(doc);
        }
        public string All_doc()
        {
            var report = new System.Text.StringBuilder();
            foreach (var item in doctors)
            {
                report.AppendLine($"{item.Name}\t{item.PhoneNumber}\t{item.specialization}\n{item.Appointments}");
            }

            return report.ToString();
        }
    }
}