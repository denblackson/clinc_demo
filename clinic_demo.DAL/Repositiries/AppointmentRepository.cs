using clinic_demo.DAL.Interfaces;
using clinic_demo.Domain.Entity;

namespace clinic_demo.DAL.Repositiries
{
    public class AppointmentRepository : IBaseRepository<AppointmentEntity>
    {
        private readonly AppDbContext _appDbContext;

        public AppointmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(AppointmentEntity entity)
        {
            await _appDbContext.Appointments.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<AppointmentEntity> GetAll()
        {
            return _appDbContext.Appointments;
        }

        public async Task Delete(AppointmentEntity entity)
        {
            _appDbContext.Appointments.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<AppointmentEntity> Update(AppointmentEntity entity)
        {
            _appDbContext.Appointments.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
