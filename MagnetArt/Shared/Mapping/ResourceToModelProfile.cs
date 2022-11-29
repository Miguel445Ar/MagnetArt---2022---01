using AutoMapper;
using MagnetArt.Providers.Domain.Models;
using MagnetArt.Providers.Resources;

namespace MagnetArt.Shared.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProviderResource, Provider>();
        }
    }
}
