using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Core.Domain.Entities;
using OnionArchitecture.Core.Repositories.Contracts;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Repositories
{
    public class AssignmentsRepository : IAssignmentsRepository
    {
        private readonly OnionArchitectureContext _context;
        public AssignmentsRepository(OnionArchitectureContext context) =>
            _context = context;
        public async Task Create(Assignment assignment)
        {
            await _context.AddAsync(assignment);
            await _context.SaveChangesAsync();
            // para mantener las entades en modo detached, depende lo que estes haciendo
            // la decicion de mantenerlas o no mantenerlas trackeadass
            _context.Entry(assignment).State = EntityState.Detached;
        }

        public Task<Assignment> Get(int id) => _context
            .Assignments
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task Update(Assignment assignment)
        {
            _context.Update(assignment);
            await _context.SaveChangesAsync();
            // para mantener las entades en modo detached, depende lo que estes haciendo
            // la decicion de mantenerlas o no mantenerlas trackeadass
            _context.Entry(assignment).State = EntityState.Detached;
        }
    }
}
