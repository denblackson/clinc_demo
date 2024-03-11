using Microsoft.VisualStudio.TestTools.UnitTesting;
using clinic_demo.DAL.Repositiries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic_demo.Domain.Entity;
using clinic_demo.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace clinic_demo.DAL.Repositiries.Tests
{
    [TestClass()]
    public class AppointmentRepositoryTests
    {
      [TestMethod()]
        public async Task TestCreateAppointment()
        {
            //Arrange
           var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase1")
               .Options;

            using (var context = new AppDbContext(options))
            {
                var repository = new AppointmentRepository(context);
                var appointment = new AppointmentEntity { PatientId = 1, DoctorId = 2, Date = DateTime.Now, Status = AppointmentStatus.Pending , Description = "desc"};

                // Act
                await repository.Create(appointment);
            }

            // Assert
            using (var context = new AppDbContext(options))
            {
                Assert.AreEqual(1, context.Appointments.Count());
            }
        }

        [TestMethod()]
        public void TestGetAllAppointments()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Appointments.Add(new AppointmentEntity { PatientId = 1, DoctorId = 2, Date = DateTime.Now, Status = AppointmentStatus.Pending, Description = ""});
                context.Appointments.Add(new AppointmentEntity { PatientId = 3, DoctorId = 4, Date = DateTime.Now.AddDays(1), Status = AppointmentStatus.Confirmed, Description = ""});
                context.SaveChanges();
            }

            // Act
            using (var context = new AppDbContext(options))
            {
                var repository = new AppointmentRepository(context);
                var appointments = repository.GetAll().ToList();

                // Assert
                Assert.AreEqual(2, appointments.Count);
            }
        }

        [TestMethod()]
        public async Task TestDeleteAppointment()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var appointment = new AppointmentEntity { PatientId = 1, DoctorId = 2, Date = DateTime.Now, Status = AppointmentStatus.Pending ,Description = ""};
                context.Appointments.Add(appointment);
                context.SaveChanges();

                var repository = new AppointmentRepository(context);

                // Act
                await repository.Delete(appointment);
                context.SaveChanges();

            }

            // Assert
            using (var context = new AppDbContext(options))
            {
                Assert.AreEqual(0, context.Appointments.Count());
            }
        }
    }
}