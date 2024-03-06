using clinic_demo.DAL.Interfaces;
using clinic_demo.Domain.Entity;

namespace clinic_demo.DAL.Repositiries
{
    public class DoctorRepository : IBaseRepository<DoctorEntity>
    {
        private readonly AppDbContext _appDbContext;

        public DoctorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(DoctorEntity entity)
        {
            await _appDbContext.Doctors.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<DoctorEntity> GetAll()
        {
            return _appDbContext.Doctors;
        }

        public async Task Delete(DoctorEntity entity)
        {
            _appDbContext.Doctors.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<DoctorEntity> Update(DoctorEntity entity)
        {
            _appDbContext.Doctors.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
