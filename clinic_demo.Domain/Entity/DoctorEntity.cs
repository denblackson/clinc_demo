namespace clinic_demo.Domain.Entity
{
    public class DoctorEntity
    {
        public int DoctorEntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<PatientDoctor> PatientDoctors { get; set; }
    }
}
