using clinic_demo.Domain.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.UnitTest
{
    [TestClass]
    public class AppointmentEntityTests
    {
        [TestMethod]
        public void TestAppointmentProperties()
        {
            // Arrange
            var appointment = new AppointmentEntity();
            var patientId = 1;
            var doctorId = 2;
            var date = DateTime.Now;
            var status = AppointmentStatus.Pending;
            var description = "Regular checkup";

            // Act
            appointment.PatientId = patientId;
            appointment.DoctorId = doctorId;
            appointment.Date = date;
            appointment.Status = status;
            appointment.Description = description;

            // Assert
            Assert.AreEqual(patientId, appointment.PatientId);
            Assert.AreEqual(doctorId, appointment.DoctorId);
            Assert.AreEqual(date, appointment.Date);
            Assert.AreEqual(status, appointment.Status);
            Assert.AreEqual(description, appointment.Description);
        }
    }
}
