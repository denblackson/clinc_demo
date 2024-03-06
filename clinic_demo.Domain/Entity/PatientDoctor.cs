namespace clinic_demo.Domain.Entity
{
    public class PatientDoctor
    {
        public int PatientDoctorId { get; set; }
        public int PatientId { get; set; }
        public PatientEntity Patient { get; set; }

        public int DoctorId { get; set; }
        public DoctorEntity Doctor { get; set; }
    }
}
