using OnionArchitecture.Core.Domain.Entities;
using OnionArchitecture.Core.Dtos.Requests;

namespace OnionArchitecture.Core.Mappers.Assignments
{
    public class UpdateAssignmentResponseDtoMapper : IMapper<Assignment, UpdateAssignmentRequestDto>
    {
        public Assignment Map(UpdateAssignmentRequestDto source)
        {
            var createAssignmentResponseDto = new Assignment
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
            };
            return createAssignmentResponseDto;
        }
    }
}
