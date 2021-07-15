using OnionArchitecture.Core.Domain.Entities;
using OnionArchitecture.Core.Repositories.Contracts;
using OnionArchitecture.Core.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace OnionArchitecture.Core.Services
{
    public class CompleteAssignmentService : ICompleteAssignmentService
    {
        private readonly IAssignmentsRepository _assignmentsRepository;

        public CompleteAssignmentService(IAssignmentsRepository assignmentsRepository)
        {
            _assignmentsRepository = assignmentsRepository;
        }
        public async Task Complete(int id)
        {
            Assignment assignment = await _assignmentsRepository.Get(id);
            if (assignment == default(Assignment)) throw new Exception();
            assignment.Completed = false;
            await _assignmentsRepository.Update(assignment);
        }
    }
}
