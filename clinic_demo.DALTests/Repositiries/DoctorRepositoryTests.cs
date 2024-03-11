using clinic_demo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace clinic_demo.DAL.Repositiries.Tests
{
    [TestClass()]
    public class DoctorRepositoryTests
    {
      [TestMethod()]
        public async Task TestCreateDoctor()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var repository = new DoctorRepository(context);
                var doctor = new DoctorEntity { FirstName = "Dr. Smith", Specialty = "Cardiologist",DoctorEntityId = 1, Email = "example@example.com",LastName = "BOBRKURWA", PhoneNumber = "39209320"};

                // Act
                await repository.Create(doctor);
            }

            // Assert
            using (var context = new AppDbContext(options))
            {
                Assert.AreEqual(1, context.Doctors.Count());
            }
        }

        [TestMethod()]
        public void TestGetAllDoctors()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Doctors.Add(new DoctorEntity { FirstName = "Dr. Smith", Specialty = "Cardiologist", DoctorEntityId = 1, Email = "example@example.com", LastName = "BOBRKURWA", PhoneNumber = "39209320" });
                context.Doctors.Add(new DoctorEntity { FirstName = "Dr. Smith", Specialty = "Cardiologist", DoctorEntityId = 2, Email = "example@example.com", LastName = "BOBRKURWA", PhoneNumber = "39209320" });
                context.SaveChanges();
            }

            // Act
            using (var context = new AppDbContext(options))
            {
                var repository = new DoctorRepository(context);
                var doctors = repository.GetAll().ToList();

                // Assert
                Assert.AreEqual(2, doctors.Count);
            }
        }

        [TestMethod()]
        public async Task TestDeleteDoctor()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var doctor = new DoctorEntity { FirstName = "Dr. Smith", Specialty = "Cardiologist", DoctorEntityId = 1, Email = "example@example.com", LastName = "BOBRKURWA", PhoneNumber = "39209320" };
                context.Doctors.Add(doctor);
                context.SaveChanges();

                var repository = new DoctorRepository(context);

                // Act
                await repository.Delete(doctor);
            }

            // Assert
            using (var context = new AppDbContext(options))
            {
                Assert.AreEqual(0, context.Doctors.Count());
            }
        }
    }
}