using AutoMapper;
using MagnetArt.Providers.Domain.Models;
using MagnetArt.Providers.Domain.Services;
using MagnetArt.Providers.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace MagnetArt.Providers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProvidersController: ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderService providerService, IMapper mapper)
        {
            _providerService = providerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProviderResource>> GetProvidersAsync()
        {
            var providers = await _providerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderResource>>(providers);
            return resources;
        }
    }
}
