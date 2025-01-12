namespace Common.Utilities.Services.FTP.Models
{
    public class FTPConnectionOptions
    {
        public string Section => nameof(FTPConnectionOptions);

        public int Port { get; set; } //FTP ===> 21, SFTP===> 22
        public string Server { get; set; }
        public string ServerIp { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UrlBase { get; set; }
        public string RootDirectory { get; set; }
    }
}
