namespace ConsoleApp
{
    public sealed class AppSettings
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public User[] Users { get; set; }
    }

    public sealed class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
