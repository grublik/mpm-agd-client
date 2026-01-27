using MpmClient.Security;

namespace MpmClient.Api
{
    internal static class AppServices
    {
        public static TokenStore TokenStore { get; } = new();

        public static ApiClientFactory ApiClientFactory { get; } =
            new(TokenStore, () => Settings.Default.MpmApiServerAddr);
    }
}