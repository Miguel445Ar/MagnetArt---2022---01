using MagnetArt.Providers.Domain.Models;
using MagnetArt.Providers.Domain.Services.Communication;

namespace MagnetArt.Providers.Domain.Services
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> ListAsync();
        Task<Provider> FindByIdAsync(int id);
        Task<ProviderResponse> SaveAsync(Provider provider);
        Task<ProviderResponse> UpdateAsync(int id, Provider provider);
        Task<ProviderResponse> DeleteAsync(int id);
    }
}
