using System.ComponentModel.DataAnnotations;

namespace MagnetArt.Providers.Resources
{
    public class SaveProviderResource
    {
        [Required]
        public string Name { get; set; }
        public string ApiUrl { get; set; } = "http://api-default.com/";
        public bool KeyRequired { get; set; } = false;
        public string ApiKey { get; set; } = "defaultHash";
    }
}
