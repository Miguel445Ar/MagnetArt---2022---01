using MagnetArt.Providers.Domain.Models;
using MagnetArt.Shared.Domain.Services.Communication;

namespace MagnetArt.Providers.Domain.Services.Communication
{
    public class ProviderResponse : BaseResponse<Provider>
    {
        public ProviderResponse(Provider resource) : base(resource)
        {
        }

        public ProviderResponse(string message) : base(message)
        {
        }
    }
}
