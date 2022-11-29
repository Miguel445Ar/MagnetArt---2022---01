using MagnetArt.Shared.Persistance.Contexts;

namespace MagnetArt.Shared.Persistance.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
