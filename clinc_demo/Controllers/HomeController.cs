using clinic_demo.BLL.Interfaces;
using clinic_demo.Domain.DTO.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace clinc_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public HomeController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            return View();
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
    }



}

