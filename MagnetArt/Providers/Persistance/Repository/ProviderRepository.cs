using MagnetArt.Providers.Domain.Models;
using MagnetArt.Providers.Domain.Repositories;
using MagnetArt.Shared.Persistance.Contexts;
using MagnetArt.Shared.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MagnetArt.Providers.Persistance.Repository
{
    public class ProviderRepository : BaseRepository, IProviderRepository
    {
        public ProviderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
        }

        public async Task<Provider> FindByIdAsync(int id)
        {
            return await _context.Providers.FindAsync(id);
        }

        public async Task<IEnumerable<Provider>> ListAsync()
        {
            return await _context.Providers.ToListAsync();
        }

        public void Remove(Provider provider)
        {
            _context.Remove(provider);
        }

        public void Update(Provider provider)
        {
            _context.Update(provider);
        }
    }
}
