using Profiles.Domain.Entities.ForeignEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public string Complaints { get; set; } = String.Empty;
        public string Conclusion { get; set; } = String.Empty;
        public string Recomendations { get; set; } = String.Empty;
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = new();
    }
}
