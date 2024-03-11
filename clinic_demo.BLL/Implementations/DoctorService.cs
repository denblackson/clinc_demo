
using clinic_demo.BLL.Interfaces;
using clinic_demo.DAL.Interfaces;
using clinic_demo.DAL.Repositiries;
using clinic_demo.Domain.DTO.Appointment;
using clinic_demo.Domain.DTO.Doctor;
using clinic_demo.Domain.Entity;
using clinic_demo.Domain.Enum;
using clinic_demo.Domain.Responce;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace clinic_demo.BLL.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IBaseRepository<DoctorEntity> _doctorRepository;
        private ILogger<DoctorEntity> _logger;

        public DoctorService(IBaseRepository<DoctorEntity> doctorRepository,
            ILogger<DoctorEntity> logger)
        {
            _doctorRepository = doctorRepository;
            _logger = logger;
        }

        public async Task<IBaseResponce<IEnumerable<DoctorDTO>>> GetAllDoctors()
        {
            try
            {
              var doctors = await _doctorRepository.GetAll()
                    .Select(x => new DoctorDTO()
                    {
                       DoctorId =x.DoctorEntityId,
                       FirstName = x.FirstName,
                       LastName = x.LastName,
                       Email = x.Email,
                       PhoneNumber = x.PhoneNumber,
                       Specialty = x.Specialty
                    })
                    .ToListAsync();

                return new BaseResponce<IEnumerable<DoctorDTO>>()
                {
                    Data = doctors,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"[Appointment.GetAllDoctors]");
                return new BaseResponce<IEnumerable<DoctorDTO>>()
                {
                    Description = $"{e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<DoctorDTO>> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _doctorRepository.GetAll().Select(x=>new DoctorDTO()
                    {
                        DoctorId = x.DoctorEntityId,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        Specialty = x.Specialty
                })
                    .FirstOrDefaultAsync(x => x.DoctorId == id);

                if (doctor == null)
                {
                    return new BaseResponce<DoctorDTO>()
                    {
                        StatusCode = StatusCode.NotFound,
                        Description = "Appointment not found"
                    };
                }
                
                return new BaseResponce<DoctorDTO>()
                {
                   Data = doctor,
                   StatusCode = StatusCode.Ok
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"[Appointment.GetDoctorById]: {e.Message}");
                return new BaseResponce<DoctorDTO>()
                {
                    Description = $"{e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
