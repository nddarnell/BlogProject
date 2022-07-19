namespace BlogProject.ViewModels
{
    public class MailSettings
    {
        // So we can configure and use the smtp server
        // From google for example
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}