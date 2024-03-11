using clinic_demo.DAL.Interfaces;
using clinic_demo.Domain.DTO.Appointment;
using clinic_demo.Domain.Entity;
using clinic_demo.Domain.Enum;
using clinic_demo.Domain.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace clinic_demo.BLL.Implementations.Tests
{
    [TestClass()]
    public class AppointmentServiceTests
    {
      [TestMethod()]
      public async Task TestCreateAppointment()
      {
          // Arrange
          var mockRepository = new Mock<IBaseRepository<AppointmentEntity>>();
          var mockLogger = new Mock<ILogger<AppointmentEntity>>();
          var appointmentService = new AppointmentService(mockRepository.Object, mockLogger.Object);
          var model = new CreateAppointmentDTO { PatientId = 1, DoctorId = 1, Date = DateTime.Now, Description = "Regular checkup",Status = AppointmentStatus.Pending.ToString(), AppointmentId = 1};

          // Act
          var result = await appointmentService.Create(model);

          // Assert
          Assert.AreEqual(StatusCode.InternalServerError, result.StatusCode);
          // Add more assertions based on expected behavior
      }

        [TestMethod()]
        public async Task TestGetAllAppointments()
        {
            // Arrange
            var mockRepository = new Mock<IBaseRepository<AppointmentEntity>>();
            var mockLogger = new Mock<ILogger<AppointmentEntity>>();
            var appointmentService = new AppointmentService(mockRepository.Object, mockLogger.Object);
            var filter = new AppointmentFilter { AppointmentDate = DateTime.Now };

            // Act
            var result = await appointmentService.GetAllAppointments(filter);

            // Assert
            Assert.AreEqual(StatusCode.InternalServerError, result.StatusCode);
            // Add more assertions based on expected behavior
        }

        [TestMethod()]
        public async Task TestChangeStatus()
        {
            // Arrange
            var mockRepository = new Mock<IBaseRepository<AppointmentEntity>>();
            var mockLogger = new Mock<ILogger<AppointmentEntity>>();
            var appointmentService = new AppointmentService(mockRepository.Object, mockLogger.Object);
            var appointmentId = 1;
            var newStatus = AppointmentStatus.Completed;

            // Act
            var result = await appointmentService.ChangeStatus(appointmentId, newStatus);

            // Assert
            Assert.AreEqual(StatusCode.InternalServerError, result.StatusCode);
            // Add more assertions based on expected behavior

        }

        [TestMethod()]
        public async Task TestEndAppointment()
        {
            // Arrange
            var mockRepository = new Mock<IBaseRepository<AppointmentEntity>>();
            var mockLogger = new Mock<ILogger<AppointmentEntity>>();
            var appointmentService = new AppointmentService(mockRepository.Object, mockLogger.Object);
            var appointmentId = 1;

            // Act
            var result = await appointmentService.EndAppointment(appointmentId);

            // Assert
            Assert.AreEqual(StatusCode.InternalServerError, result.StatusCode);
            // Add more assertions based on expected behavior
        }
    }
}