using DietitianTrackingSystemApp.Data.Domain.Entities;

namespace DietitianTrackingSystemApp.Data.Domain.EfCoreUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DietitianTrackingSystemDbContext _context;

        public UnitOfWork(DietitianTrackingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {           
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}