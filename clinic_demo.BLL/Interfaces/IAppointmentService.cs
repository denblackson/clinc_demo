using clinic_demo.Domain.DTO.Appointment;
using clinic_demo.Domain.Entity;
using clinic_demo.Domain.Enum;
using clinic_demo.Domain.Filters;
using clinic_demo.Domain.Responce;

namespace clinic_demo.BLL.Interfaces
{
    public interface IAppointmentService
    {
        Task<IBaseResponce<AppointmentEntity>> Create(CreateAppointmentDTO model);
        Task<IBaseResponce<IEnumerable<AppointmentDTO>>> GetAllAppointments(AppointmentFilter filter);
        Task<IBaseResponce<bool>> ChangeStatus(int id, AppointmentStatus newStatus);
        Task<IBaseResponce<bool>> EndAppointment(long id); //TODO: remove?????
    }
}
