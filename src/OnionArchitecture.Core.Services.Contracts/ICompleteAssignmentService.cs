using System.Threading.Tasks;

namespace OnionArchitecture.Core.Services.Contracts
{
    public interface ICompleteAssignmentService
    {
        Task Complete(int id);
    }
}
