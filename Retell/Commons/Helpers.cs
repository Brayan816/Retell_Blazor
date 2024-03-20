namespace Retell.Commons
{
    public class Helpers
    {
        public static string GetApiUrl()
        {
            return Environment.GetEnvironmentVariable("ApiUrl");
        }
    }
}
