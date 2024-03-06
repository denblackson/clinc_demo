using System.ComponentModel.DataAnnotations;
using clinic_demo.Domain.DTO.Doctor;
using clinic_demo.Domain.DTO.Patient;

namespace clinic_demo.Domain.DTO.Appointment
{
    public class CreateAppointmentDTO
    {

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public PatientDTO Patient { get; set; }
        public DoctorDTO Doctor { get; set; }


        public virtual ICollection<ValidationResult> Validate()
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this, serviceProvider: null, items: null);

            Validator.TryValidateObject(this, context, results, true);

            if (AppointmentId< 0)
            {
                throw new Exception("AppointmentEntityId must be greater than or equal to zero.");
            }

            if (PatientId < 0)
            {
                throw new Exception("PatientEntityId must be greater than or equal to zero.");
            }

            if (DoctorId < 0)
            {
                throw new Exception("PatientEntityId must be greater than or equal to zero.");
            }

            if (Date < DateTime.Today) // ????????????????????????
            {
                throw new Exception("PatientEntityId must be greater than or equal to zero.");
            }

            if (string.IsNullOrEmpty(Description))
            {
                throw new Exception("Description is empty");
            }

            return results;
        }

     

    }
}
