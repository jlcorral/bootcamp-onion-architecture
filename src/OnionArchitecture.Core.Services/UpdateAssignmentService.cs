using OnionArchitecture.Core.Domain.Entities;
using OnionArchitecture.Core.Dtos.Requests;
using OnionArchitecture.Core.Mappers;
using OnionArchitecture.Core.Mappers.Assignments;
using OnionArchitecture.Core.Repositories.Contracts;
using OnionArchitecture.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Core.Services
{
    public class UpdateAssignmentService : IUpdateAssignmentService
    {
        private IAssignmentsRepository _assignmentsRepository;
        IMapper<Assignment, UpdateAssignmentRequestDto> _mapper;
        public UpdateAssignmentService(IAssignmentsRepository assignmentsRepository)
        {
            _assignmentsRepository = assignmentsRepository;
            _mapper = new UpdateAssignmentResponseDtoMapper();
        }
        public async Task Update(UpdateAssignmentRequestDto updateAssignmentRequestDto)
        {
            Assignment dbAssignment = await _assignmentsRepository.Get(updateAssignmentRequestDto.Id);
            if (dbAssignment == default(Assignment)) throw new Exception();

            Assignment updatedAssignment = _mapper.Map(updateAssignmentRequestDto);
            updatedAssignment.Timestamp = dbAssignment.Timestamp;
            updatedAssignment.Completed = dbAssignment.Completed;

            await _assignmentsRepository.Update(updatedAssignment);
        }
    }
}
