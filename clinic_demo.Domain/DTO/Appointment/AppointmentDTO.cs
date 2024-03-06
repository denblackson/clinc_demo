using clinic_demo.Domain.DTO.Doctor;
using clinic_demo.Domain.DTO.Patient;

namespace clinic_demo.Domain.DTO.Appointment
{
    public class AppointmentDTO
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

    }
}
