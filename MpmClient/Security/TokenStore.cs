namespace MpmClient.Security
{
    internal sealed class TokenStore
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public void Clear()
        {
            AccessToken = null;
            RefreshToken = null;
        }
    }
}