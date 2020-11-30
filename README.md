# Small library to help get application settings from environment variables

Небольшая библиотека для заполнения строковых настроек приложения из переменных окружения.

Пример использования:
```csharp
public class AppSettings
{
    public AuthSettings Auth { get; set; }
}

public class AuthSettings
{
    public string Login { get; set; }
    public string Password { get; set; }
}

static void Main(string[] args)
{
    var appSettings = new AppSettings();
    var environmentName = "Production";

    // Заполняем значениями из "appsettings.json"
    var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environmentName}.json").Build();
    configuration.Bind(appSettings);

    // Изменяем некоторые настройки через переменные окружения.
    // Пример переменной окружения: "Production_ServiceName_Auth_Password" = "secret-password"
    Environment2Settings.SetProperies(appSettings, $"{environmentName}", "ServiceName");
    
    Console.WriteLine(appSettings.Auth.Password);
}
```

Функция:
```csharp
    Environment2Settings.SetProperies<T>(T obj, params string[] envPrefixes) 
```
заполняет публичные строковые свойства (на любом уровне вложенности) объекта obj из переменных окружения.
Если вложенные свойства не инициализированы, то для них будет вызван дефолтный конструктор.
Префиксы из envPrefixes соединяются в одну строку через символ разделителя: **`_`**.

Подробнее смотри:
  [Example](https://github.com/Rubius/Environment2Settings/tree/main/Example),
  [Tests](https://github.com/Rubius/Environment2Settings/tree/main/Tests).
