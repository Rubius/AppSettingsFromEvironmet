using System;
using Common.Utils;
using Microsoft.Extensions.Configuration;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            AppSettings appSettings = new AppSettings();

            // Загружаем настройки из "appsettings.json"
            LoadFromJson(appSettings);
            Print(appSettings);

            // Перезагружаем настройки из переменных окружения
            SetEnvironmentVariables();
            Environment2Settings.SetProperies(appSettings.UserConnection, "ServiceName");
            Print(appSettings);
        }

        static void SetEnvironmentVariables()
        {
            Environment.SetEnvironmentVariable("ServiceName_Auth_Login", "secret-login");
            Environment.SetEnvironmentVariable("ServiceName_Auth_Password", "secret-password");
        }

        static void LoadFromJson(AppSettings appSettings)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            configuration.Bind(appSettings);
        }

        static void Print(AppSettings appSettings)
        {
            var auth = appSettings.UserConnection.Auth;
            Console.WriteLine($"Login: {auth.Login}. Password: {auth.Password}. Timeout: {appSettings.UserConnection.Timeout}");
        }
    }
}
