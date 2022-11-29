using AutoMapper;
using MagnetArt.Providers.Domain.Models;
using MagnetArt.Providers.Domain.Services;
using MagnetArt.Providers.Resources;
using MagnetArt.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace MagnetArt.Providers.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProvidersController : ControllerBase
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
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProviderResource resource) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var provider = _mapper.Map<SaveProviderResource, Provider>(resource);
            var result = await _providerService.SaveAsync(provider);
            if (!result.Success)
                return BadRequest(result.Message);
            var providerResource = _mapper.Map<Provider,ProviderResource>(result.Resource);
            return Ok(providerResource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProviderById(int id)
        {
            var provider = await _providerService.FindByIdAsync(id);
            var resource = _mapper.Map<Provider, ProviderResource>(provider);
            return Ok(resource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProviderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var provider = _mapper.Map<SaveProviderResource, Provider>(resource);
            var result = await _providerService.UpdateAsync(id,provider);
            if (!result.Success)
                return BadRequest(result.Message);
            var providerResource = _mapper.Map<Provider, ProviderResource>(result.Resource);
            return Ok(providerResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _providerService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var resource = _mapper.Map<Provider, ProviderResource>(result.Resource);
            return Ok(resource);
        }
    }
}
