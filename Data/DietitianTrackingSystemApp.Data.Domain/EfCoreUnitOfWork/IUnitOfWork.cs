namespace DietitianTrackingSystemApp.Data.Domain.EfCoreUnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}