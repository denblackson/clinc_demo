using System.ComponentModel.DataAnnotations;
using clinic_demo.Domain.Enum;
namespace clinic_demo.Domain.Entity
{
    public class AppointmentEntity
    {
        
        public int AppointmentEntityId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; }
        public string Description { get; set; }
        public PatientEntity Patient { get; set; }
        public DoctorEntity Doctor { get; set; }
    }
}
