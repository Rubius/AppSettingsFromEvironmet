namespace Example
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public class AppSettings
    {
        public Connection UserConnection { get; set; }
        public string SomeSettings { get; set; }
    }

    public class Connection
    {
        public AuthSettings Auth { get; set; }
        public int Timeout { get; set; }
    }

    public class AuthSettings
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
