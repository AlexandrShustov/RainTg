namespace Domain.Options
{
    public class RaindropOptions
    {
        public static string SectionName { get; set; } = "Raindrop";

        public string AuthUrl { get; set; }
        public string TestToken { get; set; }
        public string RedirectUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
