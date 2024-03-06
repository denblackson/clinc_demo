using clinic_demo.BLL.Interfaces;
using clinic_demo.DAL.Interfaces;
using clinic_demo.Domain.DTO.Appointment;
using clinic_demo.Domain.Entity;
using clinic_demo.Domain.Enum;
using clinic_demo.Domain.Filters;
using clinic_demo.Domain.Responce;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace clinic_demo.BLL.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IBaseRepository<AppointmentEntity> _appointmentRepository;
        private ILogger<AppointmentEntity> _logger;

        public AppointmentService(IBaseRepository<AppointmentEntity> appointmentRepository,
            ILogger<AppointmentEntity> logger)
        {
            _appointmentRepository = appointmentRepository;
            _logger = logger;
        }


        public async Task<IBaseResponce<AppointmentEntity>> Create(CreateAppointmentDTO model)
        {
            try
            {
                model.Validate();

                _logger.LogInformation($"Appointment id = {model.AppointmentId}    creation query");



                var appointment = await _appointmentRepository.GetAll()
                    .Where(x => x.PatientId == model.PatientId && x.Date == model.Date)
                    .FirstOrDefaultAsync();


                if (appointment != null)
                {
                    return new BaseResponce<AppointmentEntity>()
                    {
                        Description = "Запис на цей час та з цим пацієнтом вже існує",
                        StatusCode = StatusCode.AlreadyExists
                    };
                }

                appointment = new AppointmentEntity()
                {
                    AppointmentEntityId = model.AppointmentId,
                    PatientId = model.PatientId,
                    DoctorId = model.DoctorId,
                    Date = model.Date,
                    Status = AppointmentStatus.Pending,
                    Description = model.Description
                };
                await _appointmentRepository.Create(appointment);


                return new BaseResponce<AppointmentEntity>()
                {
                    StatusCode = StatusCode.Ok,
                    Description = "Task created successfully"
                };


            }
            catch (Exception e)
            {
                _logger.LogError(e, $"[Appointment.Create]: {e.Message}");
                return new BaseResponce<AppointmentEntity>()
                {
                    Description = $"{e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<IEnumerable<AppointmentDTO>>> GetAllAppointments(AppointmentFilter filter)
        {
            try
            {
                var appointments = await _appointmentRepository.GetAll()
                    .Where(x => x.Status != AppointmentStatus.Completed)
                    .Where(x => x.Date == filter.AppointmentDate)
                    .Select(x => new AppointmentDTO()
                    {
                        DoctorId = x.DoctorId,
                        PatientId = x.PatientId,
                        Date = x.Date,
                        Description = x.Description,
                        Status = x.Status.ToString()
                    })
                    .ToListAsync();


                return new BaseResponce<IEnumerable<AppointmentDTO>>()
                {
                    Data = appointments,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"[Appointment.GetAllAppointments]: {e.Message}");
                return new BaseResponce<IEnumerable<AppointmentDTO>>()
                {
                    Description = $"{e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<bool>> ChangeStatus(int id, AppointmentStatus newStatus)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAll().FirstOrDefaultAsync(x => x.AppointmentEntityId == id);

                if (appointment == null)
                {
                    return new BaseResponce<bool>()
                    {
                        StatusCode = StatusCode.NotFound,
                        Description = "Appointment not found"
                    };
                }

                appointment.Status = newStatus;

                await _appointmentRepository.Update(appointment);
               
                return new BaseResponce<bool>()
                {
                    StatusCode = StatusCode.Ok,
                    Description = $"Appointment status was turned to {newStatus}"
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"[Appointment.Create]: {e.Message}");
                return new BaseResponce<bool>()
                {
                    Description = $"{e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<bool>> EndTask(long id)
        {
            throw new NotImplementedException();
        }

    }
}