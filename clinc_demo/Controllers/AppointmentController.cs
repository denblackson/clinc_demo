using clinic_demo.BLL.Interfaces;
using clinic_demo.Domain.DTO.Appointment;
using clinic_demo.Domain.DTO.Doctor;
using clinic_demo.Domain.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clinc_demo.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View("NewAppointment");
        }

      
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDTO model)
        {
            var response = await _appointmentService.Create(model);
            if (response.StatusCode == clinic_demo.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }




        [HttpPost]
        public async Task<IActionResult> EndAppointment(long id)
        {
            var responce = await _appointmentService.EndAppointment(id);

            if (responce.StatusCode == clinic_demo.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = responce.Description });
            }


            return BadRequest(new { description = responce.Description });
        }


        [HttpPost]
        public async Task<IActionResult> AppointmentHandler(AppointmentFilter filter)
        {
            var response = await _appointmentService.GetAllAppointments(filter);
            return Json(new { data = response.Data });
        }


        [HttpPost]
        public async Task<IActionResult> DoctorListHandler()
        {
            var response = await _doctorService.GetAllDoctors();
            return Json(new { data = response.Data });
        }

    }



}

