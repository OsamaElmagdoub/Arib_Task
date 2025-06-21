using Arib_Task.Models;

namespace Arib_Task.Repository.Manager_Repository
{
    public interface ImanagerRepository : IGenericRepository<Manager>
    {
        Task<int> Count();

        Task<Manager?> GetByName(string name);

    }
}
