using clinic_demo.DAL.Interfaces;
using clinic_demo.Domain.Entity;

namespace clinic_demo.DAL.Repositiries
{
    public class PatientRepository : IBaseRepository<PatientEntity>
    {
        private readonly AppDbContext _appDbContext;

        public PatientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public async Task Create(PatientEntity entity)
        {
            await _appDbContext.Patients.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<PatientEntity> GetAll()
        {
            return _appDbContext.Patients;
        }

        public async Task Delete(PatientEntity entity)
        {
            _appDbContext.Patients.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PatientEntity> Update(PatientEntity entity)
        {
            _appDbContext.Patients.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
