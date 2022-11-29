using MagnetArt.Shared.Domain.Repositories;
using MagnetArt.Shared.Persistance.Contexts;

namespace MagnetArt.Shared.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
