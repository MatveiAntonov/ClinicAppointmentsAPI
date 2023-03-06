using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class PatientCreated
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string? MiddleName { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
    }
}
