using System.ComponentModel.DataAnnotations;

namespace clinic_demo.Domain.DTO.Patient
{
    public class PatientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int MedicalCardNumber { get; set; }
    }
}
