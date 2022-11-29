using MagnetArt.Providers.Domain.Models;
using MagnetArt.Providers.Resources;

namespace MagnetArt.Authors.Resources
{
    public class AuthorResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string PhotoUrl { get; set; } = "www.algo.com";
        public ProviderResource Provider { get; set; }
    }
}
