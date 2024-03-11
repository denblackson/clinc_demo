
using clinic_demo.Domain.DTO.Appointment;
using clinic_demo.Domain.DTO.Doctor;
using clinic_demo.Domain.Filters;
using clinic_demo.Domain.Responce;

namespace clinic_demo.BLL.Interfaces
{
    public interface IDoctorService
    {
        Task<IBaseResponce<IEnumerable<DoctorDTO>>> GetAllDoctors();
        Task<IBaseResponce<DoctorDTO>> GetDoctorById(int id);
    }
}
