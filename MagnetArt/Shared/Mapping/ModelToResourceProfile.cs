using AutoMapper;
using MagnetArt.Providers.Domain.Models;
using MagnetArt.Providers.Resources;

namespace MagnetArt.Shared.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Provider, ProviderResource>();
        }
    }
}
