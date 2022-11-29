using MagnetArt.Providers.Domain.Models;
using MagnetArt.Providers.Domain.Repositories;
using MagnetArt.Providers.Domain.Services;
using MagnetArt.Providers.Domain.Services.Communication;
using MagnetArt.Shared.Domain.Repositories;

namespace MagnetArt.Providers.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProviderService(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
        {
            _providerRepository = providerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProviderResponse> DeleteAsync(int id)
        {
            var existingProvider = await _providerRepository.FindByIdAsync(id);
            if (existingProvider == null)
                return new ProviderResponse($"Not provider found with id {id}");
            try
            {
                _providerRepository.Remove(existingProvider);
                await _unitOfWork.CompleteAsync();
                return new ProviderResponse(existingProvider);

            }catch(Exception e)
            {
                return new ProviderResponse($"An error occurred while removing the provider. See details in {e.Message}. {e.InnerException.Message}");
            }
        }

        public async Task<Provider> FindByIdAsync(int id)
        {
            return await _providerRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Provider>> ListAsync()
        {
            return await _providerRepository.ListAsync();
        }

        public async Task<ProviderResponse> SaveAsync(Provider provider)
        {
            try
            {
                await _providerRepository.AddAsync(provider);
                await _unitOfWork.CompleteAsync();
                return new ProviderResponse(provider);

            }catch(Exception e)
            {
                return new ProviderResponse($"An error occurred when saving the provider. See details at {e.Message}. {e.InnerException.Message}");
            }
        }

        public async Task<ProviderResponse> UpdateAsync(int id, Provider provider)
        {
            var existingProvider = await _providerRepository.FindByIdAsync(id);
            if (existingProvider == null)
                return new ProviderResponse($"Not provider found with id {id}");
            existingProvider.Name = provider.Name;
            existingProvider.ApiUrl = provider.ApiUrl;
            existingProvider.KeyRequired = provider.KeyRequired;
            existingProvider.ApiKey = provider.ApiKey;
            try
            {
                _providerRepository.Update(existingProvider);
                await _unitOfWork.CompleteAsync();
                return new ProviderResponse(existingProvider);
            }catch(Exception e)
            {
                return new ProviderResponse($"An error occured when updating the provider. See details at: {e.Message}. {e.InnerException.Message}");
            }
        }
    }
}
