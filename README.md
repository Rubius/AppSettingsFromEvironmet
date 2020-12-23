# Small library to help get application settings from environment variables

Небольшая библиотека для заполнения строковых настроек приложения из переменных окружения.
Может применяться для изменения некоторых секретных настроек, которые нельзя хранить в файле типа appsettings.json.
Например, настройки подключения к базе данных в docker контейнере должны храниться в переменных окружения. 
Название переменных окружения формируются из названий полей класса настроек, разделенные символом "**`_`**".

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

    // Заполняем значениями из "appsettings.Production.json"
    var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environmentName}.json").Build();
    configuration.Bind(appSettings);

    // Изменяем некоторые настройки через переменные окружения.
    // Пример переменной окружения: "Production_ServiceName_Auth_Password" = "secret-password"
    EnvironmentVariableReader.SetProperies(appSettings, $"{environmentName}", "ServiceName");
    
    Console.WriteLine(appSettings.Auth.Password);
}
```

Функция:
```csharp
    EnvironmentVariableReader.SetProperies<T>(T obj, params string[] envPrefixes) 
```
заполняет публичные строковые свойства (на любом уровне вложенности) объекта obj из переменных окружения.
Если вложенные свойства не инициализированы, то для них будет вызван дефолтный конструктор.
Префиксы из envPrefixes соединяются в одну строку через символ разделителя: "**`_`**".

Подробнее смотри:
  [Example](https://github.com/Rubius/EnvironmentVariableReader/tree/main/Example),
  [Tests](https://github.com/Rubius/EnvironmentVariableReader/tree/main/Tests).
