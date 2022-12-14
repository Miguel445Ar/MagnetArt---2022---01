namespace MagnetArt.Providers.Resources
{
    public class ProviderResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApiUrl { get; set; } = "http://api-default.com/";
        public bool KeyRequired { get; set; } = false;
        public string ApiKey { get; set; } = "defaultHash";
    }
}
