namespace clinic_demo.Domain.Entity
{
    public class PatientEntity
    {
        public int PatientEntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int MedicalCardNumber { get; set; }
        public ICollection<PatientDoctor> PatientDoctors { get; set; }
    }
}
