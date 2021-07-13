using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Core.Dtos.Requests;
using OnionArchitecture.Core.Dtos.Responses;
using OnionArchitecture.Core.Services.Contracts;
using System.Threading.Tasks;

namespace OnionArchitecture.Api.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly ICreateAssignmentService _createAssignmentService;

        public AssignmentsController(ICreateAssignmentService createAssignmentService)
        {
            _createAssignmentService = createAssignmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAssignmentRequestDto createAssignmentRequestDto)
        {
            CreateAssignmentResponseDto response = await _createAssignmentService.Create(createAssignmentRequestDto);
            return Ok(response);
        }

    }
}
