namespace Common.Options
{
    public class RedisCacheOptions
    {
        public int Port { get; set; }
        public string IpAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? ConnectionString { get; set; }
    }
}
