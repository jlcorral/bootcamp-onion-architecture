using OnionArchitecture.Core.Domain.Entities;
using System.Threading.Tasks;

namespace OnionArchitecture.Core.Repositories.Contracts
{
    public interface IAssignmentsRepository
    {
        Task<Assignment> Get(int id);
        Task Create(Assignment assignment);
        Task Update(Assignment assignment);
    }
}
