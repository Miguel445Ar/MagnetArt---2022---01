using System.ComponentModel.DataAnnotations;

namespace MagnetArt.Providers.Resources
{
    public class SaveProviderResource
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public string ApiUrl { get; set; } = "http://api-default.com/";
        public bool KeyRequired { get; set; } = false;
        public string ApiKey { get; set; } = "defaultHash";
    }
}
