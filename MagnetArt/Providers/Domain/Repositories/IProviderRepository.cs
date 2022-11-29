using MagnetArt.Providers.Domain.Models;

namespace MagnetArt.Providers.Domain.Repositories
{
    public interface IProviderRepository
    {
        Task<IEnumerable<Provider>> ListAsync();
        Task AddAsync();
        Task<Provider> FindById(int id);
        void Update(Provider provider);
        void Remove(Provider provider);
    }
}
