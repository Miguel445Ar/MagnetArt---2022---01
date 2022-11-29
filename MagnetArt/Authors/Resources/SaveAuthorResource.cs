using MagnetArt.Providers.Resources;
using System.ComponentModel.DataAnnotations;

namespace MagnetArt.Authors.Resources
{
    public class SaveAuthorResource
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NickName { get; set; }
        public string PhotoUrl { get; set; } = "www.algo.com";
        [Required]
        public int ProvidersId { get; set; }
    }
}
