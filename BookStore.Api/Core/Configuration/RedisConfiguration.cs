namespace BookStore.Api.Core.Configuration
{
  public class RedisConfiguration
  {
    public string Host { get; set; }
    public string Port { get; set; }
    public bool EnableQueryStorage { get; set; }
    public bool EnableSubscriptions { get; set; }
  }
}