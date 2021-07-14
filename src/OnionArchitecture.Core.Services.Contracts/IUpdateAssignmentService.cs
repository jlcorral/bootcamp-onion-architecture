using OnionArchitecture.Core.Dtos.Requests;
using System.Threading.Tasks;

namespace OnionArchitecture.Core.Services.Contracts
{
    public interface IUpdateAssignmentService
    {
        Task Update(UpdateAssignmentRequestDto updateAssignmentRequestDto);
    }
}
