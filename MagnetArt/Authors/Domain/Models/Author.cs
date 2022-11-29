using MagnetArt.Providers.Domain.Models;

namespace MagnetArt.Authors.Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ApiUrl { get; set; } = "http://api-default.com/";
        public bool KeyRequired { get; set; } = false;
        public string ApiKey { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
