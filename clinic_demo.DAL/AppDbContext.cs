using clinic_demo.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace clinic_demo.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<AppointmentEntity> Appointments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        
    }
}
