using System.ComponentModel.DataAnnotations;
namespace OnionArchitecture.Core.Dtos.Requests
{
    public class UpdateAssignmentRequestDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
