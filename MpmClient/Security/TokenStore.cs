using System.Threading;

namespace MpmClient.Security
{
    internal sealed class TokenStore
    {
        private readonly SemaphoreSlim _refreshLock = new(1, 1);

        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public SemaphoreSlim RefreshLock => _refreshLock;

        public void Clear()
        {
            AccessToken = null;
            RefreshToken = null;
        }
    }
}