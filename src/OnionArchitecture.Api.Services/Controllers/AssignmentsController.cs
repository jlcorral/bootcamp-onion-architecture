using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Core.Dtos.Requests;
using OnionArchitecture.Core.Dtos.Responses;
using OnionArchitecture.Core.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace OnionArchitecture.Api.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly ICreateAssignmentService _createAssignmentService;
        private readonly IUpdateAssignmentService _updateAssignmentService;
        private readonly ICompleteAssignmentService _completeAssignmentService;

        public AssignmentsController(ICreateAssignmentService createAssignmentService,
            IUpdateAssignmentService updateAssignmentService,
            ICompleteAssignmentService completeAssignmentService)
        {
            _createAssignmentService = createAssignmentService;
            _updateAssignmentService = updateAssignmentService;
            _completeAssignmentService = completeAssignmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAssignmentRequestDto createAssignmentRequestDto)
        {
            CreateAssignmentResponseDto response = await _createAssignmentService.Create(createAssignmentRequestDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAssignmentRequestDto updateAssignmentRequestDto)
        {
            try
            {
                await _updateAssignmentService.Update(updateAssignmentRequestDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            await _completeAssignmentService.Complete(id);
            return Ok();
        }

    }
}
