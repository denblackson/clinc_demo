using clinic_demo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace clinic_demo.DAL.Repositiries.Tests
{
    [TestClass()]
    public class PatientRepositoryTests
    {
        [TestMethod()]
        public async Task TestCreatePatient()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var repository = new PatientRepository(context);
                var patient = new PatientEntity { FirstName = "John Doe", DateOfBirth = DateTime.Now, PhoneNumber = "31231231",LastName = "LL",Address = "aasd"};

                // Act
                await repository.Create(patient);
            }

            // Assert
            using (var context = new AppDbContext(options))
            {
                Assert.AreEqual(1, context.Patients.Count());
            }
        }

        [TestMethod()]
        public void TestGetAllPatients()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Patients.Add(new PatientEntity { FirstName = "John Doe", DateOfBirth = DateTime.Now, PhoneNumber = "31231231", LastName = "LL", Address = "aasd" });
                context.Patients.Add(new PatientEntity { FirstName = "John Doe", DateOfBirth = DateTime.Now, PhoneNumber = "31231231", LastName = "LL", Address = "aasd" });
                context.SaveChanges();
            }

            // Act
            using (var context = new AppDbContext(options))
            {
                var repository = new PatientRepository(context);
                var patients = repository.GetAll().ToList();

                // Assert
                Assert.AreEqual(2, patients.Count);
            }
        }

        [TestMethod()]
        public async Task TestDeletePatient()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var patient = new PatientEntity { FirstName = "John Doe", DateOfBirth = DateTime.Now, PhoneNumber = "31231231", LastName = "LL", Address = "aasd" };
                context.Patients.Add(patient);
                context.SaveChanges();

                var repository = new PatientRepository(context);

                // Act
                await repository.Delete(patient);
            }

            // Assert
            using (var context = new AppDbContext(options))
            {
                Assert.AreEqual(0, context.Patients.Count());
            }
        }
    }
}